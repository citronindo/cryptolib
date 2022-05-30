using System;
using System.Text;
using citronindo.crypto;
using citronindo.crypto.curve25519;
using citronindo.crypto.proto;
using citronindo.crypto.signal;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace citronlib.test
{
	[TestClass]
	public class TestCrypto
	{
        [TestMethod]
		public void ShareSecret()
        {
			var alice = KeyPair.GenerateKey();
			var bob = KeyPair.GenerateKey();
			var shareSecretAlice = alice.GetShareSecretKey(bob.PublicKey);
			var shareSecretBob = bob.GetShareSecretKey(alice.PublicKey);
			CollectionAssert.AreEqual(shareSecretAlice, shareSecretBob);

            var ecAlice = Curve.generateKeyPair();
            var ecBob = Curve.generateKeyPair();
            var ecShareSecretAlice = Curve.calculateAgreement(ecAlice.getPublicKey(), ecBob.getPrivateKey());
            var ecShareSecretBob = Curve.calculateAgreement(ecBob.getPublicKey(), ecAlice.getPrivateKey());
            CollectionAssert.AreEqual(ecShareSecretAlice, ecShareSecretBob);
        }

		[TestMethod]
		public void Signature()
		{
            var message = Encoding.UTF8.GetBytes("signature message");

			var key = KeyPair.GenerateKey();
			var signature = key.CalculateSignature(message);
			var verify = key.VerifySignature(signature, message);
			Assert.IsTrue(verify);

            var ecKey = Curve.generateKeyPair();
            var ecSignature = Curve.calculateSignature(ecKey.getPrivateKey(), message);
            verify = Curve.verifySignature(ecKey.getPublicKey(), message, ecSignature);
            Assert.IsTrue(verify);
        }

        [TestMethod]
        public void DecodePoint()
        {
            var bob = KeyPair.GenerateKey();
            var ecBobPublicKey = new DjbECPublicKey(bob.PublicKey);
            var bobIdentityKey = new IdentityKey(ecBobPublicKey);
            CollectionAssert.AreEqual(ecBobPublicKey.serialize(), bobIdentityKey.serialize());

            var decodePointKey = Curve.decodePoint(bobIdentityKey.serialize(), 0);
            CollectionAssert.AreEqual(ecBobPublicKey.serialize(), decodePointKey.serialize());
        }

        [TestMethod]
        public void VerifySignature()
        {
            byte[] aliceIdentityPrivate =
            {
                0xc0, 0x97, 0x24, 0x84, 0x12,
                0xe5, 0x8b, 0xf0, 0x5d, 0xf4,
                0x87, 0x96, 0x82, 0x05, 0x13,
                0x27, 0x94, 0x17, 0x8e, 0x36,
                0x76, 0x37, 0xf5, 0x81, 0x8f,
                0x81, 0xe0, 0xe6, 0xce, 0x73,
                0xe8, 0x65
            };

            byte[] aliceIdentityPublic =
            {
                0x05, 0xab, 0x7e, 0x71, 0x7d,
                0x4a, 0x16, 0x3b, 0x7d, 0x9a,
                0x1d, 0x80, 0x71, 0xdf, 0xe9,
                0xdc, 0xf8, 0xcd, 0xcd, 0x1c,
                0xea, 0x33, 0x39, 0xb6, 0x35,
                0x6b, 0xe8, 0x4d, 0x88, 0x7e,
                0x32, 0x2c, 0x64
            };

            byte[] message =
            {
                0x05, 0xed, 0xce, 0x9d, 0x9c,
                0x41, 0x5c, 0xa7, 0x8c, 0xb7,
                0x25, 0x2e, 0x72, 0xc2, 0xc4,
                0xa5, 0x54, 0xd3, 0xeb, 0x29,
                0x48, 0x5a, 0x0e, 0x1d, 0x50,
                0x31, 0x18, 0xd1, 0xa8, 0x2d,
                0x99, 0xfb, 0x4a
            };

            byte[] aliceSignature =
            {
                0x5d, 0xe8, 0x8c, 0xa9, 0xa8,
                0x9b, 0x4a, 0x11, 0x5d, 0xa7,
                0x91, 0x09, 0xc6, 0x7c, 0x9c,
                0x74, 0x64, 0xa3, 0xe4, 0x18,
                0x02, 0x74, 0xf1, 0xcb, 0x8c,
                0x63, 0xc2, 0x98, 0x4e, 0x28,
                0x6d, 0xfb, 0xed, 0xe8, 0x2d,
                0xeb, 0x9d, 0xcd, 0x9f, 0xae,
                0x0b, 0xfb, 0xb8, 0x21, 0x56,
                0x9b, 0x3d, 0x90, 0x01, 0xbd,
                0x81, 0x30, 0xcd, 0x11, 0xd4,
                0x86, 0xce, 0xf0, 0x47, 0xbd,
                0x60, 0xb8, 0x6e, 0x88
            };

            var keyPair = KeyPair.GenerateKey(aliceIdentityPrivate);
            var ecPublicKey = new DjbECPublicKey(keyPair.PublicKey);

            ECPrivateKey alicePrivateKey = Curve.decodePrivatePoint(aliceIdentityPrivate);
            ECPublicKey alicePublicKey = Curve.decodePoint(aliceIdentityPublic, 0);

            CollectionAssert.AreEqual(ecPublicKey.serialize(), aliceIdentityPublic);
            CollectionAssert.AreEqual(ecPublicKey.serialize(), alicePublicKey.serialize());
            CollectionAssert.AreEqual(keyPair.PrivateKey, alicePrivateKey.serialize());

            if (!Curve.verifySignature(alicePublicKey, message, aliceSignature))
            {
                Assert.Fail("Sig verification failed!");
            }
        }

        [TestMethod]
        public void PreKeySignalMessageEncryptDecrypt()
        {
            uint registrationId = KeyHelper.generateRegistrationId(false);
            uint devideId = 1;
            uint preKeyId = 31337;
            uint signedPreKeyId = 22;
            var timestamp = (ulong)(DateTime.UtcNow - DateTime.UnixEpoch).TotalMilliseconds;

            SignalProtocolAddress aliceAddress = new("+14159999999", 1);
            SignalProtocolAddress bobAddress = new("+14158888888", 1);

            ECKeyPair aliceIdentityKeyPair = Curve.generateKeyPair();
            IdentityKeyPair aliceIdentityKey = new(new IdentityKey(aliceIdentityKeyPair.getPublicKey()),
                                                                   aliceIdentityKeyPair.getPrivateKey());
            SignalProtocolStore aliceStore = new InMemorySignalProtocolStore(aliceIdentityKey, registrationId);
            SessionBuilder aliceSessionBuilder = new(aliceStore, bobAddress);

            ECKeyPair bobIdentityKeyPair = Curve.generateKeyPair();
            IdentityKeyPair bobIdentityKey = new(new IdentityKey(bobIdentityKeyPair.getPublicKey()),
                                                                 bobIdentityKeyPair.getPrivateKey());
            SignalProtocolStore bobStore = new InMemorySignalProtocolStore(bobIdentityKey, registrationId);

            ECKeyPair bobPreKeyPair = Curve.generateKeyPair();
            ECKeyPair bobSignedPreKeyPair = Curve.generateKeyPair();
            byte[] bobSignedPreKeySignature = Curve.calculateSignature(bobStore.GetIdentityKeyPair().getPrivateKey(),
                                                              bobSignedPreKeyPair.getPublicKey().serialize());

            PreKeyBundle bobPreKey = new(
                bobStore.GetLocalRegistrationId(),
                devideId,
                preKeyId,
                bobPreKeyPair.getPublicKey(),
                signedPreKeyId,
                bobSignedPreKeyPair.getPublicKey(),
                bobSignedPreKeySignature,
                bobStore.GetIdentityKeyPair().getPublicKey()
            );

            bobStore.StorePreKey(
                preKeyId,
                new PreKeyRecord(bobPreKey.getPreKeyId(), bobPreKeyPair)
            );
            bobStore.StoreSignedPreKey(signedPreKeyId,
                new SignedPreKeyRecord(signedPreKeyId, timestamp, bobSignedPreKeyPair, bobSignedPreKeySignature)
            );

            aliceSessionBuilder.process(bobPreKey);

            string originalMessage = "L'homme est condamné à être libre";
            SessionCipher aliceSessionCipher = new(aliceStore, bobAddress);
            CiphertextMessage outgoingMessage = aliceSessionCipher.encrypt(Encoding.UTF8.GetBytes(originalMessage));
            Assert.AreEqual(CiphertextMessage.PREKEY_TYPE, outgoingMessage.getType());

            PreKeySignalMessage incomingMessage = new(outgoingMessage.serialize());
            SessionCipher bobSessionCipher = new(bobStore, aliceAddress);
            byte[] plaintext = bobSessionCipher.decrypt(incomingMessage);
            Assert.AreEqual(originalMessage, Encoding.UTF8.GetString(plaintext));

            CiphertextMessage bobOutgoingMessage = bobSessionCipher.encrypt(Encoding.UTF8.GetBytes(originalMessage));
            byte[] alicePlaintext = aliceSessionCipher.decrypt(new SignalMessage(bobOutgoingMessage.serialize()));
            Assert.AreEqual(originalMessage, Encoding.UTF8.GetString(alicePlaintext));
        }

        [TestMethod]
        public void SignalMessageEncryptDecrypt()
        {
            uint registrationId = KeyHelper.generateRegistrationId(false);

            ECKeyPair aliceIdentityKeyPair = Curve.generateKeyPair();
            IdentityKeyPair aliceIdentityKey = new(new IdentityKey(aliceIdentityKeyPair.getPublicKey()),
                                                                   aliceIdentityKeyPair.getPrivateKey());
            ECKeyPair aliceBaseKey = Curve.generateKeyPair();

            SessionRecord aliceSessionRecord = new();
            SessionState aliceSessionState = aliceSessionRecord.getSessionState();

            ECKeyPair bobIdentityKeyPair = Curve.generateKeyPair();
            IdentityKeyPair bobIdentityKey = new(new IdentityKey(bobIdentityKeyPair.getPublicKey()),
                                                                 bobIdentityKeyPair.getPrivateKey());
            ECKeyPair bobBaseKey = Curve.generateKeyPair();
            ECKeyPair bobEphemeralKey = bobBaseKey;

            SessionRecord bobSessionRecord = new();
            SessionState bobSessionState = bobSessionRecord.getSessionState();

            AliceSignalProtocolParameters aliceParameters = AliceSignalProtocolParameters.newBuilder()
                .setOurBaseKey(aliceBaseKey)
                .setOurIdentityKey(aliceIdentityKey)
                .setTheirOneTimePreKey(May<ECPublicKey>.NoValue)
                .setTheirRatchetKey(bobEphemeralKey.getPublicKey())
                .setTheirSignedPreKey(bobBaseKey.getPublicKey())
                .setTheirIdentityKey(bobIdentityKey.getPublicKey())
                .create();

            BobSignalProtocolParameters bobParameters = BobSignalProtocolParameters.newBuilder()
                .setOurRatchetKey(bobEphemeralKey)
                .setOurSignedPreKey(bobBaseKey)
                .setOurOneTimePreKey(May<ECKeyPair>.NoValue)
                .setOurIdentityKey(bobIdentityKey)
                .setTheirIdentityKey(aliceIdentityKey.getPublicKey())
                .setTheirBaseKey(aliceBaseKey.getPublicKey())
                .create();

            RatchetingSession.initializeSession(aliceSessionState, aliceParameters);
            RatchetingSession.initializeSession(bobSessionState, bobParameters);

            SignalProtocolAddress aliceAddress = new("+14159999999", 1);
            SignalProtocolStore aliceStore = new InMemorySignalProtocolStore(aliceIdentityKey, registrationId);
            aliceStore.StoreSession(aliceAddress, aliceSessionRecord);
            SessionCipher aliceCipher = new(aliceStore, aliceAddress);

            SignalProtocolAddress bobAddress = new("+14158888888", 1);
            SignalProtocolStore bobStore = new InMemorySignalProtocolStore(bobIdentityKey, registrationId);
            bobStore.StoreSession(bobAddress, bobSessionRecord);
            SessionCipher bobCipher = new(bobStore, bobAddress);

            byte[] alicePlaintext = Encoding.UTF8.GetBytes("This is a plaintext message.");
            CiphertextMessage message = aliceCipher.encrypt(alicePlaintext);
            byte[] bobPlaintext = bobCipher.decrypt(new SignalMessage(message.serialize()));

            CollectionAssert.AreEqual(alicePlaintext, bobPlaintext);

            byte[] bobReply = Encoding.UTF8.GetBytes("This is a message from Bob.");
            CiphertextMessage reply = bobCipher.encrypt(bobReply);
            byte[] receivedReply = aliceCipher.decrypt(new SignalMessage(reply.serialize()));

            CollectionAssert.AreEqual(bobReply, receivedReply);

        }

        [TestMethod]
        public void SenderKeyMessageEncryptDecrypt()
        {
            SignalProtocolAddress SENDER_ADDRESS = new SignalProtocolAddress("+14150001111", 1);
            SenderKeyName GROUP_SENDER = new SenderKeyName("nihilist history reading group", SENDER_ADDRESS);

            InMemorySenderKeyStore aliceStore = new InMemorySenderKeyStore();
            InMemorySenderKeyStore bobStore = new InMemorySenderKeyStore();

            GroupSessionBuilder aliceSessionBuilder = new GroupSessionBuilder(aliceStore);
            GroupSessionBuilder bobSessionBuilder = new GroupSessionBuilder(bobStore);

            GroupCipher aliceGroupCipher = new(aliceStore, GROUP_SENDER);
            GroupCipher bobGroupCipher = new(bobStore, GROUP_SENDER);

            SignalSenderKeyDistributionMessage sentAliceDistributionMessage = aliceSessionBuilder.create(GROUP_SENDER);
            SignalSenderKeyDistributionMessage receivedAliceDistributionMessage = new SignalSenderKeyDistributionMessage(sentAliceDistributionMessage.serialize());

            bobSessionBuilder.process(GROUP_SENDER, receivedAliceDistributionMessage);

            byte[] originalMessage = Encoding.UTF8.GetBytes("smert ze smert");
            byte[] ciphertextFromAlice = aliceGroupCipher.encrypt(originalMessage);
            byte[] plaintextFromAlice = bobGroupCipher.decrypt(ciphertextFromAlice);

            CollectionAssert.AreEqual(originalMessage, plaintextFromAlice);
        }
	}
}


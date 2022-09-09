using citronindo;
using citronindo.crypto.curve25519;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace citronindo.crypto
{
    public class KeyPair
    {
        private Curve25519 provider = Curve25519.getInstance();

        public KeyPair() { }

        public KeyPair(byte[] publicKey, byte[] privateKey, Curve25519 curve)
        {
            PublicKey = publicKey;
            PrivateKey = privateKey;
            provider = curve;
        }

        public byte[] PrivateKey { get; set; } = Array.Empty<byte>();
        public byte[] PublicKey { get; set; } = Array.Empty<byte>();

        public byte[] GetShareSecretKey(byte[] peerPublicKey)
        {
            return provider.calculateAgreement(peerPublicKey, PrivateKey);
        }

        public byte[] CalculateSignature(byte[] message)
        {
            return provider.calculateSignature(PrivateKey, message);
        }

        public PreKey CreateSignedPreKey(uint keyID)
        {
            PreKey newKey = PreKey.NewPreKey(keyID, this);
            newKey.Signature = Signature(newKey);
            return newKey;
        }

        public bool VerifySignature(byte[] signature, byte[] message)
        {
            return provider.verifySignature(PublicKey, message, signature);
        }
        
        private byte[] Signature(KeyPair keyToSign)
        {
            var pubKeyForSignature = new DjbECPublicKey(keyToSign.PublicKey);
            var signature = Curve.calculateSignature(new DjbECPrivateKey(PrivateKey), pubKeyForSignature.serialize());
            return signature;
        }

        public static KeyPair GenerateKey()
        {
            var curve = Curve25519.getInstance();
            return curve.generateKeyPair();
        }

        public static KeyPair GenerateKey(byte[] priv)
        {
            var curve = Curve25519.getInstance();
            return new KeyPair
            {
                PrivateKey = priv,
                PublicKey = curve.generatePublicKey(priv),
                provider = curve
            };
        }
    }
}

using System;

using citronindo.cryptolib.bc.Asn1;
using citronindo.cryptolib.bc.Asn1.Cms;
using citronindo.cryptolib.bc.Asn1.Pkcs;
using citronindo.cryptolib.bc.Asn1.X509;
using citronindo.cryptolib.bc.Crypto;
using citronindo.cryptolib.bc.Crypto.Parameters;
using citronindo.cryptolib.bc.Security;
using citronindo.cryptolib.bc.Utilities;

namespace citronindo.cryptolib.bc.Cms
{
	internal class PasswordRecipientInfoGenerator : RecipientInfoGenerator
	{
		private static readonly CmsEnvelopedHelper Helper = CmsEnvelopedHelper.Instance;

		private AlgorithmIdentifier	keyDerivationAlgorithm;
		private KeyParameter		keyEncryptionKey;
		// TODO Can get this from keyEncryptionKey?		
		private string				keyEncryptionKeyOID;

		internal PasswordRecipientInfoGenerator()
		{
		}

		internal AlgorithmIdentifier KeyDerivationAlgorithm
		{
			set { this.keyDerivationAlgorithm = value; }
		}

		internal KeyParameter KeyEncryptionKey
		{
			set { this.keyEncryptionKey = value; }
		}

		internal string KeyEncryptionKeyOID
		{
			set { this.keyEncryptionKeyOID = value; }
		}

		public RecipientInfo Generate(KeyParameter contentEncryptionKey, SecureRandom random)
		{
			byte[] keyBytes = contentEncryptionKey.GetKey();

			string rfc3211WrapperName = Helper.GetRfc3211WrapperName(keyEncryptionKeyOID);
			IWrapper keyWrapper = Helper.CreateWrapper(rfc3211WrapperName);

			// Note: In Java build, the IV is automatically generated in JCE layer
			int ivLength = Platform.StartsWith(rfc3211WrapperName, "DESEDE") ? 8 : 16;
			byte[] iv = new byte[ivLength];
			random.NextBytes(iv);

			ICipherParameters parameters = new ParametersWithIV(keyEncryptionKey, iv);
			keyWrapper.Init(true, new ParametersWithRandom(parameters, random));
        	Asn1OctetString encryptedKey = new DerOctetString(
				keyWrapper.Wrap(keyBytes, 0, keyBytes.Length));

			DerSequence seq = new DerSequence(
				new DerObjectIdentifier(keyEncryptionKeyOID),
				new DerOctetString(iv));

			AlgorithmIdentifier keyEncryptionAlgorithm = new AlgorithmIdentifier(
				PkcsObjectIdentifiers.IdAlgPwriKek, seq);

			return new RecipientInfo(new PasswordRecipientInfo(
				keyDerivationAlgorithm, keyEncryptionAlgorithm, encryptedKey));
		}
	}
}

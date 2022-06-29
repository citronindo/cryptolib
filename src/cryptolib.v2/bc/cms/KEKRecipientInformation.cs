using System;
using System.IO;

using citronindo.cryptolib.bc.Asn1.Cms;
using citronindo.cryptolib.bc.Asn1.X509;
using citronindo.cryptolib.bc.Crypto;
using citronindo.cryptolib.bc.Crypto.Parameters;
using citronindo.cryptolib.bc.Security;

namespace citronindo.cryptolib.bc.Cms
{
    /**
    * the RecipientInfo class for a recipient who has been sent a message
    * encrypted using a secret key known to the other side.
    */
    public class KekRecipientInformation
        : RecipientInformation
    {
        private KekRecipientInfo info;

		internal KekRecipientInformation(
			KekRecipientInfo	info,
			CmsSecureReadable	secureReadable)
			: base(info.KeyEncryptionAlgorithm, secureReadable)
		{
            this.info = info;
            this.rid = new RecipientID();

			KekIdentifier kekId = info.KekID;

			rid.KeyIdentifier = kekId.KeyIdentifier.GetOctets();
        }

		/**
        * decrypt the content and return an input stream.
        */
        public override CmsTypedStream GetContentStream(
            ICipherParameters key)
        {
			try
			{
				byte[] encryptedKey = info.EncryptedKey.GetOctets();
                IWrapper keyWrapper = WrapperUtilities.GetWrapper(keyEncAlg.Algorithm.Id);

				keyWrapper.Init(false, key);

				KeyParameter sKey = ParameterUtilities.CreateKeyParameter(
					GetContentAlgorithmName(), keyWrapper.Unwrap(encryptedKey, 0, encryptedKey.Length));

				return GetContentFromSessionKey(sKey);
			}
			catch (SecurityUtilityException e)
			{
				throw new CmsException("couldn't create cipher.", e);
			}
			catch (InvalidKeyException e)
			{
				throw new CmsException("key invalid in message.", e);
			}
        }
    }
}

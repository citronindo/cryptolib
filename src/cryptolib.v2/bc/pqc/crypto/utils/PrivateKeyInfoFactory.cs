using System;

using citronindo.cryptolib.bc.Asn1;
using citronindo.cryptolib.bc.Asn1.Pkcs;
using citronindo.cryptolib.bc.Asn1.X509;
using citronindo.cryptolib.bc.Crypto;
using citronindo.cryptolib.bc.Pqc.Asn1;
using citronindo.cryptolib.bc.Pqc.Crypto.Cmce;
using citronindo.cryptolib.bc.Pqc.Crypto.Lms;
using citronindo.cryptolib.bc.Pqc.Crypto.Picnic;
using citronindo.cryptolib.bc.Pqc.Crypto.Saber;
using citronindo.cryptolib.bc.Pqc.Crypto.SphincsPlus;
using citronindo.cryptolib.bc.Utilities;

namespace citronindo.cryptolib.bc.Pqc.Crypto.Utilities
{
    public class PrivateKeyInfoFactory
    {
        private PrivateKeyInfoFactory()
        {

        }

        /// <summary> Create a PrivateKeyInfo representation of a private key.</summary>
        /// <param name="privateKey"> the key to be encoded into the info object.</param>
        /// <returns> the appropriate PrivateKeyInfo</returns>
        /// <exception cref="ArgumentException"> on an error encoding the key</exception>
        public static PrivateKeyInfo CreatePrivateKeyInfo(AsymmetricKeyParameter privateKey)
        {
            return CreatePrivateKeyInfo(privateKey, null);
        }

        /// <summary> Create a PrivateKeyInfo representation of a private key with attributes.</summary>
        /// <param name="privateKey"> the key to be encoded into the info object.</param>
        /// <param name="attributes"> the set of attributes to be included.</param>
        /// <returns> the appropriate PrivateKeyInfo</returns>
        /// <exception cref="ArgumentException"> on an error encoding the key</exception>
        public static PrivateKeyInfo CreatePrivateKeyInfo(AsymmetricKeyParameter privateKey, Asn1Set attributes)
        {
            if (privateKey is LMSPrivateKeyParameters)
            {
                LMSPrivateKeyParameters parameters = (LMSPrivateKeyParameters)privateKey;

                byte[] encoding = Composer.Compose().U32Str(1).Bytes(parameters).Build();
                byte[] pubEncoding = Composer.Compose().U32Str(1).Bytes(parameters.GetPublicKey()).Build();

                AlgorithmIdentifier algorithmIdentifier = new AlgorithmIdentifier(PkcsObjectIdentifiers.IdAlgHssLmsHashsig);
                return new PrivateKeyInfo(algorithmIdentifier, new DerOctetString(encoding), attributes, pubEncoding);
            }
            if (privateKey is HSSPrivateKeyParameters)
            {
                HSSPrivateKeyParameters parameters = (HSSPrivateKeyParameters)privateKey;

                byte[] encoding = Composer.Compose().U32Str(parameters.L).Bytes(parameters).Build();
                byte[] pubEncoding = Composer.Compose().U32Str(parameters.L).Bytes(parameters.GetPublicKey().GetLmsPublicKey()).Build();

                AlgorithmIdentifier algorithmIdentifier = new AlgorithmIdentifier(PkcsObjectIdentifiers.IdAlgHssLmsHashsig);
                return new PrivateKeyInfo(algorithmIdentifier, new DerOctetString(encoding), attributes, pubEncoding);
            }
            if (privateKey is SPHINCSPlusPrivateKeyParameters)
            {
                SPHINCSPlusPrivateKeyParameters parameters = (SPHINCSPlusPrivateKeyParameters)privateKey;

                byte[] encoding = parameters.GetEncoded();
                byte[] pubEncoding = parameters.GetEncodedPublicKey();

                AlgorithmIdentifier algorithmIdentifier = new AlgorithmIdentifier(PqcUtilities.SphincsPlusOidLookup(parameters.GetParameters()));
                return new PrivateKeyInfo(algorithmIdentifier, new DerOctetString(encoding), attributes, pubEncoding);
            }
            if (privateKey is CmcePrivateKeyParameters)
            {
                CmcePrivateKeyParameters parameters = (CmcePrivateKeyParameters) privateKey;

                byte[] encoding = parameters.GetEncoded();
                AlgorithmIdentifier algorithmIdentifier =
                    new AlgorithmIdentifier(PqcUtilities.McElieceOidLookup(parameters.Parameters));

                CmcePublicKey CmcePub = new CmcePublicKey(parameters.ReconstructPublicKey());
                CmcePrivateKey CmcePriv = new CmcePrivateKey(0, parameters.Delta, parameters.C, parameters.G,
                    parameters.Alpha, parameters.S, CmcePub);
                return new PrivateKeyInfo(algorithmIdentifier, CmcePriv, attributes);
            }
            if (privateKey is SABERPrivateKeyParameters)
            {
                SABERPrivateKeyParameters parameters = (SABERPrivateKeyParameters)privateKey;

                byte[] encoding = parameters.GetEncoded();

                AlgorithmIdentifier algorithmIdentifier = new AlgorithmIdentifier(PqcUtilities.SaberOidLookup(parameters.GetParameters()));

                return new PrivateKeyInfo(algorithmIdentifier, new DerOctetString(encoding), attributes);
            }
            if (privateKey is PicnicPrivateKeyParameters)
            {
                PicnicPrivateKeyParameters parameters = (PicnicPrivateKeyParameters)privateKey;

                byte[] encoding = parameters.GetEncoded();

                AlgorithmIdentifier algorithmIdentifier = new AlgorithmIdentifier(PqcUtilities.PicnicOidLookup(parameters.GetParameters()));
                return new PrivateKeyInfo(algorithmIdentifier, new DerOctetString(encoding), attributes);
            }

            throw new ArgumentException("Class provided is not convertible: " + Platform.GetTypeName(privateKey));
        }
    }
}
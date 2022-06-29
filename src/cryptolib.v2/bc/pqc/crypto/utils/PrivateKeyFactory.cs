using System;
using System.IO;

using citronindo.cryptolib.bc.Asn1;
using citronindo.cryptolib.bc.Asn1.BC;
using citronindo.cryptolib.bc.Asn1.Pkcs;
using citronindo.cryptolib.bc.Asn1.X509;
using citronindo.cryptolib.bc.Crypto;
using citronindo.cryptolib.bc.Crypto.Utilities;
using citronindo.cryptolib.bc.Math;
using citronindo.cryptolib.bc.Pqc.Asn1;
using citronindo.cryptolib.bc.Pqc.Crypto.Cmce;
using citronindo.cryptolib.bc.Pqc.Crypto.Lms;
using citronindo.cryptolib.bc.Pqc.Crypto.Picnic;
using citronindo.cryptolib.bc.Pqc.Crypto.Saber;
using citronindo.cryptolib.bc.Pqc.Crypto.SphincsPlus;
using citronindo.cryptolib.bc.Utilities;

namespace citronindo.cryptolib.bc.Pqc.Crypto.Utilities
{
    public class PrivateKeyFactory
    {

        /// <summary> Create a private key parameter from a PKCS8 PrivateKeyInfo encoding.</summary>
        /// <param name="privateKeyInfoData"> the PrivateKeyInfo encoding</param>
        /// <returns> a suitable private key parameter</returns>
        /// <exception cref="IOException"> on an error decoding the key</exception>
        public static AsymmetricKeyParameter CreateKey(byte[] privateKeyInfoData)
        {
            return CreateKey(PrivateKeyInfo.GetInstance(Asn1Object.FromByteArray(privateKeyInfoData)));
        }

        /// <summary> Create a private key parameter from a PKCS8 PrivateKeyInfo encoding read from a stream</summary>
        /// <param name="inStr"> the stream to read the PrivateKeyInfo encoding from</param>
        /// <returns> a suitable private key parameter</returns>
        /// <exception cref="IOException"> on an error decoding the key</exception>
        public static AsymmetricKeyParameter CreateKey(Stream inStr)
        {
            return CreateKey(PrivateKeyInfo.GetInstance(new Asn1InputStream(inStr).ReadObject()));
        }


        /// <summary> Create a private key parameter from the passed in PKCS8 PrivateKeyInfo object.</summary>
        /// <param name="keyInfo"> the PrivateKeyInfo object containing the key material</param>
        /// <returns> a suitable private key parameter</returns>
        /// <exception cref="IOException"> on an error decoding the key</exception>
        public static AsymmetricKeyParameter CreateKey(PrivateKeyInfo keyInfo)
        {
            AlgorithmIdentifier algId = keyInfo.PrivateKeyAlgorithm;
            DerObjectIdentifier algOID = algId.Algorithm;

            if (algOID.Equals(PkcsObjectIdentifiers.IdAlgHssLmsHashsig))
            {
                byte[] keyEnc = Asn1OctetString.GetInstance(keyInfo.ParsePrivateKey()).GetOctets();
                DerBitString pubKey = keyInfo.PublicKeyData;

                if (Pack.BE_To_UInt32(keyEnc, 0) == 1)
                {
                    if (pubKey != null)
                    {
                        byte[] pubEnc = pubKey.GetOctets();

                        return LMSPrivateKeyParameters.GetInstance(Arrays.CopyOfRange(keyEnc, 4, keyEnc.Length),
                            Arrays.CopyOfRange(pubEnc, 4, pubEnc.Length));
                    }

                    return LMSPrivateKeyParameters.GetInstance(Arrays.CopyOfRange(keyEnc, 4, keyEnc.Length));
                }
            }

            if (algOID.On(BCObjectIdentifiers.pqc_kem_mceliece))
            {
                CmcePrivateKey cmceKey = CmcePrivateKey.GetInstance(keyInfo.ParsePrivateKey());
                CmceParameters spParams = PqcUtilities.McElieceParamsLookup(keyInfo.PrivateKeyAlgorithm.Algorithm);

                return new CmcePrivateKeyParameters(spParams, cmceKey.Delta, cmceKey.C, cmceKey.G, cmceKey.Alpha, cmceKey.S);
            }
            
            if (algOID.On(BCObjectIdentifiers.sphincsPlus))
            {
                byte[] keyEnc = Asn1OctetString.GetInstance(keyInfo.ParsePrivateKey()).GetOctets();
                SPHINCSPlusParameters spParams = SPHINCSPlusParameters.GetParams((uint)BigInteger.ValueOf(Pack.BE_To_UInt32(keyEnc, 0)).IntValue);

                return new SPHINCSPlusPrivateKeyParameters(spParams, Arrays.CopyOfRange(keyEnc, 4, keyEnc.Length));
            }
            if (algOID.On(BCObjectIdentifiers.pqc_kem_saber))
            {
                byte[] keyEnc = Asn1OctetString.GetInstance(keyInfo.ParsePrivateKey()).GetOctets();
                SABERParameters spParams = PqcUtilities.SaberParamsLookup(keyInfo.PrivateKeyAlgorithm.Algorithm);

                return new SABERPrivateKeyParameters(spParams, keyEnc);
            }
            if (algOID.On(BCObjectIdentifiers.picnic))
            {
                byte[] keyEnc = Asn1OctetString.GetInstance(keyInfo.ParsePrivateKey()).GetOctets();
                PicnicParameters picnicParams = PqcUtilities.PicnicParamsLookup(keyInfo.PrivateKeyAlgorithm.Algorithm);

                return new PicnicPrivateKeyParameters(picnicParams, keyEnc);
            }
            
            
            throw new Exception("algorithm identifier in private key not recognised");

        }
    }
}
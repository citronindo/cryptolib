using System;
using System.Collections;
using System.IO;

using citronindo.cryptolib.bc.Asn1;
using citronindo.cryptolib.bc.Asn1.Nist;
using citronindo.cryptolib.bc.Asn1.Ntt;
using citronindo.cryptolib.bc.Asn1.X509;
using citronindo.cryptolib.bc.Cms;
using citronindo.cryptolib.bc.Crypto.IO;
using citronindo.cryptolib.bc.Crypto.Parameters;
using citronindo.cryptolib.bc.Security;
using citronindo.cryptolib.bc.Utilities;
using citronindo.cryptolib.bc.Crypto;
using citronindo.cryptolib.bc.Crypto.Operators;

namespace citronindo.cryptolib.bc.Operators
{
    public class CmsContentEncryptorBuilder
    {
        private static readonly IDictionary KeySizes = Platform.CreateHashtable();

        static CmsContentEncryptorBuilder()
        {
            KeySizes[NistObjectIdentifiers.IdAes128Cbc] = 128;
            KeySizes[NistObjectIdentifiers.IdAes192Cbc] = 192;
            KeySizes[NistObjectIdentifiers.IdAes256Cbc] = 256;

            KeySizes[NttObjectIdentifiers.IdCamellia128Cbc] = 128;
            KeySizes[NttObjectIdentifiers.IdCamellia192Cbc] = 192;
            KeySizes[NttObjectIdentifiers.IdCamellia256Cbc] = 256;
        }

        private static int GetKeySize(DerObjectIdentifier oid)
        {
            if (KeySizes.Contains(oid))
            {
                return (int)KeySizes[oid];
            }

            return -1;
        }

        private readonly DerObjectIdentifier encryptionOID;
        private readonly int keySize;

        private readonly EnvelopedDataHelper helper = new EnvelopedDataHelper();
        //private SecureRandom random;

        public CmsContentEncryptorBuilder(DerObjectIdentifier encryptionOID)
            : this(encryptionOID, GetKeySize(encryptionOID))
        {
        }

        public CmsContentEncryptorBuilder(DerObjectIdentifier encryptionOID, int keySize)
        {
            this.encryptionOID = encryptionOID;
            this.keySize = keySize;
        }

        public ICipherBuilderWithKey Build()
        {
            //return new Asn1CipherBuilderWithKey(encryptionOID, keySize, random);
            return new Asn1CipherBuilderWithKey(encryptionOID, keySize, null);
        }
    }
}

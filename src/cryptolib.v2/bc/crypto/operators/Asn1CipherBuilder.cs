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
using citronindo.cryptolib.bc.Crypto.Utilities;
using citronindo.cryptolib.bc.Security;
using citronindo.cryptolib.bc.Utilities;

namespace citronindo.cryptolib.bc.Crypto.Operators
{
    public class Asn1CipherBuilderWithKey : ICipherBuilderWithKey
    {
        private readonly KeyParameter encKey;
        private AlgorithmIdentifier algorithmIdentifier;

        public Asn1CipherBuilderWithKey(DerObjectIdentifier encryptionOID, int keySize, SecureRandom random)
        {
            if (random == null)
            {
                random = new SecureRandom();
            }

            CipherKeyGenerator keyGen = CipherKeyGeneratorFactory.CreateKeyGenerator(encryptionOID, random);

            encKey = new KeyParameter(keyGen.GenerateKey());
            algorithmIdentifier = AlgorithmIdentifierFactory.GenerateEncryptionAlgID(encryptionOID, encKey.GetKey().Length * 8, random);
        }

        public object AlgorithmDetails
        {
            get { return algorithmIdentifier; }
        }

        public int GetMaxOutputSize(int inputLen)
        {
            throw new NotImplementedException();
        }

        public ICipher BuildCipher(Stream stream)
        {
            object cipher = EnvelopedDataHelper.CreateContentCipher(true, encKey, algorithmIdentifier);

            //
            // BufferedBlockCipher
            // IStreamCipher
            //

            if (cipher is IStreamCipher)
            {
                cipher = new BufferedStreamCipher((IStreamCipher)cipher);
            }

            if (stream == null)
            {
                stream = new MemoryStream();
            }

            return new BufferedCipherWrapper((IBufferedCipher)cipher, stream);
        }

        public ICipherParameters Key
        {
            get { return encKey; }
        }
    }

    public class BufferedCipherWrapper : ICipher
    {
        private readonly IBufferedCipher bufferedCipher;
        private readonly CipherStream stream;

        public BufferedCipherWrapper(IBufferedCipher bufferedCipher, Stream source)
        {
            this.bufferedCipher = bufferedCipher;
            stream = new CipherStream(source, bufferedCipher, bufferedCipher);
        }

        public int GetMaxOutputSize(int inputLen)
        {
            return bufferedCipher.GetOutputSize(inputLen);
        }

        public int GetUpdateOutputSize(int inputLen)
        {
            return bufferedCipher.GetUpdateOutputSize(inputLen);
        }

        public Stream Stream
        {
            get { return stream; }
        }
    }
}

using System;
using System.IO;

using citronindo.cryptolib.bc.Crypto.IO;

namespace citronindo.cryptolib.bc.Crypto.Operators
{
    public class DefaultVerifierCalculator
        : IStreamCalculator
    {
        private readonly SignerSink mSignerSink;

        public DefaultVerifierCalculator(ISigner signer)
        {
            this.mSignerSink = new SignerSink(signer);
        }

        public Stream Stream
        {
            get { return mSignerSink; }
        }

        public object GetResult()
        {
            return new DefaultVerifierResult(mSignerSink.Signer);
        }
    }
}

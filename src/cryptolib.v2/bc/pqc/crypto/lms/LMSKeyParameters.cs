

using System;
using citronindo.cryptolib.bc.Crypto;
using citronindo.cryptolib.bc.Utilities;

namespace citronindo.cryptolib.bc.Pqc.Crypto.Lms
{
    public abstract class LMSKeyParameters
        : AsymmetricKeyParameter, IEncodable
    {
        protected LMSKeyParameters(bool isPrivateKey)
            : base(isPrivateKey) { }

        public abstract byte[] GetEncoded();
    }
    
}
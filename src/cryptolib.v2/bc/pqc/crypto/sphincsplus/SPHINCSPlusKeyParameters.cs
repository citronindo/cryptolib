using citronindo.cryptolib.bc.Crypto;

namespace citronindo.cryptolib.bc.Pqc.Crypto.SphincsPlus
{
    public class SPHINCSPlusKeyParameters
        : AsymmetricKeyParameter
    {
        SPHINCSPlusParameters parameters;

        protected SPHINCSPlusKeyParameters(bool isPrivate, SPHINCSPlusParameters parameters)
            : base(isPrivate)
        {
            this.parameters = parameters;
        }

        public SPHINCSPlusParameters GetParameters()
        {
            return parameters;
        }
    }
}

using citronindo.cryptolib.bc.Crypto;

namespace citronindo.cryptolib.bc.Pqc.Crypto.Frodo
{
    public class FrodoKeyParameters
        : AsymmetricKeyParameter
    {
        private FrodoParameters parameters;

        public FrodoKeyParameters(
            bool isPrivate,
            FrodoParameters parameters)
            : base(isPrivate)
        {
            this.parameters = parameters;
        }

        public FrodoParameters Parameters => parameters;

    }
}
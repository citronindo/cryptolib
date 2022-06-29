
using citronindo.cryptolib.bc.Crypto;

namespace citronindo.cryptolib.bc.Pqc.Crypto.Picnic
{
    public class PicnicKeyParameters
        : AsymmetricKeyParameter
    {

    PicnicParameters parameters;

    public PicnicKeyParameters(bool isPrivate, PicnicParameters parameters)
        : base(isPrivate)
    {
        this.parameters = parameters;
    }

    public PicnicParameters GetParameters()
    {
        return parameters;
    }
    }
}
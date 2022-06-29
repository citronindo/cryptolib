
using citronindo.cryptolib.bc.Utilities;

namespace citronindo.cryptolib.bc.Pqc.Crypto.Picnic
{
    public class PicnicPublicKeyParameters
        : PicnicKeyParameters
    {

    private byte[] publicKey;

    public PicnicPublicKeyParameters(PicnicParameters parameters, byte[] pkEncoded)
        : base(false, parameters)
    {
        publicKey = Arrays.Clone(pkEncoded);
    }

    public byte[] GetEncoded()
    {
        return Arrays.Clone(publicKey);
    }

    }
}
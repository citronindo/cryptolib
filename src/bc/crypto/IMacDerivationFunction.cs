namespace citronindo.cryptolib.bc.Crypto
{
    public interface IMacDerivationFunction:IDerivationFunction
    {
        IMac GetMac();
    }
}
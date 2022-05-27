namespace citronindo.crypto.aesgcm
{
    internal interface IGcmExponentiator
    {
        void Init(byte[] x);
        void ExponentiateX(long pow, byte[] output);
    }
}
using citronindo.crypto.curve25519;

namespace citronindo.crypto.curve25519
{
    public class Fe_isreduced
    {
        public static bool fe_isreduced(byte[] Curve_pubkey)
        {
            int[] fe = new int[10];
            byte[] strict = new byte[32];

            Fe_frombytes.fe_frombytes(fe, Curve_pubkey);
            Fe_tobytes.fe_tobytes(strict, fe);
            if (Crypto_verify_32.crypto_verify_32(strict, Curve_pubkey) != 0)
                return false;
            return true;
        }
    }
}

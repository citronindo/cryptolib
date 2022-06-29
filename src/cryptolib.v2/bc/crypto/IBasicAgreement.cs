using System;
using citronindo.cryptolib.bc.Math;

namespace citronindo.cryptolib.bc.Crypto
{
    /**
     * The basic interface that basic Diffie-Hellman implementations
     * conforms to.
     */
    public interface IBasicAgreement
    {
        /**
         * initialise the agreement engine.
         */
        void Init(ICipherParameters parameters);

        /**
         * return the field size for the agreement algorithm in bytes.
         */
        int GetFieldSize();

        /**
         * given a public key from a given party calculate the next
         * message in the agreement sequence.
         */
        BigInteger CalculateAgreement(ICipherParameters pubKey);
    }

}

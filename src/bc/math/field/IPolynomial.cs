using System;

namespace citronindo.cryptolib.bc.Math.Field
{
    public interface IPolynomial
    {
        int Degree { get; }

        //BigInteger[] GetCoefficients();

        int[] GetExponentsPresent();

        //Term[] GetNonZeroTerms();
    }
}

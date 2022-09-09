using System;

namespace citronindo.cryptolib.bc.Math.EC
{
    public interface ECPointMap
    {
        ECPoint Map(ECPoint p);
    }
}

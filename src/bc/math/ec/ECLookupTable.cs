﻿using System;

namespace citronindo.cryptolib.bc.Math.EC
{
    public interface ECLookupTable
    {
        int Size { get; }
        ECPoint Lookup(int index);
        ECPoint LookupVar(int index);
    }
}

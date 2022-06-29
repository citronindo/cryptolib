﻿using System;
using System.IO;

namespace citronindo.cryptolib.bc.Utilities.IO
{
    public class MemoryInputStream
        : MemoryStream
    {
        public MemoryInputStream(byte[] buffer)
            : base(buffer, false)
        {
        }

        public sealed override bool CanWrite
        {
            get { return false; }
        }
    }
}

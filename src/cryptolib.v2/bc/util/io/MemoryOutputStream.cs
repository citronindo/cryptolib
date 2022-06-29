using System;
using System.IO;

namespace citronindo.cryptolib.bc.Utilities.IO
{
    public class MemoryOutputStream
        : MemoryStream
    {
        public sealed override bool CanRead
        {
            get { return false; }
        }
    }
}

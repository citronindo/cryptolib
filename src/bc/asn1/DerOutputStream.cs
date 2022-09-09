using System;
using System.IO;

namespace citronindo.cryptolib.bc.Asn1
{
    internal class DerOutputStream
        : Asn1OutputStream
    {
        internal DerOutputStream(Stream os)
            : base(os)
        {
        }

        internal override int Encoding
        {
            get { return EncodingDer; }
        }
    }
}

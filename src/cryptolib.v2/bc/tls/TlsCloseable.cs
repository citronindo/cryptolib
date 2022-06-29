using System;
using System.IO;

namespace citronindo.cryptolib.bc.Tls
{
    public interface TlsCloseable
    {
        /// <exception cref="IOException"/>
        void Close();
    }
}

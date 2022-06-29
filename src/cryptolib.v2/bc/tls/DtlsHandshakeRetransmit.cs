using System;
using System.IO;

namespace citronindo.cryptolib.bc.Tls
{
    internal interface DtlsHandshakeRetransmit
    {
        /// <exception cref="IOException"/>
        void ReceivedHandshakeRecord(int epoch, byte[] buf, int off, int len);
    }
}

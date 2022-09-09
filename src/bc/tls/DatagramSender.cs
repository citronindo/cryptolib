using System;
using System.IO;

namespace citronindo.cryptolib.bc.Tls
{
    public interface DatagramSender
    {
        /// <exception cref="IOException"/>
        int GetSendLimit();

        /// <exception cref="IOException"/>
        void Send(byte[] buf, int off, int len);
    }
}

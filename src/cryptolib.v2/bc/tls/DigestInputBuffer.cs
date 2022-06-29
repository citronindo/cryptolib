using System;
using System.IO;

using citronindo.cryptolib.bc.Tls.Crypto;
using citronindo.cryptolib.bc.Utilities.IO;

namespace citronindo.cryptolib.bc.Tls
{
    internal class DigestInputBuffer
        : MemoryStream
    {
        internal void UpdateDigest(TlsHash hash)
        {
            Streams.WriteBufTo(this, new TlsHashSink(hash));
        }

        /// <exception cref="IOException"/>
        internal void CopyInputTo(Stream output)
        {
            // TODO[tls-port]
            // NOTE: Copy data since the output here may be under control of external code.
            //Streams.PipeAll(new MemoryStream(buf, 0, count), output);
            Streams.WriteBufTo(this, output);
        }
    }
}

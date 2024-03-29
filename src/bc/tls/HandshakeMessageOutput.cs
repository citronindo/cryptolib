﻿using System;
using System.IO;

using citronindo.cryptolib.bc.Utilities;

namespace citronindo.cryptolib.bc.Tls
{
    internal sealed class HandshakeMessageOutput
        : MemoryStream
    {
        internal static int GetLength(int bodyLength)
        {
            return 4 + bodyLength;
        }

        /// <exception cref="IOException"/>
        internal static void Send(TlsProtocol protocol, short handshakeType, byte[] body)
        {
            HandshakeMessageOutput message = new HandshakeMessageOutput(handshakeType, body.Length);
            message.Write(body, 0, body.Length);
            message.Send(protocol);
        }

        /// <exception cref="IOException"/>
        internal HandshakeMessageOutput(short handshakeType)
            : this(handshakeType, 60)
        {
        }

        /// <exception cref="IOException"/>
        internal HandshakeMessageOutput(short handshakeType, int bodyLength)
            : base(GetLength(bodyLength))
        {
            TlsUtilities.CheckUint8(handshakeType);
            TlsUtilities.WriteUint8(handshakeType, this);
            // Reserve space for length
            Seek(3L, SeekOrigin.Current);
        }

        /// <exception cref="IOException"/>
        internal void Send(TlsProtocol protocol)
        {
            // Patch actual length back in
            int bodyLength = (int)Length - 4;
            TlsUtilities.CheckUint24(bodyLength);

            Seek(1L, SeekOrigin.Begin);
            TlsUtilities.WriteUint24(bodyLength, this);

#if PORTABLE
            byte[] buf = ToArray();
            int count = buf.Length;
#else
            byte[] buf = GetBuffer();
            int count = (int)Length;
#endif
            protocol.WriteHandshakeMessage(buf, 0, count);

            Platform.Dispose(this);
        }

        internal void PrepareClientHello(TlsHandshakeHash handshakeHash, int bindersSize)
        {
            // Patch actual length back in
            int bodyLength = (int)Length - 4 + bindersSize;
            TlsUtilities.CheckUint24(bodyLength);

            Seek(1L, SeekOrigin.Begin);
            TlsUtilities.WriteUint24(bodyLength, this);

#if PORTABLE
            byte[] buf = ToArray();
            int count = buf.Length;
#else
            byte[] buf = GetBuffer();
            int count = (int)Length;
#endif

            handshakeHash.Update(buf, 0, count);

            Seek(0L, SeekOrigin.End);
        }

        internal void SendClientHello(TlsClientProtocol clientProtocol, TlsHandshakeHash handshakeHash, int bindersSize)
        {
#if PORTABLE
            byte[] buf = ToArray();
            int count = buf.Length;
#else
            byte[] buf = GetBuffer();
            int count = (int)Length;
#endif

            if (bindersSize > 0)
            {
                handshakeHash.Update(buf, count - bindersSize, bindersSize);
            }

            clientProtocol.WriteHandshakeMessage(buf, 0, count);

            Platform.Dispose(this);
        }
    }
}

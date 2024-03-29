﻿using System;
using System.Collections;
using System.IO;

using citronindo.cryptolib.bc.Utilities;
using citronindo.cryptolib.bc.Utilities.IO;

namespace citronindo.cryptolib.bc.Tls
{
    public sealed class ServerNameList
    {
        private readonly IList m_serverNameList;

        /// <param name="serverNameList">an <see cref="IList"/> of <see cref="ServerName"/>.</param>
        public ServerNameList(IList serverNameList)
        {
            if (null == serverNameList)
                throw new ArgumentNullException("serverNameList");

            this.m_serverNameList = serverNameList;
        }

        /// <returns>an <see cref="IList"/> of <see cref="ServerName"/>.</returns>
        public IList ServerNames
        {
            get { return m_serverNameList; }
        }

        /// <summary>Encode this <see cref="ServerNameList"/> to a <see cref="Stream"/>.</summary>
        /// <param name="output">the <see cref="Stream"/> to encode to .</param>
        /// <exception cref="IOException"/>
        public void Encode(Stream output)
        {
            MemoryStream buf = new MemoryStream();

            short[] nameTypesSeen = TlsUtilities.EmptyShorts;
            foreach (ServerName entry in ServerNames)
            {
                nameTypesSeen = CheckNameType(nameTypesSeen, entry.NameType);
                if (null == nameTypesSeen)
                    throw new TlsFatalAlert(AlertDescription.internal_error);

                entry.Encode(buf);
            }

            int length = (int)buf.Length;
            TlsUtilities.CheckUint16(length);
            TlsUtilities.WriteUint16(length, output);
            Streams.WriteBufTo(buf, output);
        }

        /// <summary>Parse a <see cref="ServerNameList"/> from a <see cref="Stream"/>.</summary>
        /// <param name="input">the <see cref="Stream"/> to parse from.</param>
        /// <returns>a <see cref="ServerNameList"/> object.</returns>
        /// <exception cref="IOException"/>
        public static ServerNameList Parse(Stream input)
        {
            byte[] data = TlsUtilities.ReadOpaque16(input, 1);

            MemoryStream buf = new MemoryStream(data, false);

            short[] nameTypesSeen = TlsUtilities.EmptyShorts;
            IList server_name_list = Platform.CreateArrayList();
            while (buf.Position < buf.Length)
            {
                ServerName entry = ServerName.Parse(buf);

                nameTypesSeen = CheckNameType(nameTypesSeen, entry.NameType);
                if (null == nameTypesSeen)
                    throw new TlsFatalAlert(AlertDescription.illegal_parameter);

                server_name_list.Add(entry);
            }

            return new ServerNameList(server_name_list);
        }

        private static short[] CheckNameType(short[] nameTypesSeen, short nameType)
        {
             // RFC 6066 3. The ServerNameList MUST NOT contain more than one name of the same NameType.
            if (Arrays.Contains(nameTypesSeen, nameType))
                return null;

            return Arrays.Append(nameTypesSeen, nameType);
        }
    }
}

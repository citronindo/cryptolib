﻿using System;
using System.Collections;
using System.IO;

using citronindo.cryptolib.bc.Asn1;
using citronindo.cryptolib.bc.Asn1.Ocsp;
using citronindo.cryptolib.bc.Asn1.X509;
using citronindo.cryptolib.bc.Utilities;
using citronindo.cryptolib.bc.Utilities.IO;

namespace citronindo.cryptolib.bc.Tls
{
    /// <summary>RFC 3546 3.6</summary>
    public sealed class OcspStatusRequest
    {
        private readonly IList m_responderIDList;
        private readonly X509Extensions m_requestExtensions;

        /// <param name="responderIDList">an <see cref="IList"/> of <see cref="ResponderID"/>, specifying the list of
        /// trusted OCSP responders. An empty list has the special meaning that the responders are implicitly known to
        /// the server - e.g., by prior arrangement.</param>
        /// <param name="requestExtensions">OCSP request extensions. A null value means that there are no extensions.
        /// </param>
        public OcspStatusRequest(IList responderIDList, X509Extensions requestExtensions)
        {
            this.m_responderIDList = responderIDList;
            this.m_requestExtensions = requestExtensions;
        }

        /// <returns>an <see cref="IList"/> of <see cref="ResponderID"/>.</returns>
        public IList ResponderIDList
        {
            get { return m_responderIDList; }
        }

        /// <returns>OCSP request extensions.</returns>
        public X509Extensions RequestExtensions
        {
            get { return m_requestExtensions; }
        }

        /// <summary>Encode this <see cref="OcspStatusRequest"/> to a <see cref="Stream"/>.</summary>
        /// <param name="output">the <see cref="Stream"/> to encode to.</param>
        /// <exception cref="IOException"/>
        public void Encode(Stream output)
        {
            if (m_responderIDList == null || m_responderIDList.Count < 1)
            {
                TlsUtilities.WriteUint16(0, output);
            }
            else
            {
                MemoryStream buf = new MemoryStream();
                foreach (ResponderID responderID in m_responderIDList)
                {
                    byte[] derEncoding = responderID.GetEncoded(Asn1Encodable.Der);
                    TlsUtilities.WriteOpaque16(derEncoding, buf);
                }
                TlsUtilities.CheckUint16(buf.Length);
                TlsUtilities.WriteUint16((int)buf.Length, output);
                Streams.WriteBufTo(buf, output);
            }

            if (m_requestExtensions == null)
            {
                TlsUtilities.WriteUint16(0, output);
            }
            else
            {
                byte[] derEncoding = m_requestExtensions.GetEncoded(Asn1Encodable.Der);
                TlsUtilities.CheckUint16(derEncoding.Length);
                TlsUtilities.WriteUint16(derEncoding.Length, output);
                output.Write(derEncoding, 0, derEncoding.Length);
            }
        }

        /// <summary>Parse an <see cref="OcspStatusRequest"/> from a <see cref="Stream"/>.</summary>
        /// <param name="input">the <see cref="Stream"/> to parse from.</param>
        /// <returns>an <see cref="OcspStatusRequest"/> object.</returns>
        /// <exception cref="IOException"/>
        public static OcspStatusRequest Parse(Stream input)
        {
            IList responderIDList = Platform.CreateArrayList();
            {
                byte[] data = TlsUtilities.ReadOpaque16(input);
                if (data.Length > 0)
                {
                    MemoryStream buf = new MemoryStream(data, false);
                    do
                    {
                        byte[] derEncoding = TlsUtilities.ReadOpaque16(buf, 1);
                        Asn1Object asn1 = TlsUtilities.ReadAsn1Object(derEncoding);
                        ResponderID responderID = ResponderID.GetInstance(asn1);
                        TlsUtilities.RequireDerEncoding(responderID, derEncoding);
                        responderIDList.Add(responderID);
                    }
                    while (buf.Position < buf.Length);
                }
            }

            X509Extensions requestExtensions = null;
            {
                byte[] derEncoding = TlsUtilities.ReadOpaque16(input);
                if (derEncoding.Length > 0)
                {
                    Asn1Object asn1 = TlsUtilities.ReadAsn1Object(derEncoding);
                    X509Extensions extensions = X509Extensions.GetInstance(asn1);
                    TlsUtilities.RequireDerEncoding(extensions, derEncoding);
                    requestExtensions = extensions;
                }
            }

            return new OcspStatusRequest(responderIDList, requestExtensions);
        }
    }
}

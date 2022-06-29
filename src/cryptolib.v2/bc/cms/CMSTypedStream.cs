using System;
using System.IO;

using citronindo.cryptolib.bc.Asn1.Pkcs;
using citronindo.cryptolib.bc.Utilities;
using citronindo.cryptolib.bc.Utilities.IO;

namespace citronindo.cryptolib.bc.Cms
{
	public class CmsTypedStream
	{
		private const int BufferSize = 32 * 1024;

		private readonly string	_oid;
		private readonly Stream	_in;

		public CmsTypedStream(
			Stream inStream)
			: this(PkcsObjectIdentifiers.Data.Id, inStream, BufferSize)
		{
		}

		public CmsTypedStream(
			string oid,
			Stream inStream)
			: this(oid, inStream, BufferSize)
		{
		}

		public CmsTypedStream(
			string	oid,
			Stream	inStream,
			int		bufSize)
		{
			_oid = oid;
#if PORTABLE
			_in = new FullReaderStream(inStream);
#else
			_in = new FullReaderStream(new BufferedStream(inStream, bufSize));
#endif
		}

		public string ContentType
		{
			get { return _oid; }
		}

		public Stream ContentStream
		{
			get { return _in; }
		}

		public void Drain()
		{
			Streams.Drain(_in);
            Platform.Dispose(_in);
		}

		private class FullReaderStream : FilterStream
		{
			internal FullReaderStream(Stream input)
				: base(input)
			{
			}

			public override int Read(byte[]	buf, int off, int len)
			{
				return Streams.ReadFully(base.s, buf, off, len);
			}
		}
	}
}

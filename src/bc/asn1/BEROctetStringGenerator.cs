using System;
using System.IO;

using citronindo.cryptolib.bc.Utilities.IO;

namespace citronindo.cryptolib.bc.Asn1
{
	public class BerOctetStringGenerator
		: BerGenerator
	{
		public BerOctetStringGenerator(Stream outStream)
			: base(outStream)
		{
			WriteBerHeader(Asn1Tags.Constructed | Asn1Tags.OctetString);
		}

		public BerOctetStringGenerator(
			Stream	outStream,
			int		tagNo,
			bool	isExplicit)
			: base(outStream, tagNo, isExplicit)
		{
			WriteBerHeader(Asn1Tags.Constructed | Asn1Tags.OctetString);
		}

		public Stream GetOctetOutputStream()
		{
			return GetOctetOutputStream(new byte[1000]); // limit for CER encoding.
		}

		public Stream GetOctetOutputStream(
			int bufSize)
		{
			return bufSize < 1
				?	GetOctetOutputStream()
				:	GetOctetOutputStream(new byte[bufSize]);
		}

		public Stream GetOctetOutputStream(
			byte[] buf)
		{
			return new BufferedBerOctetStream(this, buf);
		}

		private class BufferedBerOctetStream
			: BaseOutputStream
		{
			private byte[] _buf;
			private int    _off;
			private readonly BerOctetStringGenerator _gen;
			private readonly Asn1OutputStream _derOut;

			internal BufferedBerOctetStream(
				BerOctetStringGenerator	gen,
				byte[]					buf)
			{
				_gen = gen;
				_buf = buf;
				_off = 0;
				_derOut = Asn1OutputStream.Create(_gen.Out, Asn1Encodable.Der);
			}

			public override void Write(byte[] buffer, int offset, int count)
			{
				Streams.ValidateBufferArguments(buffer, offset, count);

                int bufLen = _buf.Length;
                int available = bufLen - _off;
                if (count < available)
                {
                    Array.Copy(buffer, offset, _buf, _off, count);
                    _off += count;
                    return;
                }

                int pos = 0;
                if (_off > 0)
                {
                    Array.Copy(buffer, offset, _buf, _off, available);
                    pos += available;
                    DerOctetString.Encode(_derOut, _buf, 0, bufLen);
                }

                int remaining;
                while ((remaining = count - pos) >= bufLen)
                {
                    DerOctetString.Encode(_derOut, buffer, offset + pos, bufLen);
                    pos += bufLen;
                }

                Array.Copy(buffer, offset + pos, _buf, 0, remaining);
                this._off = remaining;
            }

			public override void WriteByte(byte value)
			{
				_buf[_off++] = value;

				if (_off == _buf.Length)
				{
					DerOctetString.Encode(_derOut, _buf, 0, _off);
					_off = 0;
				}
			}

#if PORTABLE
            protected override void Dispose(bool disposing)
            {
                if (disposing)
                {
                    ImplClose();
                }
                base.Dispose(disposing);
            }
#else
            public override void Close()
            {
                ImplClose();
                base.Close();
            }
#endif

            private void ImplClose()
            {
                if (_off != 0)
                {
                    DerOctetString.Encode(_derOut, _buf, 0, _off);
                }

                _derOut.FlushInternal();

                _gen.WriteBerEnd();
            }
        }
    }
}

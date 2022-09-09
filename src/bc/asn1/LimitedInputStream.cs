using System.IO;

using citronindo.cryptolib.bc.Utilities.IO;

namespace citronindo.cryptolib.bc.Asn1
{
    internal abstract class LimitedInputStream
        : BaseInputStream
    {
        protected readonly Stream _in;
        private int _limit;

        internal LimitedInputStream(Stream inStream, int limit)
        {
            this._in = inStream;
            this._limit = limit;
        }

        internal virtual int Limit
        {
            get { return _limit; }
        }

        protected void SetParentEofDetect()
        {
            if (_in is IndefiniteLengthInputStream)
            {
                ((IndefiniteLengthInputStream)_in).SetEofOn00(true);
            }
        }
    }
}

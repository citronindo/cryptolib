using System;

using citronindo.cryptolib.bc.Utilities.IO;

namespace citronindo.cryptolib.bc.Crypto.IO
{
    public class MacSink
        : BaseOutputStream
    {
        private readonly IMac mMac;

        public MacSink(IMac mac)
        {
            this.mMac = mac;
        }

        public virtual IMac Mac
        {
            get { return mMac; }
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            Streams.ValidateBufferArguments(buffer, offset, count);

            if (count > 0)
            {
                mMac.BlockUpdate(buffer, offset, count);
            }
        }

        public override void WriteByte(byte value)
        {
            mMac.Update(value);
        }
    }
}

using citronindo.cryptolib.bc.Pqc.Crypto.Picnic;

namespace citronindo.cryptolib.bc.Pqc.Crypto.Picnic
{
    public class View
    {
        internal uint[] inputShare;
        internal byte[] communicatedBits;
        internal uint[] outputShare;

        public View(PicnicEngine engine)
        {
            inputShare = new uint[engine.stateSizeBytes];
            communicatedBits = new byte[engine.andSizeBytes];
            outputShare = new uint[engine.stateSizeBytes];
        }
    }
}
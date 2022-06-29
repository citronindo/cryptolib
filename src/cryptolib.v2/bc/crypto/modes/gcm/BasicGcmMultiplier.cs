using System;

namespace citronindo.cryptolib.bc.Crypto.Modes.Gcm
{
    public class BasicGcmMultiplier
        : IGcmMultiplier
    {
        private GcmUtilities.FieldElement H;

        public void Init(byte[] H)
        {
            GcmUtilities.AsFieldElement(H, out this.H);
        }

        public void MultiplyH(byte[] x)
        {
            GcmUtilities.Multiply(x, ref H);
        }
    }
}

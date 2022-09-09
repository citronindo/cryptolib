using System;

using citronindo.cryptolib.bc.Asn1.X509;
using citronindo.cryptolib.bc.Crypto;

namespace citronindo.cryptolib.bc.Crmf
{
    public interface IPKMacPrimitivesProvider   
    {
	    IDigest CreateDigest(AlgorithmIdentifier digestAlg);

        IMac CreateMac(AlgorithmIdentifier macAlg);
    }
}

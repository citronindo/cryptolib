using citronindo.cryptolib.bc.Asn1;
using citronindo.cryptolib.bc.Asn1.Pkcs;

namespace citronindo.cryptolib.bc.Asn1.Smime
{
    public abstract class SmimeAttributes
    {
        public static readonly DerObjectIdentifier SmimeCapabilities = PkcsObjectIdentifiers.Pkcs9AtSmimeCapabilities;
        public static readonly DerObjectIdentifier EncrypKeyPref = PkcsObjectIdentifiers.IdAAEncrypKeyPref;
    }
}

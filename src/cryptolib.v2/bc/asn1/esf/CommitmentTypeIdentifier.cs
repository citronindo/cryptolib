using System;

using citronindo.cryptolib.bc.Asn1;
using citronindo.cryptolib.bc.Asn1.Pkcs;

namespace citronindo.cryptolib.bc.Asn1.Esf
{
    public abstract class CommitmentTypeIdentifier
    {
        public static readonly DerObjectIdentifier ProofOfOrigin = PkcsObjectIdentifiers.IdCtiEtsProofOfOrigin;
        public static readonly DerObjectIdentifier ProofOfReceipt = PkcsObjectIdentifiers.IdCtiEtsProofOfReceipt;
        public static readonly DerObjectIdentifier ProofOfDelivery = PkcsObjectIdentifiers.IdCtiEtsProofOfDelivery;
        public static readonly DerObjectIdentifier ProofOfSender = PkcsObjectIdentifiers.IdCtiEtsProofOfSender;
        public static readonly DerObjectIdentifier ProofOfApproval = PkcsObjectIdentifiers.IdCtiEtsProofOfApproval;
        public static readonly DerObjectIdentifier ProofOfCreation = PkcsObjectIdentifiers.IdCtiEtsProofOfCreation;
    }
}
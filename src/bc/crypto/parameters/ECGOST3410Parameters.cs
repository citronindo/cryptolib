using System;

using citronindo.cryptolib.bc.Asn1;
using citronindo.cryptolib.bc.Math;
using citronindo.cryptolib.bc.Math.EC;

namespace citronindo.cryptolib.bc.Crypto.Parameters
{
    public class ECGost3410Parameters
        : ECNamedDomainParameters
    {
        private readonly DerObjectIdentifier _publicKeyParamSet;
        private readonly DerObjectIdentifier _digestParamSet;
        private readonly DerObjectIdentifier _encryptionParamSet;

        public DerObjectIdentifier PublicKeyParamSet
        {
            get { return _publicKeyParamSet; }
        }

        public DerObjectIdentifier DigestParamSet
        {
            get { return _digestParamSet; }
        }

        public DerObjectIdentifier EncryptionParamSet
        {
            get { return _encryptionParamSet; }
        }

        public ECGost3410Parameters(
            ECNamedDomainParameters dp,
            DerObjectIdentifier publicKeyParamSet,
            DerObjectIdentifier digestParamSet,
            DerObjectIdentifier encryptionParamSet)
            : base(dp.Name, dp.Curve, dp.G, dp.N, dp.H, dp.GetSeed())
        {
            this._publicKeyParamSet = publicKeyParamSet;
            this._digestParamSet = digestParamSet;
            this._encryptionParamSet = encryptionParamSet;
        }

        public ECGost3410Parameters(ECDomainParameters dp, DerObjectIdentifier publicKeyParamSet,
            DerObjectIdentifier digestParamSet,
            DerObjectIdentifier encryptionParamSet)
            : base(publicKeyParamSet, dp.Curve, dp.G, dp.N, dp.H, dp.GetSeed())
        {
            this._publicKeyParamSet = publicKeyParamSet;
            this._digestParamSet = digestParamSet;
            this._encryptionParamSet = encryptionParamSet;
        }
    }
}

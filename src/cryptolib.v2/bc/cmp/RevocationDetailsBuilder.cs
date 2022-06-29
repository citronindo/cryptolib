﻿using System;

using citronindo.cryptolib.bc.Asn1;
using citronindo.cryptolib.bc.Asn1.Cmp;
using citronindo.cryptolib.bc.Asn1.Crmf;
using citronindo.cryptolib.bc.Asn1.X509;
using citronindo.cryptolib.bc.Math;

namespace citronindo.cryptolib.bc.Cmp
{
    public class RevocationDetailsBuilder
    {
        private readonly CertTemplateBuilder _templateBuilder = new CertTemplateBuilder();

        public RevocationDetailsBuilder SetPublicKey(SubjectPublicKeyInfo publicKey)
        {
            if (publicKey != null)
            {
                _templateBuilder.SetPublicKey(publicKey);
            }

            return this;
        }

        public RevocationDetailsBuilder SetIssuer(X509Name issuer)
        {
            if (issuer != null)
            {
                _templateBuilder.SetIssuer(issuer);
            }

            return this;
        }

        public RevocationDetailsBuilder SetSerialNumber(BigInteger serialNumber)
        {
            if (serialNumber != null)
            {
                _templateBuilder.SetSerialNumber(new DerInteger(serialNumber));
            }

            return this;
        }

        public RevocationDetailsBuilder SetSubject(X509Name subject)
        {
            if (subject != null)
            {
                _templateBuilder.SetSubject(subject);
            }

            return this;
        }

        public RevocationDetails Build()
        {
            return new RevocationDetails(new RevDetails(_templateBuilder.Build()));
        }
    }
}
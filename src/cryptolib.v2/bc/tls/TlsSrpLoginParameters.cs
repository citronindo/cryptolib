﻿using System;

using citronindo.cryptolib.bc.Math;
using citronindo.cryptolib.bc.Tls.Crypto;
using citronindo.cryptolib.bc.Utilities;

namespace citronindo.cryptolib.bc.Tls
{
    public class TlsSrpLoginParameters
    {
        protected byte[] m_identity;
        protected TlsSrpConfig m_srpConfig;
        protected BigInteger m_verifier;
        protected byte[] m_salt;

        public TlsSrpLoginParameters(byte[] identity, TlsSrpConfig srpConfig, BigInteger verifier, byte[] salt)
        {
            this.m_identity = Arrays.Clone(identity);
            this.m_srpConfig = srpConfig;
            this.m_verifier = verifier;
            this.m_salt = Arrays.Clone(salt);
        }

        public virtual TlsSrpConfig Config
        {
            get { return m_srpConfig; }
        }

        public virtual byte[] Identity
        {
            get { return m_identity; }
        }

        public virtual byte[] Salt
        {
            get { return m_salt; }
        }

        public virtual BigInteger Verifier
        {
            get { return m_verifier; }
        }
    }
}

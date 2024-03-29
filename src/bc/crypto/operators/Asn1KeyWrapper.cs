﻿using System;
using System.Collections;

using citronindo.cryptolib.bc.Asn1;
using citronindo.cryptolib.bc.Asn1.Nist;
using citronindo.cryptolib.bc.Asn1.Oiw;
using citronindo.cryptolib.bc.Asn1.Pkcs;
using citronindo.cryptolib.bc.Asn1.X509;
using citronindo.cryptolib.bc.Crypto.Encodings;
using citronindo.cryptolib.bc.Crypto.Engines;
using citronindo.cryptolib.bc.Security;
using citronindo.cryptolib.bc.Utilities;
using citronindo.cryptolib.bc.X509;

namespace citronindo.cryptolib.bc.Crypto.Operators
{
    public class Asn1KeyWrapper
        : IKeyWrapper
    {
        private string algorithm;
        private IKeyWrapper wrapper;

        public Asn1KeyWrapper(string algorithm, X509Certificate cert)
        {
            this.algorithm = algorithm;
            wrapper = KeyWrapperUtil.WrapperForName(algorithm, cert.GetPublicKey());
        }

        public Asn1KeyWrapper(DerObjectIdentifier algorithm, X509Certificate cert)
             : this(algorithm, cert.GetPublicKey())
        {
        }

        public Asn1KeyWrapper(DerObjectIdentifier algorithm, ICipherParameters key)
            : this(algorithm, null, key)
        {
        }

        public Asn1KeyWrapper(DerObjectIdentifier algorithm, Asn1Encodable parameters, X509Certificate cert)
            :this(algorithm, parameters, cert.GetPublicKey())
        {
        }

        public Asn1KeyWrapper(DerObjectIdentifier algorithm, Asn1Encodable parameters, ICipherParameters key)
        {
            this.algorithm = algorithm.Id;
            if (algorithm.Equals(PkcsObjectIdentifiers.IdRsaesOaep))
            {
                RsaesOaepParameters oaepParams = RsaesOaepParameters.GetInstance(parameters);
                WrapperProvider provider;
                if (oaepParams.MaskGenAlgorithm.Algorithm.Equals(PkcsObjectIdentifiers.IdMgf1))
                {
                    AlgorithmIdentifier digAlg = AlgorithmIdentifier.GetInstance(oaepParams.MaskGenAlgorithm.Parameters);

                    provider = new RsaOaepWrapperProvider(oaepParams.HashAlgorithm.Algorithm, digAlg.Algorithm);
                }
                else
                {
                    provider = new RsaOaepWrapperProvider(oaepParams.HashAlgorithm.Algorithm, oaepParams.MaskGenAlgorithm.Algorithm);
                }
                wrapper = (IKeyWrapper)provider.CreateWrapper(true, key);
            }
            else if (algorithm.Equals(PkcsObjectIdentifiers.RsaEncryption))
            {
                wrapper = (IKeyWrapper)new RsaPkcs1Wrapper(true, key);
            }
            else
            {
                throw new ArgumentException("unknown algorithm: " + algorithm.Id);
            }
        }

        public object AlgorithmDetails
        {
            get { return wrapper.AlgorithmDetails; }
        }

        public IBlockResult Wrap(byte[] keyData)
        {
            return wrapper.Wrap(keyData);
        }
    }

    public class Asn1KeyUnwrapper
     : IKeyUnwrapper
    {
        private string algorithm;
        private IKeyUnwrapper wrapper;

        public Asn1KeyUnwrapper(string algorithm, ICipherParameters key)
        {
            this.algorithm = algorithm;
            wrapper = KeyWrapperUtil.UnwrapperForName(algorithm, key);
        }

        public Asn1KeyUnwrapper(DerObjectIdentifier algorithm, ICipherParameters key)
            : this(algorithm, null, key)
        {
        }

        public Asn1KeyUnwrapper(DerObjectIdentifier algorithm, Asn1Encodable parameters, ICipherParameters key)
        {
            this.algorithm = algorithm.Id;
            if (algorithm.Equals(PkcsObjectIdentifiers.IdRsaesOaep))
            {
                RsaesOaepParameters oaepParams = RsaesOaepParameters.GetInstance(parameters);
                WrapperProvider provider;
                if (oaepParams.MaskGenAlgorithm.Algorithm.Equals(PkcsObjectIdentifiers.IdMgf1))
                {
                    AlgorithmIdentifier digAlg = AlgorithmIdentifier.GetInstance(oaepParams.MaskGenAlgorithm.Parameters);

                    provider = new RsaOaepWrapperProvider(oaepParams.HashAlgorithm.Algorithm, digAlg.Algorithm);
                }
                else
                {
                    provider = new RsaOaepWrapperProvider(oaepParams.HashAlgorithm.Algorithm, oaepParams.MaskGenAlgorithm.Algorithm);
                }
                wrapper = (IKeyUnwrapper)provider.CreateWrapper(false, key);
            }
            else if (algorithm.Equals(PkcsObjectIdentifiers.RsaEncryption))
            {
                RsaesOaepParameters oaepParams = RsaesOaepParameters.GetInstance(parameters);
                WrapperProvider provider;
                if (oaepParams.MaskGenAlgorithm.Algorithm.Equals(PkcsObjectIdentifiers.IdMgf1))
                {
                    AlgorithmIdentifier digAlg = AlgorithmIdentifier.GetInstance(oaepParams.MaskGenAlgorithm.Parameters);

                    provider = new RsaOaepWrapperProvider(oaepParams.HashAlgorithm.Algorithm, digAlg.Algorithm);
                }
                else
                {
                    provider = new RsaOaepWrapperProvider(oaepParams.HashAlgorithm.Algorithm, oaepParams.MaskGenAlgorithm.Algorithm);
                }
                wrapper = (IKeyUnwrapper)new RsaPkcs1Wrapper(false, key);
            }
            else
            {
                throw new ArgumentException("unknown algorithm: " + algorithm.Id);
            }
        }

        public object AlgorithmDetails
        {
            get { return wrapper.AlgorithmDetails; }
        }

        public IBlockResult Unwrap(byte[] keyData, int offSet, int length)
        {
            return wrapper.Unwrap(keyData, offSet, length);
        }
    }

    internal class KeyWrapperUtil
    {
        //
        // Provider 
        //
        private static readonly IDictionary providerMap = Platform.CreateHashtable();

        static KeyWrapperUtil()
            
        {
            providerMap.Add("RSA/ECB/PKCS1PADDING", new RsaOaepWrapperProvider(OiwObjectIdentifiers.IdSha1));
            providerMap.Add("RSA/NONE/PKCS1PADDING", new RsaOaepWrapperProvider(OiwObjectIdentifiers.IdSha1));
            providerMap.Add("RSA/NONE/OAEPWITHSHA1ANDMGF1PADDING", new RsaOaepWrapperProvider(OiwObjectIdentifiers.IdSha1));
            providerMap.Add("RSA/NONE/OAEPWITHSHA224ANDMGF1PADDING", new RsaOaepWrapperProvider(NistObjectIdentifiers.IdSha224));
            providerMap.Add("RSA/NONE/OAEPWITHSHA256ANDMGF1PADDING", new RsaOaepWrapperProvider(NistObjectIdentifiers.IdSha256));
            providerMap.Add("RSA/NONE/OAEPWITHSHA384ANDMGF1PADDING", new RsaOaepWrapperProvider(NistObjectIdentifiers.IdSha384));
            providerMap.Add("RSA/NONE/OAEPWITHSHA512ANDMGF1PADDING", new RsaOaepWrapperProvider(NistObjectIdentifiers.IdSha512));
            providerMap.Add("RSA/NONE/OAEPWITHSHA256ANDMGF1WITHSHA1PADDING", new RsaOaepWrapperProvider(NistObjectIdentifiers.IdSha256, OiwObjectIdentifiers.IdSha1));
        }

        public static IKeyWrapper WrapperForName(string algorithm, ICipherParameters parameters)
        {
            WrapperProvider provider = (WrapperProvider)providerMap[Strings.ToUpperCase(algorithm)];

            if (provider == null)
                throw new ArgumentException("could not resolve " + algorithm + " to a KeyWrapper");

            return (IKeyWrapper)provider.CreateWrapper(true, parameters);
        }

        public static IKeyUnwrapper UnwrapperForName(string algorithm, ICipherParameters parameters)
        {
            WrapperProvider provider = (WrapperProvider)providerMap[Strings.ToUpperCase(algorithm)];
            if (provider == null)
                throw new ArgumentException("could not resolve " + algorithm + " to a KeyUnwrapper");

            return (IKeyUnwrapper)provider.CreateWrapper(false, parameters);
        }
    }

    internal interface WrapperProvider
    {
        object CreateWrapper(bool forWrapping, ICipherParameters parameters);
    }

    internal class RsaPkcs1Wrapper : IKeyWrapper, IKeyUnwrapper
    {
        private readonly AlgorithmIdentifier algId;
        private readonly IAsymmetricBlockCipher engine;

        public RsaPkcs1Wrapper(bool forWrapping, ICipherParameters parameters)
        {
            this.algId = new AlgorithmIdentifier(
                                PkcsObjectIdentifiers.RsaEncryption,
                                DerNull.Instance);

            this.engine = new Pkcs1Encoding(new RsaBlindedEngine());
            this.engine.Init(forWrapping, parameters);
        }

        public object AlgorithmDetails
        {
            get { return algId; }
        }

        public IBlockResult Unwrap(byte[] cipherText, int offset, int length)
        {
            return new SimpleBlockResult(engine.ProcessBlock(cipherText, offset, length));
        }

        public IBlockResult Wrap(byte[] keyData)
        {
            return new SimpleBlockResult(engine.ProcessBlock(keyData, 0, keyData.Length));
        }
    }

    internal class RsaPkcs1WrapperProvider
    : WrapperProvider
    {
        internal RsaPkcs1WrapperProvider()
        {
        }

        object WrapperProvider.CreateWrapper(bool forWrapping, ICipherParameters parameters)
        {
            return new RsaPkcs1Wrapper(forWrapping, parameters);
        }
    }

    internal class RsaOaepWrapper : IKeyWrapper, IKeyUnwrapper
    {
        private readonly AlgorithmIdentifier algId;
        private readonly IAsymmetricBlockCipher engine;

        public RsaOaepWrapper(bool forWrapping, ICipherParameters parameters, DerObjectIdentifier digestOid)
            : this(forWrapping, parameters, digestOid, digestOid)
        {
        }

        public RsaOaepWrapper(bool forWrapping, ICipherParameters parameters, DerObjectIdentifier digestOid, DerObjectIdentifier mgfOid)
        {
            AlgorithmIdentifier digestAlgId = new AlgorithmIdentifier(digestOid, DerNull.Instance);

            if (mgfOid.Equals(NistObjectIdentifiers.IdShake128) || mgfOid.Equals(NistObjectIdentifiers.IdShake256))
            {
                this.algId = new AlgorithmIdentifier(
                    PkcsObjectIdentifiers.IdRsaesOaep,
                    new RsaesOaepParameters(
                        digestAlgId,
                        new AlgorithmIdentifier(mgfOid),
                        RsaesOaepParameters.DefaultPSourceAlgorithm));
            }
            else
            {
                this.algId = new AlgorithmIdentifier(
                     PkcsObjectIdentifiers.IdRsaesOaep,
                     new RsaesOaepParameters(
                         digestAlgId,
                         new AlgorithmIdentifier(PkcsObjectIdentifiers.IdMgf1, new AlgorithmIdentifier(mgfOid, DerNull.Instance)),
                         RsaesOaepParameters.DefaultPSourceAlgorithm));
            }

            this.engine = new OaepEncoding(new RsaBlindedEngine(), DigestUtilities.GetDigest(digestOid), DigestUtilities.GetDigest(mgfOid), null);
            this.engine.Init(forWrapping, parameters);
        }

        public object AlgorithmDetails
        {
            get { return algId; }
        }

        public IBlockResult Unwrap(byte[] cipherText, int offset, int length)
        {
            return new SimpleBlockResult(engine.ProcessBlock(cipherText, offset, length));
        }

        public IBlockResult Wrap(byte[] keyData)
        {
            return new SimpleBlockResult(engine.ProcessBlock(keyData, 0, keyData.Length));
        }
    }

    internal class RsaOaepWrapperProvider
        : WrapperProvider
    {
        private readonly DerObjectIdentifier digestOid;
        private readonly DerObjectIdentifier mgfOid;

        internal RsaOaepWrapperProvider(DerObjectIdentifier digestOid)
        {
            this.digestOid = digestOid;
            this.mgfOid = digestOid;
        }

        internal RsaOaepWrapperProvider(DerObjectIdentifier digestOid, DerObjectIdentifier mgfOid)
        {
            this.digestOid = digestOid;
            this.mgfOid = mgfOid;
        }

        object WrapperProvider.CreateWrapper(bool forWrapping, ICipherParameters parameters)
        {
            return new RsaOaepWrapper(forWrapping, parameters, digestOid, mgfOid);
        }
    }
}

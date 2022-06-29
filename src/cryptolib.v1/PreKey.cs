using System;
namespace citronindo.crypto
{
    public class PreKey : KeyPair
    {
        public const int WantedPreKeyCount = 50;

        public PreKey() { }
        public uint KeyID { get; set; } = 0;
        public byte[]? Signature { get; set; }

        public static PreKey NewPreKey(uint keyId, KeyPair keyPair)
        {
            return new PreKey
            {
                KeyID = keyId,
                PublicKey = keyPair.PublicKey,
                PrivateKey = keyPair.PrivateKey
            };
        }

        public static PreKey NewPreKey(uint keyId)
        {
            KeyPair keyPair = GenerateKey();
            return new PreKey
            {
                KeyID = keyId,
                PublicKey = keyPair.PublicKey,
                PrivateKey = keyPair.PrivateKey
            };
        }
    }
}


namespace citronindo.crypto.curve25519
{
	/// <summary>
	/// Curve25519 public and private key stored together.
	/// </summary>
	public class CurveKeyPair
	{

		private readonly byte[] publicKey;
		private readonly byte[] privateKey;

		/// <summary>
		/// Create a curve 25519 keypair from a public and private keys.
		/// </summary>
		/// <param name="publicKey">32 byte public key</param>
		/// <param name="privateKey">32 byte private key</param>
		public CurveKeyPair(byte[] publicKey, byte[] privateKey)
		{
			this.publicKey = publicKey;
			this.privateKey = privateKey;
		}

		/// <summary>
		/// Curve25519 public key
		/// </summary>
		/// <returns></returns>
		public byte[] getPublicKey()
		{
			return publicKey;
		}

		/// <summary>
		/// Curve25519 private key
		/// </summary>
		/// <returns></returns>
		public byte[] getPrivateKey()
		{
			return privateKey;
		}
	}
}
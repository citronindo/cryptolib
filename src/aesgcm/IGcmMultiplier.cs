namespace citronindo.crypto.aesgcm
{
	public interface IGcmMultiplier
	{
		void Init(byte[] H);
		void MultiplyH(byte[] x);
	}
}
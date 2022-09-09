namespace citronindo.cryptolib.bc.Pqc.Crypto.Lms
{
    public interface ILMSContextBasedSigner
    {
        LMSContext GenerateLmsContext();

        byte[] GenerateSignature(LMSContext context);

        long GetUsagesRemaining();
    }
}
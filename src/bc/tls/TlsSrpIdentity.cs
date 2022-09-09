using System;

namespace citronindo.cryptolib.bc.Tls
{
    /// <summary>Processor interface for an SRP identity.</summary>
    public interface TlsSrpIdentity
    {
        byte[] GetSrpIdentity();

        byte[] GetSrpPassword();
    }
}

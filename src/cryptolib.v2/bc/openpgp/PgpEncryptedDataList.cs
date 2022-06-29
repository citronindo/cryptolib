using System;
using System.Collections;
using System.IO;

using citronindo.cryptolib.bc.Utilities;
using citronindo.cryptolib.bc.Utilities.Collections;

namespace citronindo.cryptolib.bc.Bcpg.OpenPgp
{
	/// <remarks>A holder for a list of PGP encryption method packets.</remarks>
    public class PgpEncryptedDataList
		: PgpObject
    {
        private readonly IList list = Platform.CreateArrayList();
        private readonly InputStreamPacket data;

        public PgpEncryptedDataList(
            BcpgInputStream bcpgInput)
        {
            while (bcpgInput.NextPacketTag() == PacketTag.PublicKeyEncryptedSession
                || bcpgInput.NextPacketTag() == PacketTag.SymmetricKeyEncryptedSessionKey)
            {
                list.Add(bcpgInput.ReadPacket());
            }

            Packet packet = bcpgInput.ReadPacket();
            if (!(packet is InputStreamPacket))
                throw new IOException("unexpected packet in stream: " + packet);

            this.data = (InputStreamPacket)packet;

            for (int i = 0; i != list.Count; i++)
            {
                if (list[i] is SymmetricKeyEncSessionPacket)
                {
                    list[i] = new PgpPbeEncryptedData((SymmetricKeyEncSessionPacket) list[i], data);
                }
                else
                {
                    list[i] = new PgpPublicKeyEncryptedData((PublicKeyEncSessionPacket) list[i], data);
                }
            }
        }

		public PgpEncryptedData this[int index]
		{
			get { return (PgpEncryptedData) list[index]; }
		}

		public int Count
		{
			get { return list.Count; }
		}

		public bool IsEmpty
        {
			get { return list.Count == 0; }
        }

		public IEnumerable GetEncryptedDataObjects()
        {
            return new EnumerableProxy(list);
        }
    }
}

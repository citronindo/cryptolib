using System;

using citronindo.cryptolib.bc.Utilities.Date;

namespace citronindo.cryptolib.bc.Pkix
{
    public class CertStatus
    {
        public const int Unrevoked = 11;

        public const int Undetermined = 12;

        private int status = Unrevoked;

        DateTimeObject revocationDate = null;

        /// <summary>
        /// Returns the revocationDate.
        /// </summary>
         public DateTimeObject RevocationDate
        {
            get { return revocationDate; }
            set { this.revocationDate = value; }
        }

		/// <summary>
        /// Returns the certStatus.
        /// </summary>
        public int Status
        {
            get { return status; }
            set { this.status = value; }
        }
    }
}

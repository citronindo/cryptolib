using System;

using citronindo.cryptolib.bc.Asn1;
using citronindo.cryptolib.bc.Utilities.Collections;

namespace citronindo.cryptolib.bc.X509
{
	public interface IX509Extension
	{
		/// <summary>
		/// Get all critical extension values, by oid
		/// </summary>
		/// <returns>IDictionary with string (OID) keys and Asn1OctetString values</returns>
		ISet GetCriticalExtensionOids();

		/// <summary>
		/// Get all non-critical extension values, by oid
		/// </summary>
		/// <returns>IDictionary with string (OID) keys and Asn1OctetString values</returns>
		ISet GetNonCriticalExtensionOids();

		Asn1OctetString GetExtensionValue(DerObjectIdentifier oid);
	}
}

using System;
using System.Collections;

using citronindo.cryptolib.bc.Asn1.Cms;

namespace citronindo.cryptolib.bc.Cms
{
	/**
	 * Basic generator that just returns a preconstructed attribute table
	 */
	public class SimpleAttributeTableGenerator
		: CmsAttributeTableGenerator
	{
		private readonly AttributeTable attributes;

		public SimpleAttributeTableGenerator(
			AttributeTable attributes)
		{
			this.attributes = attributes;
		}

		public virtual AttributeTable GetAttributes(
			IDictionary parameters)
		{
			return attributes;
		}
	}
}

using System;

namespace citronindo.cryptolib.bc.X509.Store
{
	public interface IX509Selector
#if !PORTABLE
		: ICloneable
#endif
	{
#if PORTABLE
        object Clone();
#endif
        bool Match(object obj);
	}
}

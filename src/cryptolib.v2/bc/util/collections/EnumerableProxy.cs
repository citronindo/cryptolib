using System;
using System.Collections;
using System.Collections.Generic;

namespace citronindo.cryptolib.bc.Utilities.Collections
{
	public sealed class EnumerableProxy
		: IEnumerable
	{
		private readonly IEnumerable inner;

		public EnumerableProxy(
			IEnumerable inner)
		{
			if (inner == null)
				throw new ArgumentNullException("inner");

			this.inner = inner;
		}

		public IEnumerator GetEnumerator()
		{
			return inner.GetEnumerator();
		}
	}

	internal sealed class EnumerableProxy<T>
		: IEnumerable<T>
	{
		private readonly IEnumerable<T> m_inner;

		internal EnumerableProxy(IEnumerable<T> inner)
		{
			if (inner == null)
				throw new ArgumentNullException("inner");

			m_inner = inner;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return m_inner.GetEnumerator();
		}

		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			return m_inner.GetEnumerator();
		}
	}
}

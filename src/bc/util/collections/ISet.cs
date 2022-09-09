using System;
using System.Collections;

namespace citronindo.cryptolib.bc.Utilities.Collections
{
	public interface ISet
		: ICollection
	{
		void Add(object o);
		void AddAll(IEnumerable e);
		void Clear();
		bool Contains(object o);
		bool IsEmpty { get; }
		bool IsFixedSize { get; }
		bool IsReadOnly { get; }
		void Remove(object o);
		void RemoveAll(IEnumerable e);
	}
}

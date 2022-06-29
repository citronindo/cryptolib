using System;
using System.IO;

namespace citronindo.cryptolib.bc.Cms
{
	public interface CmsReadable
	{
		Stream GetInputStream();
	}
}

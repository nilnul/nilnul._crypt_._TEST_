using System;
using System.Diagnostics;
using System.Security.Cryptography;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Linq.Expressions;

namespace nilnul._crypt_._TEST_.cript_.symmetric_.rijndael
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestMethod1()
		{
			using (var rijndael= new RijndaelManaged())
			{
			Debug.WriteLine(
				nilnul.txt.accumulate_.join_.Comma.Singleton.accumulate(
					rijndael.LegalBlockSizes.Select(x=> x.)
				)
				
			);

			}
		}
	}
}

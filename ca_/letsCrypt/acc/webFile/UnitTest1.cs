using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace nilnul._crypt_._TEST_.ca_.letsCrypt.acc.webFile
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestMethod1()
		{
			var authz = (await order.Authorizations()).First();
			var httpChallenge = await authz.Http();
			var keyAuthz = httpChallenge.KeyAuthz;
		}
	}
}

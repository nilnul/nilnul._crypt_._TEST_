using System;
using System.Diagnostics;
using Certes;
using Certes.Acme;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace nilnul._crypt_._TEST_.ca_.letsCrypt.acc.restore
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestMethod1()
		{
			var pemKey = @"-----BEGIN EC PRIVATE KEY-----
MHcCAQEEIPRzqDEjeyVXk+0EHfzjZ5pLHla2LI7hL3w4rLofM0mLoAoGCCqGSM49
AwEHoUQDQgAEbJMi61CDkLtKdec6OkbXibhUCNrLr0Yv9lNXztfysEw1SfHtf07O
Z3Q+RA0xoke6dkNy4h+zgJ5P7uWjoVZakg==
-----END EC PRIVATE KEY-----
";
			// Load the saved account key
			var accountKey = KeyFactory.FromPem(pemKey);
			var acme = new AcmeContext(WellKnownServers.LetsEncryptStagingV2, accountKey);
			var account =  acme.Account().Result;
			var url = account.Location;
			Debug.WriteLine(url);
			/*
			 https://acme-staging-v02.api.letsencrypt.org/acme/acct/11484349
			 */

		}
	}
}

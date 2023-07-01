using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Certes;
using Certes.Acme;
using System.Linq;
using System.Diagnostics;

namespace nilnul._crypt_._TEST_.ca_.letsCrypt.acc.order
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
			var account = acme.Account().Result;



			/*	Order
	Place a wildcard certificate order(DNS validation is required for wildcard certificates)
	*/

			const string domain = "nilnul.com";
			var order = acme.NewOrder(new[] { $"*.{domain}" }).Result;
			var location=order.Location;
			Debug.WriteLine($"order:{System.Environment.NewLine}{location}");
			/*Generate the value for DNS TXT record
			*/
			var authz = (order.Authorizations()).Result.First();
			var dnsChallenge = authz.Dns().Result;
			var dnsTxt = acme.AccountKey.DnsTxt(dnsChallenge.Token);

			Debug.WriteLine(dnsTxt);

			var my = nilnul.fs.folder_.tmp.denote_.ver_.newest_._folder._EnsureItIsFolderX.Folder_ofKey("certes");


				var file = new nilnul.fs.folder.denote_.MainVered(my).nextAddress("cert", "dns");

			System.IO.File.WriteAllText(file, dnsTxt);

			nilnul.fs.file.explore_._SelX.Vod(file);



			/*Add a DNS TXT record to _acme - challenge.your.domain.name with dnsTxt value.*/
			/*
For non-wildcard certificate, HTTP challenge is also available

			var order = await acme.NewOrder(new[] { "your.domain.name" }).Result;
			*/
		}
	}
}

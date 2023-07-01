using System;
using System.Diagnostics;
using System.Linq;
using Certes;
using Certes.Acme;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace nilnul._crypt_._TEST_.ca_.letsCrypt.acc.dns
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestMethod1()
		{
			/*
			 C-xizY0evOS_ux3ph3rCdLZl1L1Ku9J8ghpuz9kxWow
			 */

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

			var domainFinal = $"*.{domain}";

			var domainUri = new Uri(domainFinal);

			var order = acme.Order(domainUri);//.Result;


			/*Generate the value for DNS TXT record
			*/
			var authz = (order.Authorizations(domainUri)).Result.First();


			var dnsChallenge = authz.c.Dns().Result;



			dnsChallenge.Validate();

			var privateKey = KeyFactory.NewKey(KeyAlgorithm.ES256);
			var cert = order.Generate(new CsrInfo
			{
				CountryName = "CA",
				State = "Ontario",
				Locality = "Toronto",
				Organization = "Certes",
				OrganizationUnit = "Dev",
				CommonName = "your.domain.name",
			}, privateKey).Result;
			//Export full chain certification
			var certPem = cert.ToPem();
			Debug.WriteLine(certPem);

			var my = nilnul.fs.folder_.tmp.denote_.ver_.next._CreateFolderX.Folder_ofBase("certes");
			var file = new nilnul.fs.folder.denote_.MainVered(my).nextAddress("cert", "cert");
			System.IO.File.WriteAllText(file, certPem);

			nilnul.fs.file.explore_._SelX.Vod(file);


			//Export PFX
			var pfxBuilder = cert.ToPfx(privateKey);
			var pfx = pfxBuilder.Build("my-cert", "abcd1234");

			Debug.Write(
				nilnul.txt.codec.Base64.Code(pfx)
			);

			var file2 = new nilnul.fs.folder.denote_.MainVered(my).nextAddress("cert", "pfx");
			System.IO.File.WriteAllBytes(file2, pfx);



			nilnul.fs.file.explore_._SelX.Vod(file2);


		}
	}
}

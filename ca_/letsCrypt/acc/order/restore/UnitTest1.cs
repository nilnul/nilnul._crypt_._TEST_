using System;
using System.Diagnostics;
using System.Linq;
using Certes;
using Certes.Acme;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace nilnul._crypt_._TEST_.ca_.letsCrypt.acc.order.restore
{
	/*I successfully renewed a certificate but validation didn’t happen this time - how is that possible?
Once you successfully complete the challenges for a domain, the resulting authorization is cached for your account to use again later. Cached authorizations last for 30 days from the time of validation. If the certificate you requested has all of the necessary authorizations cached then validation will not happen again until the relevant cached authorizations expire.
https://letsencrypt.org/docs/faq/

 */
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

			//var domainUri = new Uri(domainFinal); https://acme-staging-v02.api.letsencrypt.org/acme/order/11484349/59946388

			var location = new Uri( "https://acme-staging-v02.api.letsencrypt.org/acme/order/11484349/59946388");

			var order = acme.Order(location);
			//var order = account.Orders().Result.Orders().Result.FirstOrDefault();//  acme.Order(domainUri);//.Result;


			/*Generate the value for DNS TXT record
			*/
			var authz = (order.Authorizations()).Result.First();


			var dnsChallenge = authz.Dns().Result;



			var validateResult=dnsChallenge.Validate().Result;



			/*C-xizY0evOS_ux3ph3rCdLZl1L1Ku9J8ghpuz9kxWow*/


		}
	}
}

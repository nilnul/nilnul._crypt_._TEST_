using System;
using Certes;
using Certes.Acme;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace nilnul._crypt_._TEST_.ca_.letsCrypt.acc
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestMethod1()
		{
			var acme = new AcmeContext(WellKnownServers.LetsEncryptStagingV2);
			//var acme = new AcmeContext(WellKnownServers.LetsEncryptV2);

			var account =  acme.NewAccount("wangyoutian@nilnul.com", true).Result;



			// Save the account key for later use
			var pemKey = acme.AccountKey.ToPem();

			var my = nilnul.fs.folder_.tmp.denote_.ver_.next._CreateFolderX.Folder_ofBase("certes");
			var file = new nilnul.fs.folder.denote_.MainVered(my).nextAddress("cert", "perm");
			System.IO.File.WriteAllText(file,pemKey);
			nilnul.fs.file.explore_._SelX.Vod(file);
			
		}
	}
}

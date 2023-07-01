using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace nilnul._crypt_._TEST_.cript_.symmetric_.aes.onFile
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestMethod1()
		{
			var file = nilnul.fs.folder_.tmp.denote_.mainVered_._NextX.SpearTxt("aes", ".test");
			var bytes = new Byte[1024];
			var rnd = new Random();
			
			 rnd.NextBytes(bytes);
			

			System.IO.File.WriteAllBytes(file, bytes );

			//密码
			var pass = "asfasfake";

			///产生一个明文文件
			var outputFile = nilnul.fs.folder_.tmp.denote_.mainVered_._NextX.SpearTxt("aes.test", ".crypt");

			///加密
			nilnul.crypt_.symmetric_.aes._OnFileX._Encrypt(file, pass, outputFile);

			///解密
			var outputDecryptFile = nilnul.fs.folder_.tmp.denote_.mainVered_._NextX.SpearTxt("aes.test", ".decrypt");
			nilnul.crypt_.symmetric_.aes._OnFileX._Decrypt(outputFile, pass, outputDecryptFile);



			var bytesRead = System.IO.File.ReadAllBytes(outputDecryptFile);

			///对比加密或解密，如果相等则测试通过
			Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(
				nilnul._data.byt.str_.seq.Eq.Singleton.Equals(
				bytes, bytesRead),"not eq"
			);

			///查看一下三个文件
			/// .test, .crypt, .decrypt
			nilnul.fs.file.explore_._SelX.Vod(outputDecryptFile);




		}
	}
}

using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace nilnul._crypt_._TEST_._this.hash_.sha_.twoFivSix
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestMethod1()
		{
			const string i = "Hello, world!";
			//var r = nilnul._crypt.hash_.sha_.TwoFivSix.HexLower(i);
			//Debug.WriteLine(
			//	r
			//); ;

			var appended = 0;
			var r = nilnul._crypt.hash_.sha_.TwoFivSix.HexLower(i + appended);

			while (
				!r.StartsWith(
					nilnul.txt.op_.unary_.RepeatX.Repeat("0",4 )
				)
			)
			{
				appended++;
				r = nilnul._crypt.hash_.sha_.TwoFivSix.HexLower(i + appended);

			}
			Debug.WriteLine(
				r
			); ;

			Debug.WriteLine(
				appended
			); ;


		}
	}
}

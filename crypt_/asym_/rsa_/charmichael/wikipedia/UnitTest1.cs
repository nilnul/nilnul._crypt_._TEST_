using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.Numerics;

namespace nilnul._crypt_._TEST_.nilnul0.crypt_.asym_.rsa.carmichael.wiki
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestMethod1()
		{

			var prime = 61;
			var prime1q = 53; //the two must be different
			var n = prime * prime1q;

			var primeDec = prime - 1;
			var prime1qDec = prime1q - 1;

			var m = (prime - 1) * (prime1q - 1) /BigInteger.GreatestCommonDivisor(primeDec,prime1qDec);        //totient function. eg:8

			var totientOfN = (prime - 1) * (prime1q - 1) /BigInteger.GreatestCommonDivisor(primeDec,prime1qDec);;

			/*
			 * 
			 from :https://baike.baidu.com/item/RSA算法

			任意选取一个大整数e，满足 ，整数e用做加密钥（注意：e的选取是很容易的，例如，所有大于p和q的素数都可用


			 发信人: shallpion (紫竹), 信区: Algorithm
标  题: Re: RSA算法公钥求教
发信站: 水木社区 (Fri Jul 24 02:22:27 2015), 站内

e的选择对安全并无影响，因此从很早起就约定e为65537，偶尔也有人用一些其他的e，常见的有3,17一类，这些都是费马素数，但现在这些已经不推荐了，因为曾经有一段时间人们觉得小e有安全问题，虽然现在已经意识到小e本身没啥事，只要block的padding合理就行。因为rsa速度问题早起很多implementation都是在硬件里的，出于兼容的考虑现在一律推荐65537


			 */
			var e = 17; ///public exponent; must be lt <see cref="m"/>

						///private exponent;
						///
			var egcd = nilnul.num.integer.co.op_.unary_.ExtendedGcd.Eval(e, m);
			var d = egcd.Item1;     //d * e = 1 (%m     d = 1/e

			while (d<0)
			{
				d += m;
			}

			var pubKey = (n,e);

			var privKey = (n, d);

			var message = 65;

			var cyphered = BigInteger.ModPow(message, e, pubKey.n);
			var decyphered = BigInteger.ModPow(
				cyphered
				,
				privKey.d
				,
				privKey.n
			);

			Debug.Assert(
				decyphered ==message
			);


		}
	}
}

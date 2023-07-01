using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace nilnul._crypt_._TEST_.nilnul0.crypt_.asym_.rsa
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestMethod1()
		{

			var prime = 3;
			var prime1q = 5;
			var n = prime * prime1q;

			var m = (prime - 1) * (prime1q - 1);        //totient function. eg:8

			/*
			 * 
			 from :https://baike.baidu.com/item/RSA算法

			任意选取一个大整数e，满足 ，整数e用做加密钥（注意：e的选取是很容易的，例如，所有大于p和q的素数都可用


			 发信人: shallpion (紫竹), 信区: Algorithm
标  题: Re: RSA算法公钥求教
发信站: 水木社区 (Fri Jul 24 02:22:27 2015), 站内

e的选择对安全并无影响，因此从很早起就约定e为65537，偶尔也有人用一些其他的e，常见的有3,17一类，这些都是费马素数，但现在这些已经不推荐了，因为曾经有一段时间人们觉得小e有安全问题，虽然现在已经意识到小e本身没啥事，只要block的padding合理就行。因为rsa速度问题早起很多implementation都是在硬件里的，出于兼容的考虑现在一律推荐65537

a common choice is to have e=3 (which requires a good padding scheme) or e=65537, which is slower but safer.


			if GCD(e, phi(pq) !=1, then:

It doesn't become vulnerable; instead, it becomes impossible to decrypt uniquely.

Let us take the example you give: N=65 and e=3.

Then, if we encrypt the plaintext 2, we get 23mod65=8.

However, if we encrypt the plaintext 57, we get 573mod65=8

when you generate an RSA key, common practice nowadays is to select e first, and then when you select the primes p, q, you make sure that p−1,q−1 are relatively prime to e; this is equivalent to making sure that e and ϕ(N) are relatively prime.


			 */
			var e = 65537;  ///public exponent

							///private exponent
							///by euler extended gcd
							///
			var egcd = nilnul.num.integer.co.op_.unary_.ExtendedGcd.Eval(
				e, m
			);

			var d = egcd.Item1;		//d * e = 1 (%m     d = 1/e


		}
	}
}

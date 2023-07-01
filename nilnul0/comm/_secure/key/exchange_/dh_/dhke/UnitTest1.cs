using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Numerics;

namespace nilnul._crypt_._TEST_.nilnul0.comm._secure.key.exchange_.dh_.dhke
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestMethod1()
		{

			/// prime
			var modulus = 23;
			var p = modulus; //pub

			/// primitive root modulo p;
			var base0 = 5;
			var g = base0;	//pub

			var alice = 4;
			var a = alice;

			var aliceOut = 0;
			ref var A = ref aliceOut;
			A = (int) BigInteger.ModPow(g, a,p);
			// to derive a, we need: a=lg(g,A), which is difficult as it's a discrete logarithm;
			Assert.IsTrue(
				A == BigInteger.Pow( 5,4)%23 //4
			); 

			var bobSecrete = 3;
			var b = bobSecrete;
			var bobOut = 0;
			ref var B = ref bobOut;
			B = (int) BigInteger.ModPow(g, b,p);

			Assert.IsTrue(
				B ==BigInteger.Pow( 5,3)%23 //10
			);

			//alice
			var s = (int)BigInteger.ModPow(B, a, p);
			Assert.IsTrue(
				s==BigInteger.Pow(10,4)%23	//18
			);

			//bob
			var s1 = (int)BigInteger.ModPow(A, b, p);
			Assert.IsTrue(
				s1==BigInteger.Pow(4,3)%23	//18
				);
			//s = A^b mod p = B^a mod p = (g^a)^b mod p = (g^b)^a mod p = g^ab mod p = 18

			Assert.IsTrue(s1 == s);

		}
	}
}

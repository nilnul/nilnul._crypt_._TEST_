using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Org.BouncyCastle.Math;
using System;
using System.Numerics;

namespace nilnul._crypt_._TEST_.nilnul0.crypt_.asym_.rsa_.hackernoon
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestMethod1()
		{
			//https://hackernoon.com/public-key-cryptography-simply-explained-e932e3093046

			//Choose 2 large prime numbers, p & q.
			var p = 5;
			var q = 7;

			//Compute n = pq, z = (p-1)(q-1)
			var n = p * q;  //35
			var z = (p - 1) * (q - 1); //24


			//Choose e (with e < z) such that e has no common factors with z.
			// that means e cannot be 0;
			// nilnul: we further require e>1;


			var e = 2;
			for (; e < z; e++)
			{
				if (z % e != 0)
				{
					break;
				}
			}
			// e=5;

			//Choose d such that ed — 1 is exactly divisible by z.
			var d = 2;  //as e<z, so d=1 wouldnot work
			for (; ; d++)
			{
				var ed = e * d;
				--ed;
				if (ed % z == 0)//as e<z, so d=1 wouldnot work here
				{
					if (e != d)
					{
						break;
					}
				}

			}
			//d =29;

			var pub = (n, e);
			var pri = (n, d);


			Func<BigInteger, BigInteger> encrypt = m => BigInteger.ModPow(m, pub.e, pub.n);

			Func<BigInteger, BigInteger> decrypt = m => BigInteger.ModPow(m, pri.d, pri.n);
			var msg = 42; // this num cannot exceed n; or we will get msg%n;
				msg = msg % n;  //42%n


			t(msg);

			msg = 15;
			t(msg);

			t(23);

			for (int i = 0; i < n; i++)
			{
				t(i);
			}

			void t(int msg)
			{

				var cipher = encrypt(msg);

				//Assert.AreEqual(cipher, 7);

				var decipher = decrypt(cipher);

				Assert.AreEqual(decipher, msg);  // happends to be 7:7;

			}






		}
	}
}

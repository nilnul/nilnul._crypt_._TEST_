using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace nilnul._crypt_._TEST_.nilnul0.crypt_.asym_.rsa_.charmichael
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestMethod1()
		{
			/*di-mgt.com.au/rsa_theory.html
			 * 
			 The original definition of RSA uses the Euler totient function ϕ(n)=(p−1)(q−1). More recent standards use the Charmichael function λ(n)=lcm(p−1,q−1) instead.

so that an alternative secret exponent (we'll call it d') is defined by d' = e-1 (mod λ(n)), where λ(n) = lcm(p-1, q-1) = (p-1)(q-1)/gcd(p-1, q-1). Later refinements of the RSA algorithm like PKCS#1 use this definition.

But it doesn't matter which one you use. Both d and d' will give you the same results.

Note that the proofs above use the fact that x1+kφ(n) ≡ x (mod n) for any integer x. Well, by definition, xλ(n) ≡ 1 (mod n), so we can just write x1+kλ(n) ≡ x (mod n), and all the proofs will still work.

Both values of d and d' will uniquely decrypt a message c encrypted with c = me mod n, and both will give the same signature s = md mod n = md' mod n.

In fact, any secret exponent of the form d' + rλ(n) will work, for any integer r. Since λ(n) divides φ(n), then our d is one of these.



For practical values of n in the thousands of bits, the difference between d and d' is a couple of bits and makes no practical difference.

			λ(n) is smaller than ϕ(n) and divides it. The value of d′ computed by d′=e^−1 mod λ(n) is usually different from that derived by d= e ^ −1 mod ϕ(n), but the end result is the same. Both d and d′ will decrypt a message m^e mod n and both will give the same signature value s=m ^d mod n=m^d′ mod n. To compute λ(n), use the relation
λ(n)=(p−1)(q−1) / gcd(p−1,q−1) .

			Later refinements of the RSA algorithm like PKCS#1 use this definition.
			
			In fact, any secret exponent of the form d' + rλ(n) will work, for any integer r. Since λ(n) divides φ(n), then our d is one of these. 
			For practical values of n in the thousands of bits, the difference between d and d' is a couple of bits and makes no practical difference. */
		}
	}
}

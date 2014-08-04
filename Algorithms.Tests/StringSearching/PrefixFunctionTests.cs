using System;

using NUnit.Framework;

using Algorithms.StringSearching;

namespace Algorithms.Tests.StringSearching
{
	[TestFixture]
	public class PrefixFunctionTests
	{
		[Test]
		public void NaiveTest()
		{
			int[] result = PrefixFunction.Naive("abcabcd");
			Assert.That(result, Is.EqualTo(new[] { 0, 0, 0, 1, 2, 3, 0 }));

			int[] result2 = PrefixFunction.Naive("abcdabcabcdabcdab");
			Console.WriteLine(String.Join(", ", result2));

			Assert.That(result2, Is.EqualTo(new[] { 0, 0, 0, 0, 1, 2, 3, 1, 2, 3, 4, 5, 6, 7, 4, 5, 6 }));

			int[] result3 = PrefixFunction.Naive("aaa");
			Assert.That(result3, Is.EqualTo(new[] { 0, 1, 2 }));
		}

		[Test]
		public void SearchTest()
		{
			var index = PrefixFunction.Search("name", "My name is Alex. I'm from Australia.");
			Assert.That(index, Is.EqualTo(3));

			var index2 = PrefixFunction.Search("My", "My name is Alex. I'm from Australia.");
			Assert.That(index2, Is.EqualTo(0));

			var index3 = PrefixFunction.Search("Alex", "My name is Alex. I'm from Australia.");
			Assert.That(index3, Is.EqualTo("My name is Alex. I'm from Australia.".IndexOf("Alex")));
		}
	}
}
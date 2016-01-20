using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordsCounter.Utils;

namespace WordsCounterTest
{
	[TestClass]
	public class CountingTest
	{

		private Counter Counter {get; set;}

		[Description("This test checks tha lower case conversion"), TestMethod]
		public void TestWordsCounterLowerCaseConversion()
		{
			Counter = new Counter();
			string text = "This test checks the lower case Conversion";
			var words = Counter.CountWords(text);

			Assert.IsTrue(words[0] == "this - 1" && words[6] == "conversion - 1");
		}

		[Description("This test checks is splitting correctly by ' ' "), TestMethod]
		public void TestWordsCounterSplit()
		{
			Counter = new Counter();
			string text = "This test checks the split";
			var words = Counter.CountWords(text);

			Assert.IsTrue(words.Count == 5);
		}

		[Description("This test checks that Non words characters are not taken into account "), TestMethod]
		public void TestWordsNonWordsCharactersListed()
		{
			Counter = new Counter();
			string text = "This test checks the character like ? doesn't take into account";
			var words = Counter.CountWords(text);

			Assert.IsTrue(!words.Contains("? - 1"));
		}

		[Description("This test checks that words are clean of non words characters"), TestMethod]
		public void TestWordsCleanWords()
		{
			Counter = new Counter();
			string text = "This? test) checks that words are clean of non words characters";
			var words = Counter.CountWords(text);

			Assert.IsTrue(words[0] == "this - 1" && words[1] == "test - 1");
		}

		[Description("This test checks that multiple appearances are counted correctly"), TestMethod]
		public void TestWordsMultipleAppearances()
		{
			Counter = new Counter();
			string text = "This is this and that is that";
			var words = Counter.CountWords(text);

			Assert.IsTrue(words[0] == "this - 2" && words[1] == "is - 2" && words[2] == "and - 1" && words[3] == "that - 2");
		}

	}
}
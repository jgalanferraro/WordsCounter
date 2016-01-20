using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace WordsCounter.Utils
{
	public class Counter
	{

		//This is just an example, I realize there are more.
		private IList<string> SpecialCharacters
		{
			get
			{
				return new List<string>() { ",", ";", ".", ":", "?", "¿", "¡", "!", "(", ")", "{", "}", "\"" };
			}
		}

		public List<string> CountWords(string text)
		{
			List<string> words = text.ToLowerInvariant().Split(' ').Where(x => !SpecialCharacters.Contains(x)).ToList();
			CleanWords(ref words);

			return words.Where(x => !string.IsNullOrEmpty(x)).GroupBy(x => x).Select(g => string.Format("{0} - {1}", g.Key, g.Count())).ToList();
		}

		//If the special character is in the middle I assume is a mistake in one word, but I realize could be two words.
		private void CleanWords(ref List<string> words)
		{
			for (int i = 0; i < words.Count(); i++)
			{
				foreach (var specialCharacter in SpecialCharacters)
				{
					words[i] = words[i].Replace(specialCharacter, string.Empty);
				}
			}
		}
	}
}
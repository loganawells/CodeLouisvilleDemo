using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp.Utilities
{
	public static class AlphabetUtility
	{
		private const char _firstLetter = 'A';
		private const char _lastLetter = 'Z';

		public static string GenerateAlphabetString()
		{
			var alphabet = new StringBuilder();

			for (char letter = _firstLetter; letter <= _lastLetter; letter++)
			{
				alphabet.Append(letter);
			}

			return alphabet.ToString();
		}

		public static string GenerateBackwardAlphabetString()
		{
			var alphabet = new StringBuilder();

			for (char letter = _lastLetter; letter >= _firstLetter; letter--)
			{
				alphabet.Append(letter);
			}

			return alphabet.ToString();
		}

		public static string GenerateSkippedAlphabetString()
		{
			var alphabet = new StringBuilder();

			for (char letter = _firstLetter; letter <= _lastLetter; letter++, letter++)
			{
				alphabet.Append(letter);
			}

			return alphabet.ToString();
		}
	}
}

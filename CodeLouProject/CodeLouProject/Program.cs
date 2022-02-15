using CodeLouisvilleLibrary;
using System;
using System.Text;

namespace CodeLouProject
{
	public class Program
	{
		static void Main(string[] args)
		{
			var gameObject = new YardageBook("Test app name");
			gameObject.Run();
		}
	}
}
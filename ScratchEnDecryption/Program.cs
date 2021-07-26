using System;

namespace ScratchEnDecryption
{
	class Program
	{
		static void Main(string[] args)
		{
			string password = Guid.NewGuid().ToString();
			string key = Guid.NewGuid().ToString();
			string salt = Guid.NewGuid().ToString();

			Console.WriteLine("Password: {1}{0}Key: {2}{0}Salt: {3}{0}", Environment.NewLine, password, key, salt);

			string encrypted = CypherHelper.Encipher(password, key, salt);
			Console.WriteLine("Encrypted: {0}", encrypted);
			string decrypted = CypherHelper.Decipher(encrypted, Guid.NewGuid().ToString(), salt);
			Console.WriteLine("Decrypted: {0}", decrypted);



			Console.ReadLine();


		}
	}
}

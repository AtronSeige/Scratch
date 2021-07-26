using System;
using System.Collections.Generic;
using System.Text;

namespace ScratchEnDecryption
{
	internal class CypherHelper
	{
		//* These functions are ONLY for use in Guard. */
		//* Guard uses the GUID of the application as the key to encrypt/decrypt the database data */
		internal static string Encipher(string decryptedValue, string key, string salt)
		{
			RijndaelStringEncrypter rse = new RijndaelStringEncrypter(key, salt);

			return rse.Encrypt(decryptedValue);
		}

		internal static string Decipher(string encryptedvalue, string key, string salt)
		{
			RijndaelStringEncrypter rse = new RijndaelStringEncrypter(key, salt);

			return rse.Decrypt(encryptedvalue);
		}
	}
}

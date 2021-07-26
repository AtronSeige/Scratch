using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace ScratchEnDecryption
{
	internal class RijndaelStringEncrypter
	{
		private RijndaelManaged _encryptionProvider;
		private ICryptoTransform _encrypter;
		private ICryptoTransform _decrypter;

		private byte[] _key;
		private byte[] _iv;

		internal RijndaelStringEncrypter(string key, string salt)
		{
			var hash = new SHA256Managed();
			byte[] encryptionKey = hash.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
			hash.Clear();
			hash.Dispose();


			_encryptionProvider = new RijndaelManaged();
			var saltBytes = UTF8Encoding.UTF8.GetBytes(salt);
			var derivedbytes = new Rfc2898DeriveBytes(encryptionKey, saltBytes, 3);
			_key = derivedbytes.GetBytes(_encryptionProvider.KeySize / 8);
			_iv = derivedbytes.GetBytes(_encryptionProvider.BlockSize / 8);
		}

		internal string Encrypt(string value)
		{
			var valueBytes = UTF8Encoding.UTF8.GetBytes(value);
			if (_encrypter == null)
			{
				_encrypter = _encryptionProvider.CreateEncryptor(_key, _iv);
			}
			var encryptedBytes = _encrypter.TransformFinalBlock(valueBytes, 0, valueBytes.Length);
			var encrypted = Convert.ToBase64String(encryptedBytes);
			return encrypted;
		}

		internal string Decrypt(string value)
		{
			var valueBytes = Convert.FromBase64String(value);
			if (_decrypter == null)
			{
				_decrypter = _encryptionProvider.CreateDecryptor(_key, _iv);
			}
			var decryptedBytes = _decrypter.TransformFinalBlock(valueBytes, 0, valueBytes.Length);
			var decrypted = UTF8Encoding.UTF8.GetString(decryptedBytes);
			return decrypted;
		}

		//public string GetNameWithEncryptionPrefix(string value)
		//{
		//	return string.Concat("encryptedHidden_", value);
		//}

		internal void Dispose()
		{
			if (_encrypter != null)
			{
				_encrypter.Dispose();
				_encrypter = null;
			}
			if (_decrypter != null)
			{
				_decrypter.Dispose();
				_decrypter = null;
			}
			if (_encryptionProvider != null)
			{
				_encryptionProvider.Clear();
				_encryptionProvider.Dispose();
				_encryptionProvider = null;
			}
		}
	}
}

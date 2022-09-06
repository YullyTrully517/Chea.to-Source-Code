using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace CheatoClient
{
	// Token: 0x02000022 RID: 34
	public static class StringCipher
	{
		// Token: 0x0600014F RID: 335 RVA: 0x0000CA98 File Offset: 0x0000AC98
		public static string Encrypt(string plainText, string passPhrase)
		{
			byte[] saltStringBytes = StringCipher.Generate256BitsOfRandomEntropy();
			byte[] ivStringBytes = StringCipher.Generate256BitsOfRandomEntropy();
			byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
			string result;
			using (Rfc2898DeriveBytes password = new Rfc2898DeriveBytes(passPhrase, saltStringBytes, 1000))
			{
				byte[] keyBytes = password.GetBytes(32);
				using (RijndaelManaged symmetricKey = new RijndaelManaged())
				{
					symmetricKey.BlockSize = 256;
					symmetricKey.Mode = CipherMode.CBC;
					symmetricKey.Padding = PaddingMode.PKCS7;
					using (ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, ivStringBytes))
					{
						using (MemoryStream memoryStream = new MemoryStream())
						{
							using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
							{
								cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
								cryptoStream.FlushFinalBlock();
								byte[] cipherTextBytes = saltStringBytes;
								cipherTextBytes = cipherTextBytes.Concat(ivStringBytes).ToArray<byte>();
								cipherTextBytes = cipherTextBytes.Concat(memoryStream.ToArray()).ToArray<byte>();
								memoryStream.Close();
								cryptoStream.Close();
								result = Convert.ToBase64String(cipherTextBytes);
							}
						}
					}
				}
			}
			return result;
		}

		// Token: 0x06000150 RID: 336 RVA: 0x0000CBF8 File Offset: 0x0000ADF8
		public static string Decrypt(string cipherText, string passPhrase)
		{
			byte[] cipherTextBytesWithSaltAndIv = Convert.FromBase64String(cipherText);
			byte[] saltStringBytes = cipherTextBytesWithSaltAndIv.Take(32).ToArray<byte>();
			byte[] ivStringBytes = cipherTextBytesWithSaltAndIv.Skip(32).Take(32).ToArray<byte>();
			byte[] cipherTextBytes = cipherTextBytesWithSaltAndIv.Skip(64).Take(cipherTextBytesWithSaltAndIv.Length - 64).ToArray<byte>();
			string @string;
			using (Rfc2898DeriveBytes password = new Rfc2898DeriveBytes(passPhrase, saltStringBytes, 1000))
			{
				byte[] keyBytes = password.GetBytes(32);
				using (RijndaelManaged symmetricKey = new RijndaelManaged())
				{
					symmetricKey.BlockSize = 256;
					symmetricKey.Mode = CipherMode.CBC;
					symmetricKey.Padding = PaddingMode.PKCS7;
					using (ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes, ivStringBytes))
					{
						using (MemoryStream memoryStream = new MemoryStream(cipherTextBytes))
						{
							using (CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
							{
								byte[] plainTextBytes = new byte[cipherTextBytes.Length];
								int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
								memoryStream.Close();
								cryptoStream.Close();
								@string = Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
							}
						}
					}
				}
			}
			return @string;
		}

		// Token: 0x06000151 RID: 337 RVA: 0x0000CD70 File Offset: 0x0000AF70
		private static byte[] Generate256BitsOfRandomEntropy()
		{
			byte[] randomBytes = new byte[32];
			using (RNGCryptoServiceProvider rngCsp = new RNGCryptoServiceProvider())
			{
				rngCsp.GetBytes(randomBytes);
			}
			return randomBytes;
		}

		// Token: 0x040002DF RID: 735
		private const int Keysize = 256;

		// Token: 0x040002E0 RID: 736
		private const int DerivationIterations = 1000;
	}
}

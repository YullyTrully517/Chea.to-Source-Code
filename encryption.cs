using System;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace CheatoClient
{
	// Token: 0x02000008 RID: 8
	public static class encryption
	{
		// Token: 0x06000054 RID: 84 RVA: 0x00006496 File Offset: 0x00004696
		public static void error(string message)
		{
			new GigaChadMessageBox(message, "Cheato Spoofer", "OK", 466, 150, 14f, ScrollBars.None, true).ShowDialog();
			Process.GetCurrentProcess().Kill();
		}

		// Token: 0x06000055 RID: 85 RVA: 0x000064CC File Offset: 0x000046CC
		public static string byte_arr_to_str(byte[] ba)
		{
			StringBuilder hex = new StringBuilder(ba.Length * 2);
			foreach (byte b in ba)
			{
				hex.AppendFormat("{0:x2}", b);
			}
			return hex.ToString();
		}

		// Token: 0x06000056 RID: 86 RVA: 0x00006518 File Offset: 0x00004718
		public static byte[] str_to_byte_arr(string hex)
		{
			byte[] result;
			try
			{
				int NumberChars = hex.Length;
				byte[] bytes = new byte[NumberChars / 2];
				for (int i = 0; i < NumberChars; i += 2)
				{
					bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
				}
				result = bytes;
			}
			catch
			{
				encryption.error("Auth session has expired, reopen Cheato Spoofer and try again! \ud83d\udc80");
				Environment.Exit(0);
				result = null;
			}
			return result;
		}

		// Token: 0x06000057 RID: 87 RVA: 0x0000658C File Offset: 0x0000478C
		public static string encrypt_string(string plain_text, byte[] key, byte[] iv)
		{
			Aes encryptor = Aes.Create();
			encryptor.Mode = CipherMode.CBC;
			encryptor.Key = key;
			encryptor.IV = iv;
			string result;
			using (MemoryStream mem_stream = new MemoryStream())
			{
				using (ICryptoTransform aes_encryptor = encryptor.CreateEncryptor())
				{
					using (CryptoStream crypt_stream = new CryptoStream(mem_stream, aes_encryptor, CryptoStreamMode.Write))
					{
						byte[] p_bytes = Encoding.Default.GetBytes(plain_text);
						crypt_stream.Write(p_bytes, 0, p_bytes.Length);
						crypt_stream.FlushFinalBlock();
						byte[] c_bytes = mem_stream.ToArray();
						result = encryption.byte_arr_to_str(c_bytes);
					}
				}
			}
			return result;
		}

		// Token: 0x06000058 RID: 88 RVA: 0x00006654 File Offset: 0x00004854
		public static string decrypt_string(string cipher_text, byte[] key, byte[] iv)
		{
			Aes encryptor = Aes.Create();
			encryptor.Mode = CipherMode.CBC;
			encryptor.Key = key;
			encryptor.IV = iv;
			string @string;
			using (MemoryStream mem_stream = new MemoryStream())
			{
				using (ICryptoTransform aes_decryptor = encryptor.CreateDecryptor())
				{
					using (CryptoStream crypt_stream = new CryptoStream(mem_stream, aes_decryptor, CryptoStreamMode.Write))
					{
						byte[] c_bytes = encryption.str_to_byte_arr(cipher_text);
						crypt_stream.Write(c_bytes, 0, c_bytes.Length);
						crypt_stream.FlushFinalBlock();
						byte[] p_bytes = mem_stream.ToArray();
						@string = Encoding.Default.GetString(p_bytes, 0, p_bytes.Length);
					}
				}
			}
			return @string;
		}

		// Token: 0x06000059 RID: 89 RVA: 0x00006720 File Offset: 0x00004920
		public static string iv_key()
		{
			return Guid.NewGuid().ToString().Substring(0, Guid.NewGuid().ToString().IndexOf("-", StringComparison.Ordinal));
		}

		// Token: 0x0600005A RID: 90 RVA: 0x00006764 File Offset: 0x00004964
		public static string sha256(string r)
		{
			return encryption.byte_arr_to_str(new SHA256Managed().ComputeHash(Encoding.Default.GetBytes(r)));
		}

		// Token: 0x0600005B RID: 91 RVA: 0x00006780 File Offset: 0x00004980
		public static string encrypt(string message, string enc_key, string iv)
		{
			byte[] _key = Encoding.Default.GetBytes(encryption.sha256(enc_key).Substring(0, 32));
			byte[] _iv = Encoding.Default.GetBytes(encryption.sha256(iv).Substring(0, 16));
			return encryption.encrypt_string(message, _key, _iv);
		}

		// Token: 0x0600005C RID: 92 RVA: 0x000067CC File Offset: 0x000049CC
		public static string decrypt(string message, string enc_key, string iv)
		{
			byte[] _key = Encoding.Default.GetBytes(encryption.sha256(enc_key).Substring(0, 32));
			byte[] _iv = Encoding.Default.GetBytes(encryption.sha256(iv).Substring(0, 16));
			return encryption.decrypt_string(message, _key, _iv);
		}
	}
}

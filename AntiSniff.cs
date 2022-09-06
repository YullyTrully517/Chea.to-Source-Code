using System;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace CheatoClient
{
	// Token: 0x0200001D RID: 29
	public class AntiSniff
	{
		// Token: 0x060000CF RID: 207 RVA: 0x0000A160 File Offset: 0x00008360
		public static bool ValidationCallback(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
		{
			bool flag = sslPolicyErrors > SslPolicyErrors.None;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				bool flag2 = chain.ChainPolicy.VerificationFlags == X509VerificationFlags.NoFlag && chain.ChainPolicy.RevocationMode == X509RevocationMode.Online;
				if (flag2)
				{
					result = true;
				}
				else
				{
					X509Chain newChain = new X509Chain();
					X509ChainElementCollection chainElements = chain.ChainElements;
					for (int i = 1; i < chainElements.Count - 1; i++)
					{
						newChain.ChainPolicy.ExtraStore.Add(chainElements[i].Certificate);
					}
					result = newChain.Build(chainElements[0].Certificate);
				}
			}
			return result;
		}

		// Token: 0x060000D0 RID: 208 RVA: 0x0000A208 File Offset: 0x00008408
		public static bool Check()
		{
			bool result;
			try
			{
				ServicePointManager.CheckCertificateRevocationList = true;
				HttpWebRequest request = WebRequest.Create("https://chea.to") as HttpWebRequest;
				request.Timeout = 10000;
				request.ContinueTimeout = 10000;
				request.ReadWriteTimeout = 10000;
				request.KeepAlive = true;
				request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:75.0) Gecko/20100101 Firefox/75.0";
				request.Host = "chea.to";
				request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
				request.Method = "GET";
				request.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(AntiSniff.ValidationCallback);
				using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
				{
					bool flag = response.StatusCode == HttpStatusCode.OK;
					if (flag)
					{
						response.Close();
						result = false;
					}
					else
					{
						response.Close();
						result = true;
					}
				}
			}
			catch
			{
				result = true;
			}
			return result;
		}
	}
}

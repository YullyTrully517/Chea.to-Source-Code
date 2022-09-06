using System;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using Microsoft.CSharp.RuntimeBinder;
using Newtonsoft.Json;

namespace CheatoClient
{
	// Token: 0x02000004 RID: 4
	internal class Gofile
	{
		// Token: 0x0600000F RID: 15 RVA: 0x000022A0 File Offset: 0x000004A0
		public static bool GetServer(out string serverId)
		{
			bool result;
			try
			{
				string GETresponse = Gofile.wc.DownloadString("https://api.gofile.io/getServer");
				object json = JsonConvert.DeserializeObject(GETresponse);
				if (Gofile.<>o__1.<>p__2 == null)
				{
					Gofile.<>o__1.<>p__2 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(string), typeof(Gofile)));
				}
				Func<CallSite, object, string> target = Gofile.<>o__1.<>p__2.Target;
				CallSite <>p__ = Gofile.<>o__1.<>p__2;
				if (Gofile.<>o__1.<>p__1 == null)
				{
					Gofile.<>o__1.<>p__1 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.GetIndex(CSharpBinderFlags.None, typeof(Gofile), new CSharpArgumentInfo[]
					{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
					}));
				}
				Func<CallSite, object, string, object> target2 = Gofile.<>o__1.<>p__1.Target;
				CallSite <>p__2 = Gofile.<>o__1.<>p__1;
				if (Gofile.<>o__1.<>p__0 == null)
				{
					Gofile.<>o__1.<>p__0 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.GetIndex(CSharpBinderFlags.None, typeof(Gofile), new CSharpArgumentInfo[]
					{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
					}));
				}
				serverId = target(<>p__, target2(<>p__2, Gofile.<>o__1.<>p__0.Target(Gofile.<>o__1.<>p__0, json, "data"), "server"));
				result = true;
			}
			catch
			{
				serverId = null;
				result = false;
			}
			return result;
		}

		// Token: 0x06000010 RID: 16 RVA: 0x000023E0 File Offset: 0x000005E0
		public static bool UploadData(byte[] file, out string downloadPage, out string code, out string parentFolder, out string fileId, out string fileName, out string md5, out string directLink, out string info, string extension = "")
		{
			bool result;
			try
			{
				string serverId = null;
				bool flag = !Gofile.GetServer(out serverId);
				if (flag)
				{
					throw new Exception("Failed to find available Gofile server");
				}
				bool flag2 = extension.Length > 0;
				if (flag2)
				{
					extension = "." + extension.Replace(".", "");
				}
				string tempFilePath = Path.Combine(Path.GetTempPath(), Functions.GenerateRandomAlphanumericString(32) + extension);
				File.WriteAllBytes(tempFilePath, file);
				byte[] POSTresponse = Gofile.wc.UploadFile("https://" + serverId + ".gofile.io/uploadFile", tempFilePath);
				File.Delete(tempFilePath);
				string response = Encoding.UTF8.GetString(POSTresponse);
				object json = JsonConvert.DeserializeObject(response);
				if (Gofile.<>o__2.<>p__2 == null)
				{
					Gofile.<>o__2.<>p__2 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(string), typeof(Gofile)));
				}
				Func<CallSite, object, string> target = Gofile.<>o__2.<>p__2.Target;
				CallSite <>p__ = Gofile.<>o__2.<>p__2;
				if (Gofile.<>o__2.<>p__1 == null)
				{
					Gofile.<>o__2.<>p__1 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.GetIndex(CSharpBinderFlags.None, typeof(Gofile), new CSharpArgumentInfo[]
					{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
					}));
				}
				Func<CallSite, object, string, object> target2 = Gofile.<>o__2.<>p__1.Target;
				CallSite <>p__2 = Gofile.<>o__2.<>p__1;
				if (Gofile.<>o__2.<>p__0 == null)
				{
					Gofile.<>o__2.<>p__0 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.GetIndex(CSharpBinderFlags.None, typeof(Gofile), new CSharpArgumentInfo[]
					{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
					}));
				}
				downloadPage = target(<>p__, target2(<>p__2, Gofile.<>o__2.<>p__0.Target(Gofile.<>o__2.<>p__0, json, "data"), "downloadPage"));
				if (Gofile.<>o__2.<>p__5 == null)
				{
					Gofile.<>o__2.<>p__5 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(string), typeof(Gofile)));
				}
				Func<CallSite, object, string> target3 = Gofile.<>o__2.<>p__5.Target;
				CallSite <>p__3 = Gofile.<>o__2.<>p__5;
				if (Gofile.<>o__2.<>p__4 == null)
				{
					Gofile.<>o__2.<>p__4 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.GetIndex(CSharpBinderFlags.None, typeof(Gofile), new CSharpArgumentInfo[]
					{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
					}));
				}
				Func<CallSite, object, string, object> target4 = Gofile.<>o__2.<>p__4.Target;
				CallSite <>p__4 = Gofile.<>o__2.<>p__4;
				if (Gofile.<>o__2.<>p__3 == null)
				{
					Gofile.<>o__2.<>p__3 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.GetIndex(CSharpBinderFlags.None, typeof(Gofile), new CSharpArgumentInfo[]
					{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
					}));
				}
				code = target3(<>p__3, target4(<>p__4, Gofile.<>o__2.<>p__3.Target(Gofile.<>o__2.<>p__3, json, "data"), "code"));
				if (Gofile.<>o__2.<>p__8 == null)
				{
					Gofile.<>o__2.<>p__8 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(string), typeof(Gofile)));
				}
				Func<CallSite, object, string> target5 = Gofile.<>o__2.<>p__8.Target;
				CallSite <>p__5 = Gofile.<>o__2.<>p__8;
				if (Gofile.<>o__2.<>p__7 == null)
				{
					Gofile.<>o__2.<>p__7 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.GetIndex(CSharpBinderFlags.None, typeof(Gofile), new CSharpArgumentInfo[]
					{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
					}));
				}
				Func<CallSite, object, string, object> target6 = Gofile.<>o__2.<>p__7.Target;
				CallSite <>p__6 = Gofile.<>o__2.<>p__7;
				if (Gofile.<>o__2.<>p__6 == null)
				{
					Gofile.<>o__2.<>p__6 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.GetIndex(CSharpBinderFlags.None, typeof(Gofile), new CSharpArgumentInfo[]
					{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
					}));
				}
				parentFolder = target5(<>p__5, target6(<>p__6, Gofile.<>o__2.<>p__6.Target(Gofile.<>o__2.<>p__6, json, "data"), "parentFolder"));
				if (Gofile.<>o__2.<>p__11 == null)
				{
					Gofile.<>o__2.<>p__11 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(string), typeof(Gofile)));
				}
				Func<CallSite, object, string> target7 = Gofile.<>o__2.<>p__11.Target;
				CallSite <>p__7 = Gofile.<>o__2.<>p__11;
				if (Gofile.<>o__2.<>p__10 == null)
				{
					Gofile.<>o__2.<>p__10 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.GetIndex(CSharpBinderFlags.None, typeof(Gofile), new CSharpArgumentInfo[]
					{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
					}));
				}
				Func<CallSite, object, string, object> target8 = Gofile.<>o__2.<>p__10.Target;
				CallSite <>p__8 = Gofile.<>o__2.<>p__10;
				if (Gofile.<>o__2.<>p__9 == null)
				{
					Gofile.<>o__2.<>p__9 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.GetIndex(CSharpBinderFlags.None, typeof(Gofile), new CSharpArgumentInfo[]
					{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
					}));
				}
				fileId = target7(<>p__7, target8(<>p__8, Gofile.<>o__2.<>p__9.Target(Gofile.<>o__2.<>p__9, json, "data"), "fileId"));
				if (Gofile.<>o__2.<>p__14 == null)
				{
					Gofile.<>o__2.<>p__14 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(string), typeof(Gofile)));
				}
				Func<CallSite, object, string> target9 = Gofile.<>o__2.<>p__14.Target;
				CallSite <>p__9 = Gofile.<>o__2.<>p__14;
				if (Gofile.<>o__2.<>p__13 == null)
				{
					Gofile.<>o__2.<>p__13 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.GetIndex(CSharpBinderFlags.None, typeof(Gofile), new CSharpArgumentInfo[]
					{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
					}));
				}
				Func<CallSite, object, string, object> target10 = Gofile.<>o__2.<>p__13.Target;
				CallSite <>p__10 = Gofile.<>o__2.<>p__13;
				if (Gofile.<>o__2.<>p__12 == null)
				{
					Gofile.<>o__2.<>p__12 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.GetIndex(CSharpBinderFlags.None, typeof(Gofile), new CSharpArgumentInfo[]
					{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
					}));
				}
				fileName = target9(<>p__9, target10(<>p__10, Gofile.<>o__2.<>p__12.Target(Gofile.<>o__2.<>p__12, json, "data"), "fileName"));
				if (Gofile.<>o__2.<>p__17 == null)
				{
					Gofile.<>o__2.<>p__17 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(string), typeof(Gofile)));
				}
				Func<CallSite, object, string> target11 = Gofile.<>o__2.<>p__17.Target;
				CallSite <>p__11 = Gofile.<>o__2.<>p__17;
				if (Gofile.<>o__2.<>p__16 == null)
				{
					Gofile.<>o__2.<>p__16 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.GetIndex(CSharpBinderFlags.None, typeof(Gofile), new CSharpArgumentInfo[]
					{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
					}));
				}
				Func<CallSite, object, string, object> target12 = Gofile.<>o__2.<>p__16.Target;
				CallSite <>p__12 = Gofile.<>o__2.<>p__16;
				if (Gofile.<>o__2.<>p__15 == null)
				{
					Gofile.<>o__2.<>p__15 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.GetIndex(CSharpBinderFlags.None, typeof(Gofile), new CSharpArgumentInfo[]
					{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
					}));
				}
				md5 = target11(<>p__11, target12(<>p__12, Gofile.<>o__2.<>p__15.Target(Gofile.<>o__2.<>p__15, json, "data"), "md5"));
				if (Gofile.<>o__2.<>p__20 == null)
				{
					Gofile.<>o__2.<>p__20 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(string), typeof(Gofile)));
				}
				Func<CallSite, object, string> target13 = Gofile.<>o__2.<>p__20.Target;
				CallSite <>p__13 = Gofile.<>o__2.<>p__20;
				if (Gofile.<>o__2.<>p__19 == null)
				{
					Gofile.<>o__2.<>p__19 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.GetIndex(CSharpBinderFlags.None, typeof(Gofile), new CSharpArgumentInfo[]
					{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
					}));
				}
				Func<CallSite, object, string, object> target14 = Gofile.<>o__2.<>p__19.Target;
				CallSite <>p__14 = Gofile.<>o__2.<>p__19;
				if (Gofile.<>o__2.<>p__18 == null)
				{
					Gofile.<>o__2.<>p__18 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.GetIndex(CSharpBinderFlags.None, typeof(Gofile), new CSharpArgumentInfo[]
					{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
					}));
				}
				directLink = target13(<>p__13, target14(<>p__14, Gofile.<>o__2.<>p__18.Target(Gofile.<>o__2.<>p__18, json, "data"), "directLink"));
				if (Gofile.<>o__2.<>p__23 == null)
				{
					Gofile.<>o__2.<>p__23 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(string), typeof(Gofile)));
				}
				Func<CallSite, object, string> target15 = Gofile.<>o__2.<>p__23.Target;
				CallSite <>p__15 = Gofile.<>o__2.<>p__23;
				if (Gofile.<>o__2.<>p__22 == null)
				{
					Gofile.<>o__2.<>p__22 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.GetIndex(CSharpBinderFlags.None, typeof(Gofile), new CSharpArgumentInfo[]
					{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
					}));
				}
				Func<CallSite, object, string, object> target16 = Gofile.<>o__2.<>p__22.Target;
				CallSite <>p__16 = Gofile.<>o__2.<>p__22;
				if (Gofile.<>o__2.<>p__21 == null)
				{
					Gofile.<>o__2.<>p__21 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.GetIndex(CSharpBinderFlags.None, typeof(Gofile), new CSharpArgumentInfo[]
					{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
					}));
				}
				info = target15(<>p__15, target16(<>p__16, Gofile.<>o__2.<>p__21.Target(Gofile.<>o__2.<>p__21, json, "data"), "info"));
				result = true;
			}
			catch
			{
				downloadPage = null;
				code = null;
				parentFolder = null;
				fileId = null;
				fileName = null;
				md5 = null;
				directLink = null;
				info = null;
				result = false;
			}
			return result;
		}

		// Token: 0x04000004 RID: 4
		public static WebClient wc = new WebClient
		{
			Proxy = null,
			Headers = 
			{
				"User-Agent: Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/99.0.4844.51 Safari/537.36"
			}
		};
	}
}

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace CheatoClient
{
	// Token: 0x02000007 RID: 7
	public class ShitAuth
	{
		// Token: 0x0600003E RID: 62 RVA: 0x0000513C File Offset: 0x0000333C
		public ShitAuth(string name, string ownerid, string secret, string version)
		{
			bool flag = string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(ownerid) || string.IsNullOrWhiteSpace(secret) || string.IsNullOrWhiteSpace(version);
			if (flag)
			{
				ShitAuth.error("Auth somehow tampered with or not set up correctly... \ud83d\udc80");
				Environment.Exit(0);
			}
			this.name = name;
			this.ownerid = ownerid;
			this.secret = secret;
			this.version = version;
		}

		// Token: 0x0600003F RID: 63 RVA: 0x000051DC File Offset: 0x000033DC
		public void init()
		{
			this.enckey = encryption.sha256(encryption.iv_key());
			string init_iv = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("init"));
			nameValueCollection["ver"] = encryption.encrypt(this.version, this.secret, init_iv);
			nameValueCollection["hash"] = ShitAuth.checksum(Process.GetCurrentProcess().MainModule.FileName);
			nameValueCollection["enckey"] = encryption.encrypt(this.enckey, this.secret, init_iv);
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = init_iv;
			NameValueCollection values_to_upload = nameValueCollection;
			string response = ShitAuth.req(values_to_upload);
			bool flag = response == "CheatoAuth_Invalid";
			if (flag)
			{
				ShitAuth.error("Auth is down (app somehow not found in auth), time to hop on discord.chea.to and complain like a fucking Karen! \ud83d\udc80");
				Environment.Exit(0);
			}
			response = encryption.decrypt(response, this.secret, init_iv);
			ShitAuth.response_structure json = this.response_decoder.string_to_generic<ShitAuth.response_structure>(response);
			this.load_response_struct(json);
			this.CheckBypass();
			bool success = json.success;
			if (success)
			{
				this.load_app_data(json.appinfo);
				this.sessionid = json.sessionid;
				this.initialised = true;
			}
			else
			{
				bool flag2 = json.message == "invalidver";
				if (flag2)
				{
					this.app_data.downloadLink = json.download;
				}
			}
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000040 RID: 64 RVA: 0x00005388 File Offset: 0x00003588
		public static bool IsDebugRelease
		{
			get
			{
				return true;
			}
		}

		// Token: 0x06000041 RID: 65 RVA: 0x0000539C File Offset: 0x0000359C
		public void CheckBypass()
		{
			bool isbypass = false;
			string message = this.response.message;
			string a = message;
			if (!(a == "Logged in!"))
			{
				if (!(a == "Logged in"))
				{
					if (a == "Logged in.")
					{
						isbypass = true;
					}
				}
				else
				{
					isbypass = true;
				}
			}
			else
			{
				isbypass = true;
			}
			string hwid = this.user_data.hwid;
			string a2 = hwid;
			if (a2 == "-_-")
			{
				isbypass = true;
			}
			string createdate = this.user_data.createdate;
			string a3 = createdate;
			if (a3 == "0")
			{
				isbypass = true;
			}
			string username = this.user_data.username;
			string a4 = username;
			if (!(a4 == "hecker"))
			{
				if (!(a4 == "admin"))
				{
					if (!(a4 == "user"))
					{
						if (!(a4 == "username"))
						{
							if (a4 == "root")
							{
								isbypass = true;
							}
						}
						else
						{
							isbypass = true;
						}
					}
					else
					{
						isbypass = true;
					}
				}
				else
				{
					isbypass = true;
				}
			}
			else
			{
				isbypass = true;
			}
			bool flag = this.user_data.username != null;
			if (flag)
			{
				bool flag2 = this.user_data.username.Length < 10;
				if (flag2)
				{
					isbypass = true;
				}
			}
			string ip = this.user_data.ip;
			string a5 = ip;
			if (!(a5 == "0.0.0.0"))
			{
				if (!(a5 == "1.1.1.1"))
				{
					if (!(a5 == "1.2.3.4"))
					{
						if (!(a5 == "1.3.3.7"))
						{
							if (!(a5 == "69.69.69.69"))
							{
								if (!(a5 == "::1"))
								{
									bool flag3 = this.user_data.ip != null && this.user_data.ip != Functions.GetIP(true);
									if (flag3)
									{
										isbypass = true;
									}
								}
							}
							else
							{
								isbypass = true;
							}
						}
						else
						{
							isbypass = true;
						}
					}
					else
					{
						isbypass = true;
					}
				}
				else
				{
					isbypass = true;
				}
			}
			else
			{
				isbypass = true;
			}
			bool flag4 = isbypass;
			if (flag4)
			{
				new GigaChadMessageBox("Detected bypass attempt, stop being retarded \ud83d\udc80", "Cheato Spoofer", "OK", 466, 115, 14f, ScrollBars.None, true).ShowDialog();
				Process.GetCurrentProcess().Kill();
			}
		}

		// Token: 0x06000042 RID: 66 RVA: 0x000055CC File Offset: 0x000037CC
		public void Checkinit()
		{
			bool flag = !this.initialised;
			if (flag)
			{
				ShitAuth.error("Bro forgot to set the fucking auth up properly \ud83d\udc80");
			}
		}

		// Token: 0x06000043 RID: 67 RVA: 0x000055F4 File Offset: 0x000037F4
		public void license(string key)
		{
			this.Checkinit();
			string hwid = Functions.GetHWID();
			string init_iv = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("license"));
			nameValueCollection["key"] = encryption.encrypt(key, this.enckey, init_iv);
			nameValueCollection["hwid"] = encryption.encrypt(hwid, this.enckey, init_iv);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = init_iv;
			NameValueCollection values_to_upload = nameValueCollection;
			string response = ShitAuth.req(values_to_upload);
			response = encryption.decrypt(response, this.enckey, init_iv);
			ShitAuth.response_structure json = this.response_decoder.string_to_generic<ShitAuth.response_structure>(response);
			this.load_response_struct(json);
			this.CheckBypass();
			bool success = json.success;
			if (success)
			{
				this.load_user_data(json.info);
			}
		}

		// Token: 0x06000044 RID: 68 RVA: 0x00005730 File Offset: 0x00003930
		public void check()
		{
			this.Checkinit();
			string init_iv = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("check"));
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = init_iv;
			NameValueCollection values_to_upload = nameValueCollection;
			string response = ShitAuth.req(values_to_upload);
			response = encryption.decrypt(response, this.enckey, init_iv);
			ShitAuth.response_structure json = this.response_decoder.string_to_generic<ShitAuth.response_structure>(response);
			this.load_response_struct(json);
			this.CheckBypass();
		}

		// Token: 0x06000045 RID: 69 RVA: 0x00005818 File Offset: 0x00003A18
		public void setvar(string var, string data)
		{
			this.Checkinit();
			string init_iv = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("setvar"));
			nameValueCollection["var"] = encryption.encrypt(var, this.enckey, init_iv);
			nameValueCollection["data"] = encryption.encrypt(data, this.enckey, init_iv);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = init_iv;
			NameValueCollection values_to_upload = nameValueCollection;
			string response = ShitAuth.req(values_to_upload);
			response = encryption.decrypt(response, this.enckey, init_iv);
			ShitAuth.response_structure json = this.response_decoder.string_to_generic<ShitAuth.response_structure>(response);
			this.load_response_struct(json);
			this.CheckBypass();
		}

		// Token: 0x06000046 RID: 70 RVA: 0x00005934 File Offset: 0x00003B34
		public string getvar(string var)
		{
			this.Checkinit();
			string init_iv = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("getvar"));
			nameValueCollection["var"] = encryption.encrypt(var, this.enckey, init_iv);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = init_iv;
			NameValueCollection values_to_upload = nameValueCollection;
			string response = ShitAuth.req(values_to_upload);
			response = encryption.decrypt(response, this.enckey, init_iv);
			ShitAuth.response_structure json = this.response_decoder.string_to_generic<ShitAuth.response_structure>(response);
			this.load_response_struct(json);
			this.CheckBypass();
			bool success = json.success;
			string result;
			if (success)
			{
				result = json.response;
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06000047 RID: 71 RVA: 0x00005A54 File Offset: 0x00003C54
		public void ban()
		{
			this.Checkinit();
			string init_iv = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("ban"));
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = init_iv;
			NameValueCollection values_to_upload = nameValueCollection;
			string response = ShitAuth.req(values_to_upload);
			response = encryption.decrypt(response, this.enckey, init_iv);
			ShitAuth.response_structure json = this.response_decoder.string_to_generic<ShitAuth.response_structure>(response);
			this.load_response_struct(json);
			this.CheckBypass();
		}

		// Token: 0x06000048 RID: 72 RVA: 0x00005B3C File Offset: 0x00003D3C
		public string var(string varid)
		{
			this.Checkinit();
			string hwid = Functions.GetHWID();
			string init_iv = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("var"));
			nameValueCollection["varid"] = encryption.encrypt(varid, this.enckey, init_iv);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = init_iv;
			NameValueCollection values_to_upload = nameValueCollection;
			string response = ShitAuth.req(values_to_upload);
			response = encryption.decrypt(response, this.enckey, init_iv);
			ShitAuth.response_structure json = this.response_decoder.string_to_generic<ShitAuth.response_structure>(response);
			this.load_response_struct(json);
			this.CheckBypass();
			bool success = json.success;
			string result;
			if (success)
			{
				result = json.message;
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06000049 RID: 73 RVA: 0x00005C64 File Offset: 0x00003E64
		public bool checkblack()
		{
			this.Checkinit();
			string hwid = Functions.GetHWID();
			string init_iv = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("checkblacklist"));
			nameValueCollection["hwid"] = encryption.encrypt(hwid, this.enckey, init_iv);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = init_iv;
			NameValueCollection values_to_upload = nameValueCollection;
			string response = ShitAuth.req(values_to_upload);
			response = encryption.decrypt(response, this.enckey, init_iv);
			ShitAuth.response_structure json = this.response_decoder.string_to_generic<ShitAuth.response_structure>(response);
			this.load_response_struct(json);
			this.CheckBypass();
			return json.success;
		}

		// Token: 0x0600004A RID: 74 RVA: 0x00005D88 File Offset: 0x00003F88
		public string webhook(string webid, string param, string body = "", string conttype = "")
		{
			this.Checkinit();
			string init_iv = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("webhook"));
			nameValueCollection["webid"] = encryption.encrypt(webid, this.enckey, init_iv);
			nameValueCollection["params"] = encryption.encrypt(param, this.enckey, init_iv);
			nameValueCollection["body"] = encryption.encrypt(body, this.enckey, init_iv);
			nameValueCollection["conttype"] = encryption.encrypt(conttype, this.enckey, init_iv);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = init_iv;
			NameValueCollection values_to_upload = nameValueCollection;
			string response = ShitAuth.req(values_to_upload);
			response = encryption.decrypt(response, this.enckey, init_iv);
			ShitAuth.response_structure json = this.response_decoder.string_to_generic<ShitAuth.response_structure>(response);
			this.load_response_struct(json);
			this.CheckBypass();
			bool success = json.success;
			string result;
			if (success)
			{
				result = json.response;
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x0600004B RID: 75 RVA: 0x00005EF4 File Offset: 0x000040F4
		public byte[] download(string fileid)
		{
			this.Checkinit();
			string init_iv = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("file"));
			nameValueCollection["fileid"] = encryption.encrypt(fileid, this.enckey, init_iv);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = init_iv;
			NameValueCollection values_to_upload = nameValueCollection;
			string response = ShitAuth.req(values_to_upload);
			response = encryption.decrypt(response, this.enckey, init_iv);
			ShitAuth.response_structure json = this.response_decoder.string_to_generic<ShitAuth.response_structure>(response);
			this.load_response_struct(json);
			this.CheckBypass();
			bool success = json.success;
			byte[] result;
			if (success)
			{
				result = encryption.str_to_byte_arr(json.contents);
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x0600004C RID: 76 RVA: 0x00006018 File Offset: 0x00004218
		public void log(string message)
		{
			this.Checkinit();
			string init_iv = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("log"));
			nameValueCollection["pcuser"] = encryption.encrypt(Environment.UserName, this.enckey, init_iv);
			nameValueCollection["message"] = encryption.encrypt(message, this.enckey, init_iv);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = init_iv;
			NameValueCollection values_to_upload = nameValueCollection;
			ShitAuth.req(values_to_upload);
		}

		// Token: 0x0600004D RID: 77 RVA: 0x0000610C File Offset: 0x0000430C
		public static string checksum(string filename)
		{
			string result;
			using (MD5 md = MD5.Create())
			{
				using (FileStream fileStream = File.OpenRead(filename))
				{
					byte[] value = md.ComputeHash(fileStream);
					result = BitConverter.ToString(value).Replace("-", "").ToLowerInvariant();
				}
			}
			return result;
		}

		// Token: 0x0600004E RID: 78 RVA: 0x0000618C File Offset: 0x0000438C
		public static void error(string message)
		{
			new GigaChadMessageBox(message, "Cheato Spoofer", "OK", 466, 150, 14f, ScrollBars.None, true).ShowDialog();
			Process.GetCurrentProcess().Kill();
		}

		// Token: 0x0600004F RID: 79 RVA: 0x000061C4 File Offset: 0x000043C4
		private static string req(NameValueCollection post_data)
		{
			string result;
			try
			{
				using (WebClient client = new WebClient
				{
					Proxy = null,
					Headers = 
					{
						"User-Agent: CheatoAuth"
					}
				})
				{
					byte[] raw_response = client.UploadValues("https://chea.to/auth/api/1.3.3.7/", post_data);
					result = Encoding.Default.GetString(raw_response);
				}
			}
			catch (WebException webex)
			{
				HttpWebResponse response = (HttpWebResponse)webex.Response;
				HttpStatusCode statusCode = response.StatusCode;
				HttpStatusCode httpStatusCode = statusCode;
				if (httpStatusCode != (HttpStatusCode)429)
				{
					ShitAuth.error("Auth is down, time to hop on discord.chea.to and complain like a fucking Karen! \ud83d\udc80");
					Environment.Exit(0);
					result = "";
				}
				else
				{
					ShitAuth.error("Slow down mate... You're sending way too many requests, we don't pay nothing for hosting! \ud83d\udc80");
					Environment.Exit(0);
					result = "";
				}
			}
			return result;
		}

		// Token: 0x06000050 RID: 80 RVA: 0x00006294 File Offset: 0x00004494
		private void load_app_data(ShitAuth.app_data_structure data)
		{
			this.app_data.numUsers = data.numUsers;
			this.app_data.numOnlineUsers = data.numOnlineUsers;
			this.app_data.numKeys = data.numKeys;
			this.app_data.version = data.version;
			this.app_data.customerPanelLink = data.customerPanelLink;
		}

		// Token: 0x06000051 RID: 81 RVA: 0x000062FC File Offset: 0x000044FC
		private void load_user_data(ShitAuth.user_data_structure data)
		{
			this.user_data.username = data.username;
			this.user_data.ip = data.ip;
			this.user_data.hwid = data.hwid;
			this.user_data.createdate = data.createdate;
			this.user_data.lastlogin = data.lastlogin;
			this.user_data.subscriptions = data.subscriptions;
		}

		// Token: 0x06000052 RID: 82 RVA: 0x00006378 File Offset: 0x00004578
		public string expirydaysleft()
		{
			this.Checkinit();
			DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Local);
			dtDateTime = dtDateTime.AddSeconds((double)long.Parse(this.user_data.subscriptions[0].expiry)).ToLocalTime();
			TimeSpan difference = dtDateTime - DateTime.Now;
			string s = null;
			bool flag = difference.Days != 1;
			if (flag)
			{
				s = "s";
			}
			string s2 = null;
			bool flag2 = difference.Hours != 1;
			if (flag2)
			{
				s2 = "s";
			}
			return Convert.ToString(string.Concat(new string[]
			{
				difference.Days.ToString(),
				" day",
				s,
				", ",
				difference.Hours.ToString(),
				" hour",
				s2
			}));
		}

		// Token: 0x06000053 RID: 83 RVA: 0x0000646F File Offset: 0x0000466F
		private void load_response_struct(ShitAuth.response_structure data)
		{
			this.response.success = data.success;
			this.response.message = data.message;
		}

		// Token: 0x0400001C RID: 28
		public string name;

		// Token: 0x0400001D RID: 29
		public string ownerid;

		// Token: 0x0400001E RID: 30
		public string secret;

		// Token: 0x0400001F RID: 31
		public string version;

		// Token: 0x04000020 RID: 32
		private string sessionid;

		// Token: 0x04000021 RID: 33
		private string enckey;

		// Token: 0x04000022 RID: 34
		private bool initialised;

		// Token: 0x04000023 RID: 35
		public ShitAuth.app_data_class app_data = new ShitAuth.app_data_class();

		// Token: 0x04000024 RID: 36
		public ShitAuth.user_data_class user_data = new ShitAuth.user_data_class();

		// Token: 0x04000025 RID: 37
		public ShitAuth.response_class response = new ShitAuth.response_class();

		// Token: 0x04000026 RID: 38
		private json_wrapper response_decoder = new json_wrapper(new ShitAuth.response_structure());

		// Token: 0x02000030 RID: 48
		[DataContract]
		private class response_structure
		{
			// Token: 0x1700001F RID: 31
			// (get) Token: 0x060001A5 RID: 421 RVA: 0x00011411 File Offset: 0x0000F611
			// (set) Token: 0x060001A6 RID: 422 RVA: 0x00011419 File Offset: 0x0000F619
			[DataMember]
			public bool success { get; set; }

			// Token: 0x17000020 RID: 32
			// (get) Token: 0x060001A7 RID: 423 RVA: 0x00011422 File Offset: 0x0000F622
			// (set) Token: 0x060001A8 RID: 424 RVA: 0x0001142A File Offset: 0x0000F62A
			[DataMember]
			public string sessionid { get; set; }

			// Token: 0x17000021 RID: 33
			// (get) Token: 0x060001A9 RID: 425 RVA: 0x00011433 File Offset: 0x0000F633
			// (set) Token: 0x060001AA RID: 426 RVA: 0x0001143B File Offset: 0x0000F63B
			[DataMember]
			public string contents { get; set; }

			// Token: 0x17000022 RID: 34
			// (get) Token: 0x060001AB RID: 427 RVA: 0x00011444 File Offset: 0x0000F644
			// (set) Token: 0x060001AC RID: 428 RVA: 0x0001144C File Offset: 0x0000F64C
			[DataMember]
			public string response { get; set; }

			// Token: 0x17000023 RID: 35
			// (get) Token: 0x060001AD RID: 429 RVA: 0x00011455 File Offset: 0x0000F655
			// (set) Token: 0x060001AE RID: 430 RVA: 0x0001145D File Offset: 0x0000F65D
			[DataMember]
			public string message { get; set; }

			// Token: 0x17000024 RID: 36
			// (get) Token: 0x060001AF RID: 431 RVA: 0x00011466 File Offset: 0x0000F666
			// (set) Token: 0x060001B0 RID: 432 RVA: 0x0001146E File Offset: 0x0000F66E
			[DataMember]
			public string download { get; set; }

			// Token: 0x17000025 RID: 37
			// (get) Token: 0x060001B1 RID: 433 RVA: 0x00011477 File Offset: 0x0000F677
			// (set) Token: 0x060001B2 RID: 434 RVA: 0x0001147F File Offset: 0x0000F67F
			[DataMember(IsRequired = false, EmitDefaultValue = false)]
			public ShitAuth.user_data_structure info { get; set; }

			// Token: 0x17000026 RID: 38
			// (get) Token: 0x060001B3 RID: 435 RVA: 0x00011488 File Offset: 0x0000F688
			// (set) Token: 0x060001B4 RID: 436 RVA: 0x00011490 File Offset: 0x0000F690
			[DataMember(IsRequired = false, EmitDefaultValue = false)]
			public ShitAuth.app_data_structure appinfo { get; set; }

			// Token: 0x17000027 RID: 39
			// (get) Token: 0x060001B5 RID: 437 RVA: 0x00011499 File Offset: 0x0000F699
			// (set) Token: 0x060001B6 RID: 438 RVA: 0x000114A1 File Offset: 0x0000F6A1
			[DataMember]
			public List<ShitAuth.msg> messages { get; set; }
		}

		// Token: 0x02000031 RID: 49
		public class msg
		{
			// Token: 0x17000028 RID: 40
			// (get) Token: 0x060001B8 RID: 440 RVA: 0x000114B3 File Offset: 0x0000F6B3
			// (set) Token: 0x060001B9 RID: 441 RVA: 0x000114BB File Offset: 0x0000F6BB
			public string message { get; set; }

			// Token: 0x17000029 RID: 41
			// (get) Token: 0x060001BA RID: 442 RVA: 0x000114C4 File Offset: 0x0000F6C4
			// (set) Token: 0x060001BB RID: 443 RVA: 0x000114CC File Offset: 0x0000F6CC
			public string author { get; set; }

			// Token: 0x1700002A RID: 42
			// (get) Token: 0x060001BC RID: 444 RVA: 0x000114D5 File Offset: 0x0000F6D5
			// (set) Token: 0x060001BD RID: 445 RVA: 0x000114DD File Offset: 0x0000F6DD
			public string timestamp { get; set; }
		}

		// Token: 0x02000032 RID: 50
		[DataContract]
		private class user_data_structure
		{
			// Token: 0x1700002B RID: 43
			// (get) Token: 0x060001BF RID: 447 RVA: 0x000114EF File Offset: 0x0000F6EF
			// (set) Token: 0x060001C0 RID: 448 RVA: 0x000114F7 File Offset: 0x0000F6F7
			[DataMember]
			public string username { get; set; }

			// Token: 0x1700002C RID: 44
			// (get) Token: 0x060001C1 RID: 449 RVA: 0x00011500 File Offset: 0x0000F700
			// (set) Token: 0x060001C2 RID: 450 RVA: 0x00011508 File Offset: 0x0000F708
			[DataMember]
			public string ip { get; set; }

			// Token: 0x1700002D RID: 45
			// (get) Token: 0x060001C3 RID: 451 RVA: 0x00011511 File Offset: 0x0000F711
			// (set) Token: 0x060001C4 RID: 452 RVA: 0x00011519 File Offset: 0x0000F719
			[DataMember]
			public string hwid { get; set; }

			// Token: 0x1700002E RID: 46
			// (get) Token: 0x060001C5 RID: 453 RVA: 0x00011522 File Offset: 0x0000F722
			// (set) Token: 0x060001C6 RID: 454 RVA: 0x0001152A File Offset: 0x0000F72A
			[DataMember]
			public string createdate { get; set; }

			// Token: 0x1700002F RID: 47
			// (get) Token: 0x060001C7 RID: 455 RVA: 0x00011533 File Offset: 0x0000F733
			// (set) Token: 0x060001C8 RID: 456 RVA: 0x0001153B File Offset: 0x0000F73B
			[DataMember]
			public string lastlogin { get; set; }

			// Token: 0x17000030 RID: 48
			// (get) Token: 0x060001C9 RID: 457 RVA: 0x00011544 File Offset: 0x0000F744
			// (set) Token: 0x060001CA RID: 458 RVA: 0x0001154C File Offset: 0x0000F74C
			[DataMember]
			public List<ShitAuth.Data> subscriptions { get; set; }
		}

		// Token: 0x02000033 RID: 51
		[DataContract]
		private class app_data_structure
		{
			// Token: 0x17000031 RID: 49
			// (get) Token: 0x060001CC RID: 460 RVA: 0x0001155E File Offset: 0x0000F75E
			// (set) Token: 0x060001CD RID: 461 RVA: 0x00011566 File Offset: 0x0000F766
			[DataMember]
			public string numUsers { get; set; }

			// Token: 0x17000032 RID: 50
			// (get) Token: 0x060001CE RID: 462 RVA: 0x0001156F File Offset: 0x0000F76F
			// (set) Token: 0x060001CF RID: 463 RVA: 0x00011577 File Offset: 0x0000F777
			[DataMember]
			public string numOnlineUsers { get; set; }

			// Token: 0x17000033 RID: 51
			// (get) Token: 0x060001D0 RID: 464 RVA: 0x00011580 File Offset: 0x0000F780
			// (set) Token: 0x060001D1 RID: 465 RVA: 0x00011588 File Offset: 0x0000F788
			[DataMember]
			public string numKeys { get; set; }

			// Token: 0x17000034 RID: 52
			// (get) Token: 0x060001D2 RID: 466 RVA: 0x00011591 File Offset: 0x0000F791
			// (set) Token: 0x060001D3 RID: 467 RVA: 0x00011599 File Offset: 0x0000F799
			[DataMember]
			public string version { get; set; }

			// Token: 0x17000035 RID: 53
			// (get) Token: 0x060001D4 RID: 468 RVA: 0x000115A2 File Offset: 0x0000F7A2
			// (set) Token: 0x060001D5 RID: 469 RVA: 0x000115AA File Offset: 0x0000F7AA
			[DataMember]
			public string customerPanelLink { get; set; }

			// Token: 0x17000036 RID: 54
			// (get) Token: 0x060001D6 RID: 470 RVA: 0x000115B3 File Offset: 0x0000F7B3
			// (set) Token: 0x060001D7 RID: 471 RVA: 0x000115BB File Offset: 0x0000F7BB
			[DataMember]
			public string downloadLink { get; set; }
		}

		// Token: 0x02000034 RID: 52
		public class app_data_class
		{
			// Token: 0x17000037 RID: 55
			// (get) Token: 0x060001D9 RID: 473 RVA: 0x000115CD File Offset: 0x0000F7CD
			// (set) Token: 0x060001DA RID: 474 RVA: 0x000115D5 File Offset: 0x0000F7D5
			public string numUsers { get; set; }

			// Token: 0x17000038 RID: 56
			// (get) Token: 0x060001DB RID: 475 RVA: 0x000115DE File Offset: 0x0000F7DE
			// (set) Token: 0x060001DC RID: 476 RVA: 0x000115E6 File Offset: 0x0000F7E6
			public string numOnlineUsers { get; set; }

			// Token: 0x17000039 RID: 57
			// (get) Token: 0x060001DD RID: 477 RVA: 0x000115EF File Offset: 0x0000F7EF
			// (set) Token: 0x060001DE RID: 478 RVA: 0x000115F7 File Offset: 0x0000F7F7
			public string numKeys { get; set; }

			// Token: 0x1700003A RID: 58
			// (get) Token: 0x060001DF RID: 479 RVA: 0x00011600 File Offset: 0x0000F800
			// (set) Token: 0x060001E0 RID: 480 RVA: 0x00011608 File Offset: 0x0000F808
			public string version { get; set; }

			// Token: 0x1700003B RID: 59
			// (get) Token: 0x060001E1 RID: 481 RVA: 0x00011611 File Offset: 0x0000F811
			// (set) Token: 0x060001E2 RID: 482 RVA: 0x00011619 File Offset: 0x0000F819
			public string customerPanelLink { get; set; }

			// Token: 0x1700003C RID: 60
			// (get) Token: 0x060001E3 RID: 483 RVA: 0x00011622 File Offset: 0x0000F822
			// (set) Token: 0x060001E4 RID: 484 RVA: 0x0001162A File Offset: 0x0000F82A
			public string downloadLink { get; set; }
		}

		// Token: 0x02000035 RID: 53
		public class user_data_class
		{
			// Token: 0x1700003D RID: 61
			// (get) Token: 0x060001E6 RID: 486 RVA: 0x0001163C File Offset: 0x0000F83C
			// (set) Token: 0x060001E7 RID: 487 RVA: 0x00011644 File Offset: 0x0000F844
			public string username { get; set; }

			// Token: 0x1700003E RID: 62
			// (get) Token: 0x060001E8 RID: 488 RVA: 0x0001164D File Offset: 0x0000F84D
			// (set) Token: 0x060001E9 RID: 489 RVA: 0x00011655 File Offset: 0x0000F855
			public string ip { get; set; }

			// Token: 0x1700003F RID: 63
			// (get) Token: 0x060001EA RID: 490 RVA: 0x0001165E File Offset: 0x0000F85E
			// (set) Token: 0x060001EB RID: 491 RVA: 0x00011666 File Offset: 0x0000F866
			public string hwid { get; set; }

			// Token: 0x17000040 RID: 64
			// (get) Token: 0x060001EC RID: 492 RVA: 0x0001166F File Offset: 0x0000F86F
			// (set) Token: 0x060001ED RID: 493 RVA: 0x00011677 File Offset: 0x0000F877
			public string createdate { get; set; }

			// Token: 0x17000041 RID: 65
			// (get) Token: 0x060001EE RID: 494 RVA: 0x00011680 File Offset: 0x0000F880
			// (set) Token: 0x060001EF RID: 495 RVA: 0x00011688 File Offset: 0x0000F888
			public string lastlogin { get; set; }

			// Token: 0x17000042 RID: 66
			// (get) Token: 0x060001F0 RID: 496 RVA: 0x00011691 File Offset: 0x0000F891
			// (set) Token: 0x060001F1 RID: 497 RVA: 0x00011699 File Offset: 0x0000F899
			public List<ShitAuth.Data> subscriptions { get; set; }
		}

		// Token: 0x02000036 RID: 54
		public class Data
		{
			// Token: 0x17000043 RID: 67
			// (get) Token: 0x060001F3 RID: 499 RVA: 0x000116AB File Offset: 0x0000F8AB
			// (set) Token: 0x060001F4 RID: 500 RVA: 0x000116B3 File Offset: 0x0000F8B3
			public string subscription { get; set; }

			// Token: 0x17000044 RID: 68
			// (get) Token: 0x060001F5 RID: 501 RVA: 0x000116BC File Offset: 0x0000F8BC
			// (set) Token: 0x060001F6 RID: 502 RVA: 0x000116C4 File Offset: 0x0000F8C4
			public string expiry { get; set; }

			// Token: 0x17000045 RID: 69
			// (get) Token: 0x060001F7 RID: 503 RVA: 0x000116CD File Offset: 0x0000F8CD
			// (set) Token: 0x060001F8 RID: 504 RVA: 0x000116D5 File Offset: 0x0000F8D5
			public string timeleft { get; set; }
		}

		// Token: 0x02000037 RID: 55
		public class response_class
		{
			// Token: 0x17000046 RID: 70
			// (get) Token: 0x060001FA RID: 506 RVA: 0x000116E7 File Offset: 0x0000F8E7
			// (set) Token: 0x060001FB RID: 507 RVA: 0x000116EF File Offset: 0x0000F8EF
			public bool success { get; set; }

			// Token: 0x17000047 RID: 71
			// (get) Token: 0x060001FC RID: 508 RVA: 0x000116F8 File Offset: 0x0000F8F8
			// (set) Token: 0x060001FD RID: 509 RVA: 0x00011700 File Offset: 0x0000F900
			public string message { get; set; }
		}
	}
}

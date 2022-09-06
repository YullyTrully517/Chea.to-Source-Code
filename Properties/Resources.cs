using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Resources;
using System.Runtime.CompilerServices;

namespace CheatoClient.Properties
{
	// Token: 0x0200002C RID: 44
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
	[DebuggerNonUserCode]
	[CompilerGenerated]
	internal class Resources
	{
		// Token: 0x06000198 RID: 408 RVA: 0x000111FF File Offset: 0x0000F3FF
		internal Resources()
		{
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x06000199 RID: 409 RVA: 0x0001120C File Offset: 0x0000F40C
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				bool flag = Resources.resourceMan == null;
				if (flag)
				{
					ResourceManager temp = new ResourceManager("CheatoClient.Properties.Resources", typeof(Resources).Assembly);
					Resources.resourceMan = temp;
				}
				return Resources.resourceMan;
			}
		}

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x0600019A RID: 410 RVA: 0x00011254 File Offset: 0x0000F454
		// (set) Token: 0x0600019B RID: 411 RVA: 0x0001126B File Offset: 0x0000F46B
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
		{
			get
			{
				return Resources.resourceCulture;
			}
			set
			{
				Resources.resourceCulture = value;
			}
		}

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x0600019C RID: 412 RVA: 0x00011274 File Offset: 0x0000F474
		internal static UnmanagedMemoryStream _10x
		{
			get
			{
				return Resources.ResourceManager.GetStream("_10x", Resources.resourceCulture);
			}
		}

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x0600019D RID: 413 RVA: 0x0001129C File Offset: 0x0000F49C
		internal static UnmanagedMemoryStream _11
		{
			get
			{
				return Resources.ResourceManager.GetStream("_11", Resources.resourceCulture);
			}
		}

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x0600019E RID: 414 RVA: 0x000112C4 File Offset: 0x0000F4C4
		internal static Bitmap chadspoofer
		{
			get
			{
				object obj = Resources.ResourceManager.GetObject("chadspoofer", Resources.resourceCulture);
				return (Bitmap)obj;
			}
		}

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x0600019F RID: 415 RVA: 0x000112F4 File Offset: 0x0000F4F4
		internal static Bitmap chadspoofer1
		{
			get
			{
				object obj = Resources.ResourceManager.GetObject("chadspoofer1", Resources.resourceCulture);
				return (Bitmap)obj;
			}
		}

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x060001A0 RID: 416 RVA: 0x00011324 File Offset: 0x0000F524
		internal static Bitmap chadspoofer2
		{
			get
			{
				object obj = Resources.ResourceManager.GetObject("chadspoofer2", Resources.resourceCulture);
				return (Bitmap)obj;
			}
		}

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x060001A1 RID: 417 RVA: 0x00011354 File Offset: 0x0000F554
		internal static Bitmap direct_hit_emoji_by_twitter
		{
			get
			{
				object obj = Resources.ResourceManager.GetObject("direct-hit-emoji-by-twitter", Resources.resourceCulture);
				return (Bitmap)obj;
			}
		}

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x060001A2 RID: 418 RVA: 0x00011384 File Offset: 0x0000F584
		internal static Bitmap FMujjqQVQAE5A6e
		{
			get
			{
				object obj = Resources.ResourceManager.GetObject("FMujjqQVQAE5A6e", Resources.resourceCulture);
				return (Bitmap)obj;
			}
		}

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x060001A3 RID: 419 RVA: 0x000113B4 File Offset: 0x0000F5B4
		internal static Bitmap maxresdefault
		{
			get
			{
				object obj = Resources.ResourceManager.GetObject("maxresdefault", Resources.resourceCulture);
				return (Bitmap)obj;
			}
		}

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x060001A4 RID: 420 RVA: 0x000113E4 File Offset: 0x0000F5E4
		internal static Bitmap windows_loading
		{
			get
			{
				object obj = Resources.ResourceManager.GetObject("windows-loading", Resources.resourceCulture);
				return (Bitmap)obj;
			}
		}

		// Token: 0x040002F9 RID: 761
		private static ResourceManager resourceMan;

		// Token: 0x040002FA RID: 762
		private static CultureInfo resourceCulture;
	}
}

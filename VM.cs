using System;
using System.Runtime.InteropServices;

namespace CheatoClient
{
	// Token: 0x02000027 RID: 39
	internal class VM
	{
		// Token: 0x06000171 RID: 369
		[DllImport("kernel32.dll", EntryPoint = "VirtualProtect")]
		internal unsafe static extern byte VM936799001(byte* a, int b, uint c, ref uint d);
	}
}

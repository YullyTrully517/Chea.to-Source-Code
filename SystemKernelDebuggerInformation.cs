using System;
using System.Runtime.InteropServices;

namespace CheatoClient
{
	// Token: 0x02000017 RID: 23
	public struct SystemKernelDebuggerInformation
	{
		// Token: 0x0400027D RID: 637
		[MarshalAs(UnmanagedType.U1)]
		public bool KernelDebuggerEnabled;

		// Token: 0x0400027E RID: 638
		[MarshalAs(UnmanagedType.U1)]
		public bool KernelDebuggerNotPresent;
	}
}

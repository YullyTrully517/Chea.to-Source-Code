using System;

namespace CheatoClient
{
	// Token: 0x02000018 RID: 24
	[Flags]
	public enum ThreadAccess
	{
		// Token: 0x04000280 RID: 640
		Terminate = 1,
		// Token: 0x04000281 RID: 641
		SuspendResume = 2,
		// Token: 0x04000282 RID: 642
		GetContext = 8,
		// Token: 0x04000283 RID: 643
		SetContext = 16,
		// Token: 0x04000284 RID: 644
		SetInformation = 32,
		// Token: 0x04000285 RID: 645
		QueryInformation = 64,
		// Token: 0x04000286 RID: 646
		SetThreadToken = 128,
		// Token: 0x04000287 RID: 647
		Impersonate = 256,
		// Token: 0x04000288 RID: 648
		DirectImpersonation = 512
	}
}

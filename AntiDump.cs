using System;
using System.Reflection;
using System.Runtime.InteropServices;

namespace CheatoClient
{
	// Token: 0x0200001A RID: 26
	public class AntiDump
	{
		// Token: 0x060000C2 RID: 194 RVA: 0x00009120 File Offset: 0x00007320
		public unsafe static void Parse(Type type)
		{
			Module module = type.Module;
			byte* ptr = (byte*)((void*)Marshal.GetHINSTANCE(module));
			byte* ptr2 = ptr + 60;
			ptr2 = ptr + *(uint*)ptr2;
			ptr2 += 6;
			ushort num = *(ushort*)ptr2;
			ptr2 += 14;
			ushort num2 = *(ushort*)ptr2;
			ptr2 = ptr2 + 4 + num2;
			byte* ptr3 = stackalloc byte[(UIntPtr)((uint)((UIntPtr)11UL))];
			bool flag = module.FullyQualifiedName[0] != '<';
			bool flag16 = flag;
			if (flag16)
			{
				byte* ptr4 = ptr + *(uint*)(ptr2 - 16);
				bool flag2 = *(uint*)(ptr2 - 120) > 0U;
				uint num3 = 0U;
				bool flag17 = flag2;
				if (flag17)
				{
					byte* ptr5 = ptr + *(uint*)(ptr2 - 120);
					byte* ptr6 = ptr + *(uint*)ptr5;
					byte* ptr7 = ptr + *(uint*)(ptr5 + 12);
					byte* ptr8 = ptr + *(uint*)ptr6 + 2;
					VM.VM936799001(ptr7, 11, 64U, ref num3);
					*(int*)ptr3 = 1818522734;
					*(int*)(ptr3 + 4) = 1818504812;
					*(short*)(ptr3 + (int)((IntPtr)4) * 2) = 108;
					ptr3[10] = 0;
					for (int i = 0; i < 11; i++)
					{
						ptr7[i] = ptr3[i];
					}
					VM.VM936799001(ptr8, 11, 64U, ref num3);
					*(int*)ptr3 = 1866691662;
					*(int*)(ptr3 + 4) = 1852404846;
					*(short*)(ptr3 + (int)((IntPtr)4) * 2) = 25973;
					ptr3[10] = 0;
					for (int j = 0; j < 11; j++)
					{
						ptr8[j] = ptr3[j];
					}
				}
				for (int k = 0; k < (int)num; k++)
				{
					VM.VM936799001(ptr2, 8, 64U, ref num3);
					Marshal.Copy(new byte[8], 0, (IntPtr)((void*)ptr2), 8);
					ptr2 += 40;
				}
				VM.VM936799001(ptr4, 72, 64U, ref num3);
				byte* ptr9 = ptr + *(uint*)(ptr4 + 8);
				*(int*)ptr4 = 0;
				*(int*)(ptr4 + 4) = 0;
				*(int*)(ptr4 + (int)((IntPtr)2) * 4) = 0;
				*(int*)(ptr4 + (int)((IntPtr)3) * 4) = 0;
				VM.VM936799001(ptr9, 4, 64U, ref num3);
				*(int*)ptr9 = 0;
				ptr9 += 12;
				ptr9 += *(uint*)ptr9;
				ptr9 += 4L;
				ptr9 += 2;
				ushort num4 = (ushort)(*ptr9);
				ptr9 += 2;
				for (int l = 0; l < (int)num4; l++)
				{
					VM.VM936799001(ptr9, 8, 64U, ref num3);
					ptr9 += 4;
					ptr9 += 4;
					for (int m = 0; m < 8; m++)
					{
						VM.VM936799001(ptr9, 4, 64U, ref num3);
						*ptr9 = 0;
						ptr9++;
						bool flag3 = *ptr9 == 0;
						bool flag18 = flag3;
						if (flag18)
						{
							ptr9 += 3;
							break;
						}
						*ptr9 = 0;
						ptr9++;
						bool flag4 = *ptr9 == 0;
						bool flag19 = flag4;
						if (flag19)
						{
							ptr9 += 2;
							break;
						}
						*ptr9 = 0;
						ptr9++;
						bool flag5 = *ptr9 == 0;
						bool flag20 = flag5;
						if (flag20)
						{
							ptr9++;
							break;
						}
						*ptr9 = 0;
						ptr9++;
					}
				}
			}
			else
			{
				uint num5 = *(uint*)(ptr2 - 16);
				uint num6 = *(uint*)(ptr2 - 120);
				uint[] array = new uint[(int)num];
				uint[] array2 = new uint[(int)num];
				uint[] array3 = new uint[(int)num];
				uint num7 = 0U;
				for (int n = 0; n < (int)num; n++)
				{
					VM.VM936799001(ptr2, 8, 64U, ref num7);
					Marshal.Copy(new byte[8], 0, (IntPtr)((void*)ptr2), 8);
					array[n] = *(uint*)(ptr2 + 12);
					array2[n] = *(uint*)(ptr2 + 8);
					array3[n] = *(uint*)(ptr2 + 20);
					ptr2 += 40;
				}
				bool flag6 = num6 > 0U;
				bool flag21 = flag6;
				if (flag21)
				{
					for (int num8 = 0; num8 < (int)num; num8++)
					{
						bool flag7 = array[num8] <= num6 && num6 < array[num8] + array2[num8];
						bool flag22 = flag7;
						if (flag22)
						{
							num6 = num6 - array[num8] + array3[num8];
							break;
						}
					}
					byte* ptr10 = ptr + num6;
					uint num9 = *(uint*)ptr10;
					for (int num10 = 0; num10 < (int)num; num10++)
					{
						bool flag8 = array[num10] <= num9 && num9 < array[num10] + array2[num10];
						bool flag23 = flag8;
						if (flag23)
						{
							num9 = num9 - array[num10] + array3[num10];
							break;
						}
					}
					byte* ptr11 = ptr + num9;
					uint num11 = *(uint*)(ptr10 + 12);
					for (int num12 = 0; num12 < (int)num; num12++)
					{
						bool flag9 = array[num12] <= num11 && num11 < array[num12] + array2[num12];
						bool flag24 = flag9;
						if (flag24)
						{
							num11 = num11 - array[num12] + array3[num12];
							break;
						}
					}
					uint num13 = *(uint*)ptr11 + 2U;
					for (int num14 = 0; num14 < (int)num; num14++)
					{
						bool flag10 = array[num14] <= num13 && num13 < array[num14] + array2[num14];
						bool flag25 = flag10;
						if (flag25)
						{
							num13 = num13 - array[num14] + array3[num14];
							break;
						}
					}
					VM.VM936799001(ptr + num11, 11, 64U, ref num7);
					*(int*)ptr3 = 1818522734;
					*(int*)(ptr3 + 4) = 1818504812;
					*(short*)(ptr3 + (int)((IntPtr)4) * 2) = 108;
					ptr3[10] = 0;
					for (int num15 = 0; num15 < 11; num15++)
					{
						(ptr + num11)[num15] = ptr3[num15];
					}
					VM.VM936799001(ptr + num13, 11, 64U, ref num7);
					*(int*)ptr3 = 1866691662;
					*(int*)(ptr3 + 4) = 1852404846;
					*(short*)(ptr3 + (int)((IntPtr)4) * 2) = 25973;
					ptr3[10] = 0;
					for (int num16 = 0; num16 < 11; num16++)
					{
						(ptr + num13)[num16] = ptr3[num16];
					}
				}
				for (int num17 = 0; num17 < (int)num; num17++)
				{
					bool flag11 = array[num17] <= num5 && num5 < array[num17] + array2[num17];
					bool flag26 = flag11;
					if (flag26)
					{
						num5 = num5 - array[num17] + array3[num17];
						break;
					}
				}
				byte* ptr12 = ptr + num5;
				VM.VM936799001(ptr12, 72, 64U, ref num7);
				uint num18 = *(uint*)(ptr12 + 8);
				for (int num19 = 0; num19 < (int)num; num19++)
				{
					bool flag12 = array[num19] <= num18 && num18 < array[num19] + array2[num19];
					bool flag27 = flag12;
					if (flag27)
					{
						num18 = num18 - array[num19] + array3[num19];
						break;
					}
				}
				*(int*)ptr12 = 0;
				*(int*)(ptr12 + 4) = 0;
				*(int*)(ptr12 + (int)((IntPtr)2) * 4) = 0;
				*(int*)(ptr12 + (int)((IntPtr)3) * 4) = 0;
				byte* ptr13 = ptr + num18;
				VM.VM936799001(ptr13, 4, 64U, ref num7);
				*(int*)ptr13 = 0;
				ptr13 += 12;
				ptr13 += *(uint*)ptr13;
				ptr13 += 4L;
				ptr13 += 2;
				ushort num20 = (ushort)(*ptr13);
				ptr13 += 2;
				for (int num21 = 0; num21 < (int)num20; num21++)
				{
					VM.VM936799001(ptr13, 8, 64U, ref num7);
					ptr13 += 4;
					ptr13 += 4;
					for (int num22 = 0; num22 < 8; num22++)
					{
						VM.VM936799001(ptr13, 4, 64U, ref num7);
						*ptr13 = 0;
						ptr13++;
						bool flag13 = *ptr13 == 0;
						bool flag28 = flag13;
						if (flag28)
						{
							ptr13 += 3;
							break;
						}
						*ptr13 = 0;
						ptr13++;
						bool flag14 = *ptr13 == 0;
						bool flag29 = flag14;
						if (flag29)
						{
							ptr13 += 2;
							break;
						}
						*ptr13 = 0;
						ptr13++;
						bool flag15 = *ptr13 == 0;
						bool flag30 = flag15;
						if (flag30)
						{
							ptr13++;
							break;
						}
						*ptr13 = 0;
						ptr13++;
					}
				}
			}
		}
	}
}

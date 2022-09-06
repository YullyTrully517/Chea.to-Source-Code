using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;

namespace CheatoClient
{
	// Token: 0x02000009 RID: 9
	public class json_wrapper
	{
		// Token: 0x0600005D RID: 93 RVA: 0x00006818 File Offset: 0x00004A18
		public static bool is_serialisable(Type to_check)
		{
			return to_check.IsSerializable || to_check.IsDefined(typeof(DataContractAttribute), true);
		}

		// Token: 0x0600005E RID: 94 RVA: 0x00006838 File Offset: 0x00004A38
		public json_wrapper(object obj_to_work_with)
		{
			this.current_object = obj_to_work_with;
			Type object_type = this.current_object.GetType();
			this.serializer = new DataContractJsonSerializer(object_type);
			bool flag = !json_wrapper.is_serialisable(object_type);
			if (flag)
			{
				throw new Exception(string.Format("The object {0} is not serialisable", this.current_object));
			}
		}

		// Token: 0x0600005F RID: 95 RVA: 0x00006890 File Offset: 0x00004A90
		public object string_to_object(string json)
		{
			byte[] buffer = Encoding.Default.GetBytes(json);
			object result;
			using (MemoryStream mem_stream = new MemoryStream(buffer))
			{
				result = this.serializer.ReadObject(mem_stream);
			}
			return result;
		}

		// Token: 0x06000060 RID: 96 RVA: 0x000068DC File Offset: 0x00004ADC
		public T string_to_generic<T>(string json)
		{
			return (T)((object)this.string_to_object(json));
		}

		// Token: 0x04000027 RID: 39
		private DataContractJsonSerializer serializer;

		// Token: 0x04000028 RID: 40
		private object current_object;
	}
}

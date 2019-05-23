using LegacyCore.Base;
using LegacyCore.Base.Rpc;
using Newtonsoft.Json;

namespace LegacyCore.Server.Rpc {

    /// <summary>
    /// Server's rpc serializer
    /// </summary>
    public class RpcSerializer : IRpcSerializer {

		public string Serialize(object obj) => JsonConvert.SerializeObject(obj);

		public T Deserialize<T>(string data) => JsonConvert.DeserializeObject<T>(data);
	}
}

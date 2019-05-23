using System;
using Newtonsoft.Json;

namespace LegacyCore.Base.Rpc {

    /// <summary>
    /// A response
    /// </summary>
    /// <typeparam name="T">Type of response</typeparam>
	public class RpcResponse<T> : RpcMessage {

		protected readonly Lazy<T> result;

		public T Result => this.result.Value;

        /// <summary>
        /// Constructs a new response
        /// </summary>
		public RpcResponse() {
			this.result = new Lazy<T>(() => JsonConvert.DeserializeObject<T>(this.Payload));
		}

        /// <summary>
        /// Parses result
        /// </summary>
        /// <param name="result">The result</param>
        /// <returns>The response</returns>
		public static RpcResponse<T> Parse(string result) {
			return JsonConvert.DeserializeObject<RpcResponse<T>>(result);
		}
	}

}

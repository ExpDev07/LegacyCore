using System;
using System.Collections.Generic;
using CitizenFX.Core;
using Newtonsoft.Json;

namespace LegacyCore.Base.Rpc {

    /// <summary>
    /// A rpc message
    /// </summary>
    public class RpcMessage {

        /// <summary>
        /// Event
        /// </summary>
		public string Event { get; set; }

        /// <summary>
        /// The payload
        /// </summary>
		public string Payload { get; set; } 

        /// <summary>
        /// Target of message
        /// </summary>
		public Player Target { get; set; } = null;

        /// <summary>
        /// Time message was created
        /// </summary>
		public DateTime Created { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Time message was sent
        /// </summary>
		public DateTime Sent { get; set; }

        /// <summary>
        /// Serializes this object to a json string
        /// </summary>
        /// <returns>Serialized data in this class</returns>
		public string Build() => JsonConvert.SerializeObject(this);
	}
}

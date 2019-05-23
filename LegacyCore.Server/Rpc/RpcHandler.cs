using LegacyCore.Base.Rpc;
using System;
using System.Linq;

namespace LegacyCore.Server.Rpc {

    /// <summary>
    /// Server's rpc handler
    /// </summary>
    public class RpcHandler : IRpcHandler {

		public void Attach(string @event, Delegate callback) {
			//Server.Log($"Attach: \"{@event}\" {callback.Method.Name}({string.Join(", ", callback.Method.GetParameters().Select(p => p.ParameterType + " " + p.Name))})");
			LegacyCoreServer.Instance.EventHandlers[@event] += callback;
		}

		public void Detach(string @event, Delegate callback) {
            //Server.Log($"Detach: \"{@event}\" {callback.Method.Name}({string.Join(", ", callback.Method.GetParameters().Select(p => p.ParameterType + " " + p.Name))})");
            LegacyCoreServer.Instance.EventHandlers[@event] -= callback;
		}
	}
}

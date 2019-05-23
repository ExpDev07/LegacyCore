using CitizenFX.Core;

namespace LegacyCore.Server.Rpc {

    /// <summary>
    /// Extensions to rpc
    /// </summary>
    public static class RpcExtensions {

		public static ServerRpcRequest Event(this Player player, string @event) {
            return new ServerRpcRequest(@event, new RpcHandler(), new RpcTrigger(), new RpcSerializer()).Target(player);
        }
    }
}

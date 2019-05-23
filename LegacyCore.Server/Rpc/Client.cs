namespace LegacyCore.Server.Rpc
{
	public static class Client {

		public static ServerRpcRequest Event(string @event) {
			return new ServerRpcRequest(@event, new RpcHandler(), new RpcTrigger(), new RpcSerializer());
		}
	}
}

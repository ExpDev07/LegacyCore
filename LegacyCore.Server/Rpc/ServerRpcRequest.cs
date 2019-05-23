using System;
using CitizenFX.Core;
using LegacyCore.Base.Rpc;

namespace LegacyCore.Server.Rpc {

    /// <summary>
    /// Server's rpc request
    /// </summary>
    public class ServerRpcRequest : RpcRequest {

        /// <summary>
        /// Constructs a RPC server request
        /// </summary>
        /// <param name="event">Event</param>
        /// <param name="handler">Handler for request</param>
        /// <param name="trigger">Trigger for request</param>
        /// <param name="serializer">Serializer for request</param>
		public ServerRpcRequest(string @event, IRpcHandler handler, IRpcTrigger trigger, IRpcSerializer serializer) : base(@event, handler, trigger, serializer) { }

        /// <summary>
        /// Makes request target a player
        /// </summary>
        /// <param name="player">Player to target</param>
        /// <returns></returns>
		public ServerRpcRequest Target(Player player) {
			this.message.Target = player;
			return this;
		}

		public void On(Action action) {
			this.handler.Attach(this.message.Event, action);
		}

		public void On(Action<Player> action) {
			this.handler.Attach(this.message.Event, action);
		}

		public void On(Action<Player, string> action) {
			this.handler.Attach(this.message.Event, action);
		}

		public void On(Action<Player, string, CallbackDelegate> action) {
			this.handler.Attach(this.message.Event, action);
		}

		public void On(Action<int, string, string> action) {
			this.handler.Attach(this.message.Event, action);
		}

		public void On<T>(Action<T> action) {
			this.handler.Attach(this.message.Event, action);
		}
	}
}

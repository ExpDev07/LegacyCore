using System;
using System.Threading.Tasks;

namespace LegacyCore.Base.Rpc {

    /// <summary>
    /// A rpc request
    /// </summary>
    public class RpcRequest {

		protected readonly RpcMessage message = new RpcMessage();
		protected readonly IRpcHandler handler;
		protected readonly IRpcTrigger trigger;
		protected readonly IRpcSerializer serializer;
		
        /// <summary>
        /// Constructs a RPC request
        /// </summary>
        /// <param name="event">Event</param>
        /// <param name="handler">Handler for request</param>
        /// <param name="trigger">Trigger for request</param>
        /// <param name="serializer">Serializer for request</param>
		public RpcRequest(string @event, IRpcHandler handler, IRpcTrigger trigger, IRpcSerializer serializer) {
			this.message.Event = @event;
			this.handler = handler;
			this.trigger = trigger;
			this.serializer = serializer;
		}

        /// <summary>
        /// Attaches data to payload
        /// </summary>
        /// <typeparam name="T">Type of data to add</typeparam>
        /// <param name="data">Data to add</param>
        /// <returns>Self</returns>
		public RpcRequest SetPayload<T>(T data) {
			this.message.Payload = this.serializer.Serialize(data);
			return this;
		}

        /// <summary>
        /// Pulls the rpc trigger (fires message)
        /// </summary>
		public void Trigger() {
			this.trigger.Fire(this.message);
		}

        
		public async Task Request() {
			await MakeRequest();
		}

        
		public async Task<T> Request<T>() {
			var results = await MakeRequest();
			return this.serializer.Deserialize<T>(results.Payload);
		}

        /// <summary>
        /// Makes the request and pulls the trigger
        /// </summary>
        /// <returns></returns>
		protected async Task<RpcMessage> MakeRequest() {
			var tcs = new TaskCompletionSource<RpcMessage>();
			var handler = new Action<string>(json => {
				var message = this.serializer.Deserialize<RpcMessage>(json);
				tcs.SetResult(message);
			});

			try {
                this.handler.Attach(this.message.Event, handler);
                this.Trigger();
                return await tcs.Task;
            } finally {
				this.handler.Detach(this.message.Event, handler);
			}
		}
	}
}

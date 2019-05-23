namespace LegacyCore.Base.Rpc {

	public interface IRpcTrigger {

        /// <summary>
        /// Fires an RPC message
        /// </summary>
        /// <param name="message">Message to fire</param>
		void Fire(RpcMessage message);
	}
}

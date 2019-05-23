using System;

namespace LegacyCore.Base.Rpc {

    /// <summary>
    /// A handler for Rpc
    /// </summary>
	public interface IRpcHandler {

        /// <summary>
        /// Attaches callback to event
        /// </summary>
        /// <param name="event">Event to attach to</param>
        /// <param name="callback">Callback to attach</param>
		void Attach(string @event, Delegate callback);

        /// <summary>
        /// Detaches callback from event
        /// </summary>
        /// <param name="event">Event to detach from</param>
        /// <param name="callback">Callback to detach</param>
		void Detach(string @event, Delegate callback);
	}
}

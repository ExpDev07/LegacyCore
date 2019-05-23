﻿namespace LegacyCore.Server.Rpc {

    /// <summary>
    /// A collection of server events
    /// </summary>
	public static class ServerEvents {

		public const string ResourceStarting = "onResourceStarting";
		public const string ResourceStart = "onResourceStart";
		public const string ResourceStop = "onResourceStop";

		public const string HostingSession = "hostingSession";
		public const string HostedSession = "hostedSession";

		public const string PlayerConnecting = "playerConnecting";
		public const string PlayerDropped = "playerDropped";
	}
}

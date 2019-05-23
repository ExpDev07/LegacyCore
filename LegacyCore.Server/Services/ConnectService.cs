using CitizenFX.Core;
using LegacyCore.Server.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegacyCore.Server.Services {

    /// <summary>
    /// A service for connecting players
    /// </summary>
    public class ConnectService : ServerService {

        /// <summary>
        /// Constructs a connect service
        /// </summary>
        public ConnectService() {
            Rpc.Client.Event("playerConnected").On(HandlePlayerConnecting);
        }

        /// <summary>
        /// Does not do much
        /// </summary>
        public override void Initialize() {
            // Empty
        }

        // Function that gets called when player has connected
        private void HandlePlayerConnecting([FromSource]Player citizen) {
            // Load player and set network id
            LegacyPlayer player = LegacyCoreServer.Instance.GetPlayer(citizen);
            if (int.TryParse(citizen.Handle, out int id)) {
                player.NetworkId = id;
            }
        }

    }
}

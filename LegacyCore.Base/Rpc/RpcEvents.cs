namespace LegacyCore.Base.Rpc {

    /// <summary>
    /// A collection of Rpc events
    /// </summary>
    public static class RpcEvents {

		public const string GetServerInformation = "legacycore:client:ready";
		public const string ClientDisconnect = "legacycore:client:disconnect";

		public const string GetUser = "legacycore:user:load";
		public const string GetCharacters = "legacycore:user:characters";
		public const string AcceptRules = "legacycore:user:rules";

		public const string CharacterCreate = "legacycore:character:create";
		public const string CharacterLoad = "legacycore:character:load";
		public const string CharacterDelete = "legacycore:character:delete";
		public const string CharacterSave = "legacycore:character:save";
		public const string CharacterRevive = "legacycore:character:revive";
		public const string GetCharacterPosition = "legacycore:character:getpos";

		public const string CharacterComponentSet = "legacycore:character:component:set";
		public const string CharacterPropSet = "legacycore:character:prop:set";
		
		public const string BankAtmWithdraw = "legacycore:bank:atm:withdraw";
		public const string BankBranchWithdraw = "legacycore:bank:branch:withdraw";
		public const string BankBranchDeposit = "legacycore:bank:branch:withdraw";
		public const string BankBranchTransfer = "legacycore:bank:branch:transfer";
		public const string BankOnlineTransfer = "legacycore:bank:online:transfer";

		public const string EntityDelete = "legacycore:entity:delete";

		public const string CarCreate = "legacycore:car:create";
		public const string CarSpawn = "legacycore:car:spawn";
		public const string CarSave = "legacycore:car:save";
		public const string CarTransfer = "legacycore:car:transfer";
		public const string CarClaim = "legacycore:car:claim";
		public const string CarUnclaim = "legacycore:car:unclaim";

		public const string BikeSpawn = "legacycore:bike:spawn";
		public const string BikeSave = "legacycore:bike:save";
		public const string BikeTransfer = "legacycore:bike:transfer";
		public const string BikeClaim = "legacycore:bike:claim";
		public const string BikeUnclaim = "legacycore:bike:unclaim";
	}
}

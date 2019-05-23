namespace LegacyCore.Base.Rpc {

    /// <summary>
    /// Serializer for rpc
    /// </summary>
	public interface IRpcSerializer {

        /// <summary>
        /// Serializes object
        /// </summary>
        /// <param name="obj">Object to deserialize</param>
        /// <returns>Serialized object</returns>
		string Serialize(object obj);

        /// <summary>
        /// Deserializes object
        /// </summary>
        /// <typeparam name="T">Type of object</typeparam>
        /// <param name="data">Data to deserialize</param>
        /// <returns>Deserialized data</returns>
		T Deserialize<T>(string data);
	}
}

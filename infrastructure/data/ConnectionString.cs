
namespace infrastructure.data
{
    public sealed class ConnectionString
    {
        #region propiedades

        public ConnectionString(string value) => Value = value;
        public string Value { get; }

        #endregion
    }
}

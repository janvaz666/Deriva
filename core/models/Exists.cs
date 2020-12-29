
namespace core.models
{
    public class Exists
    {
        #region propiedades

        public int Id { get; set; }
        public string Name { get; set; }

        #endregion

        #region constructores

        public Exists()
        {
            Id = 0;
            Name = string.Empty;
        }

        #endregion
    }
}

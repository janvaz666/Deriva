
namespace core.param
{
    public class Param
    {
        #region propiedades

        public int Id { get; set; }
        public string ClaveIdioma { get; set; }
        public int Usuario { get; set; }

        #endregion

        #region constructores

        public Param()
        {
            Id = 0;
            ClaveIdioma = "es";
            Usuario = 0;
        }

        #endregion
    }
}

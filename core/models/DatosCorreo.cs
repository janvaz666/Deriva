
namespace core.models
{
    public class DatosCorreo
    {
        #region propiedades

        public string Asunto { get; set; }
        public string Cuerpo { get; set; }
        public string Correo { get; set; }

        #endregion

        #region constructores

        public DatosCorreo()
        {
            Asunto = string.Empty;
            Cuerpo = string.Empty;
            Correo = string.Empty;
        }

        #endregion
    }
}

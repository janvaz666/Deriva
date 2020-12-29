
namespace mail.model
{
    public class ResultadoEnvio
    {
        #region propiedades

        public int Resultado { get; set; }
        public string Mensaje { get; set; }

        #endregion

        #region constructores

        public ResultadoEnvio()
        {
            this.Resultado = -1;
            this.Mensaje = string.Empty;
        }

        public ResultadoEnvio(int codigo, string mensaje)
        {
            this.Resultado = codigo;
            this.Mensaje = mensaje;
        }

        #endregion
    }
}

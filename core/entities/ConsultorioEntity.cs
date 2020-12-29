using System;
using System.Collections.Generic;
using System.Text;

namespace core.entities
{
    public class ConsultorioEntity
    {
        #region propiedades
        public int IdConsultorioUsuario { get; set; }

        public int Usuario_idUsuario { get; set; }
        public string Nombre { get; set; }
        public int TipoConsultorio_idTipoConsultorio { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
            
        
        #endregion

        #region costructores
        public ConsultorioEntity()
        {
            IdConsultorioUsuario = 0;
            Usuario_idUsuario = 0;
            Nombre = string.Empty;
            TipoConsultorio_idTipoConsultorio = 0;
            Correo = string.Empty;
            Telefono = string.Empty;
            Direccion = string.Empty;
            
        }
        #endregion
    }
}

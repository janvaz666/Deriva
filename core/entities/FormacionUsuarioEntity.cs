using System;
using System.Collections.Generic;
using System.Text;

namespace core.entities
{
    public class FormacionUsuarioEntity
    {
        #region propiedades
        public int IdformacionUsuario { get; set; }

        public int Usuario_idUsuario { get; set; }
        public string Carrera { get; set; }
        public string Institucion { get; set; }
        public string Nivel { get; set; }

        #endregion

        #region costructores
        public FormacionUsuarioEntity()
        {
            IdformacionUsuario = 0;
            Usuario_idUsuario = 0;
            Carrera = string.Empty;
            Institucion = string.Empty;
            Nivel = string.Empty;
            
        }
        #endregion
    }
}

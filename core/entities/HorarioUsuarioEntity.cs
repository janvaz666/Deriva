using System;
using System.Collections.Generic;
using System.Text;

namespace core.entities
{
    public class HorarioUsuarioEntity
    {
        #region propiedades
        public int IdHorarioUsuario { get; set; }

        public int Usuario_idUsuario { get; set; }
        public string Horario { get; set; }
        public string Dia { get; set; }

        #endregion

        #region costructores
        public HorarioUsuarioEntity()
        {
            IdHorarioUsuario = 0;
            Usuario_idUsuario = 0;
            Horario = string.Empty;
            Dia = string.Empty;
        }
        #endregion
    }
}

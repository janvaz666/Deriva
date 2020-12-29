using System;
using System.Collections.Generic;
using System.Text;

namespace core.entities
{
    public class EspecialidadUsuarioEntity
    {
        #region propiedades
        public int IdEspecialidadUsuario { get; set; }

        public int Usuario_idUsuario { get; set; }
        public int Especialidad_idespecialidad { get; set; }
        
        #endregion

        #region costructores
        public EspecialidadUsuarioEntity()
        {
            IdEspecialidadUsuario = 0;
            Usuario_idUsuario = 0;
            Especialidad_idespecialidad = 0;
            
        }
        #endregion
    }
}

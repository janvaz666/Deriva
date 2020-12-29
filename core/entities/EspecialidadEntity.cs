using System;
using System.Collections.Generic;
using System.Text;

namespace core.entities
{
    public class EspecialidadEntity
    {
        #region propiedades
        public int IdEspecialidad { get; set; }
        public string DescEspecialidad { get; set; }
         #endregion

        #region costructores
        public EspecialidadEntity()
        {
            IdEspecialidad = 0;
            DescEspecialidad = string.Empty;            
        }
        #endregion
    }
}

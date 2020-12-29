using core.entities;
using core.response;
using System.Collections.Generic;

namespace core.response
{
    public class ResponseEspecialidad : Response
    {
        #region propiedades            
        public List<EspecialidadEntity> especialidad { get; set; }
        #endregion
        #region constructores            
        public ResponseEspecialidad() : base()
        {
            especialidad = new List<EspecialidadEntity>();
        }
        #endregion
    }
}

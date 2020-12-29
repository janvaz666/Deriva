using core.entities;
using core.response;
using System.Collections.Generic;

namespace core.response
{
    public class ResponseConvenio : Response
    {
        #region propiedades            
        public List<ConvenioEntity> convenio { get; set; }
        #endregion
        #region constructores            
        public ResponseConvenio() : base()
        {
            convenio = new List<ConvenioEntity>();
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace core.entities
{
    public class ConvenioEntity
    {
        #region propiedades
        public int IdConvenio { get; set; }
        public string DescConvenio{ get; set; }
         #endregion

        #region costructores
        public ConvenioEntity()
        {
            IdConvenio = 0;
            DescConvenio = string.Empty;            
        }
        #endregion
    }
}

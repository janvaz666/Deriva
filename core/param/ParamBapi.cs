using core.models;
using System.Collections.Generic;

namespace core.param
{
    public class ParamBapi
    {
        #region propiedades

        
        public int IdClienteSAP { get; set; }
        public int IdPedido { get; set; }
        public int estadoPedido { get; set; }

        #endregion

        #region constructores

        public ParamBapi()
        {
            IdClienteSAP = 0;
            IdPedido = 0;
            estadoPedido = 0;
        }

        #endregion
    }
}

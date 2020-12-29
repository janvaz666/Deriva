using core.entities;
using System.Collections.Generic;

namespace core.response
{
    public class ResponseSumary : Response
    {
        #region propiedades

        public int total { get; set; }
        public int ok { get; set; }
        public int error { get; set; }
        public List<Sumary> sumario { get; set; }

        #endregion

        #region cosntructores

        public ResponseSumary() : base()
        {
            total = 0;
            ok = 0;
            error = 0;
            sumario = new List<Sumary>();
        }

        #endregion
    }
}

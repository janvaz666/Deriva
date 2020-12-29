
namespace core.entities
{
    public class Sumary
    {
        #region propiedades

        public bool ok { get; set; }
        public bool error { get; set; }
        public string operation { get; set; }
        public string message { get; set; }
        public int id { get; set;}

        #endregion

        #region constructores

        public Sumary()
        {   
            ok = false;
            error = false;
            operation = string.Empty;
            message = string.Empty;
            id = 0;
        }

        #endregion
    }
}

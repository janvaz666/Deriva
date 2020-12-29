
namespace core.response
{
    public class ResponseNew : Response
    {
        #region propiedades

        public int Id { get; set; }

        #endregion

        #region constructores

        public ResponseNew() : base()
        {
            Id = 0;
        }

        #endregion
    }
}

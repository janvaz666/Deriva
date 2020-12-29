
namespace core.response
{
    public class Response
    {
        #region propiedades

        public int Code { get; set; }
        public string Message { get; set; }

        #endregion

        #region constructores

        public Response()
        {
            Code = 0;
            Message = string.Empty;
        }

        #endregion
    }
}


namespace core.models
{
    public class FileRoutes
    {
        #region propiedades

        public string PhysicalFolderPrivate { get; set; }
        public string PhysicalFolder { get; set; }
        public string WebFolder { get; set; }
        public string PhysicalUploadsFolder { get; set; }
        public string WebUploadsFolder { get; set; }

        #endregion

        #region constructores

        public FileRoutes()
        {
            PhysicalFolderPrivate = string.Empty;
            PhysicalFolder = string.Empty;
            WebFolder = string.Empty;
            PhysicalUploadsFolder = string.Empty;
            WebUploadsFolder = string.Empty;
        }

        #endregion
    }
}

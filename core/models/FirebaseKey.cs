using System;
using System.Collections.Generic;
using System.Text;

namespace core.models
{
    public class FirebaseKey
    {
        #region propiedades

        public string FirebaseServerKeyToken { get; set; }
        public string FirebaseSenderID { get; set; } 
        public string FirebaseURL { get; set; }

        #endregion

        #region constructores

        public FirebaseKey()
        {
            FirebaseServerKeyToken = string.Empty;
            FirebaseSenderID = string.Empty;
            FirebaseURL = string.Empty;
        }

        #endregion
    }
}

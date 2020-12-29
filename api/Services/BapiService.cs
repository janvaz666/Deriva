using System;
using System.Configuration;
//using System.Web.Configuration;
using System.Text;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;

namespace api.Services
{
    public class BapiService
    {
        #region propiedades
        #endregion

        #region variables

        //readonly Configuration conf = WebConfigurationManager.OpenWebConfiguration("~\\web.config");
        //readonly KeyValueConfigurationElement kuoBAPIUrl;
        //readonly KeyValueConfigurationElement kuoBAPIUser;
        //readonly KeyValueConfigurationElement kuoBAPIPass;

        private readonly IConfiguration _config;

        #endregion

        #region constructores

        public BapiService(IConfiguration config)
        {
            this._config = config;
        }

        #endregion


        #region método públicos


        //public ResponseBAPI validaColaborador(int idEmpledo, string RFC)
        //{
            
        
        //}


            #endregion
        }
}

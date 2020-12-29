using System;
using System.Collections.Generic;
using System.Text;

namespace core.entities
{
    public class RegistroEntity
    {
        #region propiedades
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Correo { get; set; }
        public bool Activo { get; set; }
        public string Token { get; set; }
        public string Contrasena { get; set; }
        public string Telefono { get; set; }
        public string Rfc { get; set; }
        public string RazonSocial { get; set; }
        public bool ComprobanteFiscal { get; set; }

        public int Convenio_IdConvenio { get; set; }
        public float CobroMinimo { get; set; }
        public float CobroMaximo { get; set; }
        public string CedulaProfesional { get; set; }

        public List<ConsultorioEntity> Consultorio { get; set; }
        public List<EspecialidadUsuarioEntity> EspecialidadUsuario { get; set; }
        public List<FormacionUsuarioEntity> FormacionUsuario { get; set; }
        public List<HorarioUsuarioEntity> HorarioUsuario { get; set; }


        #endregion

        #region costructores
        public RegistroEntity()
        {
            IdUsuario = 0;
            Nombre = string.Empty;
            PrimerApellido = string.Empty;
            SegundoApellido = string.Empty;
            FechaNacimiento = DateTime.MinValue;
            Correo = string.Empty;
            Activo = false;
            Token = string.Empty;
            Contrasena = string.Empty;
            Telefono = string.Empty;
            Rfc = string.Empty;
            RazonSocial = string.Empty;
            ComprobanteFiscal = false;
            Convenio_IdConvenio = 0;
            CobroMinimo = 0;
            CobroMaximo = 0;
            CedulaProfesional = string.Empty;
            Consultorio = new List<ConsultorioEntity>();
            EspecialidadUsuario = new List<EspecialidadUsuarioEntity>();
            FormacionUsuario = new List<FormacionUsuarioEntity>();
            HorarioUsuario = new List<HorarioUsuarioEntity>();

        }
        #endregion
    }
}

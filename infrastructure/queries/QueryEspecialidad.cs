using System;
using System.Text;
using core.entities;
using core.param;

namespace infrastructure.queries
{
    public static class QueryEspecialidad
    {
        #region metodos          
        ///// <summary>          
        ///// Lista de Unidad Medida cargados en el sistema      
        ///// </summary>         
        ///// <returns>Consulta para leer los datos</returns>  
        //public static string ListaUnidadMedida()
        //{
        //    var qry = new StringBuilder();
        //    qry.Append("select idUnidadMedida, nombre, abreviacion, activo, idEmpresa from unidadMedida");
        //    return qry.ToString();
        //}
        /// <summary>         
        /// Leer el identificador del último UnidadMedida insertado       
        /// </summary>          
        /// <returns>Consulta para leer el dato</returns>    
        public static string UltimoIdRegistro()
        {
            var qry = new StringBuilder();
            qry.Append("select top 1 idRegistro from registro order by idRegistro desc");
            return qry.ToString();
        }
        /// <summary>          
        /// Insertar nuevo UnidadMedida     
        /// </summary>         
        /// <param name=unidadMedida">Objeto con los datos de UnidadMedida</param>    
        /// <returns>Query para realizar la inserción</returns>         
        public static string GetEspecialidad()
        {
            var qry = new StringBuilder();
            qry.Append("select * from especialidad order by idEspecialidad desc");
            return qry.ToString();
        }
        ///// <summary>         
        ///// Editar una UnidadMedida     
        ///// </summary>        
        ///// <param name="unidadMedida">Objetoc con los datos de UnidadMedida</param>      
        ///// <returns>Consulta para realizar la edición</returns>         
        //public static string EditarUnidadMedida(UnidadMedidaEntity unidadMedida)
        //{
        //    var qry = new StringBuilder();
        //    qry.Append("update unidadMedida set ");
        //    qry.AppendFormat("nombre = '{0}', ", unidadMedida.Nombre);
        //    qry.AppendFormat("abreviacion = '{0}', ", unidadMedida.Abreviacion);
        //    qry.AppendFormat("activo = '{0}', ", unidadMedida.Activo);
        //    qry.AppendFormat("idEmpresa = '{0}' ", unidadMedida.IdEmpresa);
        //    qry.AppendFormat("where idUnidadMedida = {0} ", unidadMedida.IdUnidadMedida);
        //    return qry.ToString();
        //}
        ///// <summary>         
        ///// Activar un UnidadMedida       
        ///// </summary>         
        ///// <param name="unidadMedida">Objetoc con los datos de UnidadMedida</param>       
        ///// <returns>Consulta para realizar la activacion </returns>        
        //public static string ActivarUnidadMedida(UnidadMedidaEntity unidadMedida)
        //{
        //    var qry = new StringBuilder();

        //    qry.Append("update UnidadMedida set ");
        //    qry.AppendFormat("activo = '{0}' ", unidadMedida.Activo);
        //    qry.AppendFormat("where idUnidadMedida = {0} ", unidadMedida.IdUnidadMedida);
        //    return qry.ToString();
        //}
        #endregion
    }
}

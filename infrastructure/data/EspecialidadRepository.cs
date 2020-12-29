using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;
using core.entities;
using core.interfaces;
using System.Linq;
using infrastructure.queries;

namespace infrastructure.data
{
    public class EspecialidadRepository : IEspecialidadRepository
    {
        #region variables     
        private string Mensaje;
        private readonly ConnectionString connectionString;
        #endregion
        #region constructor            
        public EspecialidadRepository(ConnectionString connectionString)
        {
            this.connectionString = connectionString;
            this.Mensaje = "";
        }
        #endregion
        #region métodos privados        
        #endregion
        #region métodos implementados         
        /// <summary>       
        /// Leer el valor del mensaje generado        
        /// </summary>          
        /// <returns>Mensaje</returns>       
        public string Message()
        {
            return Mensaje;
        }
        /// <summary>         
        /// Insertar nueva UnidadMedida   
        /// </summary>        
        /// <param name="entity">Objeto con los datos</param>   
        /// <returns>Identificador de la nueva UnidadMedida</returns>       
        async Task<IEnumerable<EspecialidadEntity>> IEspecialidadRepository.GetEspecialidad()
            {
            var query = QueryEspecialidad.GetEspecialidad();
            using var conn = new SqlConnection(connectionString.Value);
            var result = await conn.QueryAsync<EspecialidadEntity>(query);
            return result;
        }
        ///// <summary>    
        ///// Editar UnidadMedida       
        ///// </summary>       
        ///// <param name="entity">Objeto con los datos</param>       
        ///// <returns>Verdadero si el proceso se llevo a cabo correctamente</returns>        
        //bool IUnidadMedidaRepository.Update(UnidadMedidaEntity entity)
        //{
        //    var res = false;
        //    try
        //    {
        //        var queryEdit = QueryUnidadMedida.EditarUnidadMedida(entity);
        //        var conn = new SqlConnection(connectionString.Value);

        //        // Editar los datos
        //        conn.Open();
        //        var trans = conn.BeginTransaction();
        //        var er = conn.Execute(queryEdit, transaction: trans);
        //        if (er > 0)
        //        {
        //            trans.Commit();
        //            res = true;
        //        }
        //        else
        //        {
        //            trans.Rollback();
        //        }

        //        conn.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        Mensaje = "Error al editar el UnidadMedida | Error | " + ex.Message;
        //    }
        //    return res;
        //}
        ///// <summary>         
        ///// Activar UnidadMedida     
        ///// </summary>        
        ///// <param name="entity">Objeto con los datos</param>       
        ///// <returns>Verdadero si el proceso se llevo a cabo correctamente</returns>      
        //bool IUnidadMedidaRepository.Activate(UnidadMedidaEntity entity)
        //{
        //    var res = false;
        //    try
        //    {
        //        var queryEdit = QueryUnidadMedida.ActivarUnidadMedida(entity);
        //        var conn = new SqlConnection(connectionString.Value);


        //        // Editar los datos
        //        conn.Open();
        //        var trans = conn.BeginTransaction();
        //        var er = conn.Execute(queryEdit, transaction: trans);
        //        if (er > 0)
        //        {
        //            trans.Commit();
        //            res = true;
        //        }
        //        else
        //        {
        //            trans.Rollback();
        //        }

        //        conn.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        Mensaje = "Error al activar/desactivar la UnidadMedida | Error | " + ex.Message;
        //    }
        //    return res;
        //}
        //public void Delete(UnidadMedidaEntity entity)
        //{ throw new NotImplementedException(); }
        ///// <summary>          
        ///// Leer la lista de UnidadMedida         
        ///// </summary>          
        ///// <returns>Listado con las UnidadMedida</returns>   
        //async Task<IEnumerable<UnidadMedidaEntity>> IUnidadMedidaRepository.GetAllUnidadMedida()
        //{
        //    var query = QueryUnidadMedida.ListaUnidadMedida();
        //    using var conn = new SqlConnection(connectionString.Value);
        //    var result = await conn.QueryAsync<UnidadMedidaEntity>(query);
        //    return result;
        //}
        #endregion
    }
}

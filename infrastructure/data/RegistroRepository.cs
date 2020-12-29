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
    public class RegistroRepository : IRegistroRepository
    {
        #region variables     
        private string Mensaje;
        private readonly ConnectionString connectionString;
        #endregion
        #region constructor            
        public RegistroRepository(ConnectionString connectionString)
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
        int IRegistroRepository.AddUpdate(RegistroEntity entity)
        {
            var id = 0;
            var total = 0;
            try
            {

                if (entity.IdUsuario == 0)
                {
                    var queryInsert = QueryRegistro.Add(entity);
                    var queryId = QueryRegistro.UltimoIdRegistro();
                    var conn = new SqlConnection(connectionString.Value);

                    // Insertar datos                  
                    conn.Open();
                    var trans = conn.BeginTransaction();
                    var ar = conn.Execute(queryInsert, transaction: trans);
                    if (ar > 0)
                    {
                        trans.Commit();

                        // Obtener identificador
                        var result = conn.Query<int>(queryId);
                        id = result != null ? result.FirstOrDefault() : 0;
                    }
                    else
                    {
                        trans.Rollback();
                    }
                }
                else
                { 





                    total = entity.Consultorio.Count;

                    foreach (var c in entity.Consultorio)
                    {

                        var consultorio = new ConsultorioEntity()
                        {

                            Usuario_idUsuario = entity.IdUsuario,
                            Nombre = c.Nombre,
                            TipoConsultorio_idTipoConsultorio = c.TipoConsultorio_idTipoConsultorio,
                            Correo = c.Correo,
                            Telefono = c.Telefono,
                            Direccion = c.Direccion
                        };

                        if (c.IdConsultorioUsuario == 0)
                        {

                            var queryInsertConsultorio = QueryConsultorio.Add(consultorio);
                            var queryId = QueryConsultorio.UltimoIdRegistro();
                            var conn = new SqlConnection(connectionString.Value);

                            // Insertar datos                  
                            conn.Open();
                            var trans = conn.BeginTransaction();
                            var ar = conn.Execute(queryInsertConsultorio, transaction: trans);
                            if (ar > 0)
                            {
                                trans.Commit();

                                // Obtener identificador
                                var result = conn.Query<int>(queryId);
                                id = result != null ? result.FirstOrDefault() : 0;
                            }
                            else
                            {
                                trans.Rollback();
                            }


                        }
                        else { 
                        //Update de datos
                        }

                    };

                    total = 0;

                    total = entity.EspecialidadUsuario.Count;

                    foreach (var c in entity.EspecialidadUsuario)
                    {

                        var especialidad = new EspecialidadUsuarioEntity()
                        {

                            Usuario_idUsuario = entity.IdUsuario,
                            Especialidad_idespecialidad = c.Especialidad_idespecialidad

                        };

                        if (c.IdEspecialidadUsuario == 0)
                        {

                            var queryInsertEspecialidad = QueryEspecialidadUsuario.Add(especialidad);
                            var queryId = QueryConsultorio.UltimoIdRegistro();
                            var conn = new SqlConnection(connectionString.Value);

                            // Insertar datos                  
                            conn.Open();
                            var trans = conn.BeginTransaction();
                            var ar = conn.Execute(queryInsertEspecialidad, transaction: trans);
                            if (ar > 0)
                            {
                                trans.Commit();

                                // Obtener identificador
                                var result = conn.Query<int>(queryId);
                                id = result != null ? result.FirstOrDefault() : 0;
                            }
                            else
                            {
                                trans.Rollback();
                            }


                        }
                        else
                        {
                            //Update de datos
                        }

                    };


                    total = 0;

                    total = entity.FormacionUsuario.Count;

                    foreach (var c in entity.FormacionUsuario)
                    {

                        var formacion = new FormacionUsuarioEntity()
                        {

                            Usuario_idUsuario = entity.IdUsuario,
                            Carrera = c.Carrera,
                            Institucion = c.Institucion,
                            Nivel = c.Nivel
                        };

                        if (c.IdformacionUsuario == 0)
                        {

                            var queryInsertFormacion = QueryFormacion.Add(formacion);
                            var queryId = QueryConsultorio.UltimoIdRegistro();
                            var conn = new SqlConnection(connectionString.Value);

                            // Insertar datos                  
                            conn.Open();
                            var trans = conn.BeginTransaction();
                            var ar = conn.Execute(queryInsertFormacion, transaction: trans);
                            if (ar > 0)
                            {
                                trans.Commit();

                                // Obtener identificador
                                var result = conn.Query<int>(queryId);
                                id = result != null ? result.FirstOrDefault() : 0;
                            }
                            else
                            {
                                trans.Rollback();
                            }


                        }
                        else
                        {
                            //Update de datos
                        }

                    };

                    total = 0;

                    total = entity.HorarioUsuario.Count;

                    foreach (var c in entity.HorarioUsuario)
                    {

                        var horario = new HorarioUsuarioEntity()
                        {

                            Usuario_idUsuario = entity.IdUsuario,
                            Horario = c.Horario
                        };

                        if (c.IdHorarioUsuario == 0)
                        {

                            var queryInsertHorario = QueryHorario.Add(horario);
                            var queryId = QueryConsultorio.UltimoIdRegistro();
                            var conn = new SqlConnection(connectionString.Value);

                            // Insertar datos                  
                            conn.Open();
                            var trans = conn.BeginTransaction();
                            var ar = conn.Execute(queryInsertHorario, transaction: trans);
                            if (ar > 0)
                            {
                                trans.Commit();

                                // Obtener identificador
                                var result = conn.Query<int>(queryId);
                                id = result != null ? result.FirstOrDefault() : 0;
                            }
                            else
                            {
                                trans.Rollback();
                            }


                        }
                        else
                        {
                            //Update de datos
                        }

                    };

                }

            }





            catch (Exception ex)
            {
                id = -1;
                Mensaje = "Error al insertar Registro | Error | " + ex.Message;
            }
            return id;
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

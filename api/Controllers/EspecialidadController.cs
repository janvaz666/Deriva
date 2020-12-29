using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using core.entities;
using core.interfaces;
using core.response;
using NLog;


namespace api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class EspecialidadController : ControllerBase
    {
        #region variables

        private static Logger _log = LogManager.GetCurrentClassLogger();
        private readonly IEspecialidadRepository especialidadRepository;

        #endregion

        #region constructores
        public EspecialidadController(IEspecialidadRepository especialidadRepository)
        {
            this.especialidadRepository = especialidadRepository;
        }
        #endregion

        #region acciones
        /// <summary>
       
        /// <response code="200">Proceso de búsqueda realizado correctamente</response>
        /// <response code="500">Error al realizar el proceso</response>
        [HttpGet]
        [Route("getEspecialidad")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(ResponseEspecialidad), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseEspecialidad), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetEspecialidad()
        {
            var response = new ResponseEspecialidad();

            try
            {
                response.Code = 200;
                response.especialidad = await especialidadRepository.GetEspecialidad() as List<EspecialidadEntity>;
                response.Message = "OK";
            }
            catch (Exception ex)
            {
                response.Code = 500;
                response.Message = "Error al leer los tipos de unidad de medida";
                _log.Error("Error al leer los tipos de unidad de medida | Error | {0}", ex.Message);
            }

            return Ok(response);
        }

        ///// <summary>
        ///// Agregar tipo moneda
        ///// </summary>
        ///// <returns>Registro de nuevo tipo de moneda</returns>
        ///// <response code = "200" > Proceso de registro realizado correctamente</response>
        ///// <response code = "500" > Error al realizar el proceso</response>
        //[HttpPost]
        //[Route("AddPrimerRegistro")]
        //[Produces("application/json")]
        //[ProducesResponseType(typeof(ResponseSumary), StatusCodes.Status200OK)]
        //[ProducesResponseType(typeof(ResponseSumary), StatusCodes.Status500InternalServerError)]
        //public IActionResult AddPrimerRegistro(RegistroEntity entity)
        //{

        //    var response = new ResponseSumary();

        //    try
        //    {
        //        response.Code = 200;
        //        var ok = false;
        //        var error = false;
        //        var ope = "nueva tipo unidad medida";
        //        var id = registroRepository.Add(entity);
        //        if (id > 0)
        //        {
        //            response.ok += 1;
        //            ok = true;
        //            error = false;
                    
        //        }
        //        else
        //        {
        //            response.error += 1;
        //            ok = false;
        //            error = true;
        //            _log.Error("operación: {1}, error: {2}", ope, registroRepository.Message());
        //        }
        //        response.sumario.Add(new Sumary()
        //        {
        //            ok = ok,
        //            error = error,
        //            operation = ope,
        //            id = id
        //        });
        //    }
        //    catch (Exception ex)
        //    {
        //        response.total = -1;
        //        response.ok = -1;
        //        response.error = -1;
        //        response.Code = 500;
        //        response.Message = "Error al crear registro";
        //        _log.Error("Error al crear registro | Error | {0}", ex.Message);
        //    }

        //    return Ok(response);

        //}

        ///// <summary>
        ///// Actualiza los datos de tipo de unidad medida
        ///// </summary>
        ///// <returns>Actualiza los datos de unidad medida</returns>
        ///// <response code="200">Rol actualizado correctamente</response>
        ///// <response code="500">Error al actualizar nuevo rol</response>
        //[HttpPut]
        //[Authorize]
        //[Route("UpdateUnidadMedida")]
        //[Produces("application/json")]
        //[ProducesResponseType(typeof(ResponseSumary), StatusCodes.Status200OK)]
        //[ProducesResponseType(typeof(ResponseSumary), StatusCodes.Status500InternalServerError)]
        //public IActionResult UpdateUnidadMedida(UnidadMedidaEntity entity)
        //{
        //    var response = new ResponseSumary();

        //    try
        //    {
        //        response.Code = 200;
        //        var ok = false;
        //        var error = false;
        //        var ope = "actualización unidad de medida";
        //        var correcto = unidadmedidaRepository.Update(entity);
        //        if (correcto)
        //        {
        //            response.ok += 1;
        //            ok = true;
        //            error = false;
        //        }
        //        else
        //        {
        //            response.Code = 500;
        //            response.error += 1;
        //            ok = false;
        //            error = true;
        //            _log.Error("operación: {1}, error: {2}", ope, unidadmedidaRepository.Message());
        //        }
        //        response.sumario.Add(new Sumary()
        //        {
        //            ok = ok,
        //            error = error,
        //            operation = ope
        //        });

        //    }
        //    catch (Exception ex)
        //    {
        //        response.total = -1;
        //        response.ok = -1;
        //        response.error = -1;
        //        response.Code = 500;
        //        response.Message = "Error al actualizar tipo unidad de medida";
        //        _log.Error("Error al actualizar tipo unidad de medida | Error | {0}", ex.Message);
        //    }
        //    return Ok(response);

        //}

        ///// <summary>
        ///// Actualiza Status
        ///// </summary>
        ///// <returns>Actualiza Status/returns>
        ///// <response code="200">Status actualizado correctamente</response>
        ///// <response code="500">Error al actualizar Status</response>
        //[HttpPut]
        //[Authorize]
        //[Route("UpdateStatus")]
        //[Produces("application/json")]
        //[ProducesResponseType(typeof(ResponseSumary), StatusCodes.Status200OK)]
        //[ProducesResponseType(typeof(ResponseSumary), StatusCodes.Status500InternalServerError)]
        //public IActionResult UpdateStatus(UnidadMedidaEntity entity)
        //{
        //    var response = new ResponseSumary();

        //    try
        //    {
        //        response.Code = 200;
        //        var ok = false;
        //        var error = false;
        //        var ope = "actualización Status";
        //        var correcto = unidadmedidaRepository.Activate(entity);
        //        if (correcto)
        //        {
        //            response.ok += 1;
        //            ok = true;
        //            error = false;
        //        }
        //        else
        //        {
        //            response.Code = 500;
        //            response.error += 1;
        //            ok = false;
        //            error = true;
        //            _log.Error("operación: {1}, error: {2}", ope, unidadmedidaRepository.Message());
        //        }
        //        response.sumario.Add(new Sumary()
        //        {
        //            ok = ok,
        //            error = error,
        //            operation = ope
        //        });

        //    }
        //    catch (Exception ex)
        //    {
        //        response.total = -1;
        //        response.ok = -1;
        //        response.error = -1;
        //        response.Code = 500;
        //        response.Message = "Error al actualizar status";
        //        _log.Error("Error al actualizar status | Error | {0}", ex.Message);
        //    }
        //    return Ok(response);

        //}


        #endregion
    }
}

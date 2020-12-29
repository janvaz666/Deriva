using core.entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace core.interfaces
{
    public interface IEspecialidadRepository
    {
        string Message();
        Task<IEnumerable<EspecialidadEntity>> GetEspecialidad();
        //bool Update(UnidadMedidaEntity entity);
        //bool Activate(UnidadMedidaEntity entity);
        //void Delete(UnidadMedidaEntity entity);
        //Task<IEnumerable<UnidadMedidaEntity>> GetAllUnidadMedida();
    }
}

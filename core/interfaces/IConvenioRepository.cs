using core.entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace core.interfaces
{
    public interface IConvenioRepository
    {
        string Message();
        Task<IEnumerable<ConvenioEntity>> GetConvenio();
        //bool Update(UnidadMedidaEntity entity);
        //bool Activate(UnidadMedidaEntity entity);
        //void Delete(UnidadMedidaEntity entity);
        //Task<IEnumerable<UnidadMedidaEntity>> GetAllUnidadMedida();
    }
}

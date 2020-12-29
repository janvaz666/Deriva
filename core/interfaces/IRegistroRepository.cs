using core.entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace core.interfaces
{
    public interface IRegistroRepository
    {
        

        string Message();
        int AddUpdate(RegistroEntity entity);
        //bool Update(UnidadMedidaEntity entity);
        //bool Activate(UnidadMedidaEntity entity);
        //void Delete(UnidadMedidaEntity entity);
        //Task<IEnumerable<UnidadMedidaEntity>> GetAllUnidadMedida();
    }
}

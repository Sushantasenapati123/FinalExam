using Final.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Irepository.IModel
{
    public interface IEntity
    {
        Task<List<Model>> BatchBind();
        Task<List<Model>> TechnologyBind();
        Task<List<Model>> EmployeeBind(int Batch_id, int Technology_id);
        Task<int> SaveMark(Model objassent);
        Task<List<Model>> ViewReport(int Batch_id);
    }
}

using Dapper;
using Exam.Domain.Sports;
using Final.Model.Entity;
using Final_Irepository.IModel;
using FstMonthExam.IRepository.Factory;
using PathoLab.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Rpeository.ModelRepo
{
    public class EntityRepository : RepositoryBase, IEntity
    {
        public EntityRepository(IConnectionFactory connectionFactory) : base(connectionFactory)
        {
        }
        public async Task<List<Model>> BatchBind()
        {
            try
            {
                DynamicParameters ObjParm = new DynamicParameters();
                ObjParm.Add("@ACTION", "BB");
                var query = "SP_EMPLOYEE_MARKLIST";
                ObjParm.Add("@P_MSGOUT", dbType: DbType.String, direction: ParameterDirection.Output, size: 5215585);

                var GetAppById = Connection.Query<Model>(query, ObjParm, commandType: CommandType.StoredProcedure).AsList();
                return GetAppById;


            }
            catch (Exception ex)
            {
                return null;

            }
        }

        public async Task<List<Model>> EmployeeBind(int Batch_id, int Technology_id)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@ACTION", "BE");
                param.Add("@Technology_id", Technology_id);
                param.Add("@Batch_id", Batch_id);
                var query = "SP_EMPLOYEE_MARKLIST";
                param.Add("@P_MSGOUT", dbType: DbType.String, direction: ParameterDirection.Output, size: 5215585);

                var GetAppById = Connection.Query<Model>(query, param, commandType: CommandType.StoredProcedure).AsList();
                return GetAppById;


            }
            catch (Exception ex)
            {
                return null;

            }
        }

        public async Task<int> SaveMark(Model objassent)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();

                param.Add("@ACTION", "IM");
                param.Add("@empid", objassent.empid);
                param.Add("@mark", objassent.mark);
                param.Add("@P_MSGOUT", dbType: DbType.String, direction: ParameterDirection.Output, size: 5215585);

                Connection.Execute("[SP_EMPLOYEE_MARKLIST]", param, commandType: CommandType.StoredProcedure);
                int x = Convert.ToInt32(param.Get<string>("@P_MSGOUT"));

                return x;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public async Task<List<Model>> TechnologyBind()
        {
            try
            {
                DynamicParameters ObjParm = new DynamicParameters();
                ObjParm.Add("@ACTION", "BT");
                var query = "SP_EMPLOYEE_MARKLIST";
                ObjParm.Add("@P_MSGOUT", dbType: DbType.String, direction: ParameterDirection.Output, size: 5215585);

                var GetAppById = Connection.Query<Model>(query, ObjParm, commandType: CommandType.StoredProcedure).AsList();
                return GetAppById;


            }
            catch (Exception ex)
            {
                return null;

            }
        }

        public async Task<List<Model>> ViewReport(int Batch_id)
        {
            try
            {
                DynamicParameters ObjParm = new DynamicParameters();
                ObjParm.Add("@ACTION", "VM");
                ObjParm.Add("@Batch_id", Batch_id);
                var query = "SP_EMPLOYEE_MARKLIST";
                ObjParm.Add("@P_MSGOUT", dbType: DbType.String, direction: ParameterDirection.Output, size: 5215585);

                var GetAppById = Connection.Query<Model>(query, ObjParm, commandType: CommandType.StoredProcedure).AsList();
                return GetAppById;


            }
            catch (Exception ex)
            {
                return null;

            }
        }
    }
}

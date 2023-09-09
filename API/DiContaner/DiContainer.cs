


using Exam.Irepository.ISport;
using Exam.Repository.PatientRepo;
using Final_Irepository.IModel;
using Final_Rpeository.ModelRepo;
using FstMonthExam.IRepository.Factory;
using FstMonthExam.Repository.Factory;



namespace Exam.Web.DiContaner
{
    public static class DiContainer
    {
        public static void AddCustomContainer(this IServiceCollection services, IConfiguration configuration)
        {
            IConnectionFactory connectionFactory = new ConnectionFactory(configuration.GetConnectionString("DefaultConnection"));
            services.AddSingleton(connectionFactory);
            // services.AddScoped<SpotInterface, PatientRepositary>();
            services.AddScoped<SpotInterface, PatientRepositary>();
            services.AddScoped<IEntity, EntityRepository>();


            //builder.Services.AddScoped<SpotInterface, PatientRepositary>();


        }
    }
}

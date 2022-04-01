using Autofac;
using NLayer.Core.Repositories;
using NLayer.Core.Services;
using NLayer.Core.UnitOfWorks;
using NLayer.Repository;
using NLayer.Repository.Repositories;
using NLayer.Repository.UnitOfWork;
using NLayer.Service.Mapping;
using NLayer.Service.Services;
using System.Reflection;
using Module = Autofac.Module;
namespace NLayer.Web.Modules
{
    public class RepoServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            //Generic
            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(Service<>)).As(typeof(IService<>)).InstancePerLifetimeScope();

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();


            //dinamik olarak class'ları ve interfaceleri alabilmek için assembly leri almamız lazım.

            var apiAssembly = Assembly.GetExecutingAssembly();

            var repoAssembly = Assembly.GetAssembly(typeof(AppDbContext));

            //direkt NLayer.Service olarak da vewrebiliriz fakat tip güvenirliği şeklinde gitmemiz daha doğru olacaktır.
            var serviceAssembly = Assembly.GetAssembly(typeof(MapProfile));
            
            //sonu repository ile biten class'ları ve buna eş gelen interfaceleri al.
            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly).Where(a=>a.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerLifetimeScope();

            //InstancePerLifetimeScope => Scope - Bir instance başladı bitene kadar aynı instance kullanılsın diyoruz
            //InstancePerDependency => transient - Her seferinde yeni bir instance oluşturması

            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly).Where(a => a.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerLifetimeScope();

        }
    }
}

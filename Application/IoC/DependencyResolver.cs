using Autofac;
using AutoMapper;
using Domain.Repositories;
using Infrastructure.Repositories;
using Application.Mapper;
using Application.Services.AppUserService;
using Application.Services.AuthorServices;
using Application.Services.ContactServices;
using Application.Services.PostServices;


namespace Application.DependencyResolver
{
    public class DependencyResolver : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ContactRepository>().As<IContactRepository>().InstancePerLifetimeScope();
            builder.RegisterType<AuthorRepository>().As<IAuthorRepository>().InstancePerLifetimeScope();
            builder.RegisterType<AppUserRepository>().As<IAppUserRepository>().InstancePerLifetimeScope();
            builder.RegisterType<PostRepository>().As<IPostRepository>().InstancePerLifetimeScope();

            builder.RegisterType<ContactService>().As<IContactService>().InstancePerLifetimeScope();
            builder.RegisterType<AuthorService>().As<IAuthorService>().InstancePerLifetimeScope();
            builder.RegisterType<PostService>().As<IPostService>().InstancePerLifetimeScope();
            builder.RegisterType<AppUserService>().As<IAppUserService>().InstancePerLifetimeScope();

            builder.Register(context => new MapperConfiguration(cfg =>
            {
                //Register Mapper Profile
                cfg.AddProfile<Mapping>();
            }
            )).AsSelf().SingleInstance();

            builder.Register(c =>
            {
                //This resolves a new context that can be used later.
                var context = c.Resolve<IComponentContext>();
                var config = context.Resolve<MapperConfiguration>();
                return config.CreateMapper(context.Resolve);
            })
            .As<IMapper>()
            .InstancePerLifetimeScope();


            base.Load(builder);
        }
    }
}

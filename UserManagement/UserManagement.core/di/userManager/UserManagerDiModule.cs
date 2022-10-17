using Autofac;
using Autofac.Core;
using Autofac.Core.Registration;
using UserManagement.core.Services.users;
using UserManagement.core.Services.users.dataStore;
using UserManagement.core.Services.users.Impl;
using UserManagement.core.shared;

namespace UserManagement.core.di.userManager;

public class UserManagerDiModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<UserManagerManager>().As<IUserManagerQuery>();
        builder.RegisterType<UserManagerManager>().As<IUserManagerCommand>();

        builder.RegisterType<UserStoreFactory>().As<IUserStoreFactory>();

        /*builder.RegisterType<UserMemoryStore>().As<IUserStore>().SingleInstance();
        builder.RegisterType<UserFileStore>().As<IUserStore>().SingleInstance();*/
    }
}

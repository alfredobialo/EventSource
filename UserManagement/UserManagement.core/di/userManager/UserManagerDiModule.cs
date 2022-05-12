using Autofac;
using UserManagement.core.Services.users;
using UserManagement.core.Services.users.dataStore;
using UserManagement.core.Services.users.Impl;

namespace UserManagement.core.di.userManager;

public class UserManagerDiModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<UserManagerManager>()
            .As<IUserManagerQuery>();  
        builder.RegisterType<UserManagerManager>()
                        .As<IUserManagerCommand>();

        builder.RegisterType<UserFileStore>()
            .As<IUserStore>().SingleInstance();
    }
}

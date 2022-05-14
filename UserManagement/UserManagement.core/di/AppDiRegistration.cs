using Autofac;
using UserManagement.core.di.userManager;
using UserManagement.core.Services.users.dataStore;
using UserManagement.core.shared;

namespace UserManagement.core.di;

public class AppDiRegistration : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterModule<UserManagerDiModule>();
    }
}

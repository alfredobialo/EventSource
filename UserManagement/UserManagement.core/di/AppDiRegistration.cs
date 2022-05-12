using Autofac;
using UserManagement.core.di.userManager;

namespace UserManagement.core.di;

public class AppDiRegistration : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterModule<UserManagerDiModule>();
    }
}

using System.Text;
using Newtonsoft.Json;
using UserManagement.core.shared;

namespace UserManagement.core.Services.users.dataStore;

public class UserFileStore : IUserStore
{
    private FileDataStoreManager<AppUserEntity> fileDbManager = null;
    public UserFileStore()
    {
        fileDbManager = new FileDataStoreManager<AppUserEntity>("users.json");
    }
    public async Task<CommandResponse> CreateUser(AppUserEntity user) => await fileDbManager.AddNewItem(user);
   
}

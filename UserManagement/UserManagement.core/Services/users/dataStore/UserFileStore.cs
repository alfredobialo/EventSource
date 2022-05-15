using System.Text;
using asom.lib.core;
using Newtonsoft.Json;
using UserManagement.core.shared;
using ICriteria = UserManagement.core.shared.ICriteria;

namespace UserManagement.core.Services.users.dataStore;

public class UserFileStore : IUserStore
{
    private FileDataStoreManager<AppUserEntity> fileDbManager = null;

    public UserFileStore()
    {
        fileDbManager = new FileDataStoreManager<AppUserEntity>("users.json");
    }

    public async Task<CommandResponse> CreateUser(AppUserEntity user) =>
        await fileDbManager.AddNewItem(user);

    public async Task<CommandResponse<AppUserEntity>> GetUser(string userId) =>
        await fileDbManager.GetItem(userId);

    public async Task<PagedCommandResponse<IEnumerable<AppUserEntity>>> GetUser(PagedDataCriteria criteria)
    {
        var data = await fileDbManager.GetItems();
        var result = new PagedCommandResponse<IEnumerable<AppUserEntity>>();
        if (criteria != null && data.Success)
        {
            result.SetPagerConfig(criteria);
            IEnumerable<AppUserEntity> filtered = data.Data;

            if (!string.IsNullOrEmpty(criteria.Query))
            {
                filtered = data.Data.Where(x => x.FirstName
                            .ToLower()
                            .StartsWith(criteria.Query.ToLower())
                        ||
                        x.LastName
                            .ToLower()
                            .StartsWith(criteria.Query.ToLower())
                        ||
                        x.Email
                            .ToLower()
                            .StartsWith(criteria.Query.ToLower())
                    )
                    .OrderBy(x => x.FirstName);
            }

            var filteredData = result.Paginate(filtered);
            result.Success = true;
            result.Data = filteredData;
        }

        return result;
    }
}

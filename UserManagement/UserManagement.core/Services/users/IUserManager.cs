using UserManagement.core.Services.users.model;
using UserManagement.core.Services.users.reqRes;
using UserManagement.core.shared;

namespace UserManagement.core.Services.users;

public interface IUserManagerCommand
 {
     Task<CommandResponse> AddUser(AppUser user);
     Task<CommandResponse> UpdateProfileName(UserProfileNameUpdateRequest request);
 }

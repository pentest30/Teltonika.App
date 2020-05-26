using System.Collections.Generic;
using System.Threading.Tasks;
using Teltonika.Core.Domain.Users;

namespace Teeltonika.Application.Service
{
    public interface IUserService
    {
        Task<UserApp> AuthenticateAsync(string username, string password);
        IEnumerable<UserApp> GetAll();
    }
}
using System.Net.Http;
using System.Threading.Tasks;
using Asdf.AdminMenu.Models.Role;
using Asdf.AdminMenu.Models.User;

namespace Asdf.AdminMenu.Services
{
    public interface IRoleService
    {
        Task<HttpResponseMessage> GetAllRoles();
        Task<HttpResponseMessage> CreateRole(CreateRole createRole);
    }
}
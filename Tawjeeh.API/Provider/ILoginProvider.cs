using System.Threading.Tasks;
using Tawjeeh.EntityModel;

namespace Tawjeeh.Api.Provider
{
    public interface ILoginProvider
    {
       Task<User> ValidatedUser(string userName, string password);      

    }
}
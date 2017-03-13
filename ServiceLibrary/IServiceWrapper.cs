using System.Threading.Tasks;
using LoginNavigation;

namespace ServiceLibrary
{
    public interface IServiceWrapper
    {
        Task<bool> ValidateUser(UserLoginModel loginModel);

        Task<string> RegisterUser(UserLoginModel loginModel);
    }
}
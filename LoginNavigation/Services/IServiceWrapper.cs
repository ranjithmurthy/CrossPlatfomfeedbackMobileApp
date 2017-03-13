using System.Threading.Tasks;
using LoginNavigation;

namespace ServiceLibrary
{
    public interface IServiceWrapper
    {
        Task<bool> ValidateUser(LoginViewModel loginModel);

        Task<string> RegisterUser(LoginViewModel loginModel);
        
       // Task<string> GetAllSurvery();

        Task<T> GetJsonData<T>() where T : new();

        Task<bool> SubmitUserFeedback(UserFeedbackViewModel userFeedback);
    }
}
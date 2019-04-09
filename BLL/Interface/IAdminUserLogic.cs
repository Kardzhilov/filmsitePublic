using Model.BLL;

namespace FilmSiteAdministration.BLL
{
    public interface IAdminUserLogic
    {
        bool CheckLoginCredentials(AdminUserModelBLL userInput);
        bool RegisterAdminUser(AdminUserModelBLL userInput);
    }
}
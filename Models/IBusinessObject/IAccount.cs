using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using resm_app.Models.BusinessObjects.Accounts;
using resm_app.Models.BusinessObjects.Employees;
using resm_app.ViewModels;
using AsignUser = resm_app.Models.BusinessObjects.Accounts.AsignUser;

namespace resm_app.Models.IBusinessObject
{
    public interface IAccount
    {
        Task<UserAccount> Login(LoginViewModel login);
        Task<int> InsertAcc(UserAccount employee);
        Task<int> UpdateAcc(UserAccount employee);
        Task<int> DeleteAcc(long Id,UserAccount userAccount);
        Task<List<UserRole>> RoleLists();
        Task<List<UserPermission>> UserPermissions();
        Task<List<UserAccount>> AccLists();
        Task<List<UserAccount>> UserLists();
        Task<UserAccount> GetAccById(long Id);
        Task<int> AsignAccount(AsignUser asignUser);
        Task<int> InsertAsignUser(AsignUser asignUser);

        Task<int> AddMenu(MenuPermission menu);
        Task<List<MenuPermission>> GetMenus();
        //Task<int> MenuUserAutoAdd(int UserId,int MenuId);
        Task<List<SetPermission>> GetMenuByUser(long UserId);
        Task<int> SavePermission(List<SetPermission> permissions);

        Task<List<MenuPermission>> GetMenuPermissions(long UserId);

    }
}
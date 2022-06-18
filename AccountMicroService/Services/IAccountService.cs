/*
 * By: voidotexe
 * https://www.github.com/voidotexe
*/

using System.Threading.Tasks;
using AccountMicroService.Data;

namespace AccountMicroService.Services
{
    public interface IAccountService
    {
        Task<int> SignUp(Account account);
        bool Login(Account account);
    }
}

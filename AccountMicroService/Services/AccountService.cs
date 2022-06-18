/*
 * By: voidotexe
 * https://www.github.com/voidotexe
*/

using System.Linq;
using System.Threading.Tasks;
using AccountMicroService.Data;

namespace AccountMicroService.Services
{
    public class AccountService : IAccountService
    {
        private readonly AccountsContext _context;

        public AccountService(AccountsContext context)
        {
            _context = context;
        }

        public async Task<int> SignUp(Account account)
        {
            account.PasswordHash = BCrypt.Net.BCrypt.HashPassword(account.PasswordHash);

            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();

            return account.Id;
        }

        public bool Login(Account account)
        {
            Account filteredAccount = _context.Accounts.First<Account>(element => element.Email == account.Email);

            return BCrypt.Net.BCrypt.Verify(account.PasswordHash, filteredAccount.PasswordHash);
        }
    }
}

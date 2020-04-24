using System.Threading.Tasks;
using ecommerce.Dtos;
using ecommerce.Model;

namespace Ecommerce_website.Data
{
    public interface IAuthRepository
    {
         Task<Customer> Register(CustomerToRegister customerToRegister);
         Task<Customer>GetCustomer(string email);
         Task<bool> UserExists(string email);
    }
}
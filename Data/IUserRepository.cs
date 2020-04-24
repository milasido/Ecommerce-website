using System.Collections.Generic;
using System.Threading.Tasks;
using ecommerce.Model;

namespace Ecommerce_website.Data
{
    public interface IUserRepository
    {
         public Task<Customer> getProfile(int id);
         public Task<Customer> getAddress(int id);

         public Task<int> SaveHistory(Orders orders);
         public int getLastestOrder();
         public void updateOrderDetails(OrderDetails itemToSave);
         public void SaveAllChange();
    }
}
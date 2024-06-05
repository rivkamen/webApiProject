//using Microsoft.EntityFrameworkCore;
//using System.Text.Json;
//namespace Repositories

//{
//    public class UserRepository : IUserRepository
//    {
//        private MyStore_325950947Context _picturesStoreContext;
//        public UserRepository(MyStore_325950947Context picturesStoreContext)
//        {
//            _picturesStoreContext = picturesStoreContext;
//        }



//        public async Task<User> getUserById(int id)
//        {
//            var foundUser = await _picturesStoreContext.Users.FindAsync(id);
//            if (foundUser==null)
//                return null;
//            await _picturesStoreContext.SaveChangesAsync();
//            return foundUser;
//        }



//        public async Task<User> GetUserByEmailAndPassword(UserLogin userLogin)
//        {
//            return await _picturesStoreContext.Users.Where(e => e.Email == userLogin.Email && e.Password == userLogin.Password).FirstOrDefaultAsync();
//        }




//        public async Task<User> addUser(User user)
//        {
//            try { 
//            await _picturesStoreContext.Users.AddAsync(user);           
//            await _picturesStoreContext.SaveChangesAsync();
//            return user;
//            }
//            catch (Exception err)
//            {
//                return null;
//            }
//        }





//        public async Task<User> updateUser(int id, User userToUpdate)
//        {
//            try {
//                userToUpdate.UserId = id;
//                _picturesStoreContext.Update(userToUpdate);
//                await _picturesStoreContext.SaveChangesAsync();
//                return userToUpdate;
//            } catch(Exception err)
//            {
//                throw err;
//            }



//        }


//    }
//}


using DTOs;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace Repositories

{
    public class CategoryRepository : ICategoryRepository
    {
        private MyStore_325950947Context _picturesStoreContext;
        public CategoryRepository(MyStore_325950947Context picturesStoreContext)
        {
            _picturesStoreContext = picturesStoreContext;
        }


        public Task<User> addCategory(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Category>> getCategories()
        {
            var foundCategories = await _picturesStoreContext.Categories.ToListAsync();
            if (foundCategories == null)
                return null;
            return foundCategories;
        }

        public Task<CategoryDto> getCategoryById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Category> updateCategory(int id, User userToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}

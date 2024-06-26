﻿using DTOs;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;


namespace Repositories

{
    public class UserRepository : IUserRepository
    {
        private MyStore_325950947Context _picturesStoreContext;
        public UserRepository(MyStore_325950947Context picturesStoreContext)
        {
            _picturesStoreContext = picturesStoreContext;
        }

        public async Task<User> getUserById(int id)
        {
            var foundUser = await _picturesStoreContext.Users.FindAsync(id);
            if (foundUser == null)
                return null;
            await _picturesStoreContext.SaveChangesAsync();
            return foundUser;
        }

        public async Task<User> addUser(User user)
        {
            try
            {
                await _picturesStoreContext.Users.AddAsync(user);
                await _picturesStoreContext.SaveChangesAsync();
                return user;
            }
            catch (Exception err)
            {
                return null;
            }
        }

        public async Task<User> updateUser(int id, User userToUpdate)
        {
            try
            {
                userToUpdate.UserId = id;
                _picturesStoreContext.Update(userToUpdate);
                await _picturesStoreContext.SaveChangesAsync();
                return userToUpdate;
            }
            catch (Exception err)
            {
                throw err;
            }
        }
        public async Task<User> GetUserByEmailAndPassword(User userLogin)
        {

            return await _picturesStoreContext.Users.Where(e => e.Email == userLogin.Email && e.Password == userLogin.Password).FirstOrDefaultAsync();


        }

        
    }
}

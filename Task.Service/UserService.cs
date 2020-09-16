using System;
using System.Collections.Generic;
using System.Text;
using Task.Domain;
using Task.Repo;

namespace Task.Service
{
    public  class UserService: IUserService
    {
        private IRepository<User> userRepository;
        private IRepository<Adress> userAdressRepository;

        public UserService(IRepository<User> userRepository, IRepository<Adress> _userAdressRepository)
        {
            this.userRepository = userRepository;
            this.userAdressRepository = _userAdressRepository;
        }

        public IEnumerable<User> GetUsers()
        {
            return userRepository.GetAll();
        }

        public User GetUser(long id)
        {
            return userRepository.Get(id);
        }

        public void InsertUser(User user)
        {
            userRepository.Insert(user);
        }
        public void UpdateUser(User user)
        {
            userRepository.Update(user);
        }

        public void DeleteUser(long id)
        {
            Adress userProfile = userAdressRepository.Get(id);
            userAdressRepository.Remove(userProfile);
            User user = GetUser(id);
            userRepository.Remove(user);
            userRepository.SaveChanges();
        }
    }
}

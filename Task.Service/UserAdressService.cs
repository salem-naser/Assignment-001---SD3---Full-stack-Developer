using System;
using System.Collections.Generic;
using System.Text;
using Task.Domain;
using Task.Repo;

namespace Task.Service
{
    public class  UserAdressService:IUserAdressService
    {
        private IRepository<Adress> userAdressRepository;

        public UserAdressService(IRepository<Adress> _userAdressRepository)
        {
            this.userAdressRepository = _userAdressRepository;
        }

        public Adress GetUserProfile(long id)
        {
            return userAdressRepository.Get(id);
        }
    }
}

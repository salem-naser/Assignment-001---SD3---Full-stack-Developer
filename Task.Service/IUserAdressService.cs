using System;
using System.Collections.Generic;
using System.Text;
using Task.Domain;

namespace Task.Service
{
    public interface IUserAdressService
    {
         Adress GetUserProfile(long id);
    }
}

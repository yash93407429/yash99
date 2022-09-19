using EGroceryStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EGroceryStore.Core
{
    public interface IUser
    {
        Task<Responsemodel> Signup(User user);
        Task<Responsemodel> Login(Loginmodel loginmodel);
    }
}

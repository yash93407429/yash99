using EGroceryStore.DataAccess;
using EGroceryStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EGroceryStore.Core
{
    public class UserAccess : IUser
    {
        private readonly DB_Context dB_Context;

        public UserAccess(DB_Context context)
        {
            dB_Context = context;
        }
        public Task<Responsemodel> Login(Loginmodel loginmodel)
        {
            throw new NotImplementedException();
        }



        public async Task<Responsemodel> Signup(User user)
        {
            try
            {
                var res = dB_Context.usertable.Add(user);
                await dB_Context.SaveChangesAsync();
                if (res != null)
                {
                    Responsemodel responsemodel = new Responsemodel();
                    responsemodel.Message = "Registration Successfull";
                    return responsemodel;
                }
                else
                {
                    throw new Exception("Registration Failed");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}

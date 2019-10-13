using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Dto;

namespace WebApi.Services
{
    public class CRUDService
    {
        public int Add( Users user)
        {
            int i = 0;
            try
            {
                user.Id = 0;
                DBHelper db = new DBHelper();
                db.Users.Add(user);
                db.SaveChanges();
                i = 1;
            }
            catch (Exception ex)
            {
                i = -100;
            }
            return i;
            
        }
    }
}

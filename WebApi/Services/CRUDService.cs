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


        public List<Users> QueryS()
        {

            DBHelper db = new DBHelper();
            List<Users> users = db.Users.ToList();
            List<MainMenu> menus = db.MainMenu.ToList();
            int id = users.OrderByDescending(x => x.Id).FirstOrDefault().Id;
            foreach (var item in menus)
            {
                var lst = users.Where(x => x.Id == item.Id).FirstOrDefault();
                if (lst != null)
                {
                    users.ForEach(i =>
                    {
                        if(i.Id == item.Id)
                        {
                            i.Status = i.Status + item.Status;
                        }
                    });
                }
                else
                {
                    Users u = new Users()
                    {
                        Id = id + 1,
                        Status = item.Status
                    };
                    id += 1;
                    users.Add(u);
                }
            }
            return users;


        }
    }
}

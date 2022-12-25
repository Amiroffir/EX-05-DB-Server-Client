using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX_05.Entities
{
    public class ContactUsEntity
    {
        public void AddContactUsToDB(Model.ContactUs contactUs)
        {
            DAL.SQLQuery.RunNonQuery("INSERT INTO [dbo].[ContactUs] ([Name],[Email],[Message]) VALUES ('" + contactUs.Name + "','" + contactUs.Email + "','" + contactUs.Message + "')");
        }

    }
}

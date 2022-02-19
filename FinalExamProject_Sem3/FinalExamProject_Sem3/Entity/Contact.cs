using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalExamProject_Sem3.Entity
{
    public class Contact
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }

        public Contact()
        {

        }

        public Contact(int id, string name, string phone)
        {
            this.ID = id;
            this.Name = name;
            this.PhoneNumber = phone;
        }
    }
}

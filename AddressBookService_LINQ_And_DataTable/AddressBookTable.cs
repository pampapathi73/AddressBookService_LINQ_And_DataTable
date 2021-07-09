using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace AddressBookService_LINQ_And_DataTable
{
    class AddressBookTable
    {
        public DataTable AddAddressBookDataTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add("FirstName", typeof(string));
            table.Columns.Add("LastName", typeof(string));
            table.Columns.Add("Address", typeof(string));
            table.Columns.Add("City", typeof(string));
            table.Columns.Add("State", typeof(string));
            table.Columns.Add("Zip", typeof(int));
            table.Columns.Add("PhoneNumber", typeof(long));
            table.Columns.Add("Email", typeof(string));

            table.Rows.Add("mani", "Sharma", "House no 4", "TSK", "Assam", 786643, 997325546, "Mani@gmail.com");
            table.Rows.Add("Alok", "Das", "ITPL", "Bangalore", "Karnataka", 40002, 999000880, "Alok@gmail.com");
            table.Rows.Add("Mounesh", "Baruah", "Panji", "Panaji", "Goa", 43254, 7777743210, "Mounesh@gmail.com");
            table.Rows.Add("Rama", "Phukon", "Park street", "Kolkata", "West Bangal", 43254, 7877743990, "Rama@gmail.com");
            table.Rows.Add("rahul", "Chetia", "GH road", "Ghy", "Assam", 43254, 7888743210, "rahul@gmail.com");

            return table;
        }
        public void DisplayContacts(DataTable addresstable)
        {
            var contacts = addresstable.Rows.Cast<DataRow>();
            foreach (var contact in contacts)
            {
                Console.WriteLine("\n------------------------------------");
                Console.Write("First Name : " + contact.Field<string>("FirstName") + " " + "Last Name : " + contact.Field<string>("LastName") + " " + "Address : " + contact.Field<string>("Address") + " " + "City : " + contact.Field<string>("City") + " " + "State : " + contact.Field<string>("State")
                    + " " + "Zip : " + contact.Field<int>("Zip") + " " + "Phone Number : " + contact.Field<long>("PhoneNumber") + " " + "Email : " + contact.Field<string>("Email") + " ");
            }
        }
    
    }
}

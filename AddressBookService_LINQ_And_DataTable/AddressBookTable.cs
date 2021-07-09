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
            table.Columns.Add("AddressBookType", typeof(string));
            table.Columns.Add("AddressBookName", typeof(string));


            table.Rows.Add("Tina", "Sharma", "House no 4", "TSK", "Assam", 786643, 997325546, "tina@gmail.com");
            table.Rows.Add("Asha", "Das", "ITPL", "Bangalore", "Karnataka", 40002, 999000880, "asha@gmail.com");
            table.Rows.Add("Prakash", "Baruah", "Panji", "Panaji", "Goa", 43254, 7777743210, "prakash@gmail.com");
            table.Rows.Add("Rama", "Phukon", "Park street", "Kolkata", "West Bangal", 43254, 7877743990, "Rama@gmail.com");
            table.Rows.Add("Rekha", "Chetia", "GH road", "Ghy", "Assam", 43254, 7888743210, "rekha@gmail.com");
            
            table.Rows.Add("Tina", "Sharma", "House no 4", "TSK", "Assam", 786643, 997325546, "tina@gmail.com","Friends","Book1");
            table.Rows.Add("Asha", "Das", "ITPL", "Bangalore", "Karnataka", 40002, 999000880, "asha@gmail.com","Family","Book3");
            table.Rows.Add("Prakash", "Baruah", "Panji", "Panaji", "Goa", 43254, 7777743210, "prakash@gmail.com","Profession","Book2");
            table.Rows.Add("Rama", "Phukon", "Park street", "Kolkata", "West Bangal", 43254, 7877743990, "Rama@gmail.com","Friends","Book4");
            table.Rows.Add("Rekha", "Chetia", "GH road", "Ghy", "Assam", 43254, 7888743210, "rekha@gmail.com","Profession","Book6");


            return table;
        }
        public void DisplayContacts(DataTable addresstable)
        {
            var contacts = addresstable.Rows.Cast<DataRow>();
            foreach (var contact in contacts)
            {

                Console.Write("First Name : " + contact.Field<string>("FirstName") + " " + "Last Name : " + contact.Field<string>("LastName") + " " + "Address : " + contact.Field<string>("Address") + " " + "City : " + contact.Field<string>("City") + " " + "State : " + contact.Field<string>("State")
                    + " " + "Zip : " + contact.Field<int>("Zip") + " " + "Phone Number : " + contact.Field<long>("PhoneNumber") + " " + "Email : " + contact.Field<string>("Email") + " " + "AddressBookType : " + contact.Field<string>("AddressBookType") + " " + "AddressBookName : " + contact.Field<string>("AddressBookName") + " ");
                Console.WriteLine("\n------------------------------------");
            }
        }

        public void EditContact(DataTable table)
        {
            var contacts = table.AsEnumerable().Where(x => x.Field<string>("FirstName") == "Asha");
            foreach (var contact in contacts)
            {
                contact.SetField("LastName", "Das");
                contact.SetField("City", "Mumbai");
                contact.SetField("State", "Maharashtra");
            }

            Console.WriteLine("The Contact is updated succesfully\n");
            DisplayContacts(contacts.CopyToDataTable());
        }
        public void DeleteContact(DataTable table)
        {
            var contacts = table.AsEnumerable().Where(x => x.Field<string>("FirstName") == "Asha");
            foreach (var row in contacts.ToList())
            {
                row.Delete();
            }
            Console.WriteLine("The Contact is deleted succesfully. Now the list contains following records \n");
            DisplayContacts(table);
        }
        public void RetrieveContactBelongingToCityOrState(DataTable table)
        {
            var contacts = table.AsEnumerable().Where(x => x.Field<string>("State") == "Assam");
            foreach (var contact in contacts)
            {
                Console.Write("First Name : " + contact.Field<string>("FirstName") + " " + "Last Name : " + contact.Field<string>("LastName") + " " + "Address : " + contact.Field<string>("Address") + " " + "City : " + contact.Field<string>("City") + " " + "State : " + contact.Field<string>("State")
                     + " " + "Zip : " + contact.Field<int>("Zip") + " " + "Phone Number : " + contact.Field<long>("PhoneNumber") + " " + "Email : " + contact.Field<string>("Email") + " ");
                Console.WriteLine("\n------------------------------------");
            }

        }
        public void GetSizeByCityOrState(DataTable table)
        {
            var contacts = table.Rows.Cast<DataRow>()
                             .GroupBy(x => x["State"].Equals("Assam")).Count();
            Console.WriteLine(" : {0} ", contacts);
        }

        public void SortContacts(DataTable table)
        {
            var contacts = table.Rows.Cast<DataRow>()
                           .OrderBy(x => x.Field<string>("FirstName"));
            DisplayContacts(contacts.CopyToDataTable());
        }
        public void GetCountByType(DataTable table)
        {
            var friendsContacts = table.Rows.Cast<DataRow>()
                                         .Where(x => x["AddressBookType"].Equals("Friends")).Count();
            Console.WriteLine("'Friends' : {0} ", friendsContacts);
            var familyContact = table.Rows.Cast<DataRow>()
                             .Where(x => x["AddressBookType"].Equals("Family")).Count();
            Console.WriteLine("'Family' : {0} ", familyContact);
            var ProfessionalContact = table.Rows.Cast<DataRow>()
                             .Where(x => x["AddressBookType"].Equals("Profession")).Count();
            Console.WriteLine("'Profession' : {0} ", ProfessionalContact);
        }
    }
}

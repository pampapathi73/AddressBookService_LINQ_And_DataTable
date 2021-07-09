using System;
using System.Data;

namespace AddressBookService_LINQ_And_DataTable
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to AddressBookService LINQ And DataTable ");
            AddressBookTable addressBookTable = new AddressBookTable();
            DataTable dataTable = addressBookTable.AddAddressBookDataTable();
            addressBookTable.DisplayContacts(dataTable);
        }
    }
}

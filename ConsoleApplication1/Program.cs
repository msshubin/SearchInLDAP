using System;
using System.DirectoryServices;

namespace SearchInLDAP
{
    class Program
    {
        static void Main(string[] args)
        {
            // Показывает дерево Active Directory
            DirectoryEntry de = new DirectoryEntry("LDAP://elewise.local/dc=elewise,dc=local", null, null, AuthenticationTypes.Secure);
            DirectorySearcher ds = new DirectorySearcher(de)
            {
                PageSize = int.MaxValue//,
                //                Filter = string.Format("(&(objectCategory=person)(objectClass=user)(sAMAccountName={0}))", "shubin") // Выбрать пользователя по логину
            };
            foreach (SearchResult result in ds.FindAll())
            {
                try
                {
                    Console.WriteLine("result.GetDirectoryEntry().Name: " + result.GetDirectoryEntry().Name);
                }
                catch {
                    Console.WriteLine("---нет параметра name");
                }
                Console.ReadKey();
            }
        }
    }
}

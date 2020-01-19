using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;

namespace ScratchActiveDirectory
{
    internal class ADUser
    {
        public ADUser()
        {

        }

        public void Run(string[] args)
        {
            Console.Clear();
            Console.WriteLine("*** Test AD User ***");

            try
            {
                if (args == null || args.Length == 0)
                {
                    Print.PrintUser(UserPrincipal.Current, "CURRENT USER INFO");
                    Console.WriteLine("TestADUser completed. Press enter to close application.");
                    Console.ReadLine();
                }
                else
                {

                    // Replace this with the domain that you want to test
                    string DomainName = "DomainName";
                    using (var pc = new PrincipalContext(ContextType.Domain, DomainName, null, ContextOptions.Negotiate))
                    {
                        Console.WriteLine($"ConnectedServer : [{pc.ConnectedServer}]");
                        Console.WriteLine($"Container : [{pc.Container}]");
                        Console.WriteLine($"pc.Name : [{pc.Name}]");
                        Console.WriteLine($"pc.UserName : [{pc.UserName}]");

                        // Get the UserId and insert it here to test
                        Guid userId = Guid.Empty;
                        GetUser(pc, userId.ToString(), IdentityType.Guid);

                        //Username
                        GetUser(pc, args[0], IdentityType.Name);

                        //UserPrincipalName
                        if (!GetUser(pc, args[0], IdentityType.UserPrincipalName))
                            GetUser(pc, args[0]);



                        //A list of roles that you want to test
                        var roles = new List<string> { "Administrator",
                                        "PowerUser",
                                        "User"};

                        //List of usernames that needs to be tested
                        var servaccounts = new List<string> { "User1",
                                                "User2",
                                                "User3"};

                        var roleAndusers = new Dictionary<string, List<string>>();

                        //Group + Users. Test is the users are in the groups
                        roleAndusers.Add("Admins", new List<string> { "Administrator" });
                        roleAndusers.Add("Super Users", new List<string> { "User4", "User5", "MarketingPerson" });
                        roleAndusers.Add("Blocked", new List<string> { });
                        roleAndusers.Add("IT", new List<string> { "TriedRebooting", "Format" });

                        if (roleAndusers.Count != roles.Count)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"The number of roles and the number of items in the dictionary do not match. Testing may miss problems");
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("### An error occurred ###");
                while (ex != null)
                {
                    Console.WriteLine(ex.Message);
                    ex = ex.InnerException;
                }
                Console.ReadLine();
            }

            Console.WriteLine("TestADUser completed.");
        }

        private static bool GetUser(PrincipalContext pc, string value, IdentityType? idType = null)
        {
            try
            {
                UserPrincipal user = null;

                if (idType.HasValue)
                {
                    if (idType == IdentityType.UserPrincipalName)
                    {
                        //Add the domain url
                        value += "@users.something.com";
                    }
                    user = UserPrincipal.FindByIdentity(pc, idType.Value, value);
                }
                else
                {
                    user = UserPrincipal.FindByIdentity(pc, value);
                }

                if (user == null)
                {
                    Console.WriteLine($"Unable to find user with [{idType.ToString()}] [{value}]");
                    return false;
                }
                else
                {
                    Print.PrintUser(user, $"{idType.ToString()}: {value}", true);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"### Error TestUser [{idType.ToString()}]:[{value}]");
                while (ex != null)
                {
                    Console.WriteLine(ex.Message);
                    ex = ex.InnerException;
                }
                return false;
            }
        }



        private static void DoUsersExist(PrincipalContext context, List<string> servaccounts)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("### Testing if all the users exist.");
            List<string> notfound = new List<string>();
            string domainURL = "@somedomain.com";

            foreach (var sa in servaccounts)
            {

                UserPrincipal user = UserPrincipal.FindByIdentity(context, IdentityType.UserPrincipalName, sa + domainURL);
                if (user == null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"[{sa}] does not exist");
                    notfound.Add(sa);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"[{sa}] exists");
                    //if (showDetail)
                    //    Print.PrintGroup(group, true, true);
                }
            }


            Console.ResetColor();
            Console.WriteLine("\n=============================================");
        }


    }
}

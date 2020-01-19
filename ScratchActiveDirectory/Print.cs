using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Text;

namespace ScratchActiveDirectory
{
    internal class Print
    {
        public static void PrintUser(UserPrincipal user, string heading, bool showGroups = false)
        {
            if (!String.IsNullOrEmpty(heading))
                Console.WriteLine($"*** {heading} ***");
            Console.WriteLine("Name: " + user.Name);
            Console.WriteLine("GUID: " + user.Guid);
            Console.WriteLine("SID: " + user.Sid);
            Console.WriteLine("UPN: " + user.UserPrincipalName);
            Console.WriteLine("Locked Out: " + user.IsAccountLockedOut());

            if (showGroups)
            {
                Console.WriteLine("Groups: ");
                foreach (var g in user.GetGroups().OrderBy(x => x.Name))
                {
                    Console.WriteLine($"\t{g.Name}");
                }
                Console.WriteLine("Authorization Groups: ");
                foreach (var eg in user.GetAuthorizationGroups().OrderBy(x => x.Name))
                {
                    Console.WriteLine($"\t{eg.Name}");
                }
            }

            Console.WriteLine("===================================");

        }

        public static void PrintGroup(GroupPrincipal group, bool showMembers = false, bool showGroups = false)
        {
            Console.WriteLine("Name: " + group.Name);
            Console.WriteLine("DistinguishedName: " + group.DistinguishedName);
            Console.WriteLine("DisplayName: " + group.DisplayName);
            Console.WriteLine("SamAccountName: " + group.SamAccountName);
            Console.WriteLine("UserPrincipalName: " + group.UserPrincipalName);
            Console.WriteLine("Description: " + group.Description);
            Console.WriteLine("IsSecurityGroup: " + group.IsSecurityGroup);
            //Console.WriteLine(": " + group.GroupScope.);
            Console.WriteLine("Guid: " + group.Guid);
            Console.WriteLine("Sid: " + group.Sid);

            if (showMembers)
            {
                Console.WriteLine();
                Console.WriteLine("Members:");
                if (group.Members.Count > 0)
                {
                    foreach (var user in group.Members.OrderBy(x => x.Name))
                    {
                        if (user is UserPrincipal)
                            Print.PrintUser(user as UserPrincipal, "");

                        if (user is GroupPrincipal)
                            Print.PrintGroup(group as GroupPrincipal);
                    }
                }
                else
                {
                    Console.WriteLine("\tNo Members");
                }

            }

            if (showGroups)
            {
                Console.WriteLine();
                Console.WriteLine("Member Of:");
                var groups = group.GetGroups().OrderBy(x => x.Name);
                if (groups.Count() > 0)
                {
                    foreach (GroupPrincipal g in groups)
                    {
                        Print.PrintGroup(g, false, false);
                    }
                }
                else
                {
                    Console.WriteLine("\tNo Membership");
                }
            }

            Console.WriteLine("===================================");
        }
    }
}

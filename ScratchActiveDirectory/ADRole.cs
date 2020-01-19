using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;

namespace ScratchActiveDirectory
{
    public class ADRole
    {
        public void DoRolesExist(PrincipalContext context, List<string> roles, bool showDetail = false)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("### Testing if all the roles exist.");
            List<string> notfound = new List<string>();
            foreach (string role in roles)
            {
                using (var group = GroupPrincipal.FindByIdentity(context, role))
                {
                    if (group == null)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"[{role}] does not exist");
                        notfound.Add(role);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"[{role}] exists");
                        if (showDetail)
                            Print.PrintGroup(group, true, true);
                    }
                }
            }

            Console.ResetColor();
            Console.WriteLine("\n=============================================");
        }
    }
}

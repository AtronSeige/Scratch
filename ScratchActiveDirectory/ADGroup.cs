using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Linq;

namespace ScratchActiveDirectory
{
    public class ADGroup
    {
        public void AreGroupsAssigned(PrincipalContext context, Dictionary<string, List<string>> roleAndusers)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("### Testing if the users/groups are in the correct roles.");
            bool error = false;
            List<string> notfound = new List<string>();

            foreach (var item in roleAndusers)
            {
                if (item.Value != null && item.Value.Count > 0)
                {
                    using (var group = GroupPrincipal.FindByIdentity(context, item.Key))
                    {
                        if (group == null)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"[{item.Key}] does not exist. Could not validate users");
                            error = true;
                            notfound.Add($"[{item.Key}] missing");
                        }
                        else
                        {
                            foreach (var name in item.Value)
                            {
                                if (group.Members.Any(x => x.Name.ToUpper() == name.ToUpper()))
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine($"[{name}] exists IN [{item.Key}]");
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine($"[{ name}] is missing from [{item.Key}]");
                                    error = true;
                                    notfound.Add($"[{name}] is missing from [{item.Key}]");
                                }
                            }
                        }
                    }
                }
                else
                {
                    Console.ResetColor();
                    Console.WriteLine($"{item.Key} does not have any listed members to validate.");
                }
            }

            Console.ResetColor();
            Console.WriteLine("\n=============================================");
        }
    }
}

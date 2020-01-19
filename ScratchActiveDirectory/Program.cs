using System;

namespace ScratchActiveDirectory
{
    class Program
    {
        static void Main(string[] args)
        {
            var adUser = new ADUser();
            adUser.Run(null);
        }
    }
}

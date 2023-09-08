// See https://aka.ms/new-console-template for more information
using System;

Console.WriteLine("Hello, World!");

string path = Path.Combine(@"c:\blah", "bling.txt");
Uri uri = new Uri(path);
Console.WriteLine(uri.LocalPath);

//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
using System;
using System.Reflection;
using System.IO;
using Lib;

class deps
{
    class Env
    {
        public string Reports => Environment.GetEnvironmentVariable("reports");
    }

    public static void Main(params string[] args)
    {
        var env = new Env();
        var dst = env.Reports + "\\deps.csv";
        using var writer = new StreamWriter(dst);
        var assembly = Assembly.GetEntryAssembly();
        var path = assembly.Location;
        var home = Path.GetDirectoryName(path);
        var files = Directory.GetFiles(home);
        foreach(var file in files)
        {
            term.print(file);
            writer.WriteLine(file);
        }

    }
}
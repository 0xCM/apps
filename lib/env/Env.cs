//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Reflection;
    using System.Collections;

    using static Root;
    using static core;

    using N = EnvVarNames;

    public class Env : IEnvProvider
    {
        public static Env load()
            => new Env();

        public static ReadOnlySpan<EnvVar> vars()
        {
            var dst = list<EnvVar>();
            foreach(DictionaryEntry kv in Environment.GetEnvironmentVariables())
                 dst.Add(new EnvVar(kv.Key?.ToString() ?? EmptyString, kv.Value?.ToString() ?? EmptyString));
            return dst.ViewDeposited();
        }

        public PartId AppId
            => Assembly.GetEntryAssembly().Id();

        Env()
        {
            var dst = this;
            dst.ZEnvDb = dir(N.ZEnvDb);
            dst.ZDev = dir(N.ZDev);
            dst.Db = dir(N.Db);
            dst.Control = dir(N.Control);
            dst.Packages = dir(N.Packages);
            dst.Tools = dir(N.Tools);
            dst.Archives = dir(N.Archives);
            dst.Logs = dir(N.Logs);
            dst.ZBin = dir(N.ZBin);
            dst.DevRoot = dir(N.DevRoot);
            dst.Tmp = dir(N.ZTmp);
            dst.CdbLogPath = path(N.CdbLogPath);
            dst.DefaultSymbolCache = dir(N.DefaultSymbolCache);
            dst.SymCacheRoot = dir(N.SymCacheRoot);
            dst.CacheRoot = dir(N.CacheRoot);
            dst.Libs = dir(N.Libs);
            dst.DataRoot = dir(N.ZData);
            dst.VendorDocs = dir(N.VendorDocs);
            dst.CapturePacks = dir(N.CapturePacks);
            dst.CpuCount = number(N.CpuCount);
            dst.DevWs = dir(N.DevWs);
            dst.LlvmRoot = dir(N.LlvmRoot);
            dst.Toolbase = dir(N.Toolbase);
        }

        public EnvDirVar ZEnvDb;

        public EnvDirVar ZDev;

        public EnvDirVar DevRoot;

        public EnvDirVar Db;

        public EnvDirVar Control;

        public EnvDirVar Packages;

        public EnvDirVar Tools;

        public EnvDirVar Toolbase;

        public EnvDirVar Archives;

        public EnvDirVar Logs;

        public EnvDirVar Tmp;

        public EnvDirVar ZBin;

        public EnvPathVar CdbLogPath;

        public EnvDirVar SymCacheRoot;

        public EnvDirVar DefaultSymbolCache;

        public EnvDirVar CacheRoot;

        public EnvDirVar Libs;

        public EnvDirVar DataRoot;

        public EnvDirVar VendorDocs;

        public EnvDirVar CapturePacks;

        public EnvDirVar LlvmRoot;

        public EnvVar<ulong> CpuCount;

        public EnvDirVar DevWs;


        public EnvData Data
            => new EnvData(this);

        public string Format()
        {
            var dst = text.buffer();
            var vars = Provided;
            var count = vars.Length;
            iter(vars, var => dst.AppendLine(var.Format()));
            return dst.Emit();
        }

        public string Format(VarContextKind vck)
        {
            var dst = text.buffer();
            var vars = Provided;
            var count = vars.Length;
            iter(vars, var => dst.AppendLine(var.Format(vck)));
            return dst.Emit();
        }

        public override string ToString()
            => Format();

        public ReadOnlySpan<IEnvVar> Provided
            => Members(this);

        EnvData IEnvProvider.Env
            => Data;

        [Op]
        static EnvDirVar dir(string name)
        {
            var value = Environment.GetEnvironmentVariable(name);
            if(text.blank(value))
                @throw($"The environment variable '{name}' is undefined");
            return (name, FS.dir(value));
        }

        static EnvVar<ulong> number(string name)
        {
            var value = Environment.GetEnvironmentVariable(name);
            if(text.blank(value))
                return (name,0ul);

            if(ulong.TryParse(value, out var n))
                return (name,n);

            return (name,0);
        }

        [Op]
        static EnvPathVar path(string name)
        {
            var value = Environment.GetEnvironmentVariable(name);
            if(text.blank(value))
                @throw($"The environment variable '{name}' is undefined");
            return (name, FS.path(value));
        }

        static Index<IEnvVar> Members(Env src)
            => typeof(Env).GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly).Select(x => (IEnvVar)x.GetValue(src));
    }
}
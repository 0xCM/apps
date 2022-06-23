//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using N = EnvVarNames;

    public class Env : IEnvProvider
    {
        public static Env load()
            => new Env();

        [Op]
        static EnvDirVar dir(string name)
        {
            var value = Environment.GetEnvironmentVariable(name);
            var dst = EnvDirVar.Empty;
            if(text.blank(value))
                dst = (name,FS.dir("Z:/env"));
            return (name, FS.dir(value));
        }

        Env()
        {
            var dst = this;
            dst.ZDev = dir(N.ZDev);
            dst.Db = dir(N.Db);
            dst.Control = dir(N.Control);
            dst.Packages = dir(N.Packages);
            dst.Tools = dir(N.Tools);
            dst.Logs = dir(N.Logs);
            dst.CacheRoot = dir(N.CacheRoot);
            dst.Libs = dir(N.Libs);
            dst.CapturePacks = dir(N.CapturePacks);
            dst.DevWs = dir(N.DevWs);
            dst.LlvmRoot = dir(N.LlvmRoot);
        }

        public EnvDirVar ZDev;

        public EnvDirVar Db;

        public EnvDirVar Control;

        public EnvDirVar Packages;

        public EnvDirVar Tools;

        public EnvDirVar Logs;

        public EnvDirVar CacheRoot;

        public EnvDirVar Libs;

        public EnvDirVar CapturePacks;

        public EnvDirVar LlvmRoot;

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

        static Index<IEnvVar> Members(Env src)
            => typeof(Env).GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly).Select(x => (IEnvVar)x.GetValue(src));
    }
}
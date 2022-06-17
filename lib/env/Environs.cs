//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public partial class Environs
    {
        public static MachineEnv machine()
            => new MachineEnv(vars());

        public static EnvSet set(FS.FilePath src, char sep)
        {
            var result = Outcome.Success;
            var _name = text.left(src.FileName.Format(), Chars.Dot);

            var vars = list<EnvVar>();
            var lookup = dict<VarSymbol,object>();
            using var reader = src.Utf8LineReader();
            while(reader.Next(out var line))
            {
                var content = line.Content;
                var i = text.index(content,sep);
                if(i > 0)
                {
                    var name = text.left(content,i);
                    var value = text.right(content,i);
                    vars.Add((name,value));
                    lookup.TryAdd(name,value);
                }
            }

            return new EnvSet(_name, lookup, vars.Array());
        }

        public static EnvSet<S> set<S>(string name, S src)
            where S : struct
        {
            var values = ClrFields.values(src).Select(x => (Name:new VarSymbol(x.Field.Name), x.Value));
            var lookup = values.ToDictionary();
            var vars = values.Select(x => new EnvVar(x.Name, x.Value?.ToString()));
            return  new EnvSet<S>(name, lookup, src, vars);
        }

        public static Index<EnvVar> vars()
        {
            var dst = list<EnvVar>();
            foreach(DictionaryEntry kv in Environment.GetEnvironmentVariables())
                 dst.Add(new EnvVar(kv.Key?.ToString() ?? EmptyString, kv.Value?.ToString() ?? EmptyString));
            return dst.ToArray();
        }

        public static EnvVar<FS.FolderPath> dir(string name)
        {
            var value = Environment.GetEnvironmentVariable(name);
            var dst = EnvDirVar.Empty;
            if(text.blank(value))
                dst = (name,FS.dir("Z:/env"));
            return (name, FS.dir(value));
        }

        public static EnvVar<ulong> number(string name)
        {
            var value = Environment.GetEnvironmentVariable(name);
            if(text.blank(value))
                return (name,0ul);

            if(ulong.TryParse(value, out var n))
                return (name,n);

            return (name,0);
        }

        public static EnvVar<FS.FilePath> path(string name)
        {
            var value = Environment.GetEnvironmentVariable(name);
            if(text.blank(value))
                @throw($"The environment variable '{name}' is undefined");
            return (name, FS.path(value));
        }
    }
}
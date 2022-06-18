//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public partial class Environs
    {

        public static EnvVars vars()
        {
            var dst = list<EnvVar>();
            foreach(DictionaryEntry kv in Environment.GetEnvironmentVariables())
                 dst.Add(new EnvVar(kv.Key?.ToString() ?? EmptyString, kv.Value?.ToString() ?? EmptyString));
            return dst.ToArray().Sort();
        }

        public static EnvVar<FS.FolderPath> dir(string name)
        {
            var value = Environment.GetEnvironmentVariable(name);
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
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

        public static FS.FolderPath dir(string name)
        {
            var value = Environment.GetEnvironmentVariable(name);
            return FS.dir(value);
        }

        public static ulong number(string name)
        {
            var value = Environment.GetEnvironmentVariable(name);
            if(text.blank(value))
                return 0ul;

            if(ulong.TryParse(value, out var n))
                return n;

            return 0;
        }

        public static FS.FilePath path(string name)
        {
            var value = Environment.GetEnvironmentVariable(name);
            if(text.blank(value))
                @throw($"The environment variable '{name}' is undefined");
            return FS.path(value);
        }
    }
}
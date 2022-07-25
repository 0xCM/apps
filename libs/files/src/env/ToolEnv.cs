//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class ToolEnv
    {
        public static EnvVars<string> vars(FS.FilePath src, char sep = Chars.Eq)
        {
            var k = z16;
            var dst = list<EnvVar<string>>();
            var line = AsciLineCover.Empty;
            var buffer = alloc<char>(1024*4);
            using var reader = src.AsciLineReader();
            while(reader.Next(out line))
            {
                var content = line.Codes;
                var i = SQ.index(content, sep);
                if(i == NotFound)
                    continue;

                var _name = text.format(SQ.left(content,i), buffer);
                var _value = text.format(SQ.right(content,i), buffer);
                dst.Add(new (_name, _value));
            }
            return dst.ToArray().Sort();
        }

        readonly SettingLookup Data;

        readonly Dictionary<string,Setting> Lookup;

        public static ToolEnv load(SettingLookup src)
            => new ToolEnv(src);

        public ToolEnv(SettingLookup src)
        {
            Data = src;
            Lookup = new();
            foreach(var setting in src)
                Lookup[setting.Name] = setting;
        }

        public FolderPaths HeaderIncludes()
        {
            if(Lookup.TryGetValue("INCLUDE", out var setting))
                if(FolderPaths.parse(setting.Value.ToString(), out FolderPaths paths))
                    return paths;
            return FolderPaths.Empty;
        }

        public FolderPaths LibIncludes()
        {
            if(Lookup.TryGetValue("LIB", out var setting))
                if(FolderPaths.parse(setting.Value.ToString(), out FolderPaths paths))
                    return paths;
            return FolderPaths.Empty;
        }
    }
}
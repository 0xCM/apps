//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class ToolEnv
    {
        [MethodImpl(Inline), Op]
        public static CmdFlagSpec flagspec(string name, string desc)
            => new CmdFlagSpec(name, desc);

        /// <summary>
        /// Parses a file with lines of the form k:v where k is interpreted as a flag identifier and v is interpreted
        /// as a description. This information is then used to create a <see cref='CmdFlagSpec'/> sequence
        /// </summary>
        /// <param name="src"></param>
        public static ReadOnlySpan<CmdFlagSpec> flags(FS.FilePath src)
        {
            var k = z16;
            var dst = list<CmdFlagSpec>();
            using var reader = src.AsciLineReader();
            while(reader.Next(out var line))
            {
                var content = line.Codes;
                var i = SQ.index(content, AsciCode.Colon);
                if(i == NotFound)
                    continue;

                var name = text.trim(text.format(SQ.left(content,i)));
                var desc = text.trim(text.format(SQ.right(content,i)));
                dst.Add(flagspec(name, desc));
            }
            return dst.ViewDeposited();
        }

        public static Outcome<Settings> settings(FS.FilePath src)
        {
            try
            {
                var dst = list<Setting>();
                using var reader = src.AsciLineReader();
                while(reader.Next(out var line))
                {
                    var content = line.Codes;
                    var length = content.Length;
                    if(length != 0)
                    {
                        if(SQ.hash(first(content)))
                            continue;

                        var i = SQ.index(content, Chars.Colon);
                        if(i > 0)
                        {
                            var name = text.format(SQ.left(content,i));
                            var value = text.format(SQ.right(content,i));
                            dst.Add(new Setting(name,value));
                        }
                    }
                }
                return new Settings(dst.ToArray());
            }
            catch(Exception e)
            {
                return e;
            }
        }

        public static ToolEnv load(Settings src)
            => new ToolEnv(src);

        readonly Settings Data;

        readonly Dictionary<string,Setting> Lookup;

        public ToolEnv(Settings src)
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
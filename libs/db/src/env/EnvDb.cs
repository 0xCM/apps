//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class EnvDb
    {
        [MethodImpl(Inline), Op]
        public static CmdFlagSpec flag(string name, string desc)
            => new CmdFlagSpec(name, desc);

        /// <summary>
        /// Parses a file with lines of the form k:v where k is interpreted as a flag identifier and v is interpreted
        /// as a description. This information is then used to create a <see cref='CmdFlagSpec'/> sequence
        /// </summary>
        /// <param name="src"></param>
        public static Index<CmdFlagSpec> flags(FS.FilePath src)
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
                dst.Add(flag(name, desc));
            }
            return dst.ToArray();
        }

        public static Settings config(FS.FolderPath src)
            => config(src + FS.file("tools", FS.ext("env")));

        public static EnvVars vars()
            => Environs.vars();

        public static MachineEnv machine()
            => new MachineEnv(vars());

        public static ToolEnv tools(Settings src)
            => new ToolEnv(src);

        public static Settings config(FS.FilePath src, char sep = Chars.Colon)
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

                    var i = SQ.index(content, sep);
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

        public static Index<EnvSetting> records(EnvVars src, string name)
        {
            const char Sep = ';';
            var buffer = list<EnvSetting>();
            var k=0u;
            for(var i=0; i<src.Count; i++)
            {
                ref readonly var v = ref src[i];
                var vName = v.VarName.Format();
                var vValue = v.VarValue;

                if(v.Contains(Sep))
                {
                    var parts = text.split(vValue,Sep).Index();
                    for(var j=0; j<parts.Count; j++)
                    {
                        ref readonly var part = ref parts[j];
                        var dst = new EnvSetting();
                        dst.Seq = k++;
                        dst.EnvName = name;
                        dst.VarName = vName;
                        dst.VarValue = part;
                        dst.Join = Sep.ToString();
                        buffer.Add(dst);
                    }
                }
                else
                {
                    var dst = new EnvSetting();
                    dst.Seq = k++;
                    dst.EnvName = name;
                    dst.VarName = vName;
                    dst.VarValue = vValue;
                    dst.Join = EmptyString;
                    buffer.Add(dst);
                }
            }

            return buffer.ToIndex();
        }
    }
}
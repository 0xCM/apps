//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using N = EnvVarNames;

    public class Env
    {
        public static EnvVars<string> env(FS.FilePath src, char sep = Chars.Eq)
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

        [Op]
        static EnvDirVar dir(string name)
        {
            var value = Environment.GetEnvironmentVariable(name);
            var dst = EnvDirVar.Empty;
            if(text.blank(value))
                dst = (name,FS.dir("Z:/env"));
            return (name, FS.dir(value));
        }

        public EnvData Data
            => default;

        public string Format()
        {
            var dst = text.buffer();
            var vars = Provided;
            var count = vars.Length;
            iter(vars, var => dst.AppendLine(var.Format()));
            return dst.Emit();
        }

        public ReadOnlySpan<IEnvVar> Provided
            => Members(this);

        static Index<IEnvVar> Members(Env src)
            => typeof(Env).GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly).Select(x => (IEnvVar)x.GetValue(src));
    }
}
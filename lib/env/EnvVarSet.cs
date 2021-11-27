//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    public struct EnvVarSet
    {
        public static Outcome parse(FS.FilePath src, out EnvVarSet dst)
        {
            var result = Outcome.Success;
            dst.Source = src;
            dst.Name = text.left(src.FileName.Format(), Chars.Dot);
            dst.Vars = new();

            var vars = list<EnvVar>();
            using var reader = src.Utf8LineReader();
            while(reader.Next(out var line))
            {
                var content = line.Content;
                var i = text.index(content,Chars.Eq);
                if(i > 0)
                {
                    var name = text.left(content,i);
                    var value = text.right(content,i);
                    vars.Add((name,value));
                }
            }
            dst.Vars = vars;

            return result;
        }

        public string Name;

        public FS.FilePath Source;

        public EnvVars Vars;
    }
}
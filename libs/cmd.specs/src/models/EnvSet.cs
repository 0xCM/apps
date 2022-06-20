//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public sealed class EnvSet : EnvSet<EnvVars>
    {
        public static EnvSet load(FS.FilePath src, char sep)
        {
            var result = Outcome.Success;
            var name = text.left(src.FileName.Format(), Chars.Dot);
            var vars = list<EnvVar>();
            var lookup = dict<VarSymbol,object>();
            using var reader = src.Utf8LineReader();
            while(reader.Next(out var line))
            {
                var content = line.Content;
                var i = text.index(content,sep);
                if(i > 0)
                {
                    var vname = text.left(content,i);
                    var vval = text.right(content,i);
                    vars.Add((vname,vval));
                    lookup.TryAdd(vname,vval);
                }
            }

            return new EnvSet(name, lookup, vars.Array());
        }

        public EnvSet(string name, ConstLookup<VarSymbol,object> data, EnvVars vars)
            : base(name, data, vars, vars)
        {
        }
    }
}
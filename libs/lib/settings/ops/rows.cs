//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class Settings
    {
        public static Settings rows(FS.FilePath src)
        {
            var formatter = Tables.formatter<Setting>();
            var data = src.ReadLines(true);
            var dst = alloc<Setting>(data.Length - 1);
            for(var i=1; i<data.Length; i++)
            {
                ref readonly var line = ref data[i];
                var parts = text.split(line, Chars.Pipe);
                Require.equal(parts.Length,2);
                seek(dst,i-1)= new Setting(text.trim(skip(parts,0)), text.trim(skip(parts,1)));
            }
            return new Settings(src,dst);
        }
    }
}
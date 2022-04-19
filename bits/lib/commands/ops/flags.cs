//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using SQ = SymbolicQuery;

    partial struct Cmd
    {
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
    }
}
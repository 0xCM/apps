//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    using SQ = SymbolicQuery;

    [ApiHost]
    public partial class Tooling : AppService<Tooling>
    {
        const NumericKind Closure = UnsignedInts;

        OmniScript OmniScript;

        protected override void Initialized()
        {
            OmniScript = Wf.OmniScript();

        }

        [MethodImpl(Inline), Op]
        public static Toolset toolset(FS.FolderPath @base, ToolId[] members)
            => new Toolset(@base, members);

        public static ReadOnlySpan<CmdFlagSpec> flags(FS.FilePath src)
        {
            var k = z16;
            var dst = list<CmdFlagSpec>();
            using var reader = src.AsciLineReader();
            while(reader.Next(out var line))
            {
                var content = line.Codes;
                var i = SQ.index(content, AsciCode.Colon);
                var name = text.trim(text.format(SQ.left(content,i)));
                var desc = text.trim(text.format(SQ.right(content,i)));
                var flag = Cmd.flagspec(name, desc);
                dst.Add(flag);
            }
            return dst.ViewDeposited();
        }
    }
}
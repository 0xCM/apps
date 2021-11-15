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

    partial class ScriptProcess
    {
        public static ReadOnlySpan<ToolFlow> flow(ReadOnlySpan<TextLine> src)
        {
            var count = src.Length;
            var counter = 0u;
            var dst = span<ToolFlow>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var line = ref skip(src,i);
                if(line.IsEmpty)
                    continue;

                var content = line.Content;
                var j = text.index(content, Chars.Colon);
                if(j >= 0)
                {
                    text15 tool = text.left(content, j);
                    var flow = text.right(content, j);
                    j = text.index(flow, "--");
                    if(j>=0)
                    {
                        var a = text.left(flow,j).Trim();
                        var b = text.left(text.right(flow, j + 2), Chars.RBracket).Trim();
                        if(nonempty(a) && nonempty(b))
                            seek(dst,counter++) = new ToolFlow(tool, FS.path(a), FS.path(b));
                    }
                }
            }

            return slice(dst,0,counter);
        }
    }
}
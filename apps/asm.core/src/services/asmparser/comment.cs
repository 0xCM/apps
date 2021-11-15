//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    using SQ = SymbolicQuery;

    partial struct AsmParser
    {
        [Op]
        public static bool comment(ReadOnlySpan<char> src, out AsmInlineComment dst)
        {
            var count = src.Length;
            var marker = AsmCommentMarker.None;
            var buffer = text.buffer();
            for(var i=0; i<count; i++)
            {
                ref readonly var c = ref skip(src,i);
                switch(c)
                {
                    case (char)AsmCommentMarker.Semicolon:
                    case (char)AsmCommentMarker.Hash:
                        if(marker == 0)
                            marker = (AsmCommentMarker)c;
                        else
                            buffer.Append(c);
                    break;
                    default:
                        if(marker !=0)
                            buffer.Append(c);
                    break;
                }
            }
            var found = marker != 0;
            if(found)
                dst = new AsmInlineComment(marker, buffer.Emit());
            else
                dst = AsmInlineComment.Empty;
            return found;
        }
    }
}
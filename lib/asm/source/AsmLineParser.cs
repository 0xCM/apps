//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;
    using static AsmSourceParts;

    public class AsmLineParser
    {

        public Index<AsmCell> Parse(string src, AsmPartKind spec)
        {
            var buffer = list<AsmCell>();
            var i = -1;
            if(OffsetLabel(spec) || BlockLabel(spec))
            {
                if(OffsetLabel(spec))
                {

                }
                else
                {
                    i = text.index(src,Chars.Colon);
                    buffer.Add(asm.label(text.left(src, i)));

                }

            }


            return buffer.ToArray();
        }
    }
}
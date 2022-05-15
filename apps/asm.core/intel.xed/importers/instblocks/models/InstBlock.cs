//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static core;

    partial class XedImport
    {
        [MethodImpl(Inline)]
        public static InstBlock block(uint seq, FormFields fields, ReadOnlySpan<string> lines)
            => new InstBlock(seq,fields,lines);

        public ref struct InstBlock
        {
            public readonly uint Seq;

            public readonly FormFields Fields;

            public readonly ReadOnlySpan<string> Lines;

            [MethodImpl(Inline)]
            public InstBlock(uint seq, FormFields fields, ReadOnlySpan<string> lines)
            {
                Require.nonzero(lines.Length);
                Seq = seq;
                Fields = fields;
                Lines = lines;
            }

            [MethodImpl(Inline)]
            public string Line(BlockField field)
            {
                var i = (uint)field;
                return Line(i);
            }

            [MethodImpl(Inline)]
            string Line(uint i)
            {
                var dst = EmptyString;
                if(i < Lines.Length)
                {
                    var line = skip(Lines,i);
                    var j = text.index(line,Chars.Colon);
                    if(j >0)
                        dst = text.trim(text.despace(text.right(line,j)));
                }
                return dst;
            }

            public string this[BlockField field]
            {
                [MethodImpl(Inline)]
                get => Line(field);
            }
        }
    }
}
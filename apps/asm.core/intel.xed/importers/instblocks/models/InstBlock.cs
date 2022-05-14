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
        public ref struct InstBlock
        {
            public readonly uint Seq;

            public readonly BitVector64<BlockField> Fields;

            public readonly LineInterval<InstForm> Range;

            public readonly InstForm Form;

            public readonly ReadOnlySpan<string> Lines;

            [MethodImpl(Inline)]
            public InstBlock(uint seq, BitVector64<BlockField> fields,  LineInterval<InstForm> range, ReadOnlySpan<string> lines)
            {
                Require.nonzero(lines.Length);
                Seq = seq;
                Fields = fields;
                Range = range;
                Form = range.Id;
                Lines = lines;
            }

            public uint Render(ITextEmitter dst)
            {
                var counter = 0u;
                var offset = Range.MinLine;
                for(var i=0; i<Lines.Length; i++)
                {
                    var line = skip(Lines,i);
                    if(text.nonempty(line))
                    {
                        dst.AppendLine(line);
                        counter++;
                    }

                }
                return counter;
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
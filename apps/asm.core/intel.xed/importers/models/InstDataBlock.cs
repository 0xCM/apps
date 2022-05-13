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
        public ref struct InstDataBlock
        {
            public readonly uint Seq;

            public readonly LineInterval<InstForm> Range;

            public readonly InstForm Form;

            public readonly ReadOnlySpan<string> Lines;

            [MethodImpl(Inline)]
            public InstDataBlock(uint seq, uint i0, uint i1, InstForm form, ReadOnlySpan<string> lines)
            {
                Range = new (form,i0,i1);
                Seq = seq;
                Form = form;
                Lines = lines;
            }

            public void Render(ITextEmitter dst)
            {
                var offset = Range.MinLine;
                for(var i=0; i<Lines.Length; i++)
                    dst.AppendLine(skip(Lines,i));
            }
        }
    }
}
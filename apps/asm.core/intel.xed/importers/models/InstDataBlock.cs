//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;

    partial class XedImport
    {
        public ref struct InstDataBlock
        {
            public readonly uint Seq;

            public readonly InstForm Form;

            public readonly ReadOnlySpan<string> Lines;

            [MethodImpl(Inline)]
            public InstDataBlock(uint seq, InstForm form, ReadOnlySpan<string> content)
            {
                Seq = seq;
                Form = form;
                Lines = content;
            }
        }
    }
}
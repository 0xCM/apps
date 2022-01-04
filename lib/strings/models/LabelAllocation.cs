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

    public class LabelAllocation : IDisposable
    {
        readonly StringBuffer Buffer;

        readonly Index<Label> Labels;

        [MethodImpl(Inline)]
        internal LabelAllocation(StringBuffer buffer, Label[] labels)
        {
            Buffer = buffer;
            Labels = labels;
        }

        public ReadOnlySpan<Label> Allocated
        {
            [MethodImpl(Inline)]
            get => Labels;
        }

        public void Dispose()
        {
            Buffer.Dispose();
        }
    }
}
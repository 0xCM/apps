//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct BufferedLabels : IDisposable
    {
        readonly Index<Label> _Labels;

        readonly StringBuffer Buffer;

        [MethodImpl(Inline)]
        internal BufferedLabels(StringBuffer buffer, Index<Label> labels)
        {
            Buffer = buffer;
            _Labels = labels;
        }

        public void Dispose()
        {
            Buffer.Dispose();
        }

        public ReadOnlySpan<Label> Labels
        {
            [MethodImpl(Inline)]
            get => _Labels.View;
        }

        public uint LabelCount
        {
            [MethodImpl(Inline)]
            get => _Labels.Count;
        }

        public ByteSize BufferSize
        {
            [MethodImpl(Inline)]
            get => Buffer.Size;
        }
    }
}
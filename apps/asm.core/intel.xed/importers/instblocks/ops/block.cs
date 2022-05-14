//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedModels;

    partial class XedImport
    {
        [MethodImpl(Inline)]
        public static LineInterval<InstForm> range(InstForm form, uint offset, uint length)
            => new (form,offset, (uint)(offset + length - 1));

        [MethodImpl(Inline)]
        public static InstBlock block(uint seq, BitVector64<BlockField> fields, LineInterval<InstForm> range, ReadOnlySpan<string> src)
            => new InstBlock(seq, fields, range, slice(src, range.MinLine, range.LineCount));
    }
}
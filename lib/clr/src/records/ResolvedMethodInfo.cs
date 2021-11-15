//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    using static Root;

    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct ResolvedMethodInfo : IComparableRecord<ResolvedMethodInfo>
    {
        public const string TableId = "methods.resolved";

        public const byte FieldCount = 3;

        public MemoryAddress EntryPoint;

        public utf8 Uri;

        public utf8 DisplaySig;

        [MethodImpl(Inline)]
        public int CompareTo(ResolvedMethodInfo src)
            => EntryPoint.CompareTo(src.EntryPoint);

        public static ReadOnlySpan<byte> RenderWidths
            => new byte[FieldCount]{16,120,80};
    }
}
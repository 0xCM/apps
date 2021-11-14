//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm.records
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential), Record(TableId)]
    public struct ValueTypeRow : IRecord<ValueTypeRow>
    {
        public const string TableId = "llvm.value-type";

        public const byte FieldCount = 3;

        public CharBlock8 Namespace;

        public uint Size;

        public uint Value;

        public static ReadOnlySpan<byte> RenderWidths
            => new byte[FieldCount]{16,16,1};
    }
}

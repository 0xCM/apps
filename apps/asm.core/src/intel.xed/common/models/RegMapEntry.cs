//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        [StructLayout(LayoutKind.Sequential, Pack=1), Record(TableName)]
        public struct RegMapEntry
        {
            public const byte FieldCount = 5;

            public const string TableName = "xed.regs.map";

            public ushort RegId;

            public Asm.RegClass RegClass;

            public NativeSize RegSize;

            public text7 RegName;

            public byte RegIndex;

            public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{8,8,8,8,8};
        }
    }
}
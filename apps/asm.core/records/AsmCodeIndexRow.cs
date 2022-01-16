//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.InteropServices;

    using Asm;

    [Record(TableId), StructLayout(LayoutKind.Sequential,Pack=1)]
    public struct AsmCodeIndexRow
    {
        public const string TableId = "asm.index";

        public const byte FieldCount = 7;

        public uint Seq;

        public uint DocId;

        public uint DocSeq;

        public ulong CT;

        public MemoryAddress Offset;

        public AsmExpr Asm;

        public AsmHexCode Encoding;

        public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{8,8,8,8,8,82,1};
    }
}
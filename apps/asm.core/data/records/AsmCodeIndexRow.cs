//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.InteropServices;

    using Asm;

    [Record(TableId), StructLayout(LayoutKind.Sequential,Pack=1)]
    public struct AsmCodeIndexRow : IComparable<AsmCodeIndexRow>
    {
        public const string TableId = "asm.index";

        public const byte FieldCount = 7;

        public uint Seq;

        public uint DocId;

        public uint DocSeq;

        public Address32 IP;

        public CorrelationToken CT;

        public AsmExpr Asm;

        public AsmHexCode Encoding;

        public int CompareTo(AsmCodeIndexRow src)
            => Asm.CompareTo(src.Asm);
        // {
        //     var result = DocId.CompareTo(src.DocId);
        //     if(result == 0)
        //         result = IP.CompareTo(src.IP);
        //     return result;
        // }

        public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{8,8,8,12,12,82,1};
    }
}
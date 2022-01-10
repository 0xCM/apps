//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    using Asm;

    using static Root;

    [Record(TableId), StructLayout(LayoutKind.Sequential,Pack=1)]
    public struct AsmDocEncoding
    {
        public const string TableId = "asm.encoding";

        public const byte FieldCount = 8;

        public uint Seq;

        public uint DocSeq;

        public @string SrcId;

        public Address32 IP;

        public AsmExpr Asm;

        public byte Size;

        public AsmHexCode Code;

        public FS.FileUri DocPath;

        public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{8,8,32,10,84,8,42,1};

        public static AsmDocEncoding Empty => default;
    }
}
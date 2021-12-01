//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    using Asm;

    using static Root;

    [Record(TableId), StructLayout(LayoutKind.Sequential,Pack=1)]
    public struct LlvmAsmEncoding
    {
        public const string TableId = "asm.encoding";

        public const byte FieldCount = 5;

        public uint Seq;

        public uint DocSeq;

        public AsmExpr Asm;

        public AsmHexCode Code;

        public FS.FileUri Doc;

        public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{8,8,84,42,1};

        public static LlvmAsmEncoding Empty => default;
    }
}
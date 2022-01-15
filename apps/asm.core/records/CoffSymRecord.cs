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
    using static core;

    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct CoffSymRecord
    {
        public const string TableId = "coff.symbols";

        public const byte FieldCount = 11;

        public uint Seq;

        public Identifier SrcId;

        public Timestamp Timestamp;

        public Address32 Address;

        public uint SymSize;

        public ushort Section;

        public Hex32 Value;

        public ImageSymType SymType;

        public SymStorageClass SymClass;

        public ushort AuxCount;

        public @string SymText;

        public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{8,36,24,10,8,8,10,8,8,8,1};
    }
}
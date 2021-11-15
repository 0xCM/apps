//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System.Runtime.InteropServices;

    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct XedOperandKind : IRecord<XedOperandKind>
    {
        public const string TableId = "xed.operand-kinds";

        public uint Index;

        public Identifier Name;

        public string Value;

        public Hash32 Hash;
    }
}
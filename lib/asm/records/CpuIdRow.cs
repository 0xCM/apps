//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.InteropServices;

    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct CpuIdRow : IRecord<CpuIdRow>
    {
        public const string TableId = "asm.cpuid";

        public const byte FieldCount = 7;

        public string Chip;

        public Hex32 Leaf;

        public Hex32 Subleaf;

        public Hex32 Eax;

        public Hex32 Ebx;

        public Hex32 Ecx;

        public Hex32 Edx;

        public static ReadOnlySpan<byte> RenderWidths
            => new byte[FieldCount]{12,12,12,12,12,12,12};
    }
}
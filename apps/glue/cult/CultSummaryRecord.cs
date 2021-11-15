//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Tools
{
    using System;
    using System.Runtime.InteropServices;

    using Z0.Asm;

    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct CultSummaryRecord : IRecord<CultSummaryRecord>
    {
        public const string TableId = "cult.summary";

        public const byte FieldCount = 6;

        public uint LineNumber;

        public Identifier Id;

        public AsmMnemonic Mnemonic;

        public string Instruction;

        public string Lat;

        public string Rcp;

        public static ReadOnlySpan<byte> RenderWidths
            => new byte[FieldCount]{12,46,46,46,6,6};
    }
}
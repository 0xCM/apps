//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct ColWidths
    {
        public const byte Seq = 8;

        public const byte DocSeq = 8;

        public const byte OriginId = 12;

        public const byte OriginName = 32;

        public const byte EncodingId = 16;

        public const byte InstructionId = 30;

        public const byte Encoded = 48;

        public const byte AsmExpr = 48;

        public const byte AsmSyntax = 120;

        public const byte IP = 12;

        public const byte Size = 5;

        public const byte BlockName = 32;

        public const byte BlockNumber = 12;

        public const byte BlockAddress = 12;

        public const byte BlockSize = 12;

        public const byte Hex8 = 8;

        public const byte RexPrefx = 5;

        public const byte VexPrefix = 12;

        public const byte EvexPrefix = 12;

        public const byte ModRm = 5;

        public const byte Sib = 5;

        public const byte Disp = 12;

        public const byte Imm = 12;

        public const byte EASZ = 5;

        public const byte EOSZ = 5;

        public const byte SymbolName = 24;
    }
}
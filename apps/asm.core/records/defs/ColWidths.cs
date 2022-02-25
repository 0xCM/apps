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

        public const byte Encoded = 42;

        public const byte AsmExpr = 42;

        public const byte AsmSyntax = 120;

        public const byte IP = 12;

        public const byte Size = 5;

        public const byte BlockName = 32;

        public const byte BlockNumber = 12;

        public const byte BlockAddress = 12;
    }
}
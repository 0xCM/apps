//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    [LiteralProvider]
    public readonly struct ModRmFields
    {
        public const string PatternSpec = "mm rrr nnn";

        public const byte RenderWidth = 10;

        public const byte Rm_Mask = 0b00_00_111;

        public const byte Rm_Min = 0;

        public const byte Rm_Max = 2;
    }
}
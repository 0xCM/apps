//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    public enum RexMode : byte
    {
        R00 = 0,

        R01 = 1,

        R10 = 2,

        R11 = 3,

        Indirect = R00 | R01 | R10,

        Direct = R11,
    }

    public readonly struct RexFields
    {
        public const string BitPattern = "aaaa w r x b";

        public const byte RenderWidth = 12;

        public const byte B_Mask = 0b000_0_0_0_1;

        /// <summary>
        /// Indicates an extension of the ModR/M r/m field, SIB base field, or Opcode reg field
        /// </summary>
        public const byte B = 0;

        public const byte X_Mask = 0b000_0_0_1_0;

        /// <summary>
        /// Indicates an extension of the SIB index field
        /// </summary>
        public const byte X = 1;

        public const byte R_Mask = 0b000_0_1_0_0;

        public const byte R = 2;

        public const byte W_Mask = 0b000_1_0_0_0;

        /// <summary>
        /// Indicates a 64-bit operand size; if not, operand size determined by CS.D
        /// </summary>
        public const byte W = 3;

    }

    public readonly struct ModRmFields
    {
        public const string BitPattern = "mm rrr nnn";

        public const byte RenderWidth = 10;

        public const byte Rm_Mask = 0b00_00_111;

        public const byte Rm_Min = 0;

        public const byte Rm_Max = 2;

    }

    public readonly struct SibFields
    {
        public const string BitPattern = "ss iii bbb";

        public const byte RenderWidth = 10;

        public const byte Base_Mask = 0b00_000_111;

        public const byte Base_Min = 0;

        public const byte Base_Max = 2;

        public const byte Base_Width = Base_Max - Base_Min + 1;

        public const byte Index_Mask = 0b00_111_000;

        public const byte Index_Min = 3;

        public const byte Index_Max = 5;

        public const byte Index_Width = Index_Max - Index_Min + 1;

        public const byte Scale_Mask = 0b11_000_000;

        public const byte Scale_Min = 6;

        public const byte Scale_Max = 7;

        public const byte Scale_Width = Scale_Max - Scale_Min + 1;
    }
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
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
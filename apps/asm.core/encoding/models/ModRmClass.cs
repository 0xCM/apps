//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    public struct ModRmClass
    {
        public readonly ModRmKind Kind;

        [MethodImpl(Inline)]
        public ModRmClass(ModRmKind kind)
        {
            Kind = kind;
        }

        public string Format()
            => Kind switch
            {
                ModRmKind.Other => "mod[0b11:0b00] | reg[0b111:0b000] | rm[0b111:0b000]",
                ModRmKind.Mod11 => "mod[0b11] | reg[0b111:0b000] | rm[0b111:0b000]",
                ModRmKind.NotMod11 => "mod[0b10:0b00] | reg[0b111:0b000] | rm[0b111:0b000]",
                _ => EmptyString,
            };

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator ModRmClass(ModRmKind src)
            => new ModRmClass(src);

        [MethodImpl(Inline)]
        public static implicit operator ModRmKind(ModRmClass src)
            => src.Kind;
    }
}
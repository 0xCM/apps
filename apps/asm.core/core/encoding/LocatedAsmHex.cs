//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    public readonly struct LocatedAsmHex : IEquatable<LocatedAsmHex>, IComparable<LocatedAsmHex>
    {
        public MemoryAddress Location {get;}

        public AsmHexCode Hex {get;}

        [MethodImpl(Inline)]
        public LocatedAsmHex(MemoryAddress loc, AsmHexCode hex)
        {
            Location = loc;
            Hex = hex;
        }


        [MethodImpl(Inline)]
        public bool Equals(LocatedAsmHex src)
            => Location == src.Location && Hex == src.Hex;

        [MethodImpl(Inline)]
        public int CompareTo(LocatedAsmHex src)
            => Location.CompareTo(src.Location);

        public string Format()
            => string.Format("{0,-12} {1}", Location, Hex);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator LocatedAsmHex((MemoryAddress loc, AsmHexCode hex) src)
            => new LocatedAsmHex(src.loc, src.hex);
    }
}
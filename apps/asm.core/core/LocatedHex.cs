//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    public readonly struct LocatedHex : IEquatable<LocatedHex>, IComparable<LocatedHex>
    {
        public MemoryAddress Location {get;}

        public AsmHexCode Hex {get;}

        [MethodImpl(Inline)]
        public LocatedHex(MemoryAddress loc, AsmHexCode hex)
        {
            Location = loc;
            Hex = hex;
        }

        [MethodImpl(Inline)]
        public static implicit operator LocatedHex((MemoryAddress loc, AsmHexCode hex) src)
            => new LocatedHex(src.loc, src.hex);

        [MethodImpl(Inline)]
        public bool Equals(LocatedHex src)
            => Location == src.Location && Hex == src.Hex;

        [MethodImpl(Inline)]
        public int CompareTo(LocatedHex src)
            => Location.CompareTo(src.Location);

        public string Format()
            => string.Format("{0,-12} {1}", Location, Hex);

        public override string ToString()
            => Format();
    }
}
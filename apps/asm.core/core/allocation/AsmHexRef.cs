//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    public readonly struct AsmHexRef
    {
        readonly MemorySeg Seg;

        [MethodImpl(Inline)]
        public AsmHexRef(MemorySeg seg)
        {
            Seg = seg;
        }

        public ReadOnlySpan<byte> Data
        {
            [MethodImpl(Inline)]
            get => Seg.View;
        }

        public byte Size
        {
            [MethodImpl(Inline)]
            get => (byte)Seg.Size;
        }

        public string Format()
            => Data.FormatHex();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public bool Equals(AsmHexRef src)
        {
            var size = src.Size;
            if(size != Size)
                return false;
            var lhs = Data;
            var rhs = src.Data;
            var result = true;
            for(var i=0; i<size; i++)
                result &= skip(lhs,i) == skip(rhs,i);
            return result;
        }

        public override int GetHashCode()
            => (int)alg.hash.marvin(Data);

        public override bool Equals(object src)
            => src is AsmHexRef x && Equals(x);

        [MethodImpl(Inline)]
        public static bool operator ==(AsmHexRef a, AsmHexRef b)
            => a.Equals(b);

        [MethodImpl(Inline)]
        public static bool operator !=(AsmHexRef a, AsmHexRef b)
            => !a.Equals(b);

        [MethodImpl(Inline)]
        public static implicit operator AsmHexRef(MemorySeg src)
            => new AsmHexRef(src);
    }
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public readonly record struct NativeSegType : INativeType<NativeSegType>
    {
        public readonly NativeScalar CellType;

        public readonly byte CellCount;

        [MethodImpl(Inline)]
        public NativeSegType(NativeScalar ct, byte count)
        {
            CellType = ct;
            CellCount = count;
        }

        public BitWidth Width
        {
            [MethodImpl(Inline)]
            get => CellType.Width*CellCount;
        }

        public NativeSegKind SegKind
        {
            [MethodImpl(Inline)]
            get => core.@as<NativeSegType,NativeSegKind>(this);
        }

        public NativeSize Size
        {
            [MethodImpl(Inline)]
            get => Sizes.native(Width);
        }

        public bool IsVoid
        {
            [MethodImpl(Inline)]
            get => CellType.IsVoid;
        }

        [MethodImpl(Inline)]
        public bool Equals(NativeSegType src)
            => CellType.Equals(src.CellType) && CellCount == src.CellCount;

        public override int GetHashCode()
            => (int)alg.hash.combine(CellType.GetHashCode(), CellCount);

        public string Format()
            => NativeRender.format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator NativeSegType((NativeScalar ct, byte count) src)
            => new NativeSegType(src.ct, src.count);

        [MethodImpl(Inline)]
        public static implicit operator NativeSegType(NativeSegKind kind)
            => core.@as<NativeSegKind,NativeSegType>(kind);

        [MethodImpl(Inline)]
        public static implicit operator NativeSegKind(NativeSegType src)
            => src.SegKind;

        public static NativeSegType Void
        {
            [MethodImpl(Inline)]
            get => new NativeSegType(NativeScalar.Void,0);
        }
    }
}
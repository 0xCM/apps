//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public readonly struct NativeSegType
    {
        public readonly NativeCellType CellType;

        public readonly byte CellCount;

        [MethodImpl(Inline)]
        public NativeSegType(NativeCellType ct, byte count)
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

        public string Format()
            => NativeTypes.format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator NativeSegType((NativeCellType ct, byte count) src)
            => new NativeSegType(src.ct, src.count);

        [MethodImpl(Inline)]
        public static implicit operator NativeSegType(NativeSegKind kind)
            => core.@as<NativeSegKind,NativeSegType>(kind);

        [MethodImpl(Inline)]
        public static implicit operator NativeSegKind(NativeSegType src)
            => src.SegKind;
    }
}
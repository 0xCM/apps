//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IClrType : IType<ClrPrimitiveKind>
    {

    }

    public interface IClrEnumType : IClrType, IScalarType<ClrEnumKind>
    {
        ClrEnumKind EnumKind {get;}

        ClrPrimitiveKind ScalarKind
            => (ClrPrimitiveKind)EnumKind;

        BitWidth ISizedType.ContentWidth
            => PrimalBits.width(EnumKind);

        BitWidth ISizedType.StorageWidth
            => PrimalBits.width(EnumKind);

        ClrPrimitiveKind IType<ClrPrimitiveKind>.Kind
            => ScalarKind;

        ClrEnumKind IType<ClrEnumKind>.Kind
            => EnumKind;

        ulong IType.Kind
            => (ulong)PrimalBits.width(EnumKind);
    }
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IClrType : IType<PrimalKind>
    {

    }

    public interface IClrEnumType : IClrType, IScalarType<ClrEnumKind>
    {
        ClrEnumKind EnumKind {get;}

        PrimalKind ScalarKind
            => (PrimalKind)EnumKind;

        BitWidth ISizedType.ContentWidth
            => PrimalBits.width(EnumKind);

        BitWidth ISizedType.StorageWidth
            => PrimalBits.width(EnumKind);

        PrimalKind IType<PrimalKind>.Kind
            => ScalarKind;

        ClrEnumKind IType<ClrEnumKind>.Kind
            => EnumKind;

        ulong IType.Kind
            => (ulong)PrimalBits.width(EnumKind);
    }
}
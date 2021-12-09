//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using PK = ClrPrimitiveKind;
    using EK = ClrEnumKind;

    public sealed class ClrTypeSystem : TypeSystem<ClrTypeSystem,PK>
    {
        public const string SystemName = "clr";

        public ClrTypeSystem()
            : base(SystemName)
        {

        }

        public ReadOnlySpan<ClrEnumKind> EnumKinds
            => _EnumsKinds;

        public override ReadOnlySpan<TypeKind<PK>> Primitives
            => _Primitives;

        static TypeKind<PK> primitive(PK kind, string name, byte arity)
            => new TypeKind<PK>(kind, name, arity);

        static Index<ClrEnumKind> _EnumsKinds = new ClrEnumKind[]{
            EK.U8,
            EK.U16,
            EK.U32,
            EK.U64,
            EK.I8,
            EK.I16,
            EK.I32,
            EK.U64,
        };

        static Index<TypeKind<PK>> _Primitives = new TypeKind<PK>[]
        {
            primitive(PK.U1, "bool", 0),
            primitive(PK.U8, "byte", 0),
            primitive(PK.U16, "ushort", 0),
            primitive(PK.U32, "uint", 0),
            primitive(PK.U64, "ulong", 0),
            primitive(PK.I8, "sbyte", 0),
            primitive(PK.I16, "short", 0),
            primitive(PK.I32, "int", 0),
            primitive(PK.I64, "long", 0),
            primitive(PK.C16, "char", 0),
            primitive(PK.F32, "float", 0),
            primitive(PK.F64, "double", 0),
            primitive(PK.F128, "decimal", 0),
            primitive(PK.String, "string", 0),
        };
    }
}
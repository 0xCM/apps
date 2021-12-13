//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using PK = CanonicalKind;
    using PN = TypeSpecs;

    public sealed partial class Canon : TypeSystem<Canon,PK>
    {
        public const string SystemName = "canonical";

        public Canon()
            : base(SystemName)
        {

        }

        public override ReadOnlySpan<TypeKind<PK>> PrimalKinds
            => _Primitives;

        public override ReadOnlySpan<IType> KnownTypes
            => _KnownTypes;

        static T known<T>()
            where T : struct, IType
                => new T();

        static TypeKind<PK> primitive(PK kind, string name, byte arity)
            => new TypeKind<PK>(kind, name, arity);

        static TypeKind<PK>[] _Primitives = new TypeKind<PK>[]{
            primitive(PK.U, PN.U,1),
            primitive(PK.I,PN.I,1),
            primitive(PK.C,PN.C,1),
            primitive(PK.Ct,PN.Ct,1),
            primitive(PK.F,PN.F,1),
            primitive(PK.V, PN.V, 1),
            primitive(PK.S, PN.S, 0),
            primitive(PK.St, PN.St, 1),
            primitive(PK.Sn, PN.Sn, 1),
            primitive(PK.Snt, PN.Snt, 2),
            primitive(PK.Bit, PN.Bit, 0),
            primitive(PK.Bits, PN.Bits, 1),
            primitive(PK.BitsN, PN.BitsN, 2),
            primitive(PK.Seq, PN.Seq, 1),
            primitive(PK.SeqN, PN.SeqN, 2),
        };

        static Index<IType> _KnownTypes => new IType[]{
            known<bit>(),
            known<bits>(),
            known<c16>(),
            known<i8>(),
            known<i16>(),
            known<i32>(),
            known<i64>(),
            known<@string>(),
            known<u8>(),
            known<u16>(),
            known<u32>(),
            known<u64>(),
        };
    }
}
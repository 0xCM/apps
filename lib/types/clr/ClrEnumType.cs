//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct ClrEnumType : IClrEnumType
    {
        public Identifier Name {get;}

        public ClrEnumKind EnumKind {get;}

        public ScalarClass ScalarClass {get;}

        [MethodImpl(Inline)]
        public ClrEnumType(Identifier name, ClrEnumKind kind)
        {
            Name = name;
            EnumKind = kind;
            ScalarClass = kind.IsSigned() ? ScalarClass.I : ScalarClass.U;
        }

        public string Format()
            => string.Format("enum<{0}:{1}>", Name, EnumKind.CsKeyword());

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator ClrEnumKind(ClrEnumType src)
            => src.EnumKind;
    }
}
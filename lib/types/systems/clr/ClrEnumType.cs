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
        public ClrEnumKind EnumKind {get;}

        [MethodImpl(Inline)]
        public ClrEnumType(ClrEnumKind kind)
        {
            EnumKind = kind;
        }

        public string Format()
            => string.Format("enum<t:{0}>", EnumKind.CsKeyword());

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator ClrEnumType(ClrEnumKind src)
            => new ClrEnumType(src);

        [MethodImpl(Inline)]
        public static implicit operator ClrEnumKind(ClrEnumType src)
            => src.EnumKind;
    }
}
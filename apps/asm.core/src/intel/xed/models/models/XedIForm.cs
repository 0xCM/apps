//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
// Source      : xed-operand-storage.h
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static XedModels;

    public readonly struct XedIForm : IEquatable<XedIForm>, IComparable<XedIForm>, IEnumCover<IFormType>
    {
        public IFormType Value {get;}

        [MethodImpl(Inline)]
        public XedIForm(IFormType src)
            => Value = src;

        [MethodImpl(Inline)]
        public bool Equals(XedIForm src)
            => ((ushort)Value).Equals((ushort)src.Value);

        [MethodImpl(Inline)]
        public int CompareTo(XedIForm src)
            => ((ushort)Value).CompareTo((ushort)src.Value);


        public override int GetHashCode()
            =>(int)Value;

        public override bool Equals(object src)
            => src is XedIForm && Equals(src);

        public string Format()
            => Value.ToString();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator XedIForm(IFormType src)
            => new XedIForm(src);

        [MethodImpl(Inline)]
        public static implicit operator IFormType(XedIForm src)
            => src.Value;
    }
}
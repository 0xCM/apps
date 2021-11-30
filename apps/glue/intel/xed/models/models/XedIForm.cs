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

    partial struct XedModels
    {
        public readonly struct XedIForm : IEquatable<XedIForm>, IComparable<XedIForm>
        {
            public IFormType Type {get;}

            [MethodImpl(Inline)]
            public XedIForm(IFormType src)
                => Type = src;

            [MethodImpl(Inline)]
            public bool Equals(XedIForm src)
                => ((ushort)Type).Equals((ushort)src.Type);

            [MethodImpl(Inline)]
            public int CompareTo(XedIForm src)
                => ((ushort)Type).CompareTo((ushort)src.Type);


            public override int GetHashCode()
                =>(int)Type;

            public override bool Equals(object src)
                => src is XedIForm && Equals(src);

            public string Format()
                => Type.ToString();

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static implicit operator XedIForm(IFormType src)
                => new XedIForm(src);

            [MethodImpl(Inline)]
            public static implicit operator IFormType(XedIForm src)
                => src.Type;
        }
    }
}
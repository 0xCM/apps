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
        public readonly struct IForm : IDataTypeComparable<IForm>
        {
            public IFormType Type {get;}

            [MethodImpl(Inline)]
            public IForm(IFormType src)
                => Type = src;

            [MethodImpl(Inline)]
            public bool Equals(IForm src)
                => ((ushort)Type).Equals((ushort)src.Type);

            [MethodImpl(Inline)]
            public int CompareTo(IForm src)
                => ((ushort)Type).CompareTo((ushort)src.Type);


            public override int GetHashCode()
                =>(int)Type;

            public override bool Equals(object src)
                => src is IForm && Equals(src);

            public string Format()
                => Type.ToString();

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static implicit operator IForm(IFormType src)
                => new IForm(src);

            [MethodImpl(Inline)]
            public static implicit operator IFormType(IForm src)
                => src.Type;
        }
    }
}
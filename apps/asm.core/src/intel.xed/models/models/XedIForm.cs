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
        [DataType(Names.iform)]
        public struct IForm : IEquatable<IForm>, IComparable<IForm>, IEnumCover<IFormType>
        {
            public IFormType Value {get;set;}

            [MethodImpl(Inline)]
            public IForm(IFormType src)
                => Value = src;

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => Value != 0;
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Value == 0;
            }

            [MethodImpl(Inline)]
            public bool Equals(IForm src)
                => ((ushort)Value).Equals((ushort)src.Value);

            [MethodImpl(Inline)]
            public int CompareTo(IForm src)
                => ((ushort)Value).CompareTo((ushort)src.Value);


            public override int GetHashCode()
                =>(int)Value;

            public override bool Equals(object src)
                => src is IForm && Equals(src);

            public string Format()
                => Value != 0 ? Value.ToString() : string.Empty;

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static implicit operator IForm(IFormType src)
                => new IForm(src);

            [MethodImpl(Inline)]
            public static implicit operator IFormType(IForm src)
                => src.Value;
        }
    }
}
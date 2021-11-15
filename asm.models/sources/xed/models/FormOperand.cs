//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct XedModels
    {
        public readonly struct FormOperand : IDataTypeComparable<FormOperand>
        {
            public string Value {get;}

            [MethodImpl(Inline)]
            public FormOperand(string src)
                => Value = src;

            public bool Equals(FormOperand src)
                => Value.Equals(src.Value);

            [MethodImpl(Inline)]
            public int CompareTo(FormOperand src)
                => Value.CompareTo(src.Value);

            [MethodImpl(Inline)]
            public string Format()
                => Value;

            public override string ToString()
                => Format();

            public override int GetHashCode()
                => (int)alg.hash.marvin(Value);

            public override bool Equals(object src)
                => src is FormOperand c && Equals(c);

            [MethodImpl(Inline)]
            public static implicit operator FormOperand(string src)
                => new FormOperand(src);
        }
    }
}
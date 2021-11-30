//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct XedFormOperand : IComparable<XedFormOperand>, IEquatable<XedFormOperand>
    {
        public string Value {get;}

        [MethodImpl(Inline)]
        public XedFormOperand(string src)
            => Value = src;

        public bool Equals(XedFormOperand src)
            => Value.Equals(src.Value);

        [MethodImpl(Inline)]
        public int CompareTo(XedFormOperand src)
            => Value.CompareTo(src.Value);

        [MethodImpl(Inline)]
        public string Format()
            => Value;

        public override string ToString()
            => Format();

        public override int GetHashCode()
            => (int)alg.hash.marvin(Value);

        public override bool Equals(object src)
            => src is XedFormOperand c && Equals(c);

        [MethodImpl(Inline)]
        public static implicit operator XedFormOperand(string src)
            => new XedFormOperand(src);
    }
}
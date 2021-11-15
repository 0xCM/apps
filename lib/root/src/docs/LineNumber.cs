//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct LineNumber : IDataTypeComparable<LineNumber>
    {
        public const byte RenderLength = 9;

        public const string RenderPattern = "{0:D8}:";

        public uint Value {get;}

        [MethodImpl(Inline)]
        public LineNumber(uint value)
        {
            Value = value;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Value == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Value != 0;
        }

        [MethodImpl(Inline)]
        public LineSegment Segment(ushort min, ushort max)
            => new LineSegment(this,min,max);

        public string Format()
            => string.Format("{0:D8}",Value);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public int CompareTo(LineNumber src)
            => Value.CompareTo(src);

        [MethodImpl(Inline)]
        public bool Equals(LineNumber src)
            => Value == src.Value;

        public override bool Equals(object obj)
            => obj is LineNumber x && Equals(x);

        public override int GetHashCode()
            => (int)Value;

        public static LineNumber Empty => default;

        [MethodImpl(Inline)]
        public static implicit operator LineNumber(uint src)
            => new LineNumber(src);

        [MethodImpl(Inline)]
        public static implicit operator uint(LineNumber src)
            => src.Value;

        [MethodImpl(Inline)]
        public static LineNumber operator ++(LineNumber src)
            => new LineNumber(src.Value + 1);
    }
}
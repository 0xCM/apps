//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct LineOffset : IEquatable<LineOffset>, IComparable<LineOffset>
    {
        public const string RenderPattern = "{0}:{1:D3}";

        public const byte RenderLength = LineNumber.RenderLength + 3;

        public LineNumber Line {get;}

        public uint Offset {get;}

        [MethodImpl(Inline)]
        public LineOffset(LineNumber line, uint offset)
        {
            Line = line;
            Offset = offset;
        }

        public string Format()
            => string.Format(RenderPattern,Line,Offset);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public int CompareTo(LineOffset src)
        {
            var i = Line.CompareTo(src.Line);
            return i==0 ? Offset.CompareTo(src.Offset) : i;
        }

        [MethodImpl(Inline)]
        public bool Equals(LineOffset src)
            => Line.Equals(src.Line) && Offset.Equals(src.Offset);


        public override bool Equals(object obj)
            => obj is LineOffset x && Equals(x);

        public override int GetHashCode()
            => (int)((uint)Line | (Offset << 16));

        [MethodImpl(Inline)]
        public static implicit operator LineOffset((LineNumber line, uint offset) src)
            => new LineOffset(src.line,src.offset);

        public static LineOffset Empty => default;
    }
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost]
    public readonly partial struct Lines
    {
        [MethodImpl(Inline)]
        public static LineSegment segment(LineNumber src, ushort min, ushort max)
            => new LineSegment(src,min,max);

        public static Fence<char> RangeFence
            => (Chars.LBracket, Chars.RBracket);

        public const string RangeDelimiter = "..";

        public const char IdentitySep = Chars.Colon;

        public static Fence<char> CountFence
            => (Chars.LParen, Chars.RParen);

        const NumericKind Closure = UnsignedInts;

        static MsgPattern<Count,LineNumber,string> BadLineNumber => "BadLineNumber(counter{0} != line{1}, content{2})";
    }
}
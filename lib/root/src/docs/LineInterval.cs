//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct LineInterval
    {
        public static Fence<char> RangeFence => (Chars.LBracket, Chars.RBracket);

        public const string RangeDelimiter = "..";

        public const char IdentitySep = Chars.Colon;

        public static Fence<char> CountFence => (Chars.LParen, Chars.RParen);

        public readonly uint Id;

        public readonly LineNumber MinLine;

        public readonly LineNumber MaxLine;

        [MethodImpl(Inline)]
        public LineInterval(uint id, LineNumber min, LineNumber max)
        {
            Id = id;
            MinLine = min;
            MaxLine = max;
        }

        public uint LineCount
        {
            [MethodImpl(Inline)]
            get => MaxLine.Value - MinLine.Value + 1;
        }

        public string Format()
            => string.Format("{0:D5}:[{1}..{2}]({3})", Id, MinLine, MaxLine, LineCount);

        public override string ToString()
            => Format();

        public static LineInterval Empty => default;
    }

}
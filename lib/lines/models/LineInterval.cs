//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    public readonly struct LineInterval
    {
        [Parser]
        public static Outcome parse(string src, out LineInterval<Identifier> dst)
        {
            var result = Outcome.Success;
            dst = LineInterval<Identifier>.Empty;
            var i = text.index(src,Chars.Colon);
            if(i >= 0)
            {
                var id = text.left(src,i);
                result = text.unfence(src, LineInterval.RangeFence, out var rs);
                if(result.Fail)
                    return result;

                var parts = text.split(rs, LineInterval.RangeDelimiter);
                if(parts.Length != 2)
                {
                    result = (false, string.Format("The range of {0} cannot be determined", src));
                    return result;
                }

                result = LineNumber.parse(skip(parts,0), out var min);
                if(result.Fail)
                    return result;

                result = LineNumber.parse(skip(parts,1), out var max);
                if(result.Fail)
                    return result;

                dst = new LineInterval<Identifier>(id,min,max);
            }
            return result;
        }

        public static Fence<char> RangeFence
            => (Chars.LBracket, Chars.RBracket);

        public const string RangeDelimiter = "..";

        public const char IdentitySep = Chars.Colon;

        public static Fence<char> CountFence
            => (Chars.LParen, Chars.RParen);

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
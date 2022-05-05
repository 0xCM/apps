//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        [DataWidth(8)]
        public readonly struct LogicClass : IComparable<LogicClass>
        {
            public readonly LogicKind Kind;

            [MethodImpl(Inline)]
            public LogicClass(LogicKind src)
            {
                Kind = src;
            }

            [MethodImpl(Inline)]
            public LogicClass(char src)
            {
                Kind = (LogicKind)src;
            }

            public bool IsAntecedant
            {
                [MethodImpl(Inline)]
                get => Kind == LogicKind.Antecedant;
            }

            public bool IsConsequent
            {
                [MethodImpl(Inline)]
                get => Kind == LogicKind.Consequent;
            }

            public char Indicator
            {
                [MethodImpl(Inline)]
                get => (char)Kind;
            }

            public string Format()
                => XedRender.format(this);

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public int CompareTo(LogicClass src)
                => XedRules.cmp(Kind,src.Kind);

            [MethodImpl(Inline)]
            public static implicit operator LogicClass(LogicKind src)
                => new LogicClass(src);

            [MethodImpl(Inline)]
            public static implicit operator LogicKind(LogicClass src)
                => src.Kind;

            [MethodImpl(Inline)]
            public static explicit operator byte(LogicClass src)
                => (byte)src.Kind;

            [MethodImpl(Inline)]
            public static implicit operator LogicClass(char src)
                => new LogicClass(src);

            [MethodImpl(Inline)]
            public static implicit operator char(LogicClass src)
                => src.Indicator;
        }
    }
}
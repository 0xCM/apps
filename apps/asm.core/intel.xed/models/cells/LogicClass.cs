//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public readonly struct LogicClass : IComparable<LogicClass>
        {
            public readonly LogicKind Kind;

            [MethodImpl(Inline)]
            public LogicClass(LogicKind src)
            {
                Kind = src;
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

            public bool IsOperator
            {
                [MethodImpl(Inline)]
                get => Kind == LogicKind.Operator;
            }

            public char Indicator
            {
                [MethodImpl(Inline)]
                get => IsAntecedant ? 'A' : IsConsequent ? 'C' : 'f';
            }

            public string Format()
                => Indicator.ToString();

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public int CompareTo(LogicClass src)
                => ((byte)this).CompareTo((byte)src);

            [MethodImpl(Inline)]
            public static implicit operator LogicClass(LogicKind src)
                => new LogicClass(src);

            [MethodImpl(Inline)]
            public static implicit operator LogicKind(LogicClass src)
                => src.Kind;

            [MethodImpl(Inline)]
            public static explicit operator byte(LogicClass src)
                => (byte)src.Kind;

        }
    }
}
//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static XedRules;
    using static XedModels;

    partial class XedPatterns
    {
        public readonly struct XedOpCode : IEquatable<XedOpCode>, IComparable<XedOpCode>
        {
            public readonly OpCodeKind Kind;

            public readonly AsmOcValue Value;

            [MethodImpl(Inline)]
            public XedOpCode(OpCodeKind kind, AsmOcValue value)
            {
                Kind = kind;
                Value = value;
            }

            public string Format()
                => XedRender.format(this);

            public override string ToString()
                => Format();


            public override int GetHashCode()
                => (int)(((uint)Kind << 24) | (uint)Value);

            public bool Equals(XedOpCode src)
                => Kind == src.Kind && Value == src.Value;

            public override bool Equals(object src)
                => src is XedOpCode x && Equals(x);

            public int CompareTo(XedOpCode src)
            {
                var result = ((byte)XedPatterns.ocindex(Kind)).CompareTo((byte)XedPatterns.ocindex(src.Kind));
                if(result == 0)
                    result = Value.CompareTo(src.Value);
                return result;
            }
        }
    }
}
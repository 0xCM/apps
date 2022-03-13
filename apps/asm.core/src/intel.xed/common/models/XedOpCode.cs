//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    partial struct XedModels
    {
        public readonly struct XedOpCode : IEquatable<XedOpCode>, IComparable<XedOpCode>
        {
            public readonly uint PatternId;

            public readonly IClass Class;

            public readonly OpCodeKind Kind;

            public readonly AsmOcValue Value;

            [MethodImpl(Inline)]
            public XedOpCode(uint id, IClass @class, OpCodeKind kind, AsmOcValue value)
            {
                PatternId = id;
                Class = @class;
                Kind = kind;
                Value = value;
            }

            public string Format()
                => XedRender.format(Value);

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
                var result = ((byte)XedRules.ocindex(Kind)).CompareTo((byte)XedRules.ocindex(src.Kind));
                if(result == 0)
                    result = Value.CompareTo(src.Value);
                return result;
            }
        }
    }
}
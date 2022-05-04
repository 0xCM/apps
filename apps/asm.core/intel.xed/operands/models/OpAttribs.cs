//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public readonly struct OpAttribs : IIndex<OpAttrib>
        {
            readonly Index<OpAttrib> Data;

            [MethodImpl(Inline)]
            public OpAttribs(OpAttrib[] src)
            {
                Data = src.Sort();
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Data.IsEmpty;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => Data.IsNonEmpty;
            }

            public OpAttrib[] Storage
            {
                [MethodImpl(Inline)]
                get => Data;
            }

            public uint Count
            {
                [MethodImpl(Inline)]
                get => Data.Count;
            }

            public ref OpAttrib this[int i]
            {
                [MethodImpl(Inline)]
                get => ref Data[i];
            }

            public ref OpAttrib this[uint i]
            {
                [MethodImpl(Inline)]
                get => ref Data[i];
            }

            public OpAttribs Sort()
            {
                Data.Sort();
                return this;
            }

            public string Format()
            {
                var dst = text.buffer();
                for(var i=0; i<Data.Count; i++)
                {
                    if(i!=0)
                        dst.Append(Chars.Colon);
                    dst.Append(this[i].Format());
                }
                return dst.Emit();
            }

            public override string ToString()
                => Format();

            public bool Search(OpAttribClass @class, out OpAttrib dst)
                => XedPatterns.first(this, @class, out dst);

            [MethodImpl(Inline)]
            public static implicit operator OpAttribs(OpAttrib[] src)
                => new OpAttribs(src);

            [MethodImpl(Inline)]
            public static implicit operator OpAttrib[](OpAttribs src)
                => src.Data;

            [MethodImpl(Inline)]
            public static implicit operator Index<OpAttrib>(OpAttribs src)
                => src.Data;

            public static OpAttribs Empty => sys.empty<OpAttrib>();
        }
    }
}
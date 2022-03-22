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
                Data = src;
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

            public bool Search(OpClass @class, out OpAttrib dst)
            {
                var result = false;
                dst = OpAttrib.Empty;
                for(var i=0; i<Count; i++)
                {
                    ref readonly var a = ref this[i];
                    if(a.Class == @class)
                    {
                        dst = a;
                        result = true;
                        break;
                    }
                }
                return result;
            }

            [MethodImpl(Inline)]
            public static implicit operator OpAttribs(OpAttrib[] src)
                => new OpAttribs(src);

            [MethodImpl(Inline)]
            public static implicit operator OpAttrib[](OpAttribs src)
                => src.Data;

            [MethodImpl(Inline)]
            public static implicit operator Index<OpAttrib>(OpAttribs src)
                => src.Data;

        }
    }
}
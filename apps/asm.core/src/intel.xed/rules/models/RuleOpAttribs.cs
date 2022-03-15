//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public readonly struct RuleOpAttribs : IIndex<RuleOpAttrib>
        {
            readonly Index<RuleOpAttrib> Data;

            [MethodImpl(Inline)]
            public RuleOpAttribs(RuleOpAttrib[] src)
            {
                Data = src;
            }

            public RuleOpAttrib[] Storage
            {
                [MethodImpl(Inline)]
                get => Data;
            }

            public uint Count
            {
                [MethodImpl(Inline)]
                get => Data.Count;
            }

            public ref RuleOpAttrib this[int i]
            {
                [MethodImpl(Inline)]
                get => ref Data[i];
            }

            public ref RuleOpAttrib this[uint i]
            {
                [MethodImpl(Inline)]
                get => ref Data[i];
            }

            public RuleOpAttribs Sort()
            {
                Data.Sort();
                return this;
            }

            public bool Search(RuleOpClass @class, out RuleOpAttrib dst)
            {
                var result = false;
                dst = RuleOpAttrib.Empty;
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
            public static implicit operator RuleOpAttribs(RuleOpAttrib[] src)
                => new RuleOpAttribs(src);

            [MethodImpl(Inline)]
            public static implicit operator RuleOpAttrib[](RuleOpAttribs src)
                => src.Data;

            [MethodImpl(Inline)]
            public static implicit operator Index<RuleOpAttrib>(RuleOpAttribs src)
                => src.Data;

        }
    }
}
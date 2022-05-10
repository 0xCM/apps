//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;

    partial class XedRules
    {
        public partial class InstSigs
        {
            [StructLayout(StructLayout,Pack=1)]
            public readonly struct KindIndicator
            {
                public readonly OpNameKind Kind;

                public readonly OpIndicator Indicator;

                [MethodImpl(Inline)]
                public KindIndicator(OpNameKind kind, OpIndicator ind)
                {
                    Kind = kind;
                    Indicator = ind;
                }
            }
        }
    }
}
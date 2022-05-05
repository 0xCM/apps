//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static XedRules;
    using static XedOperands;
    using static XedModels;
    using static core;

    partial class XedRuntime
    {
        public ref readonly Index<InstPattern> Patterns
        {
            [MethodImpl(Inline)]
            get => ref Load<Index<InstPattern>>(StoreIndex.InstPattern);
        }

        public ref readonly RuleTables RuleTables
        {
            [MethodImpl(Inline)]
            get => ref Load<RuleTables>(StoreIndex.RuleTables);
        }

        public ref readonly InstLayouts InstLayouts
        {
            [MethodImpl(Inline)]
            get => ref Load<InstLayouts>(StoreIndex.InstLayouts);
        }
    }
}
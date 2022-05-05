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
        public IMachine Machine()
        {
            var m =  machine(Rules);
            Machines.TryAdd(m.Id,m);
            return m;
        }
    }
}
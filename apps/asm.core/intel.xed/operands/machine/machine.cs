//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedOperands
    {
        public static IMachine machine(XedRules rules)
            => new MachineState(rules);
    }
}
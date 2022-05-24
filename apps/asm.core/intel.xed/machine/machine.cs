//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedOperands
    {
        public static IMachine machine(XedRuntime xed)
            => new MachineState(xed);
    }
}
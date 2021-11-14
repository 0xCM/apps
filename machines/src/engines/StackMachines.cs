//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Machines
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct StackMachines
    {
        [MethodImpl(Inline)]
        public static StackMachine create(uint capacity)
            => new StackMachine(capacity);
    }
}
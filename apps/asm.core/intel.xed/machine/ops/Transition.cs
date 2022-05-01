//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;

    partial class XedMachine
    {
        [MethodImpl(Inline)]
        ref MachineState State()
            => ref RuntimeState;

        [MethodImpl(Inline)]
        public ref MachineMode Mode()
            => ref State().Mode();

        [MethodImpl(Inline)]
        public ref Addressing Addressing()
            => ref State().Addressing();
    }
}
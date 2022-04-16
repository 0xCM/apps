//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static XedRules;

    partial class XedMachine
    {
        [MethodImpl(Inline)]
        ref MachineState State()
            => ref RuntimeState;

        [MethodImpl(Inline)]
        public ref MachineMode Mode()
            => ref State().Mode();

        [MethodImpl(Inline)]
        public ref InstPattern InstPattern()
        {
            ref var pattern = ref State().Pattern();
            State().Mode() = pattern.Mode;
            State().Group() = PatternGroup;
            State().Class() = pattern.InstClass;
            State().Form() = pattern.InstForm;
            return ref pattern;
        }
    }
}
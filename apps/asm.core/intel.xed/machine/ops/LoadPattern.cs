//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static XedRules;
    using static XedDisasm;

    partial class XedMachine
    {
        [MethodImpl(Inline)]
        public ref InstPattern LoadPattern()
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
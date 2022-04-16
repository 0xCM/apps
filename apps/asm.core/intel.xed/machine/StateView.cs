//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedModels;
    using static XedRules;

    partial class XedMachine
    {
        public ref readonly uint Id
        {
            [MethodImpl(Inline)]
            get => ref State().Id;
        }

        public ref readonly RuleState RuleState
        {
            [MethodImpl(Inline)]
            get => ref State().Rules();
        }

        public ref readonly InstGroupMember Group
        {
            [MethodImpl(Inline)]
            get => ref State().Group();
        }

        public ref readonly InstClass InstClass
        {
            [MethodImpl(Inline)]
            get => ref State().Class();
        }

        public ref readonly InstForm InstForm
        {
            [MethodImpl(Inline)]
            get => ref State().Form();
        }

        ref readonly InstPattern Pattern
        {
            [MethodImpl(Inline)]
            get => ref State().Pattern();
        }
    }
}
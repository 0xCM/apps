//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;

    partial class XedDocs
    {
        public class RuleDoc
        {
            readonly RuleTables _Rules;

            public RuleDoc(RuleTables rules)
            {
                _Rules = rules;
            }

            public ref readonly RuleTables Rules
            {
                [MethodImpl(Inline)]
                get => ref _Rules;
            }

            public string Format()
                => new RuleDocFormatter(this).Format();
        }
    }
}
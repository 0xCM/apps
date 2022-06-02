//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Rules
    {
        public static ChoiceRule<RuleValue<T>> choices<T>(Index<T> src)
            => src.Storage.Map(value);

        public static ChoiceRule<RuleValue<T>> choices<T>(params T[] src)
            => src.Map(value);
    }
}
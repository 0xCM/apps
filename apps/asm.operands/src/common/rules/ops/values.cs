//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Rules
    {
       public static RuleValue<T>[] values<T>(params T[] values)
            => values.Select(value);
    }
}
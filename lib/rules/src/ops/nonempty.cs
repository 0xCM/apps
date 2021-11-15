//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct RuleModels
    {
        public static NonEmpty<T> nonemtpy<T>()
            where T : INullity
                => default;
    }
}
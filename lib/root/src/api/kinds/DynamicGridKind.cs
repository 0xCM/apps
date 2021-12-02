// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [SymSource("api.kinds")]
    public enum DynamicGridKind : uint
    {
        None = 0,

        Generic = ApiGridCategory.GenericDynamic,

        Natural = ApiGridCategory.NaturalDynamic
    }
}
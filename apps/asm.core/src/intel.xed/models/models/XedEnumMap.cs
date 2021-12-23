//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Collections.Generic;

    using static XedModels;

    public sealed class XedEnumMap : ConstLookup<string,Type>
    {
        XedEnumMap(Dictionary<string,Type> src)
            : base(src)

        {

        }

        static Dictionary<string,Type> Data = core.dict(
            ("xed_reg_enum_t", typeof(RegId))

            );
    }
}
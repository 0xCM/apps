//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class XedEnumMap : ConstLookup<string,Type>
    {
        XedEnumMap(Dictionary<string,Type> src)
            : base(src)

        {

        }

        static Dictionary<string,Type> Data = core.dict(
            ("xed_reg_enum_t", typeof(XedRegId))

            );
    }
}
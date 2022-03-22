//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;

    partial class XedFields
    {
        [MethodImpl(Inline), Op]
        public static OSZ osz(bit src)
            => src ? OSZ.True : OSZ.False;

        [MethodImpl(Inline), Op]
        public static OSZ osz(in RuleState src)
            => src.OSZ ? OSZ.True : OSZ.False;
    }
}
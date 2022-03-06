//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;
    using static core;
    using static XedModels;

    partial class XedCmdProvider
    {
        [CmdOp("xed/check/regmap")]
        Outcome CheckRegmap(CmdArgs args)
        {
            var map = XedModels.regmap();
            var keys = map.Keys;
            for(var i=0; i<keys.Length; i++)
            {
                ref readonly var key = ref skip(keys,i);
                var kind = map[key];
                Write(string.Format("{0} = {1}", key,  kind));
            }
            return true;
        }

    }
}
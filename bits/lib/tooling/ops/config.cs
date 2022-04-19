//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Tooling
    {
        [Op]
        public static Outcome parse(string src, out ToolConfig dst)
            => ToolConfig.parse(src, out dst);
    }
}
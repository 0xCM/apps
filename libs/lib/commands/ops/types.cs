//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Cmd
    {
        [Op]
        public static Type[] types(params Assembly[] src)
            =>  src.Types().Tagged<CmdAttribute>();
    }
}
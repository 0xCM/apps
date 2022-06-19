//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Cmd
    {
        [Op]
        public static ICmd[] search(Assembly src)
        {
            var types = src.Types().Tagged<CmdAttribute>();
            var specs = types.Select(t => (ICmd)Activator.CreateInstance(t));
            return specs;
        }
    }
}
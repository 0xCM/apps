//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Root
    {
        [Op]
        public static string name(Assembly src)
            => src.GetName().Name;
    }
}
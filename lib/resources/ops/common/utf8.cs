//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Text;

    partial struct Resources
    {
        [MethodImpl(Inline), Op]
        public static string utf8(in Asset src)
            => Encoding.UTF8.GetString(view(src));
    }
}
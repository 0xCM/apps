//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    partial struct Lines
    {
        [Op]
        public static string format(in LineNumber src)
            => string.Format(LineNumber.RenderPattern, src.Value);
    }
}
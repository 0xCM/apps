//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct CsModels
    {
        [Op]
        public static CsComment comment(string content)
            => new CsComment(content);
    }
}
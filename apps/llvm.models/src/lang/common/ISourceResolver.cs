//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Lang
{
    public interface ISourceResolver
    {
        TextBlock ResolveSource(ILangSource src);
    }
}
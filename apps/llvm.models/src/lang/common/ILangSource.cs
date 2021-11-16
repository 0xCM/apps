//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Lang
{
    using System.Runtime.CompilerServices;

    using static Root;

    public interface ILangSource
    {
        LangKind LangKind {get;}
    }
}
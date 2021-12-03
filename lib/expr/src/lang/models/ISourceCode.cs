//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ISourceCode
    {
        LangKind LangKind {get;}
    }

    public interface ISourceCode<T> : ISourceCode
    {
        T Document {get;}
    }
}
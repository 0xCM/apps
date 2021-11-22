//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ISourceGenerator : IGenerator<SourceBlock>
    {
        SourceKind SourceKind {get;}
    }

    public interface ISourceGenerator<S> : ISourceGenerator, IGenerator<S,SourceBlock>
    {

    }
}
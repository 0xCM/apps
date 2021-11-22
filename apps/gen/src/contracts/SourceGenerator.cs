//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class SourceGenerator<S> : ISourceGenerator<S>
    {
        public SourceKind SourceKind {get;}

        public abstract SourceBlock Generate(S src);

        protected SourceGenerator(SourceKind kind)
        {
            SourceKind = kind;
        }
    }
}
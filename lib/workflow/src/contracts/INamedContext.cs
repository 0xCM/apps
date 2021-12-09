//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface INamedContext : IContext
    {
        Name ContextName {get;}

        string ITextual.Format()
            => ContextName;
    }

    public interface INamedContext<S> : INamedContext, IContext<S>
    {

    }
}
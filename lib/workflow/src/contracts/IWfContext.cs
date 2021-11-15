//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IWfContext : ITextual
    {
        IAppPaths Paths {get;}

        IJsonSettings Settings {get;}

        IApiParts ApiParts {get;}

        WfController Controller {get;}

        string[] Args {get;}

        string AppName
            => Controller.Name;

        string ITextual.Format()
            => AppName;
    }

    public interface IWfContext<S> : IWfContext
    {
        S State {get;}
    }
}
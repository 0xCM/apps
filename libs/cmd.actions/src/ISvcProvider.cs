//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ICmdProvider
    {
        CmdActions Actions {get;}
    }

    public interface IAppCmdService : IAppService
    {
        void Run();

        ICmdDispatcher Dispatcher {get;}
    }

    public interface ICmdDispatcher
    {
        Outcome Dispatch(string action, CmdArgs args);

        Outcome Dispatch(string action);

        IEnumerable<string> SupportedActions {get;}

        Outcome Dispatch(CmdSpec cmd)
            => Dispatch(cmd.Name, cmd.Args);
    }

    public interface ICmdRunner
    {
        void RunJobs(string match);

        void RunCmd(string name);

        void RunCmd(string name, CmdArgs args);
    }

    public interface ISvcProvider
    {
        Assembly HostComponent {get;}

        PartId PartId {get;}

        ReadOnlySpan<Type> HostTypes {get;}

        S Service<S>();
    }

    public interface ISvcProvider<T> : ISvcProvider
        where T : ISvcProvider<T>, new()
    {
        Assembly ISvcProvider.HostComponent
            => typeof(T).Assembly;

        PartId ISvcProvider.PartId
            => HostComponent.Id();

        ReadOnlySpan<Type> ISvcProvider.HostTypes
            => typeof(T).DeclaredPublicInstanceMethods().Concrete().Select(x => x.ReturnType);
    }
}
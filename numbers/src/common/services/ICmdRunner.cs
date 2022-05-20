//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ICmdRunner
    {
        void RunJobs(string match);

        void RunCmd(string name);

        void RunCmd(string name, CmdArgs args);
    }

    public interface IWsCmdRunner : ICmdRunner
    {
        void Project(IProjectWs ws);

        IProjectWs Project();

        void LoadProject(CmdArgs args);
    }

    public interface IWsCmdRunner<S> : IWsCmdRunner
        where S : IWsCmdRunner<S>, new()
    {

    }
}
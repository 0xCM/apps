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

    public interface IWsCmdRunner : ICmdRunner, IProjectProvider
    {
        void Project(IProjectWs ws);

        FileCatalog ProjectFiles {get;}

        void LoadProject(CmdArgs args);
    }

    public interface IWsCmdRunner<S> : IWsCmdRunner
        where S : IWsCmdRunner<S>, new()
    {

    }
}
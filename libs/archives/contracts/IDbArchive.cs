//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IDbArchive : IDbSources, IDbTargets
    {
        IDbTargets Logs()
            => Targets("logs");

        IDbTargets Logs(string scope)
            => Targets($"logs/{scope}");

        FS.FilePath Log(string name, FileKind kind)
            => Logs().Path(name,kind);

        FS.FilePath Log(string scope, string name, FileKind kind)
            => Logs(scope).Path(name,kind);

    }

    public interface IDbArchive<A> : IDbArchive
        where A : IDbArchive, new()
    {

    }
}
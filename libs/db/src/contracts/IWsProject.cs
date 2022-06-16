//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static ApiGranules;

    public interface IWsProject : IRootedArchive, IProjectWs
    {
        FS.FilePath Script(ScriptId id, FileKind kind)
            => Sources(scripts).Path(id, kind);
    }
}
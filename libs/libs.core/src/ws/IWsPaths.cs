//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static ApiGranules;

    public interface IWsPaths : IWsArchive
    {
        DbSources WsCmd()
            => Sources(cmd);

        DbTargets WsLogs()
            => Targets(wslogs);

        DbTargets WsLogs(Timestamp ts)
            => Targets(wslogs).Targets(ts.Format());

        DbTargets WsLogs(string scope)
            => WsLogs().Targets(scope);

        DbTargets AppLogs()
            => WsLogs(apps);

        DbTargets AppLogs(Timestamp ts)
            => WsLogs(ts).Targets(apps);

        DbTargets CmdLogs()
            => WsLogs(commands);

        DbTargets Cmdogs(Timestamp ts)
            => WsLogs(ts).Targets(commands);
    }
}
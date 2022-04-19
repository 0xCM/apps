//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    [Record(TableId)]
    public struct CmdExecStatus
    {
        public const string TableId = "cmd.status";

        public int Id;

        public DateTime StartTime;

        public bool HasExited;

        public DateTime ExitTime;

        public TimeSpan Duration;

        public int ExitCode;
    }
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public enum EventKind : uint
    {
        None = 0,

        Babble = MsgLevel.Babble,

        Status = MsgLevel.Status,

        Warn = MsgLevel.Warn,

        Error = MsgLevel.Error,

        Running,

        Ran,

        Emitting,

        Emitted,

        EmittingTable,

        EmittedTable,

        EmittingFile,

        EmittedFile,

        Creating,

        Created,

        Disposed,

        RunningCmd,

        CmdRan,

        Processing,

        Processed,

        ProcessingFile,

        ProcessedFile,
        Data,

        Rows,
    }
}
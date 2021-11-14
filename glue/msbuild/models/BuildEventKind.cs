//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public enum BuildEventKind : byte
    {
        None,

        ProjectStarted,

        ProjectFinished,

        BuildStarted,

        BuildFinished,

        BuildWarning,

        BuildError,

        BuildStatus,

        BuildMessage
    }
}
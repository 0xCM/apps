//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    public interface IEmissionLog : IDisposable, IWfEventSink<EmittedFileEvent>, IWfEventSink<EmittedTableEvent>
    {
        FS.FilePath TargetPath {get;}
    }
}
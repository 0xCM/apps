//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IWorkerLog : IDisposable
    {
        void LogStatus(string content);

        void LogError(string content);
    }
}
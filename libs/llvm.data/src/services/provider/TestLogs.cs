//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static core;

    partial class LlvmDataProvider
    {
        public Index<LlvmTestLogEntry> TestLogs(string id)
            => (Index<LlvmTestLogEntry>)DataSets.GetOrAdd(id + "-test-logs", _
                => LlvmTests.logs(FS.dir(@"J:\llvm\toolset\logs") + FS.file(id + "-tests-detail", FS.Json)));
    }
}
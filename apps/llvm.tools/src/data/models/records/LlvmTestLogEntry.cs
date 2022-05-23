//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    [Record(TableId)]
    public struct LlvmTestLogEntry
    {
        const string TableId = "llvm.logs.tests";

        [Render(24)]
        public string code;

        [Render(36)]
        public string elapsed;

        [Render(112)]
        public string name;

        [Render(1)]
        public string output;
    }
}
//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedToolDomain
    {
        [Record(TableId)]
        public struct ScriptSpec
        {
            public const string TableId = "xed.scripts";

            public string Name;

            public FS.FilePath InputPath;

            public FS.FilePath SummaryPath;

            public FS.FilePath DetailPath;
        }
    }
}
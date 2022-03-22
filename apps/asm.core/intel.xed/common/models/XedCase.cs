//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId)]
    public struct XedCase
    {
        public const string TableId = "xed.case";

        public Identifier CaseId;

        public FS.FilePath InputPath;

        public FS.FilePath SummaryPath;

        public FS.FilePath DetailPath;
    }
}
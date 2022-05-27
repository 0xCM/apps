//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Linq;

    using static Root;
    using static core;

    partial class TestApp<A>
    {
        public void EmitLogs()
        {
            var basename = AppName;
            var results = SortResults();

            if(results.Any())
            {
                var timing = results.Sum(x => x.Duration.TimeSpan.TotalSeconds);
                var dst = Db.CaseLogSummary();
                Wf.Status($"Emitting case log to {dst.ToUri()} with execution time of {timing} seconds");
                EmitTestCaseLog(dst, results);
            }
        }

        static FS.FilePath EmitTestCaseLog(FS.FilePath dst, TestCaseRecord[] records)
        {
            if(records.Length == 0)
                return FS.FilePath.Empty;

            Tables.emit(@readonly(records), TestCaseRecord.RenderWidths, TextEncodingKind.Unicode, dst);
            return dst;
        }
    }
}
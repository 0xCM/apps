//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedRules;

    partial class XedDisasmSvc
    {
        public Index<DisasmDetail> CollectDisasmDetails(WsContext context)
        {
            var result = Outcome.Success;
            var catalog = context.Files;
            var files = catalog.Entries(FileKind.XedRawDisasm);
            var count = files.Count;
            var buffer = list<DisasmDetail>();
            var docs = core.bag<AsmDisasmSummaryDoc>();
            var bag = core.bag<DisasmDetail>();
            var xedsvc = this;
            iter(files, file => {

                var blocks = XedDisasmOps.LoadFileBlocks(file);
                result = XedDisasmOps.ParseSummaries(context, file, out var doc);
                docs.Add(doc);
                var rows = doc.View;
                Require.equal((uint)rows.Length, blocks.LineBlocks.Count);
                result = xedsvc.CalcDisasmDetails(context, blocks, bag);
                result.Require();
            },true);

            var details = bag.ToArray().Sort();
            for(var i=0u; i<details.Length; i++)
                seek(details,i).Seq = i;
            EmitDisasmDetails(details, Projects.Table<DisasmDetail>(context.Project));
            context.Receiver.Collected(details);
            return details;
        }
    }
}
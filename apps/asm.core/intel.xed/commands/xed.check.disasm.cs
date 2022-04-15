//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedDisasm;

    partial class XedCmdProvider
    {
        [CmdOp("xed/check/disasm")]
        Outcome CheckDisasm(CmdArgs args)
        {
            var docs = XedDisasm.docs(Context()).Sort();
            for(var i=0; i<docs.Count; i++)
            {
                ref readonly var doc = ref docs[i];
                ref readonly var file = ref doc.File;
                ref readonly var source = ref file.Source;
                ref readonly var path = ref source.Path;
                ref readonly var docid = ref source.DocId;
                var count = file.LineCount;
                Write(string.Format("{0,-8} | {1,-8} | {2}", docid, file.LineCount, path.ToUri()));
            }

            return true;
        }
    }
}
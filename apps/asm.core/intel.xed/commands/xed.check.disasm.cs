//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;
    using static core;
    using static XedRules;
    using static XedModels;
    using static XedFields;

    partial class XedCmdProvider
    {
        XedForms XedForms => Service(Wf.XedForms);

        [CmdOp("xed/check/forms")]
        Outcome CheckForms(CmdArgs args)
        {
            //XedForms.EmitTokens();
            var buffer = ByteBlock64.Empty;
            var bv = BitVector64.Zero;
            for(var i=0u; i<64; i++)
                buffer[i] = math.odd(i) ? bit.On : bit.Off;
            bv = Bitfields.pack64x1(buffer.Bytes);
            Write(bv.Format());

            for(var i=0u; i<64; i++)
                buffer[i] = i < 8 ? bit.Off : i < 16 ? bit.On : bit.Off;
            bv = Bitfields.pack64x1(buffer.Bytes);
            Write(bv.Format());

            return true;
        }

        [CmdOp("xed/check/disasm")]
        Outcome EmitBreakdowns(CmdArgs args)
        {
            var context = Context();
            var flow = XedDisasm.flow(context);
            var targets = bag<DTarget>();
            var sources = XedDisasm.sources(context);
            iter(XedDisasm.sources(context), src => {
                var dst = new DTarget(this);
                flow.Run(src,dst);
                targets.Add(dst);
            }, true);

            return true;
        }

        void Drill(WsContext context, in FileRef src)
        {
            var buffer = XedDisasm.fields();
            var doc = XedDisasm.detail(context,src);
            var count = doc.DataFile.LineCount;
            var state = OperandState.Empty;
            for(var i=0; i<count; i++)
            {
                ref readonly var block = ref doc[i];
            }

            var name = text.left(src.Path.FileName.Format(),Chars.Dot);
            var path = context.Project.Datasets() + FS.folder("xed.disasm") +  FS.file(string.Format("{0}.{1}",name, "xed.disasm.ops.pack"), FS.Csv);
        }
    }
}
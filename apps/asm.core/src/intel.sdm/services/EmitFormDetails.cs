//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    partial class IntelSdm
    {
        void EmitFormDetails(ConstLookup<Identifier,AsmFormDescriptor> src)
        {
            var path = SdmPaths.FormDetailPath();
            var lookup = dict<Identifier,AsmFormDetail>();
            var keys = src.Keys;
            var count = keys.Length;
            var buffer = alloc<AsmFormDetail>(count);

            for(var i=0u; i<count; i++)
            {
                ref readonly var key = ref skip(keys,i);
                ref var dst = ref seek(buffer,i);
                var form = src[key];
                dst.Id = form.Id;
                dst.Name = key;
                dst.Sig = form.Sig;
                dst.OpCode = form.OpCode;
                dst.Mode64 = ((form.Mode & AsmBitModeKind.Mode64) != 0);
                dst.Mode32 = ((form.Mode & AsmBitModeKind.Mode32) != 0);
                dst.IsRex = AsmOpCodes.rex(form.OpCode);
                dst.IsVex = AsmOpCodes.vex(form.OpCode);
                dst.IsEvex = AsmOpCodes.evex(form.OpCode);
                dst.Description = form.Description;
            }
            buffer.Sort();
            for(var i=0u; i<count; i++)
                seek(buffer,i).Seq = i;

            //Require.invariant(buffer.Select(x => x.Id).Distinct().Length == count);

            TableEmit(@readonly(buffer), AsmFormDetail.RenderWidths, SdmPaths.FormDetailPath());
        }
    }
}
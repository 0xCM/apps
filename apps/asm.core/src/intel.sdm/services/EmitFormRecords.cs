//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    partial class IntelSdm
    {
        public Index<AsmFormRecord> EmitFormRecords(ReadOnlySpan<SdmOpCodeDetail> src)
        {
            var descriptors = IdentifyForms(CalcFormDescriptors(src));
            EmitFormDetails(descriptors);
            return Emit(descriptors);
        }

        Index<AsmFormRecord> Emit(ConstLookup<Identifier,AsmFormDescriptor> src)
        {
            var keys = src.Keys;
            var count = keys.Length;;
            var buffer = alloc<AsmFormRecord>(count);
            for(var i=0u; i<count; i++)
            {
                ref readonly var key = ref skip(keys,i);
                var form = src[key];
                ref var dst = ref seek(buffer,i);
                dst.Sig = form.Sig;
                dst.OpCode = form.OpCode;
            }

            buffer.Sort();
            for(var i=0u; i<count; i++)
                seek(buffer,i).Seq = i;
            TableEmit(@readonly(buffer), AsmFormRecord.RenderWidths, SdmPaths.Forms());
            return buffer;
        }
   }
}
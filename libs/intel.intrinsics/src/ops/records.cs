//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static IntrinsicsDoc;
    using static XedModels;

    using R = XedRules;

    partial class IntelIntrinsics
    {
        static void records(ReadOnlySpan<IntrinsicDef> src, Span<IntrinsicRecord> dst)
        {
            for(var i=0; i< src.Length; i++)
                record(skip(src,i), out seek(dst,i));
        }

        static void record(in IntrinsicDef src, out IntrinsicRecord dst)
        {
            dst.Key = 0;
            dst.Name = src.name;
            dst.CpuId = src.CPUID;
            dst.Types = src.types;
            dst.Category = src.category;
            dst.Signature = src.Sig();

            if(instruction(src, out var inst))
            {
                dst.InstSig = inst;
                dst.InstForm = inst.xed;
                dst.FormId = (ushort)inst.xed;
                dst.InstClass = inst.InstClass;
            }
            else
            {
                dst.InstClass = AsmInstClass.Empty;
                dst.InstSig = Instruction.Empty;
                dst.InstForm = InstForm.Empty ;
                dst.FormId = 0;
            }
        }
    }
}
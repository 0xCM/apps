//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    partial class IntelSdm
    {
        public ConstLookup<Identifier,AsmForm> LoadForms()
        {
            var result = LoadFormRecords(out var records);
            var dst = sys.empty<AsmForm>();
            if(result.Fail)
                Errors.Throw(result);

            var count = records.Count;
            dst = alloc<AsmForm>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var record = ref records[i];
                seek(dst,i) = AsmForm.define(record.Sig, record.OpCode);
            }

            return IdentifyForms(dst);
        }
    }
}
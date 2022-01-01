//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    partial class IntelSdm
    {
        public Outcome<Index<SdmOpCodeDetail>> LoadImportedOpcodeDetails()
        {
            var result = Outcome.Success;
            var dst = sys.empty<SdmOpCodeDetail>();
            var src = SdmPaths.ImportTable<SdmOpCodeDetail>();
            var lines = src.ReadNumberedLines();
            var count = lines.Count -1;
            dst = alloc<SdmOpCodeDetail>(count);
            result = ocdetails(slice(lines.View,1), dst);
            if(result.Fail)
                return result;
            else
                return (true,dst);
        }
    }
}
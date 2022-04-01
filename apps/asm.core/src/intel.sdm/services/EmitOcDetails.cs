//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial class IntelSdm
    {
        void EmitOcDetails(Index<SdmOpCodeDetail> src)
        {
            for(var i=0; i<src.Count; i++)
            {
                ref readonly var detail = ref src[i];
                var m64 = detail.Mode64.Format().Trim();
                var m32 = detail.Mode32.Format().Trim();
                if(!(m64 == "Valid" || m64 == "Invalid"))
                    Warn(string.Format("Invalid 64-bit mode specifier for {0}", detail.SigText.Format().Trim()));
                if(!(m32 == "Valid" || m32 == "Invalid"))
                    Warn(string.Format("Invalid 32-bit mode specifier for {0}", detail.SigText.Format().Trim()));
            }

            var dst = SdmPaths.ImportTable<SdmOpCodeDetail>();
            using var writer = dst.UnicodeWriter();
            TableEmit(src.View, SdmOpCodeDetail.RenderWidths, writer, dst);
        }
    }
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    partial class AsmCmdService
    {
        [CmdOp(".hexrays")]
        Outcome AsmHexArray(CmdArgs args)
        {
            var result = Outcome.Success;

            LoadProjectSources(Project(), "hex");
            var src = Files().View;
            var count = src.Length;
            var files = alloc<FS.FilePath>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var path = ref skip(src,i);
                result = Hex.hexbytes(path.ReadAsci(), out var code);
                if(result.Fail)
                    return result;

                var recoded = HexFormatter.array(code.View);
                var dst = OutDir("asmws") + path.FileName;
                using var writer = dst.AsciWriter();
                writer.WriteLine(recoded);
                Write(string.Format("{0} -> {1}", path.ToUri(), dst.ToUri()));
                seek(files,i) = dst;
            }
            Files(files,false);
            return result;
        }
    }
}
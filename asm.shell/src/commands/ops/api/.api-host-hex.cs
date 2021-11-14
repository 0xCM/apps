//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    partial class AsmCmdService
    {
        [CmdOp(".api-host-hex")]
        Outcome ApiHexHost(CmdArgs args)
        {
            var result = Outcome.Success;
            var paths = ApiArchive.HexPackPaths(true).View;
            result = ApiUri.host(arg(args,0), out var host);
            if(result.Fail)
                return result;

            var path = ApiArchive.ParsedHexPath(host);
            if(!path.Exists)
                return (false, FS.missing(path));

            var counter = 0u;
            ApiHex.load(path, out MemoryBlocks dst);
            var blocks = dst.Sort().View;

            var buffer = span<char>(Pow2.T16);

            var outdir = OutDir("xarrays") + FS.folder(string.Format("{0}.{1}", host.Part.Format(), host.HostName));
            var count = blocks.Length;
            for(var i=0; i<count; i++)
            {
                var outpath = outdir + FS.file(string.Format("{0:D5}", i),FS.XArray);
                ref readonly var block = ref skip(blocks,i);
                var length = Hex.hexarray(block.View, buffer);
                var content = text.format(slice(buffer,0,length));
                using var writer = outpath.AsciWriter();
                writer.WriteLine(content);
            }

            Write(string.Format("Emitted {0} files to {1}", count, outdir));

            return result;
        }
    }
}
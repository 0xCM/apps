//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using System.Linq;

    using static core;

    partial class ApiCode
    {
        [Op]
        public Index<ApiCodeDescriptor> Descriptors(IWfRuntime wf)
        {
            var paths = Wf.Db();
            var files = paths.ParsedExtractPaths().View;
            if(files.Length == 0)
            {
                Warn($"No code found in {paths.ParsedExtractRoot()}");
                return sys.empty<ApiCodeDescriptor>();
            }

            var count = files.Length;
            var dst = list<ApiCodeDescriptor>();
            var hex = wf.ApiHex();
            for(var i=0u; i<count; i++)
            {
                ref readonly var file = ref skip(files,i);
                var inner = wf.Running(file);
                var rows = hex.ReadRows(file);
                var blocks = rows.Length;
                if(blocks == 0)
                    wf.Warn($"No content found in {file.ToUri()}");
                else
                {
                    var buffer = alloc<ApiCodeDescriptor>(blocks);
                    var target = span(buffer);
                    for(var j=0u; j<blocks; j++)
                        store(skip(rows,j), ref seek(target,j));
                    dst.AddRange(buffer);
                    wf.Ran(inner, blocks);
                }
            }

            return dst.OrderBy(x => x.Base).ToArray();
        }

        [MethodImpl(Inline), Op]
        public static ref ApiCodeDescriptor store(in ApiHexRow src, ref ApiCodeDescriptor dst)
        {
            dst.Part = src.Uri.Part;
            dst.Host = src.Uri.Host.HostName;
            dst.Base = src.Address;
            dst.Size = src.Data.Length;
            dst.Uri = src.Uri;
            dst.Encoded = src.Data;
            return ref dst;
        }
    }
}
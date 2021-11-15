//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Linq;
    using System.Reflection;

    using static Root;
    using static core;

    [ApiHost]
    public readonly struct ApiCode
    {
        public static Index<ApiMsil> msil(ReadOnlySpan<MethodInfo> src)
        {
            var count = src.Length;
            var buffer = alloc<ApiMsil>(count);
            var methods = src;
            var target = span(buffer);
            for(var i=0; i<count; i++)
            {
                ref readonly var method = ref skip(src,i);
                var address = ClrJit.jit(method);
                var uri = ApiUri.located(method.DeclaringType.ApiHostUri(), method.Name, method.Identify());
                var located = new ResolvedMethod(uri, method, address);
                var body = method.GetMethodBody();
                var sig = method.ResolveSignature();
                if(body != null)
                {
                    var ilbytes = body.GetILAsByteArray() ?? Array.Empty<byte>();
                    var length = ilbytes.Length;
                    seek(target,i) = new ApiMsil(method.MetadataToken, address, uri, sig, ilbytes, method.MethodImplementationFlags);
                }
            }

            return buffer;
        }

        [MethodImpl(Inline), Op]
        public static ApiPartCode combine(PartId part, ApiHostBlocks[] src)
            => new ApiPartCode(part,src);

        /// <summary>
        /// Determines whether an operation accepts an argument of specified numeric kind
        /// </summary>
        /// <param name="src">The encoded operation</param>
        /// <param name="match">The kind to match</param>
        [Op]
        public static bool accepts(ApiCodeBlock src, NumericKind match)
            => TypeIdentity.numeric(src.Id.Components.Skip(2)).Contains(match);

        /// <summary>
        /// Determines the arity of the encoded operation
        /// </summary>
        /// <param name="src">The encoded operation</param>
        [MethodImpl(Inline), Op]
        public static int arity(ApiCodeBlock src)
            => src.OpUri.OpId.Components.Count() - 1;

        [Op]
        public static Index<ApiCodeDescriptor> descriptors(IWfRuntime wf)
        {
            var paths = wf.Db();
            var files = paths.ParsedExtractPaths().View;
            var empty = Index<ApiCodeDescriptor>.Empty;
            if(files.Length == 0)
            {
                wf.Warn($"No code found in {paths.ParsedExtractRoot()}");
                return empty;
            }

            var count = files.Length;
            var flow = wf.Running(Msg.ProcessingApiHexFiles.Format(count));
            var dst = list<ApiCodeDescriptor>();
            var hex = wf.ApiHex();
            for(var i=0u; i<count; i++)
            {
                ref readonly var file = ref skip(files,i);
                var inner = wf.Running(file, "apihex");
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

            wf.Ran(flow, Msg.AccumulatedDescriptors.Format(dst.Count));
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
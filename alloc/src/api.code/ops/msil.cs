//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;

    partial class ApiCode
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
    }
}

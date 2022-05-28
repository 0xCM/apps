//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
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
                var entry = ClrJit.jit(method);
                var body = method.GetMethodBody();
                if(body != null)
                {
                    var uri = ApiUri.located(method.DeclaringType.ApiHostUri(), method.Name, method.Identify());
                    var resolved = new ResolvedMethod(uri, method, entry);
                    seek(target,i) = new ApiMsil(
                        method.MetadataToken,
                        resolved.EntryPoint,
                        resolved.Method.DisplaySig(),
                        resolved.Uri,
                        method.ResolveSignature(),
                        body.GetILAsByteArray() ?? sys.empty<byte>(),
                        method.MethodImplementationFlags
                        );
                }
            }

            return buffer;
        }
    }
}

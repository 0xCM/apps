//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using Asm;

    partial class ApiCode
    {

        public static ApiMember member(in ResolvedMethod src)
            => new ApiMember(src.Uri, src.Method, src.EntryPoint, ClrDynamic.msil(src.EntryPoint, src.Uri, src.Method));

        static EncodedMember member(in CollectedEncoding src)
        {
            var token = src.Token;
            var dst = new EncodedMember();
            dst.Id = token.Id;
            dst.EntryAddress = token.EntryAddress;
            dst.TargetAddress = token.TargetAddress;
            if(token.EntryAddress != token.TargetAddress)
            {
                dst.Disp = AsmRel.disp32((token.EntryAddress, JmpRel32.InstSize), token.TargetAddress);
                dst.StubAsm = string.Format("jmp near ptr {0:x}h", (int)AsmRel.target(dst.Disp));
            }
            dst.CodeSize = (ushort)src.Code.Size;
            dst.Sig = token.Sig.Format();
            dst.Uri = token.Uri.Format();
            var result = ApiIdentity.parse(dst.Uri, out var uri);
            if(result.Fail)
                Errors.Throw(AppMsg.ParseFailure.Format(nameof(uri), dst.Uri));
            dst.Host = uri.Host.Format();
            return dst;
        }

        // public static Index<ApiMsil> msil(ReadOnlySpan<MethodInfo> src)
        // {
        //     var count = src.Length;
        //     var buffer = alloc<ApiMsil>(count);
        //     var methods = src;
        //     var target = span(buffer);
        //     for(var i=0; i<count; i++)
        //     {
        //         ref readonly var method = ref skip(src,i);
        //         var entry = ClrJit.jit(method);
        //         var body = method.GetMethodBody();
        //         if(body != null)
        //         {
        //             var uri = ApiIdentity.located(method.DeclaringType.ApiHostUri(), method.Name, method.Identify());
        //             var resolved = new ResolvedMethod(uri, method, entry);
        //             seek(target,i) = new ApiMsil(
        //                 method.MetadataToken,
        //                 resolved.EntryPoint,
        //                 resolved.Method.DisplaySig(),
        //                 resolved.Uri,
        //                 method.ResolveSignature(),
        //                 body.GetILAsByteArray() ?? sys.empty<byte>(),
        //                 method.MethodImplementationFlags
        //                 );
        //         }
        //     }

        //     return buffer;
        // }

        /// <summary>
        /// Resolves a specified method
        /// </summary>
        /// <param name="src">The source method</param>
        public static ResolvedMethod resolve(MethodInfo src)
        {
            var diviner = MultiDiviner.Service;
            var host = ApiHostUri.from(src.DeclaringType);
            var uri = ApiIdentity.define(ApiUriScheme.Located, host, src.Name, diviner.Identify(src));
            var resolved = new ResolvedMethod(src, uri, ClrJit.jit(src));
            return resolved;
        }
    }
}
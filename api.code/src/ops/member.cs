//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    partial class ApiCode
    {
        static EncodedMember member(in CollectedEncoding src)
        {
            var token = src.Token;
            var dst = new EncodedMember();
            dst.Id = token.Id;
            dst.EntryAddress = token.EntryAddress;
            dst.TargetAddress = token.TargetAddress;
            if(token.EntryAddress != token.TargetAddress)
            {
                dst.Disp = AsmRel32.disp((token.EntryAddress, JmpRel32.InstSize), token.TargetAddress);
                dst.StubAsm = string.Format("jmp near ptr {0:x}h", (int)AsmRel32.reltarget(dst.Disp));
            }
            dst.CodeSize = (ushort)src.Code.Size;
            dst.Sig = token.Sig.Format();
            dst.Uri = token.Uri.Format();
            var result = ApiUri.parse(dst.Uri, out var uri);
            if(result.Fail)
                Errors.Throw(AppMsg.ParseFailure.Format(nameof(uri), dst.Uri));
            dst.Host = uri.Host.Format();
            return dst;
        }
    }
}
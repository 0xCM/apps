//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class ApiCode
    {
        static EncodedMembers members(SymbolDispenser symbols, Index<CollectedEncoding> src)
        {
            var dst = new EncodedMembers.EncodingData();
            var total = 0u;
            src.Sort();
            iter(src, c => total += c.Code.Size);
            var binary = code(total, src);
            var offset = 0u;
            var count = src.Count;
            var offsets = alloc<uint>(count);
            var tokens = alloc<ApiToken>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var info = ref src[i];
                var size = info.Code.Size;
                seek(offsets,i) = offset;
                offset += size;
            }
            dst.Symbols = symbols;
            dst.CodeBuffer = ManagedBuffer.pin(binary.Storage);
            dst.Offsets = offsets;
            dst.Tokens = tokens;
            return new EncodedMembers(dst);
        }

        static EncodedMembers members(SymbolDispenser symbols, Index<EncodedMember> src, BinaryCode code)
        {
            var dst = new EncodedMembers.EncodingData();
            src.Sort(EncodedMember.comparer(EncodedMember.CmpKind.Target));
            var offset = 0u;
            var count = src.Count;
            var offsets = alloc<uint>(count);
            var tokens = alloc<ApiToken>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var info = ref src[i];
                ref readonly var size = ref info.CodeSize;
                if(offset + size > code.Length)
                    Errors.Throw(string.Format("Offset exceeded at {0} for {1}", i, info.Uri));

                seek(offsets,i) = offset;
                ApiUri.parse(info.Uri, out var uri).Require();
                var e = new MethodEntryPoint(info.EntryAddress, Require.notnull(uri), info.Sig);
                seek(tokens,i) = token(symbols, e, info.TargetAddress);
                var segment = slice(code.View, offset, size);
                offset += size;
            }

            dst.Symbols = symbols;
            dst.Members = src;
            dst.CodeBuffer = ManagedBuffer.pin(code.Storage);
            dst.Offsets = offsets;
            dst.Tokens = tokens;
            return new EncodedMembers(dst);
        }
    }
}
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
        public static EncodedMembers members(Index<EncodedMember> index, BinaryCode data)
        {
            var dst = new EncodedMembers.EncodingData();
            index.Sort(EncodedMember.comparer(EncodedMember.CmpKind.Target));
            var bytes = data.View;
            var offset = 0u;
            var count = index.Count;
            var offsets = alloc<uint>(count);
            var tokens = alloc<ApiToken>(count);
            var dispenser = Alloc.dispenser(Alloc.symbols);
            for(var i=0; i<count; i++)
            {
                ref readonly var info = ref index[i];
                ref readonly var size = ref info.CodeSize;
                if(offset + size > bytes.Length)
                    Errors.Throw(string.Format("Offset exceeded at {0} for {1}", i, info.Uri));

                seek(offsets,i) = offset;

                var result = entry(info, out var ep);
                if(result.Fail)
                    Errors.Throw(result.Message);

                seek(tokens,i) = ApiToken.create(dispenser, ep, info.TargetAddress);
                var code = slice(bytes, offset, size);

                offset += size;
            }

            dst.Symbols = dispenser;
            dst.Index = index;
            dst.CodeBuffer = memory.gcpin(data.Storage);
            dst.Offsets = offsets;
            dst.Tokens = tokens;
            return new EncodedMembers(dst);
        }

        static Outcome entry(in EncodedMember src, out MethodEntryPoint dst)
        {
            var result = ApiUri.parse(src.Uri, out var uri);
            dst = MethodEntryPoint.Empty;
            if(result)
            {
                if(uri.IsEmpty)
                    result = (false, string.Format("Empty uri for {0}", src.Uri));
                else
                    dst = new MethodEntryPoint(src.EntryAddress, Require.notnull(uri), src.Sig);
            }
            return result;
        }
    }
}
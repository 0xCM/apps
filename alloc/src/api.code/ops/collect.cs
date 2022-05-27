//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    using Asm;

    using static core;

    partial class ApiCode
    {
        static Index<RawMemberCode> collect(SymbolDispenser symbols, ReadOnlySpan<MethodEntryPoint> entries)
        {
            var count = entries.Length;
            var code = alloc<RawMemberCode>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var entry = ref skip(entries,i);
                var buffer = Cells.alloc(w64).Bytes;
                ref var data = ref entry.Location.Ref<byte>();
                ByteReader.read5(data, buffer);
                ref var dst = ref seek(code,i);
                collect(symbols, entry, out seek(code, i));
            }
            return code;
        }

        static void collect(SymbolDispenser symbols, MethodEntryPoint entry, out RawMemberCode dst)
        {
            dst = new RawMemberCode();
            dst.Entry = entry.Location;
            dst.Uri = entry.Uri;
            var target = stub(entry.Location, out dst.StubCode);
            dst.Target = target;
            if(target != entry.Location)
            {
                dst.Disp = AsmRel32.disp(dst.StubCode.Bytes);
                dst.Stub = new JmpStub(entry.Location, target);
                dst.Token = ApiToken.create(symbols, entry, target);
            }
            else
            {
                dst.Token = ApiToken.create(symbols, entry);
            }
        }
    }
}
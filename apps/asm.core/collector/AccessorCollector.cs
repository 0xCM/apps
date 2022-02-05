//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;


    public class AccessorCollector : AppService<AccessorCollector>
    {
        ApiJit ApiJit => Service(Wf.ApiJit);

        [MethodImpl(Inline), Op]
        public static unsafe byte code(SpanResAccessor src, out ByteBlock16 dst)
        {
            dst = ByteBlock16.Empty;
            var seg = dataseg(src);
            var size = (byte)seg.Size;
            var data = cover<byte>(seg.BaseAddress.Pointer<byte>(), seg.Size);
            for(var i=0; i<size; i++)
                dst[i] = skip(data,i);
            return size;
        }

        public Index<CapturedAccessor> CaptureAccessors(SymbolDispenser symbols)
        {
            return default;
        }
            //=> capture(symbols, ApiRuntimeCatalog.SpanResAccessors);

        [Op]
        public static MemorySeg dataseg(SpanResAccessor src)
            => dataseg(ApiCodeCollector.GetTargetAddress(src.Member, out _));

        [Op]
        public static MemorySeg codeseg(SpanResAccessor src)
            => codeseg(ApiCodeCollector.GetTargetAddress(src.Member, out _));

        static CapturedAccessor capture(SymbolDispenser symbols, SpanResAccessor src)
        {
            var target = ApiCodeCollector.GetTargetAddress(src.Member, out _);
            var token = ApiToken.create(symbols, src.Member, target);
            var member = new EncodedMember(token, codeseg(target).View.ToArray());
            return new CapturedAccessor(member, dataseg(target), src.Kind);
            //return new CapturedAccessor(member, dataseg(target).View.ToArray(), src.Kind);
        }

        static Index<CapturedAccessor> capture(SymbolDispenser symbols, ReadOnlySpan<SpanResAccessor> accessors)
        {
            var count = accessors.Length;
            var buffer = alloc<CapturedAccessor>(count);
            for(var i=0; i<count; i++)
                seek(buffer,i) = capture(symbols, skip(accessors,i));
            return buffer;
        }

        /// <summary>
        /// Queries the source type for ByteSpan property getters
        /// </summary>
        /// <param name="src">The type to query</param>
        [Op]
        public void FindAccessors(SymbolDispenser symbols, Type src, List<CapturedAccessor> dst)
        {
            var candidates = src.StaticProperties()
                 .Ignore()
                  .WithPropertyType(ResAccessorTypes)
                  .Select(p => p.GetGetMethod(true))
                  .Where(m  => m != null)
                  .Concrete();
            var count = candidates.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var candidate = ref skip(candidates,i);
                var location = ClrJit.jit(candidate);
                //var target = ApiCodeCollector.GetTargetAddress(ClrJit.jit(candidate), out _);
            }





            // return src.StaticProperties()
            //      .Ignore()
            //       .WithPropertyType(ResAccessorTypes)
            //       .Select(p => p.GetGetMethod(true))
            //       .Where(m  => m != null)
            //       .Concrete()
            //       .Select(x => new SpanResAccessor(x, ResKind(x.ReturnType)));
        }

        [Op]
        static SpanResKind ResKind(Type match)
        {
            ref readonly var src = ref first(span(ResAccessorTypes));
            var kind = SpanResKind.None;
            if(skip(src,0).Equals(match))
                kind = SpanResKind.ByteSpan;
            else if(skip(src,1).Equals(match))
                kind = SpanResKind.CharSpan;
            return kind;
        }

        static Type ByteSpanAcessorType
            => typeof(ReadOnlySpan<byte>);

        static Type CharSpanAcessorType
            => typeof(ReadOnlySpan<char>);

        static Type[] ResAccessorTypes
            => new Type[]{ByteSpanAcessorType, CharSpanAcessorType};

        static unsafe bool IsAccessor(MemoryAddress target)
        {
            var data = cover(target.Pointer<byte>(), 24);
            var result = true;
            result &= skip(data,0) == 0x48;
            result &= skip(data,1) == 0xb8;
            result &= skip(data,10) == 0x48;
            result &= skip(data,11) == 0x89;
            result &= skip(data,20) == 0x48;
            result &= skip(data,21) == 0x8b;
            return result;
        }

        // 24 bytes: [48 b8 c0 f3 bf 2b 38 01 00 00] [48 89 01] [c7 41 08 20 00 00 00] [48 8b c1 c3]
        // 0 | 00 | mov r64,imm64       # 10        | [48 b8] [c0 f3 bf 2b 38 01 00 00]
        // 1 | 10 | mov [rcx],rax       # 3         | 48 89 01
        // 2 | 13 | mov r/m32, imm32    # 7         | [c7 41 08] 20 00 00 00
        // 3 | 20 | mov r64, r/m64      # 3         | 48 8b c1
        // 4 | 23 ret                   # 1         | c3
        static unsafe MemorySeg dataseg(MemoryAddress target)
        {
            var data = cover(target.Pointer<byte>(), 24);
            var address = @as<MemoryAddress>(slice(data,2,8));
            var size = @as<uint>(slice(data, 13 + 3, 4));
            return new MemorySeg(address, size);
        }

        static unsafe MemorySeg codeseg(MemoryAddress target)
            => new MemorySeg(target, 24);
    }
}

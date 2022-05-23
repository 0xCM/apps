//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static IntrinsicTypeNames;
    using static NativeTypes;
    using static CTypeNames;

    using I = IntrinsicTypeNames;
    using C = CTypeNames;

    public readonly struct InstrinsicTypes
    {
        public static NativeTypeMap map()
            => NativeTypeMap.build(intrinsics);

        static void intrinsics(NativeTypeMap.MapBuilder map)
        {
            map.Map(__int8, i8());
            map.Map(__int16, i16());
            map.Map(__int32, i32());
            map.Map(__int64, i64());
            map.Map(__uint8, u8());
            map.Map(__uint16, u16());
            map.Map(__uint32, u32());
            map.Map(__uint64, u64());
            map.Map(__tile, i32());
            map.Map(I.unsigned, u32());

            map.Map(__mmask8, u8());
            map.Map(__mmask16, u16());
            map.Map(__mmask32, u32());
            map.Map(__mmask64, u64());

            map.Map(__m64, i64());

            map.Map(__m128i, i128());
            map.Map(__m128, seg128x32f());
            map.Map(__m128bh, seg128x16f());
            map.Map(__m128d, seg128x64f());

            map.Map(__m256i, i256());
            map.Map(__m256bh, seg256x16f());
            map.Map(__m256, seg256x32f());
            map.Map(__m256d, seg256x64f());

            map.Map(__m512, seg512x32f());
            map.Map(__m512i, i512());
            map.Map(__m512d, seg512x64f());
            map.Map(__m512bh, seg512x16f());

            map.Map(size_t, u64());
            map.Map(C.@char, i8());
            map.Map(@short, i16());
            map.Map(@int, i32());
            map.Map(@long, i64());
            map.Map(@float, f32());
            map.Map(@double, f64());
            map.Map(C.@void, @void());
        }
    }
}
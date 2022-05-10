//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{

    /*
    _mm_add_epi16  | __m128i _mm_add_epi16(__m128i a, __m128i b)  | PADDW xmm, xmm | PADDW_XMMdq_XMMdq
    _mm_add_epi32  | __m128i _mm_add_epi32(__m128i a, __m128i b)  | PADDD xmm, xmm | PADDD_XMMdq_XMMdq
    _mm_add_epi64  | __m128i _mm_add_epi64(__m128i a, __m128i b)  | PADDQ xmm, xmm | PADDQ_XMMdq_XMMdq
    _mm_add_epi8   | __m128i _mm_add_epi8(__m128i a, __m128i b)   | PADDB xmm, xmm | PADDB_XMMdq_XMMdq

    */

    using static IntrinsicTypeNames;

    public class IntrinsicSigs
    {
        const string Scope = "inx";

        NativeTypeMap TypeMap;

        public IntrinsicSigs()
        {
            TypeMap = InstrinsicTypes.map();
        }

        [MethodImpl(Inline)]
        NativeType Type(string name)
            => TypeMap[name].Target;

        [MethodImpl(Inline)]
        NativeOperandSpec Op(string name, string type, NativeOpMod mod = default)
            => NativeSigs.op(name, Type(type), mod);

        public NativeSigSpec _mm_add_epi8()
            => NativeSigs.spec(Scope, nameof(_mm_add_epi8), Type(__m128i), Op("a", __m128i), Op("b", __m128i));

        public NativeSigSpec _mm_add_epi16()
            => NativeSigs.spec(Scope, nameof(_mm_add_epi16), Type(__m128i), Op("a", __m128i), Op("b", __m128i));

        public NativeSigSpec _mm_add_epi32()
            => NativeSigs.spec(Scope, nameof(_mm_add_epi32), Type(__m128i), Op("a", __m128i), Op("b", __m128i));

        public NativeSigSpec _mm_add_epi64()
            => NativeSigs.spec(Scope, nameof(_mm_add_epi64), Type(__m128i), Op("a", __m128i), Op("b", __m128i));
    }
}
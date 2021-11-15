//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;
    using static BitMasks;

    [ApiHost]
    public class BitMaskChecker : AppService<BitMaskChecker>
    {
        const NumericKind Closure = UnsignedInts;

        [MethodImpl(Inline), Closures(Closure)]
        public static ref ulong eq<T>(T x, T y, ref byte index, ref ulong dst)
            where T : unmanaged
        {
            dst = (ulong)@byte(gmath.eq(x,y)) << index++;
            return ref dst;
        }

        [MethodImpl(Inline), Closures(Closure)]
        public static bit eq<T>(T x, T y)
            where T : unmanaged
                => gmath.eq(x,y);

        uint SuccessCount;

        uint FailureCount;

        public Pair<uint> Counts;

        Index<byte> Cases8;

        Index<byte> Cases16;

        Index<byte> Cases32;

        Index<byte> Cases64;

        BinaryLiterals<byte> Literals8;

        BinaryLiterals<ushort> Literals16;

        BinaryLiterals<uint> Literals32;

        BinaryLiterals<ulong> Literals64;

        CheckHiMaskResults<byte> HiMaskResults8;

        CheckHiMaskResults<ushort> HiMaskResults16;

        CheckHiMaskResults<uint> HiMaskResults32;

        CheckHiMaskResults<ulong> HiMaskResults64;

        ITextBuffer Log;


        public BitMaskChecker()
        {

        }

        public const uint Reps = Pow2.T08;

        [Op]
        void Init(IPolySource source, ITextBuffer log)
        {
            Log = log;
            Cases8 = source.Fill(z8, width<byte>(w8), alloc<byte>(Reps));
            Cases16 = source.Fill(z8, width<ushort>(w8), alloc<byte>(Reps));
            Cases32 = source.Fill(z8, width<uint>(w8), alloc<byte>(Reps));
            Cases64 = source.Fill(z8, width<uint>(w8), alloc<byte>(Reps));
            Literals8 = ClrLiterals.tagged<byte>(base2, typeof(BitMaskLiterals));
            Literals16 = ClrLiterals.tagged<ushort>(base2, typeof(BitMaskLiterals));
            Literals32 = ClrLiterals.tagged<uint>(base2, typeof(BitMaskLiterals));
            Literals64 = ClrLiterals.tagged<ulong>(base2, typeof(BitMaskLiterals));
            HiMaskResults8 = alloc<CheckHiMaskResult<byte>>(Reps);
            HiMaskResults16 = alloc<CheckHiMaskResult<ushort>>(Reps);
            HiMaskResults32 = alloc<CheckHiMaskResult<uint>>(Reps);
            HiMaskResults64 = alloc<CheckHiMaskResult<ulong>>(Reps);
        }

        [MethodImpl(Inline)]
        ReadOnlySpan<byte> Cases<W>(W w = default)
            where W : unmanaged, ITypeWidth<W>
        {
            if(typeof(W) == typeof(W8))
                return Cases8;
            else if(typeof(W) == typeof(W16))
                return Cases16;
            else if(typeof(W) == typeof(W32))
                return Cases32;
            else if(typeof(W) == typeof(W64))
                return Cases16;
            else
                throw no<W>();
        }

        [MethodImpl(Inline)]
        BinaryLiterals<T> Lit<T>(T t = default)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return @as<BinaryLiterals<byte>, BinaryLiterals<T>>(Literals8);
            else if(typeof(T) == typeof(ushort))
                return @as<BinaryLiterals<ushort>, BinaryLiterals<T>>(Literals16);
            else if(typeof(T) == typeof(uint))
                return @as<BinaryLiterals<uint>, BinaryLiterals<T>>(Literals32);
            else if(typeof(T) == typeof(ulong))
                return @as<BinaryLiterals<ulong>, BinaryLiterals<T>>(Literals64);
            else
                throw no<T>();
        }

        [Op]
        public void Run(IPolySource source)
        {
            var flow = Wf.Running();
            var log = text.buffer();
            Init(source, log);
            var results = 0ul;
            var index = z8;
            Check(base2);
            CheckLoMasks(ref index, ref results);
            CheckHiMasks();
            EmitReport(log);
            Counts = (SuccessCount, FailureCount);
            Wf.Ran(flow, Counts);
        }

        void EmitReport(ITextBuffer src)
        {
            Wf.Row(src.Emit());
        }

        [Op]
        void CheckHiMasks()
        {
            CheckHiMask(w8, z8, HiMaskResults8);
            CheckHiMask(w16, z16, HiMaskResults16);
            CheckHiMask(w32, z32, HiMaskResults32);
            CheckHiMask(w64,z64, HiMaskResults64);
        }

        [Op]
        public static void CheckLoMasks(ref byte index, ref ulong log)
        {
            CheckLoMask(n0, ref index, ref log);
            CheckLoMask(n1, ref index, ref log);
            CheckLoMask(n2, ref index, ref log);
        }

        [Op]
        public static void CheckLoMask(N0 @case, ref byte index, ref ulong log)
        {
            eq((Pow2.pow(3) - 1)^Pow2.pow(3), lo64(3), ref index, ref log);
            eq((Pow2.pow(7) - 1)^Pow2.pow(7), lo64(7), ref index, ref log);
            eq((Pow2.pow(13) - 1)^Pow2.pow(13), lo64(13), ref index, ref log);
            eq((Pow2.pow(25) - 1)^Pow2.pow(25), lo64(25), ref index, ref log);
            eq((Pow2.pow(59) - 1)^Pow2.pow(59), lo64(59), ref index, ref log);
        }

        [Op]
        public static void CheckLoMask(N1 @case, ref byte index, ref ulong log)
        {
            eq(4u, bits.pop(lo64(3)), ref index, ref log);
            eq(7u, bits.pop(lo64(6)), ref index, ref log);
            eq(13u, bits.pop(lo64(12)), ref index, ref log);
            eq(25u, bits.pop(lo64(24)), ref index, ref log);
            eq(59u, bits.pop(lo64(58)), ref index, ref log);
        }

        [Op]
        public static void CheckLoMask(N2 @case, ref byte index, ref ulong log)
        {
            var lomask = BitMasks.lo<uint>(6);
            var himask = BitMasks.hi<uint>(8);
            var src = uint.MaxValue;
            var dst = gmath.xor(gmath.xor(src,lomask), himask);
            eq(7u, bits.ntz(dst), ref index, ref log);
            eq(8u, (uint)bits.nlz(dst), ref index, ref log);
            eq(7u, bits.pop(BitMasks.lo<uint>(6)), ref index, ref log);
            eq(12u, bits.pop(BitMasks.lo<uint>(11)), ref index, ref log);
        }

        [Op]
        void Check(Base2 @base)
        {
            Check(@base, w8);
            Check(@base, w16);
            Check(@base, w32);
            Check(@base, w64);
        }

        [Op]
        void Check(Base2 @base, W8 w)
            =>  Check(@base, z8);


        [Op]
        void Check(Base2 @base, W16 w)
            => Check(@base, z16);

        [Op]
        void Check(Base2 @base, W32 w)
            => Check(@base, z32);

        [Op]
        void Check(Base2 @base, W64 w)
            => Check(@base, z64);

        [Op]
        public void Himask(W8 w)
            => CheckHiMask(w, z8, HiMaskResults8);

        [Op]
        public void Himask(W16 w)
            => CheckHiMask(w, z16, HiMaskResults16);

        [Op]
        public void Himask(W32 w)
            => CheckHiMask(w, z32, HiMaskResults32);

        [Op]
        public void Himask(W64 w)
            => CheckHiMask(w,z64, HiMaskResults64);

        [MethodImpl(Inline)]
        void Check<T>(Base2 @base, T t = default)
            where T : unmanaged
        {
            var literals = Lit<T>();
            foreach(var m in literals.Storage)
            {
                var bits = BitSpans32.parse(m.Text);
                var bitval = bits.Convert<T>();
                var ok = gmath.eq(bitval,m.Data);

                if(ok)
                    SuccessCount++;
                else
                    FailureCount++;

                var results = EvalResults.eq(bitval,m.Data,ok);

                var sym = ok ? "==" : "!=";
                var title = ok ? "Success" : "Failure";
                var normalized = BitStrings.normalize(m.Text);
                var bs = BitStrings.scalar(m.Data);
                var expr = text.format("{0} {1} {2}", normalized, sym, bs);
                var description = text.format("{0,-12} | {1,-14} | {2}", title, m.Name, expr);
                Log.AppendLine(description);
            }
        }

        [MethodImpl(Inline)]
        void CheckHiMask<W,T>(W w, T t, Span<CheckHiMaskResult<T>> outcomes)
            where T : unmanaged
            where W : unmanaged, ITypeWidth<W>
        {
            var mincount = (byte)1;
            var maxcount = (byte)width<T>();
            var cases = Cases(w);

            for(var i=0u; i<Reps; i++)
            {
                ref var dst = ref seek(outcomes,i);
                dst.Check1 = true;
                dst.Count = skip(cases, i);
                dst.Mask = BitMasks.hi<T>(dst.Count);
                dst.PopCount = (byte)gbits.pop(dst.Mask);
                dst.Check1 = dst.PopCount != dst.Count;
                dst.Check1 = eq(dst.Count, gbits.pop(dst.Mask));
                dst.Lowered = gmath.srl(dst.Mask, (byte)(width<T>() -  dst.Count));
                dst.EffectiveWidth = gbits.effwidth(dst.Lowered);
                dst.Check3 = dst.Count == dst.EffectiveWidth;
            }
        }
    }
}
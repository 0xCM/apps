//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct MemoryKey<T>
        where T : IEquatable<T>
    {
        readonly MemoryRange Range;

        public readonly T Data;

        [MethodImpl(Inline)]
        public MemoryKey(MemoryAddress min, MemoryAddress max, T data)
        {
            Range = (min,max);
            Data = data;
        }

        [MethodImpl(Inline)]
        public MemoryKey(MemoryRange range, T data)
        {
            Range = range;
            Data = data;
        }

        public MemoryAddress Min
        {
            [MethodImpl(Inline)]
            get => Range.Min;
        }

        public MemoryAddress Max
        {
            [MethodImpl(Inline)]
            get => Range.Max;
        }

        public ulong Hash64
        {
            [MethodImpl(Inline)]
            get => (uint.MaxValue & (ulong)Min) |((uint.MaxValue & (ulong)Max) << 32);
        }

        public uint Hash32
        {
            [MethodImpl(Inline)]
            get => alg.hash.combine((uint)Min, (uint)Max);
        }

        public override int GetHashCode()
            => (int)Hash32;

        public string Format()
            => string.Format("{0}[{1}]", Range, Data);


        [MethodImpl(Inline)]
        public static implicit operator MemoryKey<T>((MemoryRange range, T data) src)
            => new MemoryKey<T>(src.range, src.data);
   }
}
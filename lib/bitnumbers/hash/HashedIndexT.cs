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

    public readonly struct HashedIndex<T>
    {
        readonly Index<T> _Data;

        readonly Index<HashCode<T>> _Codes;

        readonly Func<T,uint> HashFunction;

        internal HashedIndex(Index<HashCode<T>> src, Func<T,uint> fx)
        {
            var count = src.Count;
            HashFunction = fx;
            _Data = sys.alloc<T>(count);
            _Codes = src;
            ref var target = ref _Data.First;
            ref readonly var source = ref _Codes.First;
            for(var i=0; i<count; i++)
            {
                ref readonly var code = ref skip(source,i);
                var index = code.Hash % count;
                seek(target,index) = code.Source;
            }
        }

        [MethodImpl(Inline)]
        public ref readonly HashCode<T> Code(uint index)
            => ref _Codes[index];

        [MethodImpl(Inline)]
        public ref readonly T Item(uint index)
            => ref _Data[index];

        [MethodImpl(Inline)]
        public uint? Index(in T src)
        {
            var h = HashFunction(src);
            if(h < _Codes.Length)
                return h % _Data.Count;
            else
                return null;
        }

        [MethodImpl(Inline)]
        public bool Contains(in T src)
            => HashFunction(src) < _Codes.Length;

        public ReadOnlySpan<HashCode<T>> Codes
        {
            [MethodImpl(Inline)]
            get => _Codes.View;
        }
    }
}
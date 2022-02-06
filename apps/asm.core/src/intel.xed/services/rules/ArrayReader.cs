//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class XTend
    {
        [MethodImpl(Inline)]
        public static ArrayReader<T> Reader<T>(this T[] src)
            => src;

        [MethodImpl(Inline)]
        public static ArrayReader<T> Reader<T>(this Index<T> src)
            => src.Storage;
    }

    public struct ArrayReader<T>
    {
        readonly T[] Data;

        int Index;

        [MethodImpl(Inline)]
        public ArrayReader(T[] src)
        {
            Data = src;
            Index = 0;
        }

        [MethodImpl(Inline)]
        public static implicit operator ArrayReader<T>(T[] src)
            => new ArrayReader<T>(src);


        [MethodImpl(Inline)]
        public ref readonly T Next()
            => ref skip(Data,Index++);

        [MethodImpl(Inline)]
        public bool Next(out T dst)
        {
            if(Index < Data.Length)
            {
                dst = Next();
                return true;
            }
            else
            {
                dst = default;
                return false;
            }
        }
    }
}
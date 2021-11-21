//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static core;
    using static Root;

    public class Bucket<T>
    {
        readonly Index<T> Data;

        public string Label {get;}

        uint Current;

        public Bucket(uint capacity, string label = null)
        {
            Data = alloc<T>(capacity);
            Label = label ?? EmptyString;
            Current = 0;
        }

        public Bucket(T[] data, string label = null)
        {
            Data = data;
            Label = label ?? EmptyString;
            Current = (uint)data.Length;
        }

        public uint Count
        {
            [MethodImpl(Inline)]
            get => Current;
        }

        public uint Capacity
        {
            [MethodImpl(Inline)]
            get => Data.Count;
        }

        public ref T this[int index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        public ref T this[uint index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        [MethodImpl(Inline)]
        public Bucket<T> Include(params T[] src)
        {
            for(var i=0; Current<Capacity && i<src.Length; i++, Current++)
                this[Current] = skip(src,i);
            return this;
        }

        public string Format(string sep = ", ")
        {
            var dst = text.buffer();
            if(nonempty(Label))
                dst.Append(Label);

            dst.Append(Chars.LParen);
            for(var i=0; i<Current; i++)
            {
                if(i != 0)
                    dst.Append(sep);
                dst.Append(this[i].ToString());
            }
            dst.Append(Chars.RParen);
            return dst.Emit();
        }

        public override string ToString()
            => Format();
    }
}
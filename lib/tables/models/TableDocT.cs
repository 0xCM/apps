//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public abstract class TableDoc<T>
        where T : struct
    {
        protected readonly Index<T> Data;

        public FS.FilePath Location {get;}

        protected TableDoc(FS.FilePath path, T[] rows)
        {
            Location = path;
            Data = rows;
        }

        public ReadOnlySpan<T> View
        {
            [MethodImpl(Inline)]
            get => Data.View;
        }

        public uint RowCount
        {
            [MethodImpl(Inline)]
            get => Data.Count;
        }

        public ref readonly T this[int i]
        {
            [MethodImpl(Inline)]
            get => ref Data[i];
        }

        public ref readonly T this[uint i]
        {
            [MethodImpl(Inline)]
            get => ref Data[i];
        }
    }
}
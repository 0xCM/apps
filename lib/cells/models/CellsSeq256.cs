//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using C = Cell256;
    using S = CellSeq256;
    using I = System.UInt32;

    /// <summary>
    /// Defines an indexed sequence of <see cref='C'/> cells
    /// </summary>
    [DataType("cellseq<w:256>")]
    public readonly struct CellSeq256 : IDataCells<S,I,C>
    {
        readonly Index<C> Data;

        [MethodImpl(Inline)]
        public CellSeq256(C[] src)
            => Data = src;

        public uint Count
        {
            [MethodImpl(Inline)]
            get => Data.Count;
        }

        public ref C this[I index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        public C[] Storage
        {
            [MethodImpl(Inline)]
            get => Data.Storage;
        }

        [MethodImpl(Inline)]
        public static implicit operator S(C[] src)
            => new S(src);

        [MethodImpl(Inline)]
        public static implicit operator C[](S src)
            => src.Storage;
    }
}
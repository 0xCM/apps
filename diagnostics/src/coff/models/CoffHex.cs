//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class CoffHex
    {
        public CoffObject Object {get;}

        public Index<HexDataRow> HexRows {get;}

        public BinaryCode HexData {get;}

        internal CoffHex(CoffObject coff, HexDataRow[] hex, BinaryCode compacted)
        {
            Object = coff;
            HexRows =  hex;
            HexData = compacted;
        }

        public ref readonly HexDataRow this[int i]
        {
            [MethodImpl(Inline)]
            get => ref HexRows[i];
        }

        public ref readonly HexDataRow this[uint i]
        {
            [MethodImpl(Inline)]
            get => ref HexRows[i];
        }

        public uint RowCount
        {
            [MethodImpl(Inline)]
            get => HexRows.Count;
        }

        public BinaryCode ObjectData
        {
            [MethodImpl(Inline)]
            get => Object.Data;
        }

        public ByteSize ObjectSize
        {
            [MethodImpl(Inline)]
            get => Object.Size;
        }
    }
}
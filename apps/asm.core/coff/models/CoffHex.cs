//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

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
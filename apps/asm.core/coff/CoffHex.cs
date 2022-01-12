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

    public class CoffHex
    {
        public static Outcome validate(CoffObject coff, HexDataRow[] rows)
        {
            var hex = rows.Compact();
            var hexsize = hex.Size;
            var objsize = coff.Size;
            if(hexsize != objsize)
                return (false,string.Format("Size mismatch: {0} != {1}", objsize, hexsize));

            var objData = coff.Data;
            var hexData = hex;
            var size = (uint)objsize;
            for(var j=0u; j<size; j++)
            {
                MemoryAddress curoffset = j;
                ref readonly var a = ref coff[j];
                ref readonly var b = ref hex[j];
                if(a != b)
                    return (false, string.Format("{0} != {1} at offset {2}", a.FormatHex(), b.FormatHex(), curoffset));
            }

            return true;
        }

        public static Outcome<CoffHex> create(CoffObject coff, HexDataRow[] rows)
        {
            var hex = rows.Compact();
            var hexsize = hex.Size;
            var objsize = coff.Size;
            if(hexsize != objsize)
                return (false,string.Format("Size mismatch: {0} != {1}", objsize, hexsize));

            var objData = coff.Data;
            var hexData = hex;
            var size = (uint)objsize;
            for(var j=0u; j<size; j++)
            {
                MemoryAddress curoffset = j;
                ref readonly var a = ref coff[j];
                ref readonly var b = ref hex[j];
                if(a != b)
                    return (false, string.Format("{0} != {1} at offset {2}", a.FormatHex(), b.FormatHex(), curoffset));
            }

            return  new CoffHex(coff, rows, hex);
        }

        public CoffObject Object {get;}

        public Index<HexDataRow> HexRows {get;}

        public BinaryCode HexData {get;}

        CoffHex(CoffObject coff, HexDataRow[] hex, BinaryCode compacted)
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
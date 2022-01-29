//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    [ApiHost]
    public readonly struct CoffObjects
    {
        public static Outcome<CoffHex> hex(CoffObject coff, HexDataRow[] rows)
        {
            var result = validate(coff, rows, out var hex);
            if(result)
                return new CoffHex(coff, rows, hex);
            else
                return result;
        }

        public static Outcome validate(CoffObject coff, HexDataRow[] rows, out BinaryCode hex)
        {
            hex = rows.Compact();
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

        [MethodImpl(Inline), Op]
        public static uint size(in CoffStringTable src)
            => first(recover<uint>(slice(src.Data,0,4)));

        public static string format(in CoffStringTable src, in CoffSymbol sym)
        {
            ref readonly var name = ref sym.Name;
            var value = sym.Value;
            var kind = name.NameKind;
            var address = kind == CoffNameKind.String ? Address32.Zero : name.Address;
            var dst = EmptyString;
            if(value < Hex16.Max)
            {
                if(address.IsNonZero)
                    dst = entry(src, name.Address).Format();
                else
                {
                    if(kind == CoffNameKind.String)
                    {
                        var len = length(src,sym.Name);
                        dst = recover<AsciCode>(slice(sym.Name.Bytes,0,len)).Format();
                    }
                }
            }
            return dst;
        }

        [MethodImpl(Inline), Op]
        public static uint length(in CoffStringTable strings, Address32 offset)
        {
            var data = slice(strings.Data, (uint)offset);
            var max = strings.Data.Length;
            var len = 0u;
            var i=0u;
            while(i < max && (sbyte)skip(data,i++) > 0)
                len++;
            return len;
        }

        [MethodImpl(Inline), Op]
        public static uint length(in CoffStringTable strings, CoffSymbolName name)
        {
            var kind = name.NameKind;
            var len  = 0u;
            if(kind == CoffNameKind.String)
                len = SymbolicQuery.length(recover<AsciCode>(name.Bytes));
            else if(kind == CoffNameKind.Address)
                len = length(strings, name.Address);
            return len;
        }

        public static string format(in CoffStringTable strings, CoffSymbolName name)
        {
            var len = length(strings, name);
            var dst = EmptyString;
            if(len <= 8)
                dst = recover<AsciCode>(slice(name.Bytes,0,len)).Format();
            else if(name.Address.IsNonZero)
                dst = entry(strings, name.Address).Format();
            return dst;
        }

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<AsciCode> entry(in CoffStringTable strings, Address32 offset)
        {
            var data = slice(strings.Data, (uint)offset);
            return recover<AsciCode>(slice(data,0, length(strings,offset)));
        }

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<CoffSymbol> symbols(ReadOnlySpan<byte> src, uint offset, uint count)
            => slice(recover<CoffSymbol>(slice(src,offset)), 0, count);

        [MethodImpl(Inline), Op]
        public static CoffObject Load(FS.FilePath path)
            => new CoffObject(path.Ext == FS.Obj ? path.SrcId(FileKind.Obj) : path.SrcId(FileKind.O), path, path.ReadBytes());

        [MethodImpl(Inline), Op]
        public static Timestamp timestamp(Hex32 src)
            => Time.epoch(TimeSpan.FromSeconds(src));

        [MethodImpl(Inline), Op]
        public static ref readonly CoffHeader header(ReadOnlySpan<byte> src, uint offset)
            => ref skip(recover<CoffHeader>(src), offset);
    }
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost]
    public static class XPart
    {
        const NumericKind Closure = NumericKind.UnsignedInts;

        [MethodImpl(Inline), Op]
        public static PartId Id(this Assembly src)
            => PartIdAttribute.id(src);

        public static string Name(this Assembly src)
        {
            var id = PartIdAttribute.id(src);
            return id != 0 ? id.Format() : src.GetName().Name;
        }

        [MethodImpl(Inline), Op]
        public static PartName PartName(this PartId id)
            => id;

        [MethodImpl(Inline), Op]
        public static PartName PartName(this Assembly src)
            => PartIdAttribute.id(src);

        [Op]
        public static string SimpleName(this AssemblyName src)
            => src.FullName.LeftOfFirst(Chars.Comma);

        [Op]
        public static bool IsPart(this AssemblyName src)
            => src.SimpleName().StartsWith("z0.");

        [Op]
        public static string Format(this PartId id)
            => PartNames.format(id);
    }

    public class PartNames
    {
        public static IReadOnlyDictionary<PartId,PartName> NameLookup()
            => _Instance.IdNames;

        public static PartName name(PartId id)
        {
            var lookup = NameLookup();
            if(lookup.TryGetValue(id, out var name))
                return name;
            else
                return new PartName(id, id.ToString().ToLower());
        }

        [Op]
        public static string format(PartId id)
        {
            var lookup = NameLookup();
            var name = PartName.Empty;
            var dst = EmptyString;
            if(lookup.TryGetValue(id, out name))
                dst = name.Format();
            else
                dst = id.ToString().ToLower();
            return dst;
        }

        [MethodImpl(Inline)]
        public static PartName name(Type src)
        {
            var id = PartIdAttribute.id(src.Assembly);
            return new PartName(id, format(name(id)));
        }

        public static bool FindId(string symbol, out PartId id)
            => _Instance.SymbolIds.TryGetValue(symbol, out id);

        static PartNames _Instance;

        Dictionary<PartId,PartName> IdNames;

        Dictionary<string,PartId> SymbolIds;

        static PartNames()
        {
            _Instance = new PartNames();
        }

        PartNames()
        {
            var fields = typeof(PartId).LiteralFields();
            IdNames = new Dictionary<PartId,PartName>();
            SymbolIds = new Dictionary<string,PartId>();
            foreach(var f in fields)
            {
                var id = (PartId)f.GetRawConstantValue();
                var symbol = SymbolAttribute.symbol(f);
                var name = new PartName(id, symbol);
                IdNames.TryAdd(id,name);
                SymbolIds.TryAdd(symbol,id);
            }
        }
    }
}
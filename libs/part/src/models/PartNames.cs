//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class PartNames
    {
        public static IReadOnlyDictionary<PartId,PartName> Lookup()
            => _Instance.NameIndex;

        static PartName name(PartId part)
        {
            var lookup = Lookup();
            if(lookup.TryGetValue(part, out var name))
                return name;
            else
                return new PartName(part, part.ToString().ToLower());
        }

        [Op]
        public static string format(PartId part)
        {
            var lookup = Lookup();
            var name = PartName.Empty;
            var dst = EmptyString;
            if(lookup.TryGetValue(part, out name))
                dst = name.Format();
            else
                dst = part.ToString().ToLower();
            return dst;
        }

        [MethodImpl(Inline)]
        public static PartId owner(Type src)
            => PartIdAttribute.id(src.Assembly);

        [MethodImpl(Inline)]
        public static PartName name(Type src)
        {
            var id = owner(src);
            return new PartName(id, format(name(id)));
        }

        // public static bool FindId(string symbol, out PartId id)
        //     => _Instance.IdIndex.TryGetValue(symbol, out id);

        static PartNames _Instance;

        Dictionary<PartId,PartName> NameIndex;

        Dictionary<string,PartId> IdIndex;

        static PartNames()
        {
            _Instance = new PartNames();
        }

        PartNames()
        {
            var fields = typeof(PartId).LiteralFields();
            NameIndex = new Dictionary<PartId,PartName>();
            IdIndex = new Dictionary<string,PartId>();
            foreach(var f in fields)
            {
                var id = (PartId)f.GetRawConstantValue();
                var symbol = SymbolAttribute.symbol(f);
                var name = new PartName(id, symbol);
                NameIndex.TryAdd(id,name);
                IdIndex.TryAdd(symbol,id);
            }
        }
    }
}
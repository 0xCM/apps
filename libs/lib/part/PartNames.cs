//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
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
            var id = PartResolution.id(src.Assembly);
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
            var fields = typeof(PartId).LiteralFields().ToReadOnlySpan();
            IdNames = new Dictionary<PartId,PartName>();
            SymbolIds = new Dictionary<string,PartId>();
            foreach(var f in fields)
            {
                var id = (PartId)f.GetRawConstantValue();
                var symbol = PartResolution.tag<SymbolAttribute>(f).MapValueOrElse(a => a.Symbol, () => f.Name);
                var name = new PartName(id, symbol);
                IdNames.TryAdd(id,name);
                SymbolIds.TryAdd(symbol,id);
            }
        }
    }
}
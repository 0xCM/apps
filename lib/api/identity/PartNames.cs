//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Collections.Generic;

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
                var symbol = f.Tag<SymbolAttribute>().MapValueOrElse(a => a.Symbol, () => f.Name);
                var name = new PartName(id, symbol);
                IdNames.TryAdd(id,name);
                SymbolIds.TryAdd(symbol,id);
            }
        }
    }
}
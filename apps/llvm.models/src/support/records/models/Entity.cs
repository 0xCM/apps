//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Collections.Generic;

    using static Root;
    using static core;

    public readonly struct Entity : IFieldProvider
    {
        public static Dictionary<string,RecordField> index(RecordField[] src, Action<RecordField> duplicate)
        {
            var count = src.Length;
            var dst = dict<string,RecordField>();
            foreach(var field in src)
            {
                if(!dst.TryAdd(field.Name, field))
                    duplicate(field);
            }

            return dst;
        }

        readonly Dictionary<string,RecordField> _Lookup;

        readonly Index<RecordField> _Fields;

        readonly Index<RecordField> _Duplicates;

        public Identifier EntityName {get;}

        public readonly DefRelations Def;

        [MethodImpl(Inline)]
        public Entity(DefRelations def, RecordField[] fields)
        {
            Def = def;
            EntityName = def.Name;
            var dupes = list<RecordField>();
            _Lookup = index(fields, f => dupes.Add(f));
            _Fields = fields;
            _Duplicates = dupes.Count == 0 ? Index<RecordField>.Empty : dupes.ToArray();
        }

        public ReadOnlySpan<RecordField> Fields
        {
            [MethodImpl(Inline)]
            get => _Fields;
        }

        public RecordField this[string field]
        {
            get
            {
                if(_Lookup.TryGetValue(field, out var value))
                {
                    return value;
                }
                else
                {
                    return RecordField.Empty;
                }
            }
        }
    }
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm.records
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Collections.Generic;

    using static Root;

    public readonly struct Entity : IFieldProvider
    {
        public static Entity load(IFieldProvider src)
            => new Entity(src.EntityName, src.Fields.ToArray());

        readonly Dictionary<string,RecordField> _Lookup;

        readonly Index<RecordField> _Fields;

        public Identifier EntityName {get;}

        [MethodImpl(Inline)]
        public Entity(Identifier name, RecordField[] fields)
        {
            EntityName = name;
            _Lookup = fields.Map(f => (f.Name,f)).ToDictionary();
            _Fields = fields;
        }

        public ReadOnlySpan<RecordField> Fields
        {
            [MethodImpl(Inline)]
            get => _Fields;
        }

        public RecordField this[string name]
        {
            get
            {
                if(_Lookup.TryGetValue(name, out var f))
                {
                    return f;
                }
                else
                {
                    return RecordField.Empty;
                }
            }
        }

        public bool Field(string name, out RecordField dst)
            => _Lookup.TryGetValue(name, out dst);
    }
}
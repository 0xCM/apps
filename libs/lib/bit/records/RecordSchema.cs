//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct BitRecordSchema
    {
        public text15 Scope {get;}

        /// <summary>
        /// Specifies record type name
        /// </summary>
        public text15 EntityName {get;}

        readonly Index<BitRecordField> _Fields;

        [MethodImpl(Inline)]
        public BitRecordSchema(text15 scope, text15 name, BitRecordField[] fields)
        {
            Scope = scope;
            EntityName = name;
            _Fields = fields;
        }

        public Span<BitRecordField> Fields
        {
            [MethodImpl(Inline)]
            get => _Fields.Edit;
        }

        public uint FieldCount
        {
            [MethodImpl(Inline)]
            get => _Fields.Count;
        }

        public ref BitRecordField this[uint i]
        {
            [MethodImpl(Inline)]
            get => ref _Fields[i];
        }

        public ref BitRecordField this[int i]
        {
            [MethodImpl(Inline)]
            get => ref _Fields[i];
        }
    }
}
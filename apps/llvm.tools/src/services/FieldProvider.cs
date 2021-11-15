//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;
    using System.Runtime.CompilerServices;

    using records;

    using static Root;

    readonly struct FieldProvider : IFieldProvider
    {
        public Identifier EntityName {get;}

        readonly LlvmDb Db;

        [MethodImpl(Inline)]
        public FieldProvider(Identifier name, LlvmDb src)
        {
            Db = src;
            EntityName = name;
        }

        public ReadOnlySpan<RecordField> Fields
        {
            [MethodImpl(Inline)]
            get => Db.SelectFields(EntityName);
        }
    }
}
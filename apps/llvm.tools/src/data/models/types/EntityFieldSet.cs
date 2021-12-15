//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;
    using System.Runtime.InteropServices;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct EntityFieldSet : IIndex<RecordField>
    {
        public Identifier EntityName {get;}

        readonly Index<RecordField> Data;

        [MethodImpl(Inline)]
        public EntityFieldSet(Identifier name, RecordField[] src)
        {
            EntityName = name;
            Data = src;
        }

        public ReadOnlySpan<RecordField> View
        {
            [MethodImpl(Inline)]
            get => Data.View;
        }

        public RecordField[] Storage
        {
            get => Data;
        }
    }
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm.records
{
    using System;
    using System.Runtime.InteropServices;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct RecordFields
    {
        public Identifier Id {get;}

        readonly Index<RecordField> Data;

        [MethodImpl(Inline)]
        public RecordFields(Identifier id, RecordField[] src)
        {
            Id = id;
            Data = src;
        }

        public ReadOnlySpan<RecordField> View
        {
            [MethodImpl(Inline)]
            get => Data.View;
        }
    }
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;
    using records;

    public ref struct EltFieldSet
    {
       public readonly Identifier EntityName;

       public readonly ReadOnlySpan<RecordField> Items;

       public EltFieldSet(Identifier name, ReadOnlySpan<RecordField> items)
       {
           EntityName = name;
           Items = items;
       }
   }
}
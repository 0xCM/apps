//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Collects the records produced by the etl process
    /// </summary>
    public ref struct EtlDatasets
    {
       public ReadOnlySpan<TextLine> Records;

       public ReadOnlySpan<RecordField> Defs;

       public LineMap<Identifier> DefMap;

   }
}
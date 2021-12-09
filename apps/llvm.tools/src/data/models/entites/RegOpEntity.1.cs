//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static LlvmNames;

    /// <summary>
    /// Represents a table-gen defined instruction
    /// </summary>
    public class MemOpEntity : RecordEntity
    {
        public MemOpEntity(DefRelations def, RecordField[] fields)
            : base(def,fields)
        {

        }

    }
}
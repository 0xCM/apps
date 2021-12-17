//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static Root;

    /// <summary>
    /// Represents a table-gen defined instruction
    /// </summary>
    public class X86RegEntity : DefFields
    {
        public const string LlvmName = "X86Reg";

        public X86RegEntity(DefRelations def, RecordField[] fields)
            : base(def,fields)
        {

        }
    }
}
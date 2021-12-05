//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    /// <summary>
    /// Represents a table-gen defined instruction
    /// </summary>
    public class IntrinsicEntity : RecordEntity
    {
        public IntrinsicEntity(DefRelations def, RecordField[] fields)
            : base(def,fields)
        {

        }

        public string TargetPrefix
        {
            get => text.remove(this[nameof(TargetPrefix)], Chars.Quote);
        }

        public string IntrinsicName
        {
            get => EntityName;
        }
    }
}

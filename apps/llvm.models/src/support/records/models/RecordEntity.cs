//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public class RecordEntity : Entity<string,RecordField>
    {
        public readonly DefRelations Def;

        [MethodImpl(Inline)]
        public RecordEntity(DefRelations def, RecordField[] fields)
            : base(fields)
        {
            Def = def;
        }

        public Identifier EntityName
            => Def.Name;

        public Identifier ParentName
            => Def.ParentName;

        protected override RecordField EmptyAttribute
            => RecordField.Empty;

        protected override Func<RecordField,string> KeyFunction
            => a => a.Name;
    }
}
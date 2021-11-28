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

    public class RecordEntity : Entity<string,RecordField>
    {
        public readonly DefRelations Def;

        public RecordEntity(DefRelations def, RecordField[] fields)
            : base(fields)
        {
            Def = def;
        }

        public Identifier EntityName
            => Def.Name;

        public Identifier ParentName
            => Def.ParentName;

        [MethodImpl(Inline)]
        protected string AttribValue(string name)
            => this[name].Value;

        protected override RecordField EmptyAttribute
            => RecordField.Empty;

        protected override Func<RecordField,string> KeyFunction
            => a => a.Name;

        protected ref bit ParseAttrib(string attrib, out bit dst)
        {
            DataParser.parse(this[attrib].Value, out dst);
            return ref dst;
        }

        protected ref int ParseAttrib(string attrib, out int dst)
        {
            DataParser.parse(this[attrib].Value, out dst);
            return ref dst;
        }

        public bool HasAncestor(string name)
            => Def.AncestorNames.Contains(name);

        public bool IsInstruction()
            => HasAncestor(RecordClasses.Instruction);

        public bool IsGenericInstruction()
            => HasAncestor(RecordClasses.GenericInstruction);

        public bool IsInstAlias()
            => HasAncestor(RecordClasses.InstAlias);

        public InstEntity ToInstruction()
            => new InstEntity(Def,AttribIndex);

        public InstAliasEntity ToInstAlias()
            => new InstAliasEntity(Def,AttribIndex);
    }
}
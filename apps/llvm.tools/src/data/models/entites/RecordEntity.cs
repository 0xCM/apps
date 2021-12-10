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

        public bool NameBeginsWith(string match)
            => text.begins(EntityName, match);

        public new string this[string name]
            => text.ifempty(Attrib(name).Value, EmptyString);

        protected string AttribValue(string name)
            => this[name];

        protected override RecordField EmptyAttribute
            => RecordField.Empty;

        protected override Func<RecordField,string> KeyFunction
            => a => a.Name;

        protected ref bit Parse(string attrib, out bit dst)
        {
            bit parse()
            {
                if(DataParser.parse(this[attrib], out bit data))
                    return data;
                else
                    return 0;
            }

            dst = Value(attrib, parse);

            return ref dst;
        }

        protected ref int Parse(string attrib, out int dst)
        {
            int parse()
            {
                if(DataParser.parse(this[attrib], out int data))
                    return data;
                else
                    return 0;
            }

            dst = Value(attrib, parse);
            return ref dst;
        }

        protected ref bits<T> Parse<T>(string attrib, out bits<T> dst)
            where T : unmanaged
        {
            bits<T> parse()
            {
                if(bits<T>.parse(this[attrib], out var b))
                    return b;
                else
                    return new bits<T>(0,default(T));
            }

            dst = Value(attrib, parse);
            return ref dst;
        }

        public bool HasAncestor(string name)
            => Def.AncestorNames.Contains(name);

        public bool IsInstruction()
            => HasAncestor(Entities.Instruction);

        public InstEntity ToInstruction()
            => new InstEntity(Def,AttribIndex);

        public bool IsGenericInstruction()
            => HasAncestor(Entities.GenericInstruction);

        public bool IsIntrinsic()
            => HasAncestor(Entities.Intrinsic);

        public IntrinsicEntity ToIntrinsic()
            => new IntrinsicEntity(Def,AttribIndex);

        public bool IsInstAlias()
            => HasAncestor(Entities.InstAlias);

        public InstAliasEntity ToInstAlias()
            => new InstAliasEntity(Def,AttribIndex);

        public bool IsDAGOperand()
            => HasAncestor(Entities.DAGOperand);

        public DAGOperandEntity ToDAGOperand()
            => new DAGOperandEntity(Def,AttribIndex);

        public bool IsRegisterClass()
            => HasAncestor(Entities.RegisterClass);

        public bool IsX86MemOperand()
            => HasAncestor(Entities.X86MemOperand);

        public bool IsRegOp()
            => IsDAGOperand() && IsRegisterClass();

        public RegOpEntity ToRegOp()
            => new RegOpEntity(Def,AttribIndex);

        public bool IsMemOp()
            => IsDAGOperand() && IsX86MemOperand();

        public MemOpEntity ToMemOp()
            => new MemOpEntity(Def,AttribIndex);
    }
}
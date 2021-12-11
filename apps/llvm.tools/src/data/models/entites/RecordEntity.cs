//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;
    using System.Runtime.CompilerServices;

    using static LlvmNames;

    public class RecordEntity : DefFields
    {
        public RecordEntity(DefRelations def, RecordField[] fields)
            : base(def,fields)
        {
        }

        public bool NameBeginsWith(string match)
            => text.begins(EntityName, match);

        protected override RecordField EmptyAttribute
            => RecordField.Empty;

        public bool HasAncestor(string name)
            => Def.AncestorNames.Contains(name);

        public bool IsInstruction()
            => HasAncestor(InstEntity.LlvmName);

        public InstEntity ToInstruction()
            => new InstEntity(Def,AttribIndex);

        public bool IsGenericInstruction()
            => HasAncestor(Entities.GenericInstruction);

        public bool IsIntrinsic()
            => HasAncestor(IntrinsicEntity.LlvmName);

        public IntrinsicEntity ToIntrinsic()
            => new IntrinsicEntity(Def,AttribIndex);

        public bool IsInstAlias()
            => HasAncestor(Entities.InstAlias);

        public InstAliasEntity ToInstAlias()
            => new InstAliasEntity(Def,AttribIndex);

        public bool IsDAGOperand()
            => HasAncestor(DAGOperandEntity.LlvmName);

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

        public bool IsX86Reg()
            => HasAncestor(X86RegEntity.LlvmName);

        public X86RegEntity ToX86Reg()
            => new X86RegEntity(Def,AttribIndex);

        public bool IfX86Reg(Action<X86RegEntity> f)
        {
            if(IsX86Reg())
            {
                f(ToX86Reg());
                return true;
            }
            else
                return false;
        }
    }
}
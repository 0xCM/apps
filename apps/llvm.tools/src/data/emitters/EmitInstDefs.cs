//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;

    using static core;

    partial class LlvmDataEmitter
    {
        public Index<InstDef> EmitInstDefs()
        {
            var result = Outcome.Success;
            var entities = DataProvider.SelectEntities();
            var count = entities.Length;
            var asmids = DataProvider.SelectAsmIdDefs();
            var found = list<Paired<ushort,InstEntity>>();
            for(var i=0; i<count; i++)
            {
                ref readonly var entity = ref entities[i];
                if(entity.IsInstruction())
                {
                    var inst = entity.ToInstruction();
                    if(asmids.Find(inst.InstName, out var id))
                        found.Add((id.Id,inst));
                    else
                    {
                        result = (false,string.Format("{0} id not found", inst.InstName));
                        break;
                    }
                }
            }

            return Emit(found.ViewDeposited());
        }

        Index<InstDef> Emit(ReadOnlySpan<Paired<ushort,InstEntity>> src)
        {
            var count = src.Length;
            var buffer = alloc<InstDef>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var pair = ref skip(src,i);
                ref readonly var id = ref pair.Left;
                ref readonly var entity = ref pair.Right;
                ref var dst = ref seek(buffer,i);
                var asmstr = entity.AsmString;
                dst.AsmId = id;
                dst.CgOnly = entity.isCodeGenOnly;
                dst.Pseudo = entity.isPseudo;
                dst.InstName = entity.InstName;
                dst.Mnemonic = asmstr.Mnemonic;
                dst.FormatPattern = asmstr.FormatPattern;
                dst.InOperandList = entity.InOperandList;
                dst.OutOperandList = entity.OutOperandList;
                dst.VarCode = entity.VarCode;
            }

            TableEmit(@readonly(buffer.Sort()), InstDef.RenderWidths, LlvmPaths.Table<InstDef>());

            return buffer;
        }
    }
}
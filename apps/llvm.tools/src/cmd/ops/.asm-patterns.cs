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
    using static core;

    partial class LlvmCmd
    {
        [CmdOp(".asm-patterns")]
        Outcome AsmStrings(CmdArgs args)
        {
            var fields = Db.DefFields();
            var names = Db.SelectList(Lists.X86Inst).Map(x => (x.Value.Text, x)).ToDictionary();
            var count = fields.Length;
            var records = span<LlvmAsmPattern>(names.Count);
            var counter = 0u;
            for(var i=0; i<count; i++)
            {
                ref readonly var field = ref fields[i];
                ref readonly var name = ref field.RecordName;
                ref readonly var value = ref field.Value;

                if(field.Name != LlvmNames.RecordFields.AsmString)
                    continue;

                // if(names.TryGetValue(field.RecordName, out var item))
                // {
                //     ref var record = ref seek(records, counter++);
                //     record.AsmId = item.Id;
                //     record.AsmName = name.Content;
                //     record.Mnemonic = AsmString.mnemonic(value);
                //     record.ExprFormat = AsmString.format(value);
                // }
            }

            var collected = slice(records,0,counter);
            var dst = LlvmPaths.Table<LlvmAsmPattern>();
            TableEmit(@readonly(collected), dst);
            return true;
        }

        void EmitList(ReadOnlySpan<Entity> src, string @class)
        {
            var dst = LlvmPaths.Table(string.Format("llvm.lists.{0}", @class));
            var emitting = EmittingTable<LlvmListItem>(dst);
            var formatter = Tables.formatter<LlvmListItem>();
            using var writer = dst.AsciWriter();
            writer.WriteLine(formatter.FormatHeader());
            var count = src.Length;
            var counter = 0u;
            for(var i=0; i<count; i++)
            {
                ref readonly var entity = ref skip(src,i);
                ref readonly var def = ref entity.Def;
                var ancestors = LlvmRecordEtl.ancestors(def);
                if(ancestors.Contains(@class))
                {
                    var item = new LlvmListItem(counter++,entity.EntityName);
                    writer.WriteLine(formatter.Format(item));
                }
            }

            EmittedTable(emitting, counter);
        }

        [CmdOp(".entities")]
        Outcome DefEntities(CmdArgs args)
        {
            var entities = Db.Entities();
            var count = entities.Length;
            var key = 0u;
            var records = list<LlvmAsmPattern>();
            var asmids = list<LlvmAsmIdentity>();
            var obmapped = list<LlvmAsmIdentity>();
            for(var i=0; i<count; i++)
            {
                ref readonly var entity = ref skip(entities,i);
                ref readonly var def = ref entity.Def;
                var ancestors = LlvmRecordEtl.ancestors(def);
                if(ancestors.Contains(RecordClasses.Instruction))
                {
                    AsciBlock32 name = entity.EntityName.Content;
                    var identity = new LlvmAsmIdentity(key++, name);
                    asmids.Add(identity);
                    var _pseudo = entity["isPseudo"];
                    var _cgonly = entity["isCodeGenOnly"];

                    if(bit.parse(_pseudo.Value, out var pseudo) && bit.parse(_cgonly.Value, out var cgonly))
                    {
                        if(pseudo || cgonly)
                            continue;

                        var asms = entity["AsmString"];
                        var map = entity["OpMap"];
                        if(map.Value.Equals("OB"))
                            obmapped.Add(identity);
                        var mnemonic = AsmString.mnemonic(asms.Value);
                        var fmt = AsmString.format(asms.Value);
                        records.Add(LlvmAsmPattern.define(key, name, mnemonic, fmt, out var _));
                    }
                }
            }

            TableEmit(records.ViewDeposited(), LlvmPaths.Table<LlvmAsmPattern>());
            TableEmit(asmids.ViewDeposited(), LlvmPaths.Table<LlvmAsmIdentity>());
            EmitList(entities, RecordClasses.AVX512);
            EmitList(entities, RecordClasses.AsmOperandClass);
            EmitList(entities, RecordClasses.AssemblerPredicate);
            EmitList(entities, RecordClasses.CondCode);
            EmitList(entities, RecordClasses.Register);
            EmitList(entities, RecordClasses.RegisterClass);
            EmitList(entities, RecordClasses.ValueType);
            EmitList(entities, RecordClasses.Map);
            EmitList(entities, RecordClasses.SubtargetFeature);
            EmitList(entities, RecordClasses.Predicate);
            EmitList(entities, RecordClasses.X86Inst);
            EmitList(entities, RecordClasses.X86MemOperand);
            EmitList(entities, RecordClasses.X86MemOffsOperand);

            iter(obmapped, ob => Write(ob.Name));
            return true;
        }
    }
}
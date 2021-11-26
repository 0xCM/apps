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
        [CmdOp(".entities")]
        Outcome DefEntities(CmdArgs args)
        {
            var entities = Db.Entities();
            var members = entities.Members;
            var count = members.Length;
            var key = 0u;
            var records = list<LlvmAsmPattern>();
            var asmids = list<LlvmAsmIdentity>();
            var obmapped = list<LlvmAsmIdentity>();
            for(var i=0; i<count; i++)
            {
                ref readonly var entity = ref skip(members,i);
                ref readonly var def = ref entity.Def;
                var ancestors = def.AncestorNames;
                var parent = def.ParentName;
                if(ancestors.Contains(RecordClasses.Instruction))
                {
                    var name = entity.EntityName.Content;
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
                        var j = text.index(name.ToLower(),mnemonic);
                        if(j >=0)
                        {
                            var variation = text.right(name, j + mnemonic.Length - 1);
                            Write(string.Format("{0,-24} | {1,-16} | {2}", name, mnemonic, variation));
                        }

                        records.Add(LlvmAsmPattern.define(key, name, mnemonic, fmt, out var _));
                    }
                }
            }

            TableEmit(records.ViewDeposited(), LlvmPaths.Table<LlvmAsmPattern>());
            TableEmit(asmids.ViewDeposited(), LlvmPaths.Table<LlvmAsmIdentity>());

            var lists = RecordEtl.EmitLists(entities, RecordClasses.Names);
            RecordEtl.EmitChildRelations(entities);

            CodeGen.GenListStringTables(lists);
            return true;
        }
    }
}
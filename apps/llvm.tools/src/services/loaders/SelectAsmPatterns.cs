//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;
    using System.Collections.Concurrent;
    using static core;

    using Asm;

    partial class LlvmDataProvider
    {
        public Index<LlvmAsmPattern> SelectAsmPatterns()
        {
            return (Index<LlvmAsmPattern>)DataSets.GetOrAdd(nameof(LlvmAsmPattern), key => Load());

            Index<LlvmAsmPattern> Load()
            {
                const byte FieldCount = LlvmAsmPattern.FieldCount;
                var src = LlvmPaths.Table<LlvmAsmPattern>();
                var buffer = list<LlvmAsmPattern>();
                using var reader = src.Utf8LineReader();
                reader.Next(out var header);
                var cols = header.Split(Chars.Pipe);
                if(cols.Length != FieldCount)
                {
                    Wf.Error(Tables.FieldCountMismatch.Format(cols.Length, FieldCount));
                    return sys.empty<LlvmAsmPattern>();
                }

                while(reader.Next(out var line))
                {
                    var row = LlvmAsmPattern.Empty;
                    cols = line.Split(Chars.Pipe);
                    if(cols.Length != FieldCount)
                    {
                        Wf.Error(Tables.FieldCountMismatch.Format(cols.Length, FieldCount));
                        return sys.empty<LlvmAsmPattern>();
                    }

                    var i=0;
                    DataParser.parse(skip(cols,i++), out row.Seq);
                    DataParser.parse(skip(cols,i++), out row.AsmId);
                    DataParser.parse(skip(cols,i++), out row.IsCodeGenOnly);
                    DataParser.parse(skip(cols,i++), out row.IsPseudo);
                    row.Instruction = skip(cols,i++);
                    row.Mnemonic = skip(cols,i++);
                    row.Variation = new AsmVariationCode(skip(cols,i++));
                    row.ExprFormat = skip(cols,i++);
                    buffer.Add(row);
                }
                return buffer.ToArray();
            }
        }
    }
}
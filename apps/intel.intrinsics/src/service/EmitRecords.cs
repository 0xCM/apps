//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static IntrinsicsDoc;
    using static IntelIntrinsics;
    using R = XedRules;
    using static XedModels;

    partial class IntelIntrinsicSvc
    {
        void EmitRecords2(Index<IntrinsicDef> src)
        {
            for(var i=0; i<src.Count; i++)
            {
                ref readonly var record = ref src[i];
            }
        }

        void EmitRecords(ReadOnlySpan<IntrinsicRecord> src, string type)
        {
            var path = TablePath(type);
            var emitting = AppSvc.EmittingTable<IntrinsicRecord>(path);
            var formatter = Tables.formatter<IntrinsicRecord>();
            using var emitter = path.AsciEmitter();
            emitter.AppendLine(formatter.FormatHeader());
            var counter = 0u;
            for(var i=0; i<src.Length; i++)
            {
                ref readonly var record = ref skip(src,i);
                ref readonly var types = ref record.Types;
                for(var j=0; j<types.Count; j++)
                    if(types[j] == type)
                    {
                        emitter.AppendLine(formatter.Format(record));
                        counter++;
                    }
            }
            AppSvc.EmittedTable(emitting, counter);
        }

        Index<IntrinsicRecord> EmitRecords(Index<IntrinsicDef> src)
        {
            var dst = alloc<IntrinsicRecord>(src.Count);
            fill(src,dst);
            AppSvc.TableEmit(dst.Sort().Resequence(), Targets().Table<IntrinsicRecord>());
            return dst;
        }

        // void EmitRecords(Index<IntrinsicDef> src, string type)
        // {
        //     var rows = list<IntrinsicRecord>();
        //     Summarize(src, rows);
        //     var buffer = list<IntrinsicRecord>();
        //     foreach(var row in rows)
        //     {
        //         foreach(var t in row.Types)
        //         {
        //             if(t == type)
        //                 buffer.Add(row);
        //         }
        //     }

        //     AppSvc.TableEmit(buffer.Index().Sort(), TablePath(type.ToLower()));
        // }

        static void fill(ReadOnlySpan<IntrinsicDef> src, Span<IntrinsicRecord> dst)
        {
            for(var i=0; i< src.Length; i++)
                fill(skip(src,i), out seek(dst,i));
        }

        static void fill(in IntrinsicDef src, out IntrinsicRecord dst)
        {
            dst.Key = 0;
            dst.Name = src.name;
            dst.CpuId = src.CPUID;
            dst.Types = src.types;
            dst.Category = src.category;
            dst.Signature = src.Sig();

            if(instruction(src, out var inst))
            {
                dst.InstSig = inst;
                dst.InstForm = inst.xed;
                dst.FormId = (ushort)inst.xed;
                dst.InstClass = inst.InstClass;
            }
            else
            {
                dst.InstClass = R.InstClass.Empty;
                dst.InstSig = Instruction.Empty;
                dst.InstForm = InstForm.Empty ;
                dst.FormId = 0;
            }
        }
    }
}
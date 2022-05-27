//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    public sealed class AsmCallPipe : AppService<AsmCallPipe>
    {
        AppSvcOps AppSvc => Wf.AppSvc();

        public ReadOnlySpan<AsmCallRow> EmitRows(ReadOnlySpan<ApiPartRoutines> src)
        {
            var dst = Db.TableDir<AsmCallRow>();
            return EmitRows(src, dst);
        }

        public ReadOnlySpan<AsmCallRow> EmitRows(ReadOnlySpan<ApiPartRoutines> src, FS.FolderPath dst)
        {
            var rows = list<AsmCallRow>();
            var count = src.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var routines = ref skip(src,i);
                var path = Db.Table(dst, AsmCallRow.TableId, routines.Part);
                EmitRows(routines, rows, path);
            }
            return rows.ViewDeposited();
        }

        public SortedSpan<AsmCallRow> EmitRows(ReadOnlySpan<AsmRoutine> src, FS.FilePath dst)
        {
            var instructions = list<ApiInstruction>();
            iter(src, routine => instructions.AddRange(routine.Instructions));
            var calls = BuildRows(instructions.ViewDeposited()).ToSortedSpan();
            var count = calls.Length;
            AppSvc.TableEmit(calls.View, dst);
            return calls;
        }

        void EmitRows(in ApiPartRoutines src, List<AsmCallRow> rows, FS.FilePath dst)
        {
            var flow = Wf.EmittingTable<AsmCallRow>(dst);
            using var writer = dst.Writer();
            var calls = BuildRows(src.Instructions());
            var view = calls.View;
            var count = view.Length;
            var formatter = Tables.formatter<AsmCallRow>();
            writer.WriteLine(formatter.FormatHeader());
            for(var i=0; i<count; i++)
            {
                ref readonly var row = ref skip(view,i);
                writer.WriteLine(formatter.Format(row));
                rows.Add(row);
            }

            Wf.EmittedTable(flow, count);
        }

        [MethodImpl(Inline), Op]
        static bool rel32dx(BinaryCode src, out int dx)
        {
            var opcode = src.First;
            if(opcode == 0xe8)
            {
                dx = i32(slice(src.View, 1));
                return true;
            }
            dx = default;
            return false;
        }

        [Op]
        public Index<AsmCallRow> BuildRows(ReadOnlySpan<ApiInstruction> src)
        {
            var calls = ApiInstructions.filter(src, 0xE8);
            var count = calls.Length;
            var buffer = alloc<AsmCallRow>(count);
            ref var row = ref first(span(buffer));
            for(var i=0u; i<count; i++)
            {
                ref readonly var call = ref skip(calls,i);
                ref var dst = ref seek(row,i);
                rel32dx(call.Encoded, out var offset);
                dst.SourcePart = call.Part;
                dst.Block = call.BaseAddress;
                dst.InstructionSize = call.InstructionSize;
                dst.Source = call.IP;
                dst.TargetOffset = (uint)offset;
                dst.Target =  (call.IP + call.InstructionSize) + offset;
                dst.Instruction = call.Statment;
                dst.Encoded = call.Encoded;
            }
            return buffer;
        }

        public Index<AsmCallRow> LoadRows()
        {
            var paths = Db.TableDir<AsmCallRow>().AllFiles.View;
            var flow = Running(string.Format("Loading {0} call recordsets", paths.Length));
            var dst = list<AsmCallRow>();
            var count = paths.Length;
            for(var i=0; i<count; i++)
            {
                var doc = TextGrids.parse(skip(paths,i));
                if(doc)
                {
                    var rows = doc.Value.Rows;
                    for(var j = 0; j<rows.Length; j++)
                    {
                        if(AsmCallRow.parse(skip(rows,j), out var record))
                            dst.Add(record);
                        else
                            Errors.Throw(AppMsg.ParseFailure.Format(nameof(AsmCallRow), skip(rows,j).Format()));
                    }
                }
            }

            Ran(flow, string.Format("Loaded {0} total call instructions", dst.Count));
            return dst.ToArray();
        }
    }
}
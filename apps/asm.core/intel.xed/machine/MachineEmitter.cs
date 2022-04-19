//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static Datasets;
    using static XedRules;
    using static XedModels;

    partial class XedMachine
    {
        public MachineEmitter Emitter
        {
            [MethodImpl(Inline)]
            get => _Emitter;
        }

        public class MachineEmitter : IDisposable
        {
            public static MachineEmitter create(XedMachine machine, Action<object> status)
                => new MachineEmitter(machine,status);

            object LogLocker = new();

            WsLog _Log;

            WsLog Log
            {
                get
                {
                    lock(LogLocker)
                    {
                        if(_Log == null)
                            _Log = WsLog.open(Ws, $"xed.machine.{Machine.Id}", FileKind.Csv);
                    }
                    return _Log;
                }
            }

            readonly XedMachine Machine;

            readonly IProjectWs Ws;

            readonly FS.FolderPath OutDir;

            readonly Action<object> Status;

            public MachineEmitter(XedMachine machine, Action<object> status)
            {
                Machine = machine;
                Ws = machine.Ws;
                Status = status;
                OutDir = Ws.Out();
            }

            public void Dispose()
            {
                lock(LogLocker)
                    if(_Log != null)
                        _Log.Dispose();
            }

            public void Flush()
            {
                lock(LogLocker)
                {
                    if(_Log != null)
                        _Log.Flush();
                }
            }

            public void EmitClassForms()
            {
                var section = nameof(Machine.ClassForms);
                var cols = new TableColumns(
                    section,
                    ("Section",16),
                    ("InstClass",18),
                    ("OpCode", 26),
                    ("Form", 1)
                    );

                var src = Machine.ClassForms.Sort();
                var rows = map(src, item =>
                    new{
                        section,
                        Machine.InstClass.Classifier,
                        Machine.OpCode,
                        item
                });

                TableEmitOld(cols, rows);
            }

            public void EmitFormPatterns(string label)
            {
                var section = nameof(Machine.FormPatterns);
                var cols = new TableColumns(
                    section,
                    ("Section",16),
                    ("PatternId",12),
                    ("InstClass", 18),
                    ("OpCode", 26),
                    ("InstForm", 1)
                    );

                var capture = Machine.Captured();
                var src = capture.FormPatterns.Map(x => (Form:x.Key, Patterns:x.Value.Array().Sort().Index()));
                var rows = map(src, kvp => map(kvp.Patterns, p =>
                    new {
                        section,
                        p.PatternId,
                        p.InstClass,
                        p.OpCode,
                        kvp.Form
                    }
                )).SelectMany(x => x);

                var emitted = Datasets.emit(cols,rows, OutDir + FS.file(label,FS.Csv));
                Status(string.Format($"Emittited {emitted.count} rows to {emitted.path}"));
            }

            public void EmitClassGroups()
            {
                var section = nameof(Machine.ClassGroups);
                var cols = new TableColumns(
                    section,
                    ("Section",16),
                    ("Mode",8),
                    ("InstClass", 18),
                    ("Index", 8),
                    ("OpCode", 26)
                    );

                var src = Machine.ClassGroups;
                var rows = map(src, member =>
                    new {
                        section,
                        member.Mode,
                        member.Class,
                        member.Index,
                        member.OpCode
                    }
                );

                TableEmitOld(cols, rows);
            }

            void TableEmitOld<T>(TableColumns cols, T[] rows, bool status = false)
            {
                if(rows.Length != 0)
                {
                    var dst = Log.TableEmit(cols, rows);

                    // if(status)
                    //     Status(string.Format($"Emittited {dst.count} rows to {dst.path}"));
                }
            }
        }
    }
}
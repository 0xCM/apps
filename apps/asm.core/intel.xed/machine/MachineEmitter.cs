//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedRules;
    using static Datasets;

    public partial class XedMachine
    {
        public interface IMachineEmitter
        {
            void EmitClassForms();

            void EmitClassGroups();
        }

        class MachineEmitter : IDisposable, IMachineEmitter
        {
            readonly WsLog Log;

            readonly XedMachine Machine;

            readonly IProjectWs Ws;

            readonly Action<object> Status;

            public MachineEmitter(XedMachine machine, Action<object> status)
            {
                Machine = machine;
                Ws = machine._Ws;
                Status = status;
                Log = WsLog.open(Ws, $"xed.machine.{machine.Id}", FileKind.Csv);
            }

            public ref readonly FS.FilePath Target => ref Log.Path;

            public void Dispose()
            {
                Log.Dispose();
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

                TableEmit(cols, rows);
            }

            public void EmitClassGroups()
            {
                var section = nameof(Machine.ClassGroups);
                var cols = new TableColumns(
                    section,
                    ("Section",16),
                    ("Mode",8),
                    ("InstClass", 18),
                    ("Indicator", 12),
                    ("Index", 8),
                    ("OpCode", 26)
                    );

                var src = Machine.ClassGroups;
                var rows = map(src, member =>
                    new {
                        section,
                        member.Mode,
                        member.Class,
                        member.Indicator,
                        member.Index,
                        member.OpCode
                    }
                );

                TableEmit(cols, rows);
            }

            void TableEmit<T>(TableColumns cols, T[] rows)
            {
                if(rows.Length != 0)
                {
                    var dst = Log.TableEmit(cols,rows);
                    Status(string.Format($"Emittited {dst.count} rows to {dst.path}"));
                }
            }
        }
    }
}
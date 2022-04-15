//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public partial class XedMachine
    {
        public interface IMachineEmitter
        {
            void EmitClassForms();
        }

        class MachineEmitter : IDisposable, IMachineEmitter
        {
            readonly WsLog Log;

            readonly XedMachine Machine;

            readonly IProjectWs Ws;

            public MachineEmitter(XedMachine machine)
            {
                Machine = machine;
                Ws = machine.Ws;
                Log = WsLog.open(Ws, $"xed.machine.{machine.MachineId}");
            }

            public ref readonly FS.FilePath Target => ref Log.Target;

            public void Dispose()
            {
                Log.Dispose();
            }

            public void EmitClassForms()
            {
                var @class = Machine.InstClass.Classifier;
                var opcode = Machine.OpCode;
                var forms = Machine.ClassForms.Sort();
                iter(forms,
                    form => Log.WriteLineFormat("{0,-18} | {1,-26} | {2}", @class, opcode, form));
            }
        }
    }
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedMachine
    {
        public class Emitter : IDisposable
        {
            public static Emitter create(XedMachine machine, Action<object> status)
                => new Emitter(machine,status);

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

            readonly IProjectWsObsolete Ws;

            readonly FS.FolderPath OutDir;

            readonly Action<object> Status;

            public Emitter(XedMachine machine, Action<object> status)
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

        }
    }
}
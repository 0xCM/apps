//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.IO;

    class WfEmissionLog : IWfEmissionLog
    {
        readonly FileStream Stream;

        readonly FS.FilePath Target;

        readonly IRecordFormatter<EmissionLogEntry> Formatter;

        bool Closed;

        public WfEmissionLog(Assembly src, FS.FilePath dst)
        {
            Closed = false;
            Target = dst;
            Target.EnsureParentExists().Delete();
            Stream = Target.Stream();
            Formatter = Tables.formatter<EmissionLogEntry>();
            FS.write(Formatter.FormatHeader() + Eol, Stream);
        }

        public WfEmissionLog(Assembly src, FS.FolderPath root, Timestamp? ts = null, string name = null)
        {
            Closed = false;
            Target = Loggers.config(src, root, name ?? "emissions", FileKind.Csv, ts);
            Target.EnsureParentExists().Delete();
            Stream = Target.Stream();
            Formatter = Tables.formatter<EmissionLogEntry>();
            FS.write(Formatter.FormatHeader() + Eol, Stream);
        }

        public void Close()
        {
            if(!Closed)
            {
                Stream.Flush();
                Stream.Dispose();
                Closed = true;
            }
        }

        public void Dispose()
        {
            Close();
        }

        // const string FormatPattern = "{0,-24} | {1,-24} | {2,-12} | {3,-12} | {4}";

        public ref readonly WfFileWritten LogEmission(in WfFileWritten flow)
        {
            try
            {
                //var count = flow.EmissionCount;
                //var status = count == 0 ? "Emitting" : "Emitted";
                //var format = string.Format(FormatPattern, flow.Token, flow.Target.Ext, status, count, flow.Target.ToUri());
                //FS.write(format + Eol, Emissions);
                FS.write(Formatter.Format(Loggers.entry(flow, out _)) + Eol, Stream);

            }
            catch(Exception error)
            {
                term.errlabel(error, "EventLogError");
            }

            return ref flow;
        }

        public ref readonly WfTableFlow<T> LogEmission<T>(in WfTableFlow<T> flow)
            where T : struct
        {
            try
            {
                // var metric = flow.EmissionCount;
                // var status = metric == 0 ? "Emitting" : "Emitted";
                // var format = string.Format(FormatPattern, flow.Token, Tables.identify<T>(), status, metric, flow.Target.ToUri());
                FS.write(Formatter.Format(Loggers.entry(flow, out _)) + Eol, Stream);
                //FS.write(format + Eol, Emissions);
            }
            catch(Exception error)
            {
                term.errlabel(error, "EventLogError");
            }
            return ref flow;
        }
    }
}
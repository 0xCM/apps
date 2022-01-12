//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.InteropServices;
    using System.IO;

    using static Root;

    public class EmissionLog : IEmissionLog
    {
        readonly FileStream Emissions;

        public FS.FilePath TargetPath {get;}

        public static IEmissionLog open(FS.FilePath dst)
            => new EmissionLog(dst);

        internal EmissionLog(FS.FilePath dst)
        {
            dst.CreateParentIfMissing().Delete();
            Emissions = dst.Stream();
            TargetPath = dst;
        }

        public void Dispose()
        {
            Emissions?.Flush();
            Emissions?.Dispose();
        }

        const string FormatPattern = "{0,-24} | {1,-24} | {2,-12} | {3,-12} | {4}";

        public void Deposit(EmittedFileEvent e)
        {
            try
            {
                FS.write(e.Format() + Eol, Emissions);
            }
            catch(Exception error)
            {
                term.errlabel(error, "EventLogError");
            }
        }

        public void Deposit(EmittedTableEvent e)
        {
            try
            {
                FS.write(e.Format() + Eol, Emissions);
            }
            catch(Exception error)
            {
                term.errlabel(error, "EventLogError");
            }
        }
    }
}
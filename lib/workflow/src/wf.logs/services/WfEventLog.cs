//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.IO;

    using static Root;

    struct WfEventLog : IWfEventLog
    {
        readonly FS.FilePath StatusPath;

        readonly FS.FilePath Error;

        readonly FileStream Status;

        public WfEventLog(WfLogConfig config)
        {
            config.StatusLog.Delete();
            config.ErrorLog.Delete();
            StatusPath = FS.path(config.StatusLog.Name);
            Error = FS.path(config.ErrorLog.Name).EnsureParentExists();
            Status = StatusPath.Stream();
        }

        public void Dispose()
        {
            Status?.Flush();
            Status?.Dispose();
        }

        [MethodImpl(Inline)]
        void Display(IAppMsg src)
            => term.print(src);

        [MethodImpl(Inline)]
        void Display(IAppEvent src)
            => term.print(src);

        [MethodImpl(Inline)]
        static string format(ITextual src)
            => string.Concat(src.Format(), Eol);

        [MethodImpl(Inline)]
        static string summary(IErrorEvent src)
            => string.Concat(src.Format(), Eol);

        public void Deposit(IAppMsg e)
        {
            try
            {
                Display(e);

                if(e.IsError)
                    Error.AppendLines(e.Format());

                FS.write(format(e), Status);
            }
            catch(Exception error)
            {
                term.errlabel(error, "EventLogError");
            }
        }

        void Emit(IAppEvent e)
        {
            Display(e);

            try
            {
                if(e.IsError)
                    Error.AppendLines(e.Format());
                FS.write(format(e), Status);
            }
            catch(Exception error)
            {
                term.errlabel(error, "EventLogError");
            }
        }

        [MethodImpl(Inline)]
        public void Deposit(IAppEvent e)
            => Emit(e);

        public void Deposit(object src)
        {
            if(src is IWfEvent e)
                Deposit(e);
            else if(src is IAppMsg m)
                Deposit(m);
        }

        [MethodImpl(Inline)]
        public void Deposit(IWfEvent e)
        {
            Display(e);

            try
            {
                if(e is IErrorEvent error)
                {
                    Error.AppendLines(e.Format());
                    FS.write(summary(error), Status);
                }
                else
                    FS.write(format(e), Status);
            }
            catch(Exception error)
            {
                term.errlabel(error, "EventLogError");
            }
        }
    }
}
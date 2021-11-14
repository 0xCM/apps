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

    readonly struct BuildLog : IBuildLog
    {
        readonly FileStream Target;

        readonly FS.FilePath Path;

        [MethodImpl(Inline)]
        public BuildLog(FS.FilePath dst)
        {
            Path = dst;
            Target = Path.Stream();
        }

        public void Dispose()
        {
            Target?.Flush();
            Target?.Dispose();
        }

        public void Deposit(BuildLogEntry src)
        {
            try
            {
                FS.write(format(src), Target);
            }
            catch(Exception e)
            {
                term.error(e);
            }
        }

        static string format(in BuildLogEntry src)
        {
            return EmptyString;
        }
    }
}
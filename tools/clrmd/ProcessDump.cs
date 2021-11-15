//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Linq;

    using Microsoft.Diagnostics.Runtime;

    public class ProcessDump : IDisposable
    {
        public static ProcessDump open(FS.FilePath src)
            => new ProcessDump(src);

        FS.FilePath Path;

        DataTarget Target;

        ClrRuntime Runtime;

        ProcessDump(FS.FilePath src)
        {
            Path = src;
            Target = DataTarget.LoadDump(src.Name);
            Runtime = Target.ClrVersions.Single().CreateRuntime();
        }

        public void Dispose()
        {
            Runtime.Dispose();
            Target.Dispose();
        }

        public Outcome FindMethod(MemoryAddress ip, out ClrMethod dst)
        {
            var method = Runtime.GetMethodByInstructionPointer(ip);
            if(method != null)
            {
                dst = method;
                return true;
            }
            else
            {
                dst = default;
                return false;
            }
        }
    }
}
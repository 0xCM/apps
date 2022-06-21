//-----------------------------------------------------------------------------
// Copyright   :  .NET Foundation
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct DumpEmitter
    {
        const int ERROR_PARTIAL_COPY = unchecked((int)0x8007012b);

        public static void emit(Process process, string outputFile, DumpTypeOption type)
        {
            // Open the file for writing
            using (var stream = new FileStream(outputFile, FileMode.Create, FileAccess.ReadWrite, FileShare.None))
            {
                MinidumpType dumpType = MinidumpType.MiniDumpNormal;
                switch (type)
                {
                    case DumpTypeOption.Full:
                        dumpType = MinidumpType.MiniDumpWithFullMemory |
                                   MinidumpType.MiniDumpWithDataSegs |
                                   MinidumpType.MiniDumpWithHandleData |
                                   MinidumpType.MiniDumpWithUnloadedModules |
                                   MinidumpType.MiniDumpWithFullMemoryInfo |
                                   MinidumpType.MiniDumpWithThreadInfo |
                                    MinidumpType.MiniDumpWithTokenInformation |
                                    MinidumpType.MiniDumpWithModuleHeaders |
                                    MinidumpType.MiniDumpWithAvxXStateContext |
                                    MinidumpType.MiniDumpWithIptTrace
                                    ;
                        break;
                    case DumpTypeOption.Heap:
                        dumpType = MinidumpType.MiniDumpWithPrivateReadWriteMemory |
                                    MinidumpType.MiniDumpWithDataSegs |
                                    MinidumpType.MiniDumpWithHandleData |
                                    MinidumpType.MiniDumpWithUnloadedModules |
                                    MinidumpType.MiniDumpWithFullMemoryInfo |
                                    MinidumpType.MiniDumpWithThreadInfo |
                                    MinidumpType.MiniDumpWithTokenInformation;
                        break;
                    case DumpTypeOption.Mini:
                        dumpType = MinidumpType.MiniDumpWithThreadInfo;
                        break;
                }

                // Retry the write dump on ERROR_PARTIAL_COPY
                for (int i = 0; i < 5; i++)
                {
                    // Dump the process!
                    if (DbgHelp.MiniDumpWriteDump(process.Handle, (uint)process.Id, stream.SafeFileHandle, dumpType, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero))
                    {
                        break;
                    }
                    else
                    {
                        int err = Marshal.GetHRForLastWin32Error();
                        if (err != ERROR_PARTIAL_COPY)
                        {
                            Marshal.ThrowExceptionForHR(err);
                        }
                    }
                }
            }
        }
    }
}
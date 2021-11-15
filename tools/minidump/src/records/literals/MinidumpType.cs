namespace Z0
{
    using System;

    partial struct MinidumpRecords
    {
        // From minidumpapiset.h
        // A normal minidump contains just the information
        // necessary to capture stack traces for all of the
        // existing threads in a process.
        //
        // A minidump with data segments includes all of the data
        // sections from loaded modules in order to capture
        // global variable contents.  This can make the dump much
        // larger if many modules have global data.
        //
        // A minidump with full memory includes all of the accessible
        // memory in the process and can be very large.  A minidump
        // with full memory always has the raw memory data at the end
        // of the dump so that the initial structures in the dump can
        // be mapped directly without having to include the raw
        // memory information.
        //
        // Stack and backing store memory can be filtered to remove
        // data unnecessary for stack walking.  This can improve
        // compression of stacks and also deletes data that may
        // be private and should not be stored in a dump.
        // Memory can also be scanned to see what modules are
        // referenced by stack and backing store memory to allow
        // omission of other modules to reduce dump size.
        // In either of these modes the ModuleReferencedByMemory flag
        // is set for all modules referenced before the base
        // module callbacks occur.
        //
        // On some operating systems a list of modules that were
        // recently unloaded is kept in addition to the currently
        // loaded module list.  This information can be saved in
        // the dump if desired.
        //
        // Stack and backing store memory can be scanned for referenced
        // pages in order to pick up data referenced by locals or other
        // stack memory.  This can increase the size of a dump significantly.
        //
        // Module paths may contain undesired information such as user names
        // or other important directory names so they can be stripped.  This
        // option reduces the ability to locate the proper image later
        // and should only be used in certain situations.
        //
        // Complete operating system per-process and per-thread information can
        // be gathered and stored in the dump.
        //
        // The virtual address space can be scanned for various types
        // of memory to be included in the dump.
        //
        // Code which is concerned with potentially private information
        // getting into the minidump can set a flag that automatically
        // modifies all existing and future flags to avoid placing
        // unnecessary data in the dump.  Basic data, such as stack
        // information, will still be included but optional data, such
        // as indirect memory, will not.
        //
        // When doing a full memory dump it's possible to store all
        // of the enumerated memory region descriptive information
        // in a memory information stream.
        //
        // Additional thread information beyond the basic thread
        // structure can be collected if desired.
        //
        // A minidump with code segments includes all of the code
        // and code-related sections from loaded modules in order
        // to capture executable content.
        //
        // MiniDumpWithoutAuxiliaryState turns off any secondary,
        // auxiliary-supported memory gathering.
        //
        // MiniDumpWithFullAuxiliaryState asks any present auxiliary
        // data providers to include all of their state in the dump.
        // The exact set of what is provided depends on the auxiliary.
        // This can be quite large.
        [Flags, DocRef(Docs + "ne-minidumpapiset-minidump_type.md")]
        public enum MinidumpType : ulong
        {
            /// <summary>
            ///
            /// </summary>
            MiniDumpNormal = 0x00000000,

            /// <summary>
            ///
            /// </summary>
            MiniDumpWithDataSegs = 0x00000001,

            /// <summary>
            ///
            /// </summary>
            MiniDumpWithFullMemory = 0x00000002,

            /// <summary>
            ///
            /// </summary>
            MiniDumpWithHandleData = 0x00000004,

            /// <summary>
            ///
            /// </summary>
            MiniDumpFilterMemory = 0x00000008,

            /// <summary>
            ///
            /// </summary>
            MiniDumpScanMemory = 0x00000010,

            /// <summary>
            ///
            /// </summary>
            MiniDumpWithUnloadedModules = 0x00000020,

            /// <summary>
            /// Include pages with data referenced by locals or other stack memory. This option can increase the size of the minidump file significantly
            /// </summary>
            MiniDumpWithIndirectlyReferencedMemory = 0x00000040,

            /// <summary>
            ///
            /// </summary>
            MiniDumpFilterModulePaths = 0x00000080,

            /// <summary>
            ///
            /// </summary>
            MiniDumpWithProcessThreadData = 0x00000100,

            /// <summary>
            ///
            /// </summary>
            MiniDumpWithPrivateReadWriteMemory = 0x00000200,

            /// <summary>
            ///
            /// </summary>
            MiniDumpWithoutOptionalData = 0x00000400,

            /// <summary>
            ///
            /// </summary>
            MiniDumpWithFullMemoryInfo = 0x00000800,

            /// <summary>
            ///
            /// </summary>
            MiniDumpWithThreadInfo = 0x00001000,

            /// <summary>
            /// Include all code and code-related sections from loaded modules to capture executable content. For per-module control, use the ModuleWriteCodeSegs enumeration value from MODULE_WRITE_FLAGS.
            /// </summary>
            MiniDumpWithCodeSegs = 0x00002000,

            /// <summary>
            ///
            /// </summary>
            MiniDumpWithoutAuxiliaryState = 0x00004000,

            /// <summary>
            ///
            /// </summary>
            MiniDumpWithFullAuxiliaryState = 0x00008000,

            /// <summary>
            ///
            /// </summary>
            MiniDumpWithPrivateWriteCopyMemory = 0x00010000,

            /// <summary>
            ///
            /// </summary>
            MiniDumpIgnoreInaccessibleMemory = 0x00020000,

            /// <summary>
            /// Adds security token related data. This will make the "!token" extension work when processing a user-mode dump.
            /// </summary>
            MiniDumpWithTokenInformation = 0x00040000,

            /// <summary>
            /// Adds module header related data
            /// </summary>
            MiniDumpWithModuleHeaders = 0x00080000,

            /// <summary>
            ///
            /// </summary>
            MiniDumpFilterTriage = 0x00100000,

            /// <summary>
            ///
            /// </summary>
            MiniDumpWithAvxXStateContext = 0x00200000,

            /// <summary>
            ///
            /// </summary>
            MiniDumpWithIptTrace = 0x00400000,

            /// <summary>
            ///
            /// </summary>
            MiniDumpScanInaccessiblePartialPages = 0x00800000,

            MiniDumpValidTypeFlags = 0x00ffffff,
        }
    }
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Diagnostics;
    using System.Runtime.InteropServices;

    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct ProcessMemoryState : IRecord<ProcessMemoryState>
    {
        public const string TableId = "image.process.state";

        /// <summary>
        /// The base address of the process
        /// </summary>
        public MemoryAddress BaseAddress;

        /// <summary>
        /// The address of the entry point
        /// </summary>
        public MemoryAddress EntryAddress;

        /// <summary>
        /// The number of bytes occupied by the module
        /// </summary>
        public ByteSize MemorySize;

        /// <summary>
        /// The process name
        /// </summary>
        public Name ImageName;

        /// <summary>
        /// The minimum working set size
        /// </summary>
        public ByteSize MinWorkingSet;

        /// <summary>
        /// The maximum working set size
        /// </summary>
        public ByteSize MaxWorkingSet;

        /// <summary>
        /// The process identifier
        /// </summary>
        public uint ProcessId;

        /// <summary>
        /// The process image version
        /// </summary>
        public VersionSpec ImageVersion;

        /// <summary>
        /// The minimum working set size
        /// </summary>
        public ByteSize VirtualSize;

        /// <summary>
        /// The maximum working set size
        /// </summary>
        public ByteSize MaxVirtualSize;

        /// <summary>
        /// The cpu affinity provided by <see cref='Process.ProcessorAffinity'/>
        /// </summary>
        public ulong Affinity;

        /// <summary>
        /// Captures the process start time
        /// </summary>
        public Timestamp StartTime;

        /// <summary>
        /// Captures the value provided by <see cref='Process.TotalProcessorTime'/>
        /// </summary>
        public Duration TotalRuntime;

        /// <summary>
        /// Captures the value provided by <see cref='Process.UserProcessorTime'/>
        /// </summary>
        public Duration UserRuntime;

        /// <summary>
        /// The path of the process image
        /// </summary>
        public FS.FilePath ImagePath;
    }
}
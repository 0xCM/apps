//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.InteropServices;

    partial struct DiagnosticRecords
    {
        /// <summary>
        /// Shape derived from https://github.com/microsoft/clrmd/Microsoft.Diagnostics.Runtime/src/DacInterface/Structs/RejitData.cs
        /// </summary>
        [Record(TableId), StructLayout(LayoutKind.Sequential)]
        public struct RejitInfo : IRecord<RejitInfo>
        {
            public const string TableId = "diagnostic.rejit";

            public MemoryAddress RejitID;

            public uint Flags;

            public MemoryAddress NativeCodeAddr;
        }
    }
}
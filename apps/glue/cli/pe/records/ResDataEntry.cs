//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.InteropServices;

    partial struct PeRecords
    {
        /// <summary>
        /// Each Resource Data entry describes an actual unit of raw data in the Resource Data area.
        /// </summary>
        [Record(TableId), StructLayout(LayoutKind.Sequential)]
        public struct ResDataEntry : IRecord<ResDataEntry>
        {
            public const string TableId = "pe.res-data-entry";

            /// <summary>
            /// The address of a unit of resource data in the Resource Data area.
            /// </summary>
            public Address32 RvaToData;

            /// <summary>
            /// The size, in bytes, of the resource data that is pointed to by the Data RVA field.
            /// </summary>
            public uint Size;

            /// <summary>
            /// The code page that is used to decode code point values within the resource data. Typically, the code page would be the Unicode code page.
            /// </summary>
            public uint CodePage;

            /// <summary>
            /// Reserved; must be 0
            /// </summary>
            public uint Reserved;
        }
    }
}
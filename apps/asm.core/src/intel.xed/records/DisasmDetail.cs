//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedRecords
    {
        [StructLayout(LayoutKind.Sequential, Pack=1)]
        public struct DisasmDetail
        {
            public uint Seq;

            public Hex64 Id;
        }
    }
}
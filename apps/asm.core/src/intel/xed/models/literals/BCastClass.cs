//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
// Source      : all-state.txt
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        public enum BCastClass : byte
        {
            None = 0,

            BCast8 = 1,

            BCast16 = 16,

            BCast32 = 32,

            BCast64 = 64
        }
    }
}
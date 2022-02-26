//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
// Sources     : all-map-descriptions.txt
//-----------------------------------------------------------------------------
namespace Z0
{
    using OCP = XedModels.OcPatternNames;

    partial struct XedModels
    {
        [SymSource(xed)]
        public enum XopMapKind : byte
        {
            [Symbol("amd-xop8", OCP.XopPattern8)]
            XOP8=8,

            [Symbol("amd-xop9", OCP.XopPattern9)]
            XOP9=9,

            [Symbol("amd-xopA", OCP.XopPatternA)]
            XOPA=10,
        }
    }
}
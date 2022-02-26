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
        public enum OpCodeClass : byte
        {
            None = 0,

            [Symbol(OCP.LegacyMapClass)]
            LEGACY = 1,

            [Symbol(OCP.XopMapClass)]
            XOP = 2,

            [Symbol(OCP.VexMapClass)]
            VEX = 4,

            [Symbol(OCP.EvexMapClass)]
            EVEX = 8,
        }
    }
}
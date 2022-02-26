//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
// Source      : all-fields.txt
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        [SymSource(xed)]
        public enum HintKind : byte
        {
            None = 0,

            CsUntaken = 1,

            DsTaken = 2,

            ValidatedUntaken = 3,

            ValidatedTaken = 4
        }
    }
}
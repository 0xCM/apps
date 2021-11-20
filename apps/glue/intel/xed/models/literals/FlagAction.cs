//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
// Source      : xed-extension-enum.h
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        /// <summary>
        /// xed-flag-action-enum.h
        /// </summary>
        [SymSource(xed)]
        public enum FlagAction
        {
            [Symbol("u", "undefined (treated as a write)")]
            FLAG_ACTION_u,

            [Symbol("tst", "test (read)")]
            FLAG_ACTION_tst,

            [Symbol("mod", "modification (write)")]
            FLAG_ACTION_mod,

            [Symbol("0", "value will be zero (write)")]
            FLAG_ACTION_0,

            [Symbol("pop", "value comes from the stack (write)")]
            FLAG_ACTION_pop,

            [Symbol("ah", "value comes from AH (write)")]
            FLAG_ACTION_ah,

            [Symbol("1", "value will be 1 (write)")]
            FLAG_ACTION_1,
        }
    }
}
//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
// Source      : xed-reg-class.h
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    partial struct XedModels
    {
        /// <summary>
        /// Mirrors the content of xed-pointer-width.txt data file
        /// </summary>
        [SymSource(xed), Flags]
        public enum PointerWidth
        {
            None = 0,

            [Symbol("b")]
            Byte = 1,

            [Symbol("w")]
            Word = 2,

            [Symbol("l")]
            DWord = 4,

            [Symbol("q")]
            QWord = 8,

            [Symbol("x")]
            XmmWord = 16,

            [Symbol("y")]
            YmmWord = 32,

            [Symbol("z")]
            ZmmWord = 64
        }
    }
}
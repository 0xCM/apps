//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    public enum LangKind : byte
    {
        None = 0,

        Asm,

        C,

        Cpp,

        Cs
    }

    public class LangTypeAttribute : Attribute
    {
        public LangTypeAttribute(LangKind kind)
        {
            Lang = kind;
        }

        public LangKind Lang {get;}
    }
}
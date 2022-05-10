//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct SdmModels
    {
        public readonly struct InstructionDoc
        {
            public Index<DocSection> Sections {get;}
        }

        public struct DocSection
        {
            public CharBlock8 Name;

            public TextBlock Content;
        }
    }
}
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
        public readonly struct ModRmRule : IEncodingRule<ModRmRule,ModRmEncKind>
        {
            public ModRmEncKind Kind {get;}

            [MethodImpl(Inline)]
            public ModRmRule(ModRmEncKind kind)
            {
                Kind = kind;
            }

            public EncodingClass Class
                => EncodingClass.ModRm;
        }
    }
}
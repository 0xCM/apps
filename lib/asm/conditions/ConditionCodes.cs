//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;

    public readonly partial struct ConditionCodes
    {
        public readonly struct ConditionFacets
        {
            public const byte ConditionCount = 16;

            public const byte Jcc8Base = 0x70;

            public const byte Jcc32Base = 0x80;
        }


        public sealed class ConditionTokenSet : TokenSet<ConditionTokenSet>
        {
            public override string Name
                => "asm.cc";

            public override Type[] Types()
                => typeof(ConditionCodes).GetNestedTypes().Enums().Tagged<SymSourceAttribute>();
        }
    }
}
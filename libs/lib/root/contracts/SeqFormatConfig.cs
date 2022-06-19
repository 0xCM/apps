//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static CharText;

    public readonly struct SeqFormatConfig : ISeqFormatSpec<SeqFormatConfig>
    {
        [MethodImpl(Inline), Op]
        public static SeqFormatConfig define(string delimiter = Comma)
            => new SeqFormatConfig(delimiter);

        public string Delimiter {get;}

        [MethodImpl(Inline)]
        public SeqFormatConfig(string delimiter)
            => Delimiter = delimiter;
    }
}
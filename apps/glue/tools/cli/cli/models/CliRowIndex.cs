//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public struct CliRowIndex : IRecord<CliRowIndex>
    {
        public CliToken Token {get;}

        public CliTableKind Table
        {
            [MethodImpl(Inline)]
            get  => Token.Table;
        }

        public uint RowId
        {
            [MethodImpl(Inline)]
            get => Token.Row;
        }

        [MethodImpl(Inline)]
        public CliRowIndex(CliToken token)
        {
            Token = token;
        }

        public static CliRowIndex Empty
        {
            [MethodImpl(Inline)]
            get => new CliRowIndex(CliToken.Empty);
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Token.IsEmpty;
        }

        [MethodImpl(Inline)]
        public static implicit operator CliRowIndex(CliToken src)
            => new CliRowIndex(src);
    }
}
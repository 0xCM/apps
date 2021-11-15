//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct TableColumn
    {
        public string Name {get;}

        public string Type {get;}

        public ushort ColWidth {get;}

        [MethodImpl(Inline)]
        public TableColumn(string name, string type, ushort width)
        {
            Name = name;
            Type = type;
            ColWidth = width;
        }

        public string Format()
            => string.Format(RP.pad(-(int)ColWidth), Name);

        public override string ToString()
            => Format();
    }
}
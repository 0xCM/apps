//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    using static Root;

    [StructLayout(LayoutKind.Sequential)]
    public readonly struct PrimalCellType
    {
        public uint ContentWidth {get;}

        public uint StorageWidth {get;}

        public ClrPrimitiveKind Kind {get;}

        [MethodImpl(Inline)]
        public PrimalCellType(uint content, uint storage, ClrPrimitiveKind @class)
        {
            ContentWidth = content;
            StorageWidth = storage;
            Kind = @class;
        }

        public static PrimalCellType Empty => default;

        public string Format()
            => CellTypes.format(this);

        public override string ToString()
            => Format();
    }
}
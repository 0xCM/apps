//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    using static Root;

    /// <summary>
    /// Identifies a rectangular region within a table
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct TableRegion : IDataTypeComparable<TableRegion>, IHashed
    {
        /// <summary>
        /// The top-left cell
        /// </summary>
        public CellIndex Min {get;}

        /// <summary>
        /// The bottom-right cell
        /// </summary>
        public CellIndex Max {get;}

        [MethodImpl(Inline)]
        public TableRegion(CellIndex min, CellIndex max)
        {
            Min = min;
            Max = max;
        }

        [MethodImpl(Inline)]
        public static implicit operator TableRegion((CellIndex ul, CellIndex lr) src)
            => new TableRegion(src.ul, src.lr);

        public string Format()
            => string.Format("[{0}..{1}]", Min, Max);

        public override string ToString()
            => Format();

        public uint Hash
        {
            [MethodImpl(Inline)]
            get => FastHash.combine(Min.Hash, Max.Hash);
        }

        public override int GetHashCode()
            => (int)Hash;

        [MethodImpl(Inline)]
        public bool Equals(TableRegion src)
            => Min == src.Min && Max == src.Max;

        public override bool Equals(object src)
            => src is CellIndex x && Equals(src);

        [MethodImpl(Inline)]
        public int CompareTo(TableRegion src)
            => Min == src.Min ? Max.CompareTo(src.Max) : Min.CompareTo(src.Min);

        [MethodImpl(Inline)]
        public static bool operator ==(TableRegion a, TableRegion b)
            => a.Equals(b);

        [MethodImpl(Inline)]
        public static bool operator !=(TableRegion a, TableRegion b)
            => a.Equals(b);

        public static CellIndex Zero => default;

        public static CellIndex Empty
            => new CellIndex(uint.MaxValue, uint.MaxValue);
    }
}
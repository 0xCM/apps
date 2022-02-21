//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct NativeVectorType : INativeType<NativeVectorType>
    {
        [MethodImpl(Inline)]
        public static NativeVectorType define(NativeCellType ct, byte count)
            => new NativeVectorType(ct,count);

        readonly ushort Data;

        [MethodImpl(Inline)]
        public NativeVectorType(NativeCellType type, byte count)
        {
            Data = (ushort)(core.@as<NativeCellType,ushort>(type) | ((ushort)count << 8));
        }

        public NativeCellType CellType
        {
            [MethodImpl(Inline)]
            get => core.@as<ushort,NativeCellType>(Data);
        }

        public ScalarClass CellClass
        {
            [MethodImpl(Inline)]
            get => CellType.Class;
        }

        public NativeSize CellSize
        {
            [MethodImpl(Inline)]
            get => CellType.Size;
        }

        public byte CellCount
        {
            [MethodImpl(Inline)]
            get => (byte)(Data >> 8);
        }

        public NativeSize Size
        {
            [MethodImpl(Inline)]
            get => Sizes.native(CellSize.Width * CellCount);
        }

        public BitWidth Width
        {
            [MethodImpl(Inline)]
            get => Size.Width;
        }

        [MethodImpl(Inline)]
        public bool Equals(NativeVectorType src)
            => Data == src.Data;

        [MethodImpl(Inline)]
        public override int GetHashCode()
            => Data;

        public override bool Equals(object src)
            => src is NativeVectorType t && Equals(t);

        public string Format()
            => NativeTypes.format(this);

        public override string ToString()
            => Format();

        public static implicit operator NativeVectorType((NativeCellType type, uint count) src)
            => new NativeVectorType(src.type, (byte)src.count);
    }
}
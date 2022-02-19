//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct NativeType : INativeType<NativeType>
    {
        [MethodImpl(Inline)]
        public static NativeType cell(NativeSize size, ScalarClass @class)
            => new NativeType(NativeCellType.define(size,@class));

        [MethodImpl(Inline)]
        public static NativeType vector(NativeCellType cellType, byte cellCount)
            => new NativeType(NativeVectorType.define(cellType, cellCount));

        readonly ushort Data;

        [MethodImpl(Inline)]
        internal NativeType(NativeCellType src)
        {
            Data = core.@as<NativeCellType,byte>(src);
        }

        [MethodImpl(Inline)]
        internal NativeType(NativeVectorType src)
        {
            Data = core.@as<NativeVectorType,byte>(src);
        }

        public bool IsCellType
        {
            [MethodImpl(Inline)]
            get => (Data & 0xFF) == 0;
        }

        public bool IsVectorType
        {
            [MethodImpl(Inline)]
            get => (Data & 0xFF) != 0;
        }

        public NativeSize Size
        {
            [MethodImpl(Inline)]
            get => IsCellType ? AsCellType().Size : AsVectorType().Size;
        }

        [MethodImpl(Inline)]
        public NativeVectorType AsVectorType()
            => core.@as<NativeType,NativeVectorType>(this);

        [MethodImpl(Inline)]
        public NativeCellType AsCellType()
            => core.@as<NativeType,NativeCellType>(this);

        [MethodImpl(Inline)]
        public bool Equals(NativeType src)
            => Data == src.Data;

        [MethodImpl(Inline)]
        public override int GetHashCode()
            => Data;

        public override bool Equals(object src)
            => src is NativeType t && Equals(t);

        [MethodImpl(Inline)]
        public static implicit operator NativeType(NativeCellType src)
            => new NativeType(src);

        [MethodImpl(Inline)]
        public static implicit operator NativeType(NativeVectorType src)
            => new NativeType(src);
    }
}
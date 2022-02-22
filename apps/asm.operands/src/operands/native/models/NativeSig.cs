//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public struct NativeSig
    {
        const uint StringSize = 16;

        const uint OpCountSize = 1;

        const uint OpCountOffset = 0;

        const uint TypeSize = 2;

        const uint ScopeSize = StringSize;

        const uint NameSize = StringSize;

        const uint OperandSize = NativeOperand.StorageSize;

        const uint ReturnSize = OperandSize;

        const uint ScopeOffset = OpCountOffset + OpCountSize;

        const uint NameOffset = ScopeOffset + ScopeSize;

        const uint ReturnOffset = NameOffset + NameSize;

        const uint OperandsOffset = ReturnOffset + ReturnSize;

        public readonly Hex64 Id;

        readonly MemorySeg DataRef;

        [MethodImpl(Inline)]
        public NativeSig(Hex64 id, MemorySeg data)
        {
            Id = id;
            DataRef = data;
        }

        readonly Span<byte> Data
        {
            [MethodImpl(Inline)]
            get => DataRef.Edit;
        }

        public ref byte OperandCount
        {
            [MethodImpl(Inline)]
            get =>  ref first(Data);
        }

        public ref StringRef Scope
        {
            [MethodImpl(Inline)]
            get => ref @as<StringRef>(seek(Data,ScopeOffset));
        }

        public ref StringRef Name
        {
            [MethodImpl(Inline)]
            get => ref @as<StringRef>(seek(Data,NameOffset));
        }

        public ref NativeOperand Return
        {
            [MethodImpl(Inline)]
            get => ref @as<NativeOperand>(seek(Data,ReturnOffset));
        }

        public Span<NativeOperand> Operands
        {
            [MethodImpl(Inline)]
            get => recover<NativeOperand>(slice(Data,OperandsOffset, OperandCount*OperandSize));
        }

        public ref NativeOperand this[uint i]
        {
            [MethodImpl(Inline)]
            get => ref seek(Operands,i);
        }

        public ref NativeOperand this[int i]
        {
            [MethodImpl(Inline)]
            get => ref seek(Operands,i);
        }

        public string Format()
            => NativeSigs.format(this);

        public string Format(SigFormatStyle style)
            => NativeSigs.format(this, style);

        public override string ToString()
            => Format();
    }
}
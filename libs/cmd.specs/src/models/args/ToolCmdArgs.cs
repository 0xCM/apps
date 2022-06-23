//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct ToolCmdArgs : IIndex<ToolCmdArg>
    {
        readonly Index<ToolCmdArg> Data;

        [MethodImpl(Inline)]
        public ToolCmdArgs(ToolCmdArg[] src)
            => Data = src;

        public ref ToolCmdArg this[int index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        public ref ToolCmdArg this[uint index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        public ToolCmdArg[] Storage
        {
            [MethodImpl(Inline)]
            get => Data.Storage;
        }

        public Span<ToolCmdArg> Terms
        {
            [MethodImpl(Inline)]
            get => Data.Storage;
        }

        public uint Count
        {
            [MethodImpl(Inline)]
            get => (uint)Data.Length;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Data.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Data.IsNonEmpty;
        }

        public string Format()
        {
            var dst = text.emitter();
            for(var i=0; i<Data.Count; i++)
                dst.Append($"{Data[i].Format()} ");
            return dst.Emit();
        }

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator ToolCmdArgs(ToolCmdArg[] src)
            => new ToolCmdArgs(src);

        public static ToolCmdArgs Empty
        {
            [MethodImpl(Inline)]
            get => new ToolCmdArgs(sys.empty<ToolCmdArg>());
        }
    }
}
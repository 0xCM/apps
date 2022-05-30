//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct Cmd
    {
        public static string format<K,T>(in ToolCmdArgs<K,T> src)
            where K : unmanaged
        {
            var dst = text.buffer();
            var view = src.View;
            var count = view.Length;
            for(var i=0; i<count; i++)
                dst.AppendLine(skip(src,i).Format());
            return dst.Emit();
        }
    }

    public readonly struct ToolCmdArgs<K,T> : IIndex<ToolCmdArg<K,T>>
        where K : unmanaged
    {
        readonly Index<ToolCmdArg<K,T>> Data;

        [MethodImpl(Inline)]
        public ToolCmdArgs(ToolCmdArg<K,T>[] src)
            => Data = src;

        public ReadOnlySpan<ToolCmdArg<K,T>> View
        {
            [MethodImpl(Inline)]
            get => Data.View;
        }

        public ToolCmdArg<K,T>[] Storage
        {
            [MethodImpl(Inline)]
            get => Data.Storage;
        }

        public ref ToolCmdArg<K,T> this[uint index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        public string Format()
            => Cmd.format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator ToolCmdArgs<K,T>(ToolCmdArg<K,T>[] src)
            => new ToolCmdArgs<K,T>(src);

        [MethodImpl(Inline)]
        public static implicit operator ToolCmdArgs(ToolCmdArgs<K,T> src)
            => new ToolCmdArgs(src.Storage.Select(x => (ToolCmdArg)x));
    }
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    using static Root;

    [Record(TableId), StructLayout(LayoutKind.Sequential, Pack=1)]
    public readonly struct LlvmListItem
    {
        public const string TableId = "llvm.lists";

        public readonly uint Key;

        public readonly string Value;

        [MethodImpl(Inline)]
        public LlvmListItem(uint key, string content)
        {
            Key = key;
            Value = content;
        }

        public string Format()
            => string.Format("{0,-8} | {1}", Key, Value);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator LlvmListItem((uint key, string content) src)
            => new LlvmListItem(src.key, src.content);
    }
}
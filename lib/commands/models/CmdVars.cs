//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct CmdVars : IIndex<CmdVar>
    {
        readonly Index<CmdVar> Data;

        [MethodImpl(Inline)]
        public CmdVars(CmdVar[] src)
        {
            Data = src;
        }

        public uint NonEmptyCount()
            => Data.Where(x => x.IsNonEmpty).Count;
        public uint Count
        {
            [MethodImpl(Inline)]
            get => Data.Count;
        }

        public int Length
        {
            [MethodImpl(Inline)]
            get => Data.Length;
        }

        public ref CmdVar this[long index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        public ref CmdVar this[ulong index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        public CmdVar[] Storage
        {
            [MethodImpl(Inline)]
            get => Data.Storage;
        }

        public string Format()
        {
            var dst = text.buffer();
            var count = Data.Count;
            for(var i=0; i<count; i++)
            {
                ref readonly var item = ref this[i];
                if(item.IsNonEmpty)
                    dst.AppendLineFormat("set {0}={1}", item.Name, item.Value);
            }
            return dst.Emit();
        }

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator CmdVars(CmdVar[] src)
            => new CmdVars(src);

        [MethodImpl(Inline)]
        public static implicit operator CmdVar[](CmdVars src)
            => src.Storage;

        public static CmdVars Empty
        {
            [MethodImpl(Inline)]
            get => core.array<CmdVar>();
        }
    }
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    public readonly struct CmdArgs : IIndex<CmdArg>
    {
        readonly Index<CmdArg> Data;

        [MethodImpl(Inline)]
        public CmdArgs(CmdArg[] src)
        {
            Data = src;
        }

        public uint Count
        {
            [MethodImpl(Inline)]
            get => Data.Count;
        }

        public ref CmdArg this[ushort i]
        {
            [MethodImpl(Inline)]
            get => ref Data[i];
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

        public int Length
        {
            [MethodImpl(Inline)]
            get => Data.Length;
        }

        public ref CmdArg First
        {
            [MethodImpl(Inline)]
            get => ref Data.First;
        }
        public Span<CmdArg> Edit
        {
            [MethodImpl(Inline)]
            get => Data.Edit;
        }

        public CmdArg[] Storage
        {
            [MethodImpl(Inline)]
            get => Data.Storage;
        }

        public ReadOnlySpan<CmdArg> View
        {
            [MethodImpl(Inline)]
            get => Data.View;
        }


        [MethodImpl(Inline)]
        public static implicit operator CmdArgs(CmdArg[] src)
            => new CmdArgs(src);

        public static CmdArgs Empty
        {
            [MethodImpl(Inline)]
            get => new CmdArgs(core.array<CmdArg>());
        }

        public string Format()
        {
            var args = View;
            var count = args.Length;
            if(count > 0)
            {
                var dst = text.buffer();
                for(var i=0; i<count; i++)
                {
                    dst.Append(skip(args,i).Value);
                    if(i != count - 1)
                        dst.Append(Chars.Space);
                }
                return dst.Emit();
            }
            else
            {
                return EmptyString;
            }
        }

        public override string ToString()
            => Format();
    }
}
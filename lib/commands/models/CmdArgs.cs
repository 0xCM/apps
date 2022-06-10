//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public readonly struct CmdArgs : IIndex<CmdArg>
    {
        const NumericKind Closure = UnsignedInts;

        [MethodImpl(Inline), Op]
        public static CmdArgDef<T> def<T>(string name, T value, ArgPrefix prefix)
            => new CmdArgDef<T>(name, value, prefix);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static CmdArgDef<T> def<T>(ushort pos, T value, ArgPrefix prefix)
            => new CmdArgDef<T>(pos, value.ToString(), value, prefix);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static CmdArgDef<T> def<T>(ushort pos, string name, T value, ArgPrefix prefix)
            => new CmdArgDef<T>(pos, name, value, prefix);

        public static CmdArgs args(ReadOnlySpan<string> src)
        {
            var dst = alloc<CmdArg>(src.Length);
            for(ushort i=0; i<src.Length; i++)
                seek(dst,i) = new CmdArg(skip(src,i));
            return dst;
        }


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
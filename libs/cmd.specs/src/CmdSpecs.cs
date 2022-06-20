//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    [ApiHost]
    public class CmdSpecs
    {
        const NumericKind Closure = UnsignedInts;

        public static ReadOnlySpan<CmdOption> options(FS.FilePath src)
        {
            var dst = list<CmdOption>();
            using var reader = src.Utf8LineReader();
            while(reader.Next(out var line))
            {
                if(line.IsNonEmpty)
                {
                    ref readonly var content = ref line.Content;
                    if(parse(content, out var option))
                        dst.Add(option);
                }
            }
            return dst.ViewDeposited();
        }

        [Parser]
        public static Outcome parse(string src, out CmdOption dst)
        {
            const char Delimiter = Chars.Colon;

            dst = CmdOption.Empty;
            if(empty(src))
                return (false,RP.Empty);
            var i = text.index(src, Delimiter);
            if(i>0)
                dst = new CmdOption(text.left(src,i).Trim(), text.right(src,i).Trim());
            else
                dst = new CmdOption(src.Trim());
            return true;
        }

        /// <summary>
        /// Creates an option without purpose
        /// </summary>
        /// <param name="name">The option name</param>
        [MethodImpl(Inline), Factory]
        public static CmdOption option(string name)
            => new CmdOption(name);

        /// <summary>
        /// Creates a meaningful option
        /// </summary>
        /// <param name="name">The option name</param>
        /// <param name="value">What does it do?</param>
        [MethodImpl(Inline), Factory]
        public static CmdOption option(string name, string value)
            => new CmdOption(name, value);

        [MethodImpl(Inline)]
        public static CmdJob<T> job<T>(string name, T spec)
            where T : struct
                => new CmdJob<T>(name, spec);

        [MethodImpl(Inline), Op]
        public static CmdFlag disable(in CmdFlagSpec flag)
            => new CmdFlag(flag.Name, bit.Off);

        [MethodImpl(Inline), Op]
        public static CmdFlag enable(in CmdFlagSpec flag)
            => new CmdFlag(flag.Name, bit.On);

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

        public static string format(in CmdSpec src)
        {
            if(src.IsEmpty)
                return EmptyString;

            var dst = text.buffer();
            dst.Append(src.Name);
            var count = src.Args.Length;
            for(ushort i=0; i<count; i++)
            {
                ref readonly var arg = ref src.Args[i];
                if(nonempty(arg.Name))
                {
                    dst.Append(Chars.Space);
                    dst.Append(arg.Name);
                }

                if(nonempty(arg.Value))
                {
                    dst.Append(Chars.Space);
                    dst.Append(arg.Value);
                }
            }
            return dst.Emit();
        }

        [Op, MethodImpl(Inline)]
        public static CmdSpec from(string name, CmdArgs args)
            => new CmdSpec(name, args);

        [Op]
        public static CmdSpec from(ReadOnlySpan<char> src)
        {
            var i = SQ.index(src, Chars.Space);
            if(i < 0)
                return new CmdSpec(text.format(src), CmdArgs.Empty);
            else
            {
                var name = text.format(text.left(src,i));
                var _args = text.format(text.right(src,i)).Split(Chars.Space);
                return new CmdSpec(name, args(_args));
            }
        }
    }
}
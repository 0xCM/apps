//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    [ApiHost]
    public class Cmd
    {
        const NumericKind Closure = UnsignedInts;

        /// <summary>
        /// Defines a <see cref='CmdResult'/>
        /// </summary>
        /// <param name="cmd">The completed command</param>
        /// <param name="ok">Whether the command succeeded</param>
        [MethodImpl(Inline), Op]
        public static CmdResult result(ICmd cmd, bool ok)
            => new CmdResult(cmd.CmdId, ok);

        /// <summary>
        /// Defines a <see cref='CmdResult'/>
        /// </summary>
        /// <param name="cmd">The completed command</param>
        /// <param name="ok">Whether the command succeeded</param>
        [MethodImpl(Inline), Op]
        public static CmdResult result(ICmd cmd, bool ok, dynamic payload)
            => new CmdResult(cmd.CmdId, ok, payload);

        /// <summary>
        /// Defines a <see cref='CmdResult{C}'/>
        /// </summary>
        /// <param name="cmd">The completed command</param>
        /// <param name="ok">Whether the command succeeded</param>
        /// <typeparam name="C">The command type</typeparam>
        [MethodImpl(Inline), Op]
        public static CmdResult<C> result<C>(C cmd, bool ok)
            where C : struct, ICmd<C>
                => new CmdResult<C>(cmd, ok);

        /// <summary>
        /// Defines a <see cref='CmdResult{C}'/>
        /// </summary>
        /// <param name="cmd">The completed command</param>
        /// <param name="ok">Whether the command succeeded</param>
        /// <typeparam name="C">The command type</typeparam>
        [MethodImpl(Inline), Op]
        public static CmdResult<C> result<C>(C cmd, bool ok, dynamic payload)
            where C : struct, ICmd<C>
                => new CmdResult<C>(cmd, ok, payload);

        /// <summary>
        /// Defines a <see cref='CmdResult{C,P}'/>
        /// </summary>
        /// <param name="cmd">The completed command</param>
        /// <param name="payload"></param>
        /// <param name="ok">Whether the command succeeded</param>
        /// <typeparam name="C">The command type</typeparam>
        /// <typeparam name="P">The payload type</typeparam>
        [MethodImpl(Inline), Op]
        public static CmdResult<C,P> result<C,P>(C cmd, bool ok, P payload, string msg = EmptyString)
            where C : struct, ICmd<C>
                => new CmdResult<C,P>(cmd, ok, payload, msg);

        [MethodImpl(Inline)]
        public static CmdResult<C> ok<C>(C spec)
            where C : struct, ICmd
                => new CmdResult<C>(spec, true);

        [MethodImpl(Inline)]
        public static CmdResult<C> ok<C>(C spec, string msg)
            where C : struct, ICmd
                => new CmdResult<C>(spec, true, msg);

        [MethodImpl(Inline)]
        public static CmdResult<C,P> ok<C,P>(C spec, P payload, string msg = EmptyString)
            where C : struct, ICmd
                => new CmdResult<C,P>(spec, true, payload, msg);

        [MethodImpl(Inline), Op]
        public static CmdResult fail(ICmd cmd)
            => new CmdResult(cmd.CmdId, false);

        [MethodImpl(Inline), Op]
        public static CmdResult fail(ICmd cmd, Exception e)
            => new CmdResult(cmd.CmdId, e);

        public static CmdResult<C> fail<C>(C cmd)
            where C : struct, ICmd
                => new CmdResult<C>(cmd, false);

        public static CmdResult<C> fail<C>(C cmd, Exception e)
            where C : struct, ICmd
                => new CmdResult<C>(cmd, e);

        public static CmdResult<C> fail<C>(C cmd, string message)
            where C : struct, ICmd
                => new CmdResult<C>(cmd, false, message);

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
        /// Creates a meaningful option
        /// </summary>
        /// <param name="name">The option name</param>
        /// <param name="value">What does it do?</param>
        [MethodImpl(Inline), Op]
        public static CmdOption option(string name, string value)
            => new CmdOption(name, value);

        [MethodImpl(Inline)]
        public static CmdJob<T> job<T>(string name, T spec)
            where T : struct
                => new CmdJob<T>(name, spec);

        [MethodImpl(Inline), Op]
        public static CmdArgDef<T> def<T>(string name, T value, ArgPrefix prefix)
            => new CmdArgDef<T>(name, value, prefix);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static CmdArgDef<T> def<T>(ushort pos, T value, ArgPrefix prefix)
            => new CmdArgDef<T>(pos, value.ToString(), value, prefix);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static CmdArgDef<T> def<T>(ushort pos, string name, T value, ArgPrefix prefix)
            => new CmdArgDef<T>(pos, name, value, prefix);

        [MethodImpl(Inline), Op]
        public static CmdOption option(string name)
            => new CmdOption(name);

        // public static CmdArgs args(ReadOnlySpan<string> src)
        // {
        //     var dst = alloc<CmdArg>(src.Length);
        //     for(ushort i=0; i<src.Length; i++)
        //         seek(dst,i) = new CmdArg(skip(src,i));
        //     return dst;
        // }
    }
}
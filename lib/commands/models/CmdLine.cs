//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    [Free]
    public interface ICmdLineTool<T,C>
        where T : new()
        where C : IToolCmd
    {
        CmdLine CmdLine(in C src);
    }

    /// <summary>
    /// Captures the content of a command-line
    /// </summary>
    public readonly struct CmdLine
    {
        [MethodImpl(Inline), Op]
        public static CmdLine create(params string[] src)
            => new CmdLine(src);

        readonly Index<string> Data;

        [MethodImpl(Inline)]
        public CmdLine(params string[] content)
            => Data = content;

        public ReadOnlySpan<CmdLinePart> Parts
        {
            [MethodImpl(Inline)]
            get => recover<string,CmdLinePart>(Data.Edit);
        }

        [MethodImpl(Inline)]
        public string Format()
            => text.delimit(Data.View, Chars.Space, 0);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator CmdLine(string src)
            => new CmdLine(src);

        [MethodImpl(Inline)]
        public static implicit operator CmdLine(string[] src)
            => new CmdLine(src);

        [MethodImpl(Inline)]
        public static implicit operator string(CmdLine src)
            => src.Format();

        public static CmdLine Empty
        {
            [MethodImpl(Inline)]
            get => new CmdLine(sys.empty<string>());
        }
    }
}
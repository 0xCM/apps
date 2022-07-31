//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Spans;
    using static Arrays;
    using static Algs;

    [ApiHost]
    public partial class Cmd
    {
        const NumericKind Closure = UnsignedInts;

         public static string format<T>(ICmd<T> src)
            where T : struct, ICmd<T>
        {
            var buffer = text.emitter();
            buffer.AppendFormat("{0}{1}", src.CmdId, Chars.LParen);

            var fields = ClrFields.instance(typeof(T));
            if(fields.Length != 0)
                render(__makeref(src), fields, buffer);

            buffer.Append(Chars.RParen);
            return buffer.Emit();
        }

        public static void render(TypedReference src, ReadOnlySpan<ClrFieldAdapter> fields, ITextEmitter dst)
        {
            var count = fields.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var field = ref skip(fields,i);
                dst.AppendFormat(RP.Assign, field.Name, field.GetValueDirect(src));
                if(i != count - 1)
                    dst.Append(", ");
            }
        }

        /// <summary>
        /// Creates a <see cref='CmdLine'/> that represents 'cmd.exe /c '<paramref name='spec'/>'
        /// </summary>
        /// <param name="spec">The command to execute</param>
        public static CmdLine cmd(string spec)
            => string.Format("cmd.exe /c {0}", spec);

        /// <summary>
        /// Creates a <see cref='CmdLine'/> that represents 'pwsh.exe /c '<paramref name='spec'/>'
        /// </summary>
        /// <param name="spec">The command to execute</param>
        public static CmdLine pwsh(string spec)
            => string.Format("pwsh.exe {0}", spec);

        [Op, MethodImpl(Inline)]
        public static ShellCmdSpec shell(string name, CmdArgs args)
            => new ShellCmdSpec(name, args);

        public static CmdArg arg(CmdArgs src, int index)
        {
            if(src.IsEmpty)
                sys.@throw(EmptyArgList.Format());

            var count = src.Count;
            if(count < index - 1)
                sys.@throw(ArgSpecError.Format());
            return src[(ushort)index];
        }

        public static CmdArgs args(ReadOnlySpan<string> src)
        {
            var dst = sys.alloc<CmdArg>(src.Length);
            for(ushort i=0; i<src.Length; i++)
                seek(dst,i) = new CmdArg(skip(src,i));
            return CmdArgs.create(dst);
        }

        public static string format(ShellCmdSpec src)
        {
            if(src.IsEmpty)
                return EmptyString;

            var dst = text.buffer();
            dst.Append(src.Name);
            var count = src.Args.Count;
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

        [MethodImpl(Inline), Op]
        public static CmdFlagSpec flag(string name, string desc)
            => new CmdFlagSpec(name, desc);

        public static Index<CmdFlagSpec> flags(FS.FilePath src)
        {
            var k = z16;
            var dst = list<CmdFlagSpec>();
            using var reader = src.AsciLineReader();
            while(reader.Next(out var line))
            {
                var content = line.Codes;
                var i = SQ.index(content, AsciCode.Colon);
                if(i == NotFound)
                    continue;

                var name = text.trim(Asci.format(SQ.left(content,i)));
                var desc = text.trim(Asci.format(SQ.right(content,i)));
                dst.Add(flag(name, desc));
            }
            return dst.ToArray();
        }

        [MethodImpl(Inline), Op]
        public static CmdVarInfo varinfo(Name name, TextBlock purpose)
            => new (name,purpose);

        public static CmdActions actions<T>(T src)
        {
            var dst = dict<string,IActionRunner>();
            var methods = typeof(T).DeclaredInstanceMethods().Where(x => x.Tagged<CmdOpAttribute>());
            foreach(var m in methods)
            {
                var tag = m.Tag<CmdOpAttribute>().Require();
                dst.TryAdd(tag.CommandName, new ActionRunner(tag.CommandName, src, m));
            }
            return new CmdActions(dst);
        }

        public static CmdSource source<S>(S provider, IDispatcher src)
            where S : ICmdProvider, new()
        {
            var specs = src.Commands.Specs.Index().Sort().Index();
            var part = src.Controller;
            var count = specs.Count;
            var buffer = sys.alloc<Setting64>(count);
            var dst = Settings.from(buffer);
            for(var i=0; i<specs.Count; i++)
                seek(buffer,i) = Settings.setting(string.Format("{0}[{1:D3}]", part, i), (asci64)specs[i]);
            return new CmdSource(provider.Name, dst);
        }

        public static CmdCatalog catalog(IDispatcher src)
        {
            ref readonly var defs = ref src.Commands.Defs;
            var count = defs.Count;
            var dst = sys.alloc<CmdUri>(count);
            for(var i=0; i<count; i++)
                seek(dst,i) = defs[i].Uri;
            return new CmdCatalog(dst);
        }

        public static SettingLookup<Name,asci64> commands(IDispatcher src)
        {
            var actions = src.Commands.Specs.Index().Sort().Index();
            var part = src.Controller;
            var count = actions.Count;
            var dst = sys.alloc<Setting<Name,asci64>>(count);
            var settings = Settings.asci(dst);
            for(var i=0; i<actions.Count; i++)
                seek(dst,i) = Settings.asci(string.Format("{0}[{1:D3}]", part, i), (asci64)actions[i]);
            return Settings.asci(dst);
        }

        [MethodImpl(Inline)]
        public static DataFlow<Actor,S,T> flow<S,T>(Tool tool, S src, T dst)
            => new DataFlow<Actor,S,T>(FlowId.identify(tool,src,dst), tool,src,dst);

        [MethodImpl(Inline)]
        public static FileFlow flow(in CmdFlow src)
            => new FileFlow(flow(src.Tool, src.SourcePath.ToUri(), src.TargetPath.ToUri()));

        public static void parse(ReadOnlySpan<TextLine> src, out ReadOnlySpan<CmdFlow> dst)
        {
            dst = flows(src);
        }

        public static ReadOnlySpan<CmdFlow> flows(ReadOnlySpan<TextLine> src)
        {
            var count = src.Length;
            var counter = 0u;
            var dst = span<CmdFlow>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var line = ref skip(src,i);
                if(line.IsEmpty)
                    continue;

                var content = line.Content;
                var j = text.index(content, Chars.Colon);
                if(j >= 0)
                {
                    Tool tool = text.left(content, j);
                    var flow = Fenced.unfence(text.right(content,j), Fenced.Bracketed);

                    j = text.index(flow, "--");
                    if(j == NotFound)
                        j = text.index(flow, "->");

                    if(j>=0)
                    {
                        var a = text.left(flow,j).Trim();
                        var b = text.right(flow,j+2).Trim();
                        if(nonempty(a) && nonempty(b))
                            seek(dst,counter++) = new CmdFlow(tool, FS.path(a), FS.path(b));
                    }
                }
            }

            return slice(dst,0,counter);
        }

        public static Index<ICmdReactor> reactors(IWfRuntime wf)
        {
            var types = wf.Components.Types();
            var reactors = types.Concrete().Tagged<CmdReactorAttribute>().Select(t => (ICmdReactor)Activator.CreateInstance(t));
            iter(reactors, r => r.Init(wf));
            return reactors;
        }

        [Op]
        public static ActionRunner runner(string name, object host, MethodInfo method)
            => new ActionRunner(name,host,method);

        [Op]
        public static Index<ActionRunner> runners(object host)
        {
            var methods = host.GetType().Methods().Tagged<CmdOpAttribute>();
            var buffer = sys.alloc<ActionRunner>(methods.Length);
            runners(host, methods,buffer);
            return buffer;
        }

        static void runners(object host, ReadOnlySpan<MethodInfo> src, Span<ActionRunner> dst)
        {
            var count = src.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var method = ref skip(src,i);
                var tag = method.Tag<CmdOpAttribute>().Require();
                seek(dst,i) = runner(tag.CommandName, host, method);
            }
        }

        static MsgPattern EmptyArgList => "No arguments specified";

        static MsgPattern ArgSpecError => "Argument specification error";
    }
}
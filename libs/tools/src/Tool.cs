//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public readonly struct Tool : ITool
    {
        [Op, Closures(UInt64k)]
        public static ToolCmd command<T>(in T spec)
            where T : struct
        {
            var t = typeof(T);
            var fields = Clr.fields(t);
            var count = fields.Length;
            var reflected = alloc<ClrFieldValue>(count);
            ClrFields.values(spec, fields, reflected);
            var buffer = alloc<ToolCmdArg>(count);
            var target = span(buffer);
            var source = @readonly(reflected);
            for(var i=0u; i<count; i++)
            {
                ref readonly var fv = ref skip(source,i);
                seek(target,i) = new ToolCmdArg(fv.Field.Name, fv.Value?.ToString() ?? EmptyString);
            }
            return new ToolCmd(CmdId.from(t), buffer);
        }

        [MethodImpl(Inline), Op]
        public static ToolHelp help(ToolId tool, string doc, string description, CmdOptionSpec[] options)
            => new ToolHelp(tool, doc, description, options);

        public readonly ToolId ToolId;

        [MethodImpl(Inline)]
        public Tool(ToolId id)
        {
            ToolId = id;
        }

        public Identifier Name
            => ToolId.Format();

        public string Format()
            => Name;

        public override string ToString()
            => Format();

        ToolId ITool.ToolId
            => ToolId;

        [MethodImpl(Inline)]
        public static implicit operator Tool(ToolId id)
            => new Tool(id);

        [MethodImpl(Inline)]
        public static implicit operator Actor(Tool tool)
            => new Actor(tool.Name);

        [MethodImpl(Inline)]
        public static implicit operator Tool(Actor src)
            => new Tool(src.Name.Text);

        public static Tool Empty => new Tool(ToolId.Empty);
    }
}
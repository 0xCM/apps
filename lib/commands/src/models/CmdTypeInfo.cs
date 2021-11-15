//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Reflection;

    using static Root;
    using static core;

    [DataType]
    public readonly struct CmdTypeInfo : ICmdTypeInfo, IDataType<CmdTypeInfo>
    {
        public CmdId CmdId {get;}

        public Type SourceType {get;}

        public Index<FieldInfo> Fields {get;}

        [MethodImpl(Inline)]
        public CmdTypeInfo(Type type, FieldInfo[] fields)
        {
            CmdId = CmdId.from(type);
            SourceType = type;
            Fields = fields;
        }

        public uint FieldCount
        {
            [MethodImpl(Inline)]
            get => Fields.Count;
        }

        public string Format()
            => format(this);

        public override string ToString()
            => Format();

        [Op]
        static string format(CmdTypeInfo src)
        {
            var buffer = TextTools.buffer();
            render(src, buffer);
            return buffer.Emit();
        }

        [Op]
        static void render(CmdTypeInfo src, ITextBuffer dst)
        {
            dst.Append(src.SourceType.Name);
            var fields = src.Fields.View;;
            var count = fields.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var field = ref skip(fields,count);
                dst.Append(string.Format(" | {0}:{1}", field.Name, field.FieldType.Name));
            }
        }
    }
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Reflection;

    using static core;

    public abstract class ToolOptions<T>
        where T : Tool<T>,new()
    {
        public T Tool {get;}

        Index<CmdOption> Buffer;

        protected ToolOptions()
        {
            Tool = Tool<T>.Instance;
            Buffer = alloc<CmdOption>(FieldCount + PropCount);
        }

        public virtual ReadOnlySpan<CmdOption> Values
            => UpdateValues(this, Buffer.Edit);

        static uint FieldCount => Fields.Count;

        static Index<FieldInfo> Fields {get;}

        static Index<PropertyInfo> Props {get;}

        static uint PropCount => Props.Count;

        static ToolOptions()
        {
            Fields = typeof(T).PublicFields().Tagged<OptionAttribute>();
            Props = typeof(T).Properties().Tagged<OptionAttribute>();
        }

        static ReadOnlySpan<CmdOption> UpdateValues(object host, Span<CmdOption> dst)
        {
            var j=0u;
            for(var i=0; i<FieldCount; i++,j++)
            {
                ref readonly var member = ref Fields[i];
                seek(dst,j) = new CmdOption(member.Name, member.GetValue(host).ToString());
            }

            for(var i=0; i<PropCount; i++,j++)
            {
                ref readonly var member = ref Props[i];
                seek(dst,j) = new CmdOption(member.Name, member.GetValue(host).ToString());
            }
            return dst;
        }
    }

    public abstract class ToolOptions<O,T> : ToolOptions<T>
        where T : Tool<T>, new()
        where O : ToolOptions<O,T>, new()
    {
        public static O init()
        {
            var options = new O();
            options.OnInit();
            return options;
        }

        protected virtual void OnInit()
        {

        }
    }
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class ToolCmdArgs<K,T> : Seq<ToolCmdArgs<K,T>,ToolCmdArg<K,T>>
        where K : unmanaged
    {
        public ToolCmdArgs()
        {

        }

        [MethodImpl(Inline)]
        public ToolCmdArgs(ToolCmdArg<K,T>[] src)
            : base(src)
        {

        }

        public override string Format()
        {
            var dst = text.buffer();
            for(var i=0; i<Count; i++)
                dst.AppendLine(this[i].Format());
            return dst.Emit();
        }

        [MethodImpl(Inline)]
        public static implicit operator ToolCmdArgs<K,T>(ToolCmdArg<K,T>[] src)
            => new ToolCmdArgs<K,T>(src);

        [MethodImpl(Inline)]
        public static implicit operator ToolCmdArgs(ToolCmdArgs<K,T> src)
            => new ToolCmdArgs(src.Data.Select(x => (ToolCmdArg)x));
    }
}
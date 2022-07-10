//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class ToolCmdArgs : Seq<ToolCmdArg>
    {
        [MethodImpl(Inline)]
        public ToolCmdArgs(ToolCmdArg[] src)
            :base(src)
        {

        }
        public override string Format()
        {
            var dst = text.emitter();
            for(var i=0; i<Data.Count; i++)
                dst.Append($"{Data[i].Format()} ");
            return dst.Emit();
        }

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator ToolCmdArgs(ToolCmdArg[] src)
            => new ToolCmdArgs(src);
    }
}
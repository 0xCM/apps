//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class CmdUriSeq : Seq<CmdUriSeq, CmdUri>
    {
        public CmdUriSeq()
        {

        }

        public CmdUriSeq(CmdUri[] src)
            : base(src)
        {

        }

        public override string Format()
        {
            var dst = text.emitter();
            for(var i=0; i<Count; i++)
                dst.AppendLineFormat("[{0:D3}]({1})", i, this[i]);
            return dst.Emit();
        }

        [MethodImpl(Inline)]
        public static implicit operator CmdUriSeq(CmdUri[] src)
            => new (src);
    }
}
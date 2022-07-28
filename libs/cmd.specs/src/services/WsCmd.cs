//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using G = ApiAtomic;

    [ApiHost]
    public class WsCmd
    {
        [MethodImpl(Inline), Op]
        public static WsBuildCmd build(WsId ws, Name src, FileKind srcKind, Name dst, FileKind dstKind, Name script)
        {
            var cmd = WsBuildCmd.Empty;
            cmd.WsId = ws;
            cmd.Sources = G.src;
            cmd.Targets = G.dotbuild;
            cmd.SrcId = src;
            cmd.DstId = dst;
            cmd.DstKind = dstKind;
            cmd.Script = script;
            return cmd;
        }
    }
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class CliEmitter
    {
        public void EmitMemberRefs(IApiPack dst)
        {
            var components = ApiMd.Components;
            var count = components.Length;
            var counter = 0u;
            iter(ApiMd.Components, c => EmitMemberRefs(c,dst), true);
        }

        public void EmitMemberRefs(Assembly src, IApiPack dst)
        {
            var path = dst.SectionTable<MemberRefInfo>("member.refs", src.GetSimpleName());
            using var reader = PeReader.create(FS.path(src.Location));
            TableEmit(reader.ReadMemberRefs(), path);
        }
    }
}
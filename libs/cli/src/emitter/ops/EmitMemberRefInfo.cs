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
            => iter(ApiMd.Components, c => EmitMemberRefs(c,dst), true);

        public void EmitMemberRefs(Assembly src, IApiPack dst)
        {
            using var reader = PeReader.create(FS.path(src.Location));
            TableEmit(reader.ReadMemberRefs(), dst.Metadata("member.refs").Table<MemberRefInfo>(src.GetSimpleName()));
        }
    }
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class CliEmitter
    {
        public void EmitMemberRefInfo()
        {
            var components = ApiMd.Components;
            var count = components.Length;
            var counter = 0u;
            for(var i=0; i<count; i++)
            {
                var component = skip(components,i);
                var dst = MemberRefsPath(component);
                using var reader = PeReader.create(FS.path(component.Location));
                TableEmit(reader.ReadMemberRefs(), dst);
            }
        }
    }
}
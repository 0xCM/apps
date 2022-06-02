//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.IO;
    using System.Text;

    using static core;
    using static TaggedLiterals;

    partial class Assets
    {
        public Index<ResEmission> Run(EmitResDataCmd cmd)
            => EmitEmbedded(cmd.Source, cmd.Target, cmd.Match, cmd.ClearTarget);


        public Index<ResEmission> EmitEmbedded(Assembly src, FS.FolderPath root, utf8 match, bool clear)
        {
            var flow = Running(string.Format("Emitting resources embedded in {0}", src.GetSimpleName()));
            var descriptors = match.IsEmpty ? Assets.descriptors(src) : Assets.descriptors(src, match);
            var count = descriptors.Count;

            if(count == 0)
                return sys.empty<ResEmission>();

            var buffer = sys.alloc<ResEmission>(count);
            ref var emission = ref first(buffer);

            if(clear)
                root.Clear();

            var sources = descriptors.View;
            for(var i=0; i<count; i++)
                seek(emission,i) = EmitData(skip(sources,i), root);

            Ran(flow);
            return buffer;
        }

    }
}
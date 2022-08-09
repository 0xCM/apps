//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using E = Microsoft.Build.Evaluation;

    partial class Build
    {
        public record class ProjectSpec
        {
            readonly E.Project Source;

            readonly ReadOnlySeq<Property> Props;

            readonly ReadOnlySeq<ProjectItem> Items;

            [MethodImpl(Inline)]
            internal ProjectSpec(E.Project src)
            {
                Source = src;
                Props = Source.AllEvaluatedProperties.Array().Select(BuildSvc.property);
                Items = Source.AllEvaluatedItems.Array().Select(BuildSvc.item);
            }

            public string Format()
            {
                var dst = text.emitter();
                for(var i=0; i<Props.Count; i++)
                    dst.AppendLine(Props[i].Format());
                for(var i=0; i<Items.Count; i++)
                    dst.Append(Items[i].Format());
                return dst.Emit();
            }

            public override string ToString()
                => Format();
        }
    }
}
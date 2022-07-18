//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using E = Microsoft.Build.Evaluation;

    partial class MsBuild
    {
        public class Project
        {
            readonly E.Project Source;

            internal readonly ReadOnlySeq<Property> Props;

            [MethodImpl(Inline)]
            internal Project(E.Project src)
            {
                Source = src;
                Props = Source.AllEvaluatedProperties.Array().Select(property);
            }

            public string Format()
            {
                var dst = text.emitter();
                for(var i=0; i<Props.Count; i++)
                    dst.AppendLine(Props[i].Format());
                return dst.Emit();
            }

            public override string ToString()
                => Format();

        }
    }
}
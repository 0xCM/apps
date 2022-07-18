//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using E = Microsoft.Build.Evaluation;

    partial class MsBuild
    {
        public readonly struct Property
        {
            readonly E.ProjectProperty Data;

            [MethodImpl(Inline)]
            internal Property(E.ProjectProperty src)
            {
                Data = src;
            }

            public string Format()
                => $"{Data.Name}={Data.EvaluatedValue}";

            public override string ToString()
                => Format();
        }
    }
}
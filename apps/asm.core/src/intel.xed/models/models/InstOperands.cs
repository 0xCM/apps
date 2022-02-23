//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        public struct InstOperands : IIndex<InstOperandDetail>
        {
            public const string RenderPattern = "{0,-4} | {1,-8} | {2,-24} | {3,-10} | {4,-12} | {5,-12} | {6,-12} | {7,-12}";

            static string[] ColPatterns = new string[]{"Op{0}", "Op{0}Name", "Op{0}Val", "Op{0}Action", "Op{0}Vis", "Op{0}Width", "Op{0}WKind", "Op{0}Prop2"};

            public static string Header(int index)
                => string.Format(RenderPattern, ColPatterns.Select(x => string.Format(x, index)));

            public Index<InstOperandDetail> Details;

            [MethodImpl(Inline)]
            public InstOperands(InstOperandDetail[] src)
            {
                Details = src;
            }

            public InstOperandDetail[] Storage
            {
                [MethodImpl(Inline)]
                get => Details.Storage;
            }

            public uint Count
            {
                [MethodImpl(Inline)]
                get => Details.Count;
            }

            public int Length
            {
                [MethodImpl(Inline)]
                get => Details.Length;
            }

            public ref InstOperandDetail this[int i]
            {
                [MethodImpl(Inline)]
                get => ref Details[i];
            }

            public ref InstOperandDetail this[uint i]
            {
                [MethodImpl(Inline)]
                get => ref Details[i];
            }

            public string Format()
            {
                var dst = text.buffer();
                for(var i=0; i<Count; i++)
                {
                    ref readonly var src = ref this[i];
                    if(i==0)
                    {
                        dst.AppendFormat("{0} |", src);
                    }
                    else
                    {
                        dst.AppendFormat("{0}| ", src);
                    }
                }

                return dst.Emit();
            }

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static implicit operator InstOperands(InstOperandDetail[] src)
                => new InstOperands(src);

            [MethodImpl(Inline)]
            public static implicit operator InstOperandDetail[](InstOperands src)
                => src.Storage;
        }
    }
}
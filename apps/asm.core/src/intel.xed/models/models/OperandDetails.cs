//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        public struct OperandDetails : IIndex<OperandDetail>
        {
            public const string RenderPattern = "{0,-4} | {1,-8} | {2,-24} | {3,-10} | {4,-12} | {5,-12} | {6,-12} | {7,-12}";

            static string[] ColPatterns = new string[]{"Op{0}", "Op{0}Name", "Op{0}Val", "Op{0}Action", "Op{0}Vis", "Op{0}Width", "Op{0}WKind", "Op{0}Prop2"};

            public static string Header(int index)
                => string.Format(RenderPattern, ColPatterns.Select(x => string.Format(x, index)));

            public Index<OperandDetail> Details;

            [MethodImpl(Inline)]
            public OperandDetails(OperandDetail[] src)
            {
                Details = src;
            }

            public OperandDetail[] Storage
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

            public ref OperandDetail this[int i]
            {
                [MethodImpl(Inline)]
                get => ref Details[i];
            }

            public ref OperandDetail this[uint i]
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
            public static implicit operator OperandDetails(OperandDetail[] src)
                => new OperandDetails(src);

            [MethodImpl(Inline)]
            public static implicit operator OperandDetail[](OperandDetails src)
                => src.Storage;
        }
    }
}
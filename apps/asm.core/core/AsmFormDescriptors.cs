//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    public class AsmFormDescriptors : SortedLookup<string,AsmFormDescriptor>
    {
        public const string FormKindName = "AsmFormKind";

        public SymSet CalcSymbols()
        {
            var forms = this;
            var identifiers = forms.Keys;
            var count = (uint)identifiers.Length + 1;
            var dst = SymSet.create(count);
            dst.DataType = ClrEnumKind.U16;
            dst.Name = FormKindName;
            dst.Description ="Defines asm form classifiers";
            dst.Flags = false;
            dst.SymbolKind = "asm";
            var symbols = dst.Symbols;
            var values = dst.Values;
            var descriptions = dst.Descriptions;
            var names = dst.Names;
            var kinds = dst.Kinds;
            for(ushort i=0; i<count; i++)
            {
                ref var name = ref names[i];
                ref var symbol = ref symbols[i];
                ref var value = ref values[i];
                ref var desc = ref descriptions[i];
                ref var kind = ref kinds[i];
                if(i == 0)
                {
                    name = "None";
                    symbol = EmptyString;
                    value = 0;
                    desc = EmptyString;
                    kind = EmptyString;
                }
                else
                {
                    ref readonly var id = ref skip(identifiers,i - 1);
                    var form = forms[id];

                    name = id == "lock" ? "@lock" : id;
                    symbol = form.Sig.Format();
                    value = i;
                    kind = form.OpCode.Format();
                    desc = string.Format("{0} | {1} | {2}", symbol, kind, form.Description);
                }
            }
            return dst;
        }

        public AsmFormDescriptors(Dictionary<string,AsmFormDescriptor> src)
            : base(src)
        {


        }

        public static implicit operator AsmFormDescriptors(Dictionary<string,AsmFormDescriptor> src)
            => new AsmFormDescriptors(src);
    }
}
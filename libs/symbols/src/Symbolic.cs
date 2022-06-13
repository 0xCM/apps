//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    [ApiHost]
    public partial class Symbolic
    {
        const NumericKind Closure = UnsignedInts;

        public static Index<RuntimeLiteral> runtimelits(Index<LiteralProvider> src)
        {
            var providers = src.Select(provider => (Provider: provider, Fields: provider.Type.LiteralFields().Index()));
            var count = providers.Storage.Select(x => x.Fields.Count).Sum();
            var dst = alloc<RuntimeLiteral>(count);
            var k=0u;
            for(var i=0; i<providers.Count; i++)
            {
                ref readonly var provided = ref providers[i];
                var provider = provided.Provider;
                var fields = provided.Fields;
                for(var j=0; j<fields.Count; j++, k++)
                {
                    ref readonly var field = ref fields[j];
                    var datatype = field.FieldType;
                    var host = field.DeclaringType;
                    var value = field.GetRawConstantValue();
                    var lk = ClrLiteralKind.None;
                    var data = 0ul;
                    if(datatype.IsEnum)
                    {
                        lk = (ClrLiteralKind)Enums.@base(datatype);
                        data = ClrLiterals.serialize(value,lk);
                    }
                    else
                    {
                        lk = (ClrLiteralKind)PrimalBits.kind(datatype);
                        data = ClrLiterals.serialize(value,lk);
                    }
                    seek(dst,k) = new (host.Assembly.Id(), provider.Group, ClrLiterals.name(host), ClrLiterals.name(field), data, lk);
                }
            }
            return dst;
        }

        [Op]
        public static uint example(SymStore<string> store, Span<SymRef> refs, Span<string> found)
        {
            var i=0u;
            var j=0u;
            var k=0u;
            store.Deposit("abc", out seek(refs,i++));
            store.Deposit("def", out seek(refs,i++));
            store.Deposit("hij", out seek(refs,i++));
            store.Deposit("klm", out seek(refs,i++));
            store.Deposit("nop", out seek(refs,i++));
            seek(found,j++) = store.Find(skip(refs,k++));
            seek(found,j++) = store.Find(skip(refs,k++));
            seek(found,j++) = store.Find(skip(refs,k++));
            seek(found,j++) = store.Find(skip(refs,k++));
            seek(found,j++) = store.Find(skip(refs,k++));
            return i;
        }

        public static void example()
        {
            var count = 12u;
            var store = Symbolic.store<string>(count);
            var refs = alloc<SymRef>(count);
            var found = alloc<string>(count);

            store.Deposit("abc", out var s1);
            store.Deposit("def", out var s2);
            store.Deposit("hij", out var s3);
            store.Deposit("klm", out var s4);
            store.Deposit("nop", out var s5);

            var e1 = store.Find(s1);
            var e2 = store.Find(s2);
            var e3 = store.Find(s3);
            var e4 = store.Find(s4);
            var e5 = store.Find(s5);
        }
    }
}
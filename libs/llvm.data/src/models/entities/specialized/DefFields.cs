//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    public class DefFields : Entity<string,RecordField>
    {
        public readonly DefRelations Def;

        protected static bits<byte> bits(N8 n, string src)
        {
            var data = text.remove(text.unfence(src, RenderFence.Embraced),Chars.Comma, Chars.Space);
            BitNumber.parse(data, n, out bits<byte> bits);
            return bits;
        }

        protected static bits<byte> bits(N7 n, string src)
        {
            var data = text.remove(text.unfence(src, RenderFence.Embraced),Chars.Comma, Chars.Space);
            BitNumber.parse(data, n, out bits<byte> bits);
            return bits;
        }

        protected static bits<byte> bits(N2 n, string src)
        {
            var data = text.remove(text.unfence(src, RenderFence.Embraced),Chars.Comma, Chars.Space);
            BitNumber.parse(data, n, out bits<byte> bits);
            return bits;
        }

        protected static bits<byte> bits(N3 n, string src)
        {
            var data = text.remove(text.unfence(src, RenderFence.Embraced),Chars.Comma, Chars.Space);
            BitNumber.parse(data, n, out bits<byte> bits);
            return bits;
        }

        public DefFields(DefRelations def, RecordField[] fields)
            : base(fields ?? sys.empty<RecordField>())
        {
            Def = def;
        }

        protected override Func<RecordField,string> KeyFunction
            => a => text.ifempty(a.Name,EmptyString);

        protected ref bit Parse(string attrib, out bit dst)
        {
            bit parse()
            {
                if(DataParser.parse(this[attrib], out bit data))
                    return data;
                else
                    return 0;
            }

            dst = Value(attrib, parse);

            return ref dst;
        }

        protected ref int Parse(string attrib, out int dst)
        {
            int parse()
            {
                if(DataParser.parse(this[attrib], out int data))
                    return data;
                else
                    return 0;
            }

            dst = Value(attrib, parse);
            return ref dst;
        }

        protected ref bits<T> Parse<T>(string attrib, out bits<T> dst)
            where T : unmanaged
        {
            bits<T> parse()
            {
                if(BitParser.parse(this[attrib], out bits<T> b))
                    return b;
                else
                    return new bits<T>(0,default(T));
            }

            dst = Value(attrib, parse);
            return ref dst;
        }

        protected ref list<string> Parse(string attrib, string type, out list<string> dst)
        {
            list<string> parse()
            {
                var result = LlvmTypes.parse(this[attrib], type, out var l);
                if(result)
                    return l;
                else
                    return list<string>.Empty;
            }

            dst = Value(attrib, parse);
            return ref dst;
        }

        protected ref dag<IExpr> Parse(string attrib, out dag<IExpr> dst)
        {
            dag<IExpr> parse()
            {
                var result = LlvmTypes.parse(this[attrib], out var _dst);
                if(result)
                    return _dst;
                else
                    return new dag<IExpr>(@string.Empty, @string.Empty);
            }


            dst = Value(attrib, parse);
            return ref dst;
        }

        public Identifier EntityName
            => Def.Name;

        public Identifier ParentName
            => Def.ParentName;

        public new string this[string name]
            => text.ifempty(Attrib(name).Value, EmptyString);
    }
}
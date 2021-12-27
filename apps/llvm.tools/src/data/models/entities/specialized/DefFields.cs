//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;

    using static Root;

    public class DefFields : Entity<string,RecordField>
    {
        public readonly DefRelations Def;

        public DefFields(DefRelations def, RecordField[] fields)
            : base(fields)
        {
            Def = def;
        }

        protected override Func<RecordField,string> KeyFunction
            => a => a.Name;

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
                if(bits<T>.parse(this[attrib], out var b))
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
                => new list<string>(type, text.trim(text.split(text.unfence(this[attrib], RenderFence.Bracketed), Chars.Comma)));

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
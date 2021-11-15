//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Collections.Generic;

    using static core;
    public class AsmDocBuilder
    {
        List<object> Parts;


        public static AsmDocBuilder create(string name)
            => new AsmDocBuilder(name);

        public AsmDocBuilder(string name)
        {
            DocName = name;
            Level = 0;
        }

        int Level;

        public string DocName {get;}

        public AsmDocBuilder WithDirective(text15 name, params AsmDirectiveOp[] args)
        {
            switch(args.Length)
            {
                case 1:
                    Parts.Add(asm.directive(name,skip(args,0)));
                break;
                case 2:
                    Parts.Add(asm.directive(name,skip(args,0), skip(args,1)));
                break;
                case 3:
                    Parts.Add(asm.directive(name,skip(args,0), skip(args,1), skip(args,2)));
                break;
                default:
                    Parts.Add(asm.directive(name));
                    break;
            }

            return this;
        }

        public AsmDocBuilder WithBlockLabel(TextBlock name)
        {
            Parts.Add(asm.label(name));
            return this;
        }

        public AsmDocBuilder WithByte(Hex8 src)
        {
            Parts.Add(directive(".byte", src));
            return this;
        }

        public AsmDocBuilder WithWord(Hex16 src)
        {
            Parts.Add(directive(".byte2", src));
            return this;
        }

        public AsmDocBuilder WithDWord(Hex32 src)
        {
            Parts.Add(directive(".byte4", src));
            return this;
        }

        public AsmDocBuilder WithQWord(Hex64 src)
        {
            Parts.Add(directive(".byte4", src));
            return this;
        }

        public AsmDocBuilder WithBytes(params byte[] src)
        {
            var count = src.Length;
            return this;
        }

        static AsmDirective directive<T>(text15 name, T arg)
            => asm.directive(name, new AsmDirectiveOp<T>(arg));
    }
}
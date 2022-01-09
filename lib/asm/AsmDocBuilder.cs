//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    using static core;
    using static Root;

    public class AsmDocBuilder
    {
        [MethodImpl(Inline), Op]
        public static AsmDirective directive(text15 name, AsmDirectiveOp op0 = default, AsmDirectiveOp op1 = default, AsmDirectiveOp op2 = default)
            => new AsmDirective(name,op0,op1,op2);

        [MethodImpl(Inline), Op]
        public static AsmLine line(params object[] src)
            => new AsmLine(src);

        [MethodImpl(Inline), Op]
        public static AsmOffsetLabel label(byte width, ulong value)
            => new AsmOffsetLabel(width, value);

        [MethodImpl(Inline), Op]
        public static AsmLabel label(Identifier name)
            => new AsmLabel(name);

        [MethodImpl(Inline), Op]
        public static AsmComment comment(string src)
            => new AsmComment(src);

        [MethodImpl(Inline), Op]
        public static AsmInlineComment comment(AsmCommentMarker marker, string src)
            => new AsmInlineComment(marker,src);

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
                    Parts.Add(directive(name,skip(args,0)));
                break;
                case 2:
                    Parts.Add(directive(name,skip(args,0), skip(args,1)));
                break;
                case 3:
                    Parts.Add(directive(name,skip(args,0), skip(args,1), skip(args,2)));
                break;
                default:
                    Parts.Add(directive(name));
                    break;
            }

            return this;
        }

        public AsmDocBuilder WithBlockLabel(Identifier name)
        {
            Parts.Add(label(name));
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
            => directive(name, new AsmDirectiveOp<T>(arg));
    }
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;
    using System.Runtime.InteropServices;
    using System.Runtime.CompilerServices;
    using System.Collections.Generic;

    using Asm;

    using static Root;
    using static core;
    using static AsmSyntaxModel;

    public class AsmSyntaxTreeParser
    {
        const string SourceMarker = "# Source:";

        const string StatementMarker = "     ";

        readonly List<AsmInlineComment> Comments;

        FS.FilePath CurrentSource;

        FS.FilePath PriorSource;

        uint LineCount;

        bool ParsingSource;

        bool ParsingBlock;

        bool ParsingStatement;

        AsmBlockLabel CurrentBlockLabel;

        AsmBlockLabel PriorBlockLabel;

        AsmStatement CurrentStatementText;

        AsmStatement PriorStatementText;

        public AsmSyntaxTreeParser()
        {
            Comments = new();
        }

        void Init()
        {
            CurrentSource = FS.FilePath.Empty;
            PriorSource = FS.FilePath.Empty;
            Comments.Clear();
            LineCount = 0;
            CurrentBlockLabel = AsmBlockLabel.Empty;
            PriorBlockLabel= AsmBlockLabel.Empty;
            CurrentStatementText = EmptyString;
            PriorStatementText = EmptyString;
            ParsingSource = false;
            ParsingBlock = false;
            ParsingStatement = false;

        }

        bool ParseBlockLabel(string src)
            => AsmParser.label(src, out CurrentBlockLabel);

        bool ParseComment(string src)
        {
            if(AsmParser.comment(src, out var c))
            {
                Comments.Add(c);
                return true;
            }
            else
            {
                return false;
            }

        }

        bool ParseSource(string src)
        {
            var j = text.index(src, SourceMarker);
            if(j >= 0)
            {
                var path = FS.path(text.right(src, j + SourceMarker.Length).Trim());
                if(CurrentSource.IsNonEmpty)
                {
                    CurrentSource = path;
                }
                else
                {
                    PriorSource = CurrentSource;
                    CurrentSource = path;
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        bool ParseStatement(string src)
        {
            var k = text.index(src, StatementMarker);
            if(k >= 0)
            {
                var statement = text.right(src, k + StatementMarker.Length);
                if(nonempty(statement))
                {

                    return true;
                }
            }
            return false;
        }

        void EndSourceParse()
        {

        }

        void EndStatmentParse()
        {

        }

        void EndBlockParse()
        {


        }
        Outcome Parse(Index<TextLine> lines)
        {
            var result = Outcome.Success;
            LineCount = lines.Count;
            for(var i=0; i<LineCount; i++)
            {
                ref readonly var line = ref lines[i];
                ref readonly var content = ref line.Content;

                var j = text.index(content, SourceMarker);

                if(ParseSource(content))
                {
                    if(!CurrentSource.Equals(PriorSource))
                    {
                        EndSourceParse();
                    }
                }
                else if(ParseBlockLabel(content))
                {
                    if(!CurrentBlockLabel.Equals(PriorBlockLabel))
                    {
                        EndBlockParse();
                    }
                }
                else if(ParseComment(content))
                {
                    continue;
                }
                else if(ParseStatement(content))
                {

                }

            }
            return result;
        }

        public AsmSyntaxTree Parse(FS.FilePath src)
        {
            Init();
            var result = Parse(FS.readlines(src));

            return default;
        }

    }

    public readonly struct AsmSyntaxModel
    {
        public struct AsmSyntaxTree
        {
            public FS.FileUri Source;

            public Index<AsmSyntaxStatement> Statements;

        }

        [StructLayout(LayoutKind.Sequential, Pack=1)]
        public struct AsmSyntaxStatement
        {
            public uint AsmSeq;

            public uint BlockSeq;

            public AsmBlockLabel BlockLabel;

            public AsmStatement Asm;

            public AsmIdentifier AsmId;

            public Index<Operand> Operands;

            public FS.FileUri Source;
        }

        public interface IOperand
        {
            byte Index {get;}

            byte Kind {get;}

            ReadOnlySpan<byte> Value {get;}
        }

        public interface IOperand<T> : IOperand
            where T : unmanaged
        {
            new T Value {get;}

            ReadOnlySpan<byte> IOperand.Value
                => bytes(Value);
        }

        public interface IOperand<K,T> : IOperand<T>
            where T : unmanaged
            where K : unmanaged
        {
            new K Kind {get;}

            byte IOperand.Kind
                => bw8(Kind);
        }

        public struct Operand<K,T> : IOperand<K,T>
            where K : unmanaged
            where T : unmanaged
        {
            public byte Index {get;}

            public K Kind {get;}

            public T Value {get;}

            [MethodImpl(Inline)]
            public Operand(byte index, K kind, T value)
            {
                Index = index;
                Kind = kind;
                Value = value;
            }
        }

        [StructLayout(LayoutKind.Sequential, Pack=1)]
        public struct Operand : IOperand<AsmOpClass,Cell256>
        {
            public byte Index {get;}

            public AsmOpClass Kind {get;}

            public Cell256 Value {get;}

            [MethodImpl(Inline)]
            public Operand(byte index, AsmOpClass kind, Cell256 value)
            {
                Index = index;
                Kind = kind;
                Value = value;
            }
        }

        [StructLayout(LayoutKind.Sequential, Pack=1)]
        public struct RegOperand : IOperand<AsmOpClass,RegIdentifier>
        {
            public byte Index {get;}

            public RegIdentifier Value {get;}

            [MethodImpl(Inline)]
            public RegOperand(byte index, RegIdentifier value)
            {
                Index = index;
                Value = value;
            }

            public AsmOpClass Kind => AsmOpClass.R;
        }

        public struct ImmOperand<T> : IOperand<AsmOpClass,T>
            where T : unmanaged, IImm<T>
        {
            public byte Index {get;}

            public T Value {get;}

            [MethodImpl(Inline)]
            public ImmOperand(byte index, T value)
            {
                Index = index;
                Value = value;
            }

            public AsmOpClass Kind => AsmOpClass.Imm;

            [MethodImpl(Inline)]
            public static implicit operator ImmOperand(ImmOperand<T> src)
                => new ImmOperand(src.Index,new ImmOp(src.Value));
        }

        public struct ImmOperand : IOperand<AsmOpClass,ImmOp>
        {
            public byte Index {get;}

            public ImmOp Value {get;}

            public AsmOpClass Kind => AsmOpClass.Imm;

            [MethodImpl(Inline)]
            public ImmOperand(byte index, ImmOp value)
            {
                Index = index;
                Value = value;
            }
        }
    }
}
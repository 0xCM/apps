//-----------------------------------------------------------------------------
// Origin: (c) 1998 Axel.Schreiner@informatik.uni-osnabrueck.de
//-----------------------------------------------------------------------------
namespace Monodoc.Ecma
{
    using System.Linq;
    
    using static Z0.EcmaDoc;

    partial class EcmaUrlParser
    {
        public void IsValid(string input)
        {
            var lexer = new EcmaUrlTokenizer(input);
            this.yyparse(lexer);
        }

        public EcmaDesc Parse(string input)
        {
            var lexer = new EcmaUrlTokenizer(input);
            return (EcmaDesc)this.yyparse(lexer);
        }

        public bool TryParse(string input, out EcmaDesc desc)
        {
            desc = null;
            try
            {
                desc = Parse(input);
            }
            catch
            {
                return false;
            }
            return true;
        }

        EcmaDesc SetEcmaDescType(object result, EcmaDesc.Kind kind)
        {
            var desc = result as EcmaDesc;
            desc.DescKind = kind;
            return desc;
        }

        List<T> SafeReverse<T>(List<T> input)
        {
            if (input == null)
                return null;
            input.Reverse();
            return input;
        }

        /** error output stream.
            It should be changeable.
          */
        public System.IO.TextWriter ErrorOutput = System.Console.Out;

        /** simplified error message.
            @see <a href="#yyerror(java.lang.String, java.lang.String[])">yyerror</a>
          */
        public void yyerror(string message)
        {
            yyerror(message, null);
        }
        /* An EOF token */
        public int eof_token;
        /** (syntax) error message.
            Can be overwritten to control message format.
            @param message text to be displayed.
            @param expected vector of acceptable tokens, if available.
          */
        public void yyerror(string message, string[] expected)
        {
            if ((yacc_verbose_flag > 0) && (expected != null) && (expected.Length > 0))
            {
                ErrorOutput.Write(message + ", expecting");
                for (int n = 0; n < expected.Length; ++n)
                    ErrorOutput.Write(" " + expected[n]);
                ErrorOutput.WriteLine();
            }
            else
                ErrorOutput.WriteLine(message);
        }

        protected static readonly string[] yyNames = {
          "end-of-file",null,null,null,null,null,null,null,null,null,null,null,
          null,null,null,null,null,null,null,null,null,null,null,null,null,null,
          null,null,null,null,null,null,null,null,null,null,null,null,null,null,
          null,null,null,null,null,null,null,null,null,null,null,null,null,null,
          null,null,null,null,null,null,null,null,null,null,null,null,null,
          "'C'",null,"'E'","'F'",null,null,null,null,null,null,"'M'","'N'",
          "'O'","'P'",null,null,null,"'T'",null,null,null,null,null,null,null,
          null,null,null,null,null,null,null,null,null,null,null,null,null,null,
          null,null,null,null,null,null,null,null,null,null,null,null,null,null,
          null,null,null,null,null,null,null,null,null,null,null,null,null,null,
          null,null,null,null,null,null,null,null,null,null,null,null,null,null,
          null,null,null,null,null,null,null,null,null,null,null,null,null,null,
          null,null,null,null,null,null,null,null,null,null,null,null,null,null,
          null,null,null,null,null,null,null,null,null,null,null,null,null,null,
          null,null,null,null,null,null,null,null,null,null,null,null,null,null,
          null,null,null,null,null,null,null,null,null,null,null,null,null,null,
          null,null,null,null,null,null,null,null,null,null,null,null,null,null,
          null,null,null,null,null,null,null,null,null,null,null,null,null,null,
          null,null,null,null,null,null,null,null,null,null,null,"ERROR",
          "IDENTIFIER","DIGIT","DOT","COMMA","COLON","INNER_TYPE_SEPARATOR",
          "OP_GENERICS_LT","OP_GENERICS_GT","OP_GENERICS_BACKTICK",
          "OP_OPEN_PAREN","OP_CLOSE_PAREN","OP_ARRAY_OPEN","OP_ARRAY_CLOSE",
          "SLASH_SEPARATOR","STAR","REF_ARG","OUT_ARG","EXPLICIT_IMPL_SEP",
        };

        /** index-checked interface to yyNames[].
            @param token single character or %token value.
            @return token name or [illegal] or [unknown].
          */
        public static string yyname(int token)
        {
            if ((token < 0) || (token > yyNames.Length)) return "[illegal]";
            string name;
            if ((name = yyNames[token]) != null) return name;
            return "[unknown]";
        }

        int yyExpectingState;

        /** debugging support, requires the package jay.yydebug.
            Set to null to suppress debugging messages.
          */
        internal yydebug.yyDebug debug;

        protected const int yyFinal = 9;

        int yacc_verbose_flag = 0;

        /** initial size and increment of the state/value stack [default 256].
            This is not final so that it can be overwritten outside of invocations
            of yyparse().
          */
        protected int yyMax;

        static int[] global_yyStates;

        static object[] global_yyVals;

        protected bool use_global_stacks;

        object[] yyVals;                    // value stack

        object yyVal;                       // value stack ptr

        int yyToken;                        // current input

        int yyTop;

        /** computes list of expected tokens on error by tracing the tables.
            @param state for which to compute the list.
            @return list of token names.
          */
        protected int[] yyExpectingTokens(int state)
        {
            int token, n, len = 0;
            bool[] ok = new bool[yyNames.Length];
            if ((n = yySindex[state]) != 0)
                for (token = n < 0 ? -n : 0;
                     (token < yyNames.Length) && (n + token < yyTable.Length); ++token)
                    if (yyCheck[n + token] == token && !ok[token] && yyNames[token] != null)
                    {
                        ++len;
                        ok[token] = true;
                    }
            if ((n = yyRindex[state]) != 0)
                for (token = n < 0 ? -n : 0;
                     (token < yyNames.Length) && (n + token < yyTable.Length); ++token)
                    if (yyCheck[n + token] == token && !ok[token] && yyNames[token] != null)
                    {
                        ++len;
                        ok[token] = true;
                    }
            int[] result = new int[len];
            for (n = token = 0; n < len; ++token)
                if (ok[token]) result[n++] = token;
            return result;
        }

        protected string[] yyExpecting(int state)
        {
            int[] tokens = yyExpectingTokens(state);
            string[] result = new string[tokens.Length];
            for (int n = 0; n < tokens.Length; n++)
                result[n++] = yyNames[tokens[n]];
            return result;
        }

        /** the generated parser, with debugging messages.
            Maintains a state and a value stack, currently with fixed maximum size.
            @param yyLex scanner.
            @param yydebug debug message writer implementing yyDebug, or null.
            @return result of the last reduction, if any.
            @throws yyException on irrecoverable parse error.
          */
        internal Object yyparse(yyParser.yyInput yyLex, Object yyd)
        {
            this.debug = (yydebug.yyDebug)yyd;
            return yyparse(yyLex);
        }

        /** executed at the beginning of a reduce action.
            Used as $$ = yyDefault($1), prior to the user-specified action, if any.
            Can be overwritten to provide deep copy, etc.
            @param first value for $1, or null.
            @return first.
          */
        protected Object yyDefault(Object first)
        {
            return first;
        }

        /** the generated parser.
            Maintains a state and a value stack, currently with fixed maximum size.
            @param yyLex scanner.
            @return result of the last reduction, if any.
            @throws yyException on irrecoverable parse error.
          */
        internal Object yyparse(yyParser.yyInput yyLex)
        {
            if (yyMax <= 0) yyMax = 256;        // initial size
            int yyState = 0;                   // state stack ptr
            int[] yyStates;                 // state stack 
            yyVal = null;
            yyToken = -1;
            int yyErrorFlag = 0;                // #tks to shift
            if (use_global_stacks && global_yyStates != null)
            {
                yyVals = global_yyVals;
                yyStates = global_yyStates;
            }
            else
            {
                yyVals = new object[yyMax];
                yyStates = new int[yyMax];
                if (use_global_stacks)
                {
                    global_yyVals = yyVals;
                    global_yyStates = yyStates;
                }
            }

            /*yyLoop:*/
            for (yyTop = 0; ; ++yyTop)
            {
                if (yyTop >= yyStates.Length)
                {           // dynamically increase
                    global::System.Array.Resize(ref yyStates, yyStates.Length + yyMax);
                    global::System.Array.Resize(ref yyVals, yyVals.Length + yyMax);
                }
                yyStates[yyTop] = yyState;
                yyVals[yyTop] = yyVal;
                if (debug != null) debug.push(yyState, yyVal);

                /*yyDiscarded:*/
                while (true)
                {   // discarding a token does not change stack
                    int yyN;
                    if ((yyN = yyDefRed[yyState]) == 0)
                    {   // else [default] reduce (yyN)
                        if (yyToken < 0)
                        {
                            yyToken = yyLex.advance() ? yyLex.token() : 0;
                            if (debug != null)
                                debug.lex(yyState, yyToken, yyname(yyToken), yyLex.value());
                        }
                        if ((yyN = yySindex[yyState]) != 0 && ((yyN += yyToken) >= 0)
                            && (yyN < yyTable.Length) && (yyCheck[yyN] == yyToken))
                        {
                            if (debug != null)
                                debug.shift(yyState, yyTable[yyN], yyErrorFlag - 1);
                            yyState = yyTable[yyN];     // shift to yyN
                            yyVal = yyLex.value();
                            yyToken = -1;
                            if (yyErrorFlag > 0) --yyErrorFlag;
                            goto continue_yyLoop;
                        }
                        if ((yyN = yyRindex[yyState]) != 0 && (yyN += yyToken) >= 0
                            && yyN < yyTable.Length && yyCheck[yyN] == yyToken)
                            yyN = yyTable[yyN];         // reduce (yyN)
                        else
                            switch (yyErrorFlag)
                            {

                                case 0:
                                    yyExpectingState = yyState;
                                    // yyerror(String.Format ("syntax error, got token `{0}'", yyname (yyToken)), yyExpecting(yyState));
                                    if (debug != null) debug.error("syntax error");
                                    if (yyToken == 0 /*eof*/ || yyToken == eof_token) throw new yyParser.yyUnexpectedEof();
                                    goto case 1;
                                case 1:
                                case 2:
                                    yyErrorFlag = 3;
                                    do
                                    {
                                        if ((yyN = yySindex[yyStates[yyTop]]) != 0
                                            && (yyN += Token.yyErrorCode) >= 0 && yyN < yyTable.Length
                                            && yyCheck[yyN] == Token.yyErrorCode)
                                        {
                                            if (debug != null)
                                                debug.shift(yyStates[yyTop], yyTable[yyN], 3);
                                            yyState = yyTable[yyN];
                                            yyVal = yyLex.value();
                                            goto continue_yyLoop;
                                        }
                                        if (debug != null) debug.pop(yyStates[yyTop]);
                                    } while (--yyTop >= 0);
                                    if (debug != null) debug.reject();
                                    throw new yyParser.yyException("irrecoverable syntax error");

                                case 3:
                                    if (yyToken == 0)
                                    {
                                        if (debug != null) debug.reject();
                                        throw new yyParser.yyException("irrecoverable syntax error at end-of-file");
                                    }
                                    if (debug != null)
                                        debug.discard(yyState, yyToken, yyname(yyToken),
                                                      yyLex.value());
                                    yyToken = -1;
                                    goto continue_yyDiscarded;      // leave stack alone
                            }
                    }
                    int yyV = yyTop + 1 - yyLen[yyN];
                    if (debug != null)
                        debug.reduce(yyState, yyStates[yyV - 1], yyN, YYRules.getRule(yyN), yyLen[yyN]);
                    yyVal = yyV > yyTop ? null : yyVals[yyV]; // yyVal = yyDefault(yyV > yyTop ? null : yyVals[yyV]);
                    switch (yyN)
                    {
                        case 1:
                            { yyVal = SetEcmaDescType(yyVals[0 + yyTop], EcmaDesc.Kind.Type); }
                            break;
                        case 2:
                            { yyVal = SetEcmaDescType(yyVals[0 + yyTop], EcmaDesc.Kind.Namespace); }
                            break;
                        case 3:
                            { yyVal = SetEcmaDescType(yyVals[0 + yyTop], EcmaDesc.Kind.Method); }
                            break;
                        case 4:
                            { yyVal = SetEcmaDescType(yyVals[0 + yyTop], EcmaDesc.Kind.Field); }
                            break;
                        case 5:
                            { yyVal = SetEcmaDescType(yyVals[0 + yyTop], EcmaDesc.Kind.Constructor); }
                            break;
                        case 6:
                            { yyVal = SetEcmaDescType(yyVals[0 + yyTop], EcmaDesc.Kind.Property); }
                            break;
                        case 7:
                            { yyVal = SetEcmaDescType(yyVals[0 + yyTop], EcmaDesc.Kind.Event); }
                            break;
                        case 8:
                            { yyVal = SetEcmaDescType(yyVals[0 + yyTop], EcmaDesc.Kind.Operator); }
                            break;
                        case 9:
                            { yyVal = new List<string> { (string)yyVals[0 + yyTop] }; }
                            break;
                        case 10:
                            { ((ICollection<string>)yyVals[0 + yyTop]).Add((string)yyVals[-2 + yyTop]); yyVal = yyVals[0 + yyTop]; }
                            break;
                        case 11:
                            { yyVal = new EcmaDesc { Namespace = string.Join(".", ((IEnumerable<string>)yyVals[0 + yyTop]).Reverse()) }; }
                            break;
                        case 12:
                            case_12();
                            break;
                        case 13:
                            case_13();
                            break;
                        case 14:
                            case_14();
                            break;
                        case 15:
                            { yyVal = null; }
                            break;
                        case 16:
                            { yyVal = yyVals[0 + yyTop]; }
                            break;
                        case 17:
                            { yyVal = null; }
                            break;
                        case 18:
                            { yyVal = Enumerable.Repeat<EcmaDesc>(null, (int)yyVals[0 + yyTop]).ToList(); }
                            break;
                        case 19:
                            { yyVal = yyVals[-1 + yyTop]; }
                            break;
                        case 20:
                            { yyVal = new List<EcmaDesc>() { (EcmaDesc)yyVals[0 + yyTop] }; }
                            break;
                        case 21:
                            { ((List<EcmaDesc>)yyVals[-2 + yyTop]).Add((EcmaDesc)yyVals[0 + yyTop]); yyVal = yyVals[-2 + yyTop]; }
                            break;
                        case 22:
                            { yyVal = null; }
                            break;
                        case 23:
                            case_23();
                            break;
                        case 24:
                            { yyVal = 1; }
                            break;
                        case 25:
                            { yyVal = ((int)yyVals[0 + yyTop]) + 1; }
                            break;
                        case 26:
                            { yyVal = null; }
                            break;
                        case 27:
                            { yyVal = Tuple.Create<char, string>(((string)yyVals[0 + yyTop])[0], null); }
                            break;
                        case 28:
                            { yyVal = Tuple.Create<char, string>(((string)yyVals[-2 + yyTop])[0], (string)yyVals[0 + yyTop]); }
                            break;
                        case 29:
                            { yyVal = "*"; }
                            break;
                        case 30:
                            { yyVal = yyVals[0 + yyTop]; }
                            break;
                        case 31:
                            case_31();
                            break;
                        case 32:
                            case_32();
                            break;
                        case 33:
                            case_33();
                            break;
                        case 34:
                            { yyVal = (string)yyVals[-1 + yyTop] + (yyVals[0 + yyTop] == null ? string.Empty : "<" + string.Join(",", ((IEnumerable<EcmaDesc>)yyVals[0 + yyTop]).Select(t => t.ToCompleteTypeName())) + ">"); }
                            break;
                        case 35:
                            case_35();
                            break;
                        case 36:
                            { var desc = (EcmaDesc)yyVals[-1 + yyTop]; desc.DescModifier = (EcmaDesc.Mod)yyVals[0 + yyTop]; yyVal = desc; }
                            break;
                        case 37:
                            { yyVal = EcmaDesc.Mod.Normal; }
                            break;
                        case 38:
                            { yyVal = EcmaDesc.Mod.Pointer; }
                            break;
                        case 39:
                            { yyVal = EcmaDesc.Mod.Ref; }
                            break;
                        case 40:
                            { yyVal = EcmaDesc.Mod.Out; }
                            break;
                        case 41:
                           { yyVal = null; }
                            break;
                        case 42:
                            { yyVal = new List<EcmaDesc>() { (EcmaDesc)yyVals[0 + yyTop] }; }
                            break;
                        case 43:
                            { ((List<EcmaDesc>)yyVals[0 + yyTop]).Add((EcmaDesc)yyVals[-2 + yyTop]); yyVal = yyVals[0 + yyTop]; }
                            break;
                        case 44:
                            case_44();
                            break;
                        case 45:
                            case_45();
                            break;
                        case 46:
                            case_46();
                            break;
                        case 47:
                            { yyVal = yyVals[0 + yyTop]; }
                            break;
                        case 48:
                            { yyVal = yyVals[0 + yyTop]; }
                            break;
                        case 49:
                            case_49();
                            break;
                        case 50:
                            { yyVal = yyVals[0 + yyTop]; }
                            break;
                        case 51:
                            { yyVal = null; }
                            break;
                        case 52:
                            { yyVal = yyVals[-1 + yyTop]; }
                            break;
                    }
                    yyTop -= yyLen[yyN];
                    yyState = yyStates[yyTop];
                    int yyM = yyLhs[yyN];
                    if (yyState == 0 && yyM == 0)
                    {
                        if (debug != null) debug.shift(0, yyFinal);
                        yyState = yyFinal;
                        if (yyToken < 0)
                        {
                            yyToken = yyLex.advance() ? yyLex.token() : 0;
                            if (debug != null)
                                debug.lex(yyState, yyToken, yyname(yyToken), yyLex.value());
                        }
                        if (yyToken == 0)
                        {
                            if (debug != null) debug.accept(yyVal);
                            return yyVal;
                        }
                        goto continue_yyLoop;
                    }
                    if (((yyN = yyGindex[yyM]) != 0) && ((yyN += yyState) >= 0)
                        && (yyN < yyTable.Length) && (yyCheck[yyN] == yyState))
                        yyState = yyTable[yyN];
                    else
                        yyState = yyDgoto[yyM];
                    if (debug != null) debug.shift(yyStates[yyTop], yyState);
                    goto continue_yyLoop;
                continue_yyDiscarded:;  // implements the named-loop continue: 'continue yyDiscarded'
                }
            continue_yyLoop:;       // implements the named-loop continue: 'continue yyLoop'
            }
        }

        /*
         All more than 3 lines long rules are wrapped into a method
        */
        void case_12()
        {
            var dotExpr = ((List<string>)yyVals[-1 + yyTop]);
            dotExpr.Reverse();
            var desc = yyVals[0 + yyTop] as EcmaDesc;
            desc.DescKind = EcmaDesc.Kind.Type;
            desc.Namespace = string.Join(".", dotExpr.Take(dotExpr.Count - 1));
            desc.TypeName = dotExpr.Last();
            yyVal = desc;
        }

        void case_13()
        {
            var desc = yyVals[0 + yyTop] as EcmaDesc;
            desc.DescKind = EcmaDesc.Kind.Type;
            desc.TypeName = yyVals[-1 + yyTop] as string;
            yyVal = desc;
        }

        void case_14()
        {
            bool nestedDescHasEtc = yyVals[-2 + yyTop] != null && ((EcmaDesc)yyVals[-2 + yyTop]).IsEtc;
            EcmaDesc nestedType = (EcmaDesc)yyVals[-2 + yyTop];
            yyVal = new EcmaDesc
            {
                GenericTypeArguments = yyVals[-3 + yyTop] as List<EcmaDesc>,
                NestedType = nestedType,
                ArrayDimensions = SafeReverse(yyVals[-1 + yyTop] as List<int>),
                Etc = yyVals[0 + yyTop] != null ? ((Tuple<char, string>)yyVals[0 + yyTop]).Item1 : nestedDescHasEtc ? nestedType.Etc : (char)0,
                EtcFilter = yyVals[0 + yyTop] != null ? ((Tuple<char, string>)yyVals[0 + yyTop]).Item2 : nestedDescHasEtc ? nestedType.EtcFilter : null
            };
            if (nestedDescHasEtc)
            {
                nestedType.Etc = (char)0;
                nestedType.EtcFilter = null;
            }
        }

        void case_23()
        {
            var dims = ((IList<int>)yyVals[0 + yyTop]) ?? new List<int>(2);
            dims.Add((int)yyVals[-2 + yyTop]);
            yyVal = dims;
        }

        void case_31()
        {
            var desc = yyVals[-4 + yyTop] as EcmaDesc;
            desc.MemberName = yyVals[-2 + yyTop] as string;
            desc.GenericMemberArguments = yyVals[-1 + yyTop] as List<EcmaDesc>;
            desc.MemberArguments = SafeReverse(yyVals[0 + yyTop] as List<EcmaDesc>);
            yyVal = desc;
        }

        void case_32()
        {
            var dotExpr = ((List<string>)yyVals[-2 + yyTop]);
            yyVal = new EcmaDesc
            {
                Namespace = string.Join(".", dotExpr.Skip(2).DefaultIfEmpty(string.Empty).Reverse()),
                TypeName = dotExpr.Skip(1).First(),
                MemberName = dotExpr.First(),
                GenericMemberArguments = yyVals[-1 + yyTop] as List<EcmaDesc>,
                MemberArguments = SafeReverse(yyVals[0 + yyTop] as List<EcmaDesc>)
            };
        }

        void case_33()
        {
            var desc = yyVals[-2 + yyTop] as EcmaDesc;
            desc.ExplicitImplMember = yyVals[0 + yyTop] as EcmaDesc;
            yyVal = desc;
        }

        void case_35()
        {
            var existing = yyVals[0 + yyTop] as string;
            var expr = (string)yyVals[-3 + yyTop] + (yyVals[-2 + yyTop] == null ? string.Empty : "<" + string.Join(",", ((IEnumerable<EcmaDesc>)yyVals[-2 + yyTop]).Select(t => t.ToCompleteTypeName())) + ">");
            yyVal = expr + "." + existing;
        }

        void case_44()
        {
            var dotExpr = ((List<string>)yyVals[0 + yyTop]);
            dotExpr.Reverse();

            yyVal = new EcmaDesc
            {
                Namespace = dotExpr.Count > 2 ? string.Join(".", dotExpr.Take(dotExpr.Count - 2)) : string.Empty,
                TypeName = dotExpr.Count > 1 ? dotExpr[dotExpr.Count - 2] : string.Empty,
                MemberName = dotExpr[dotExpr.Count - 1]
            };
        }

        void case_45()
        {
            var desc = yyVals[-2 + yyTop] as EcmaDesc;
            desc.MemberName = yyVals[0 + yyTop] as string;
            yyVal = desc;
        }

        void case_46()
        {
            var desc = yyVals[-2 + yyTop] as EcmaDesc;
            desc.ExplicitImplMember = yyVals[0 + yyTop] as EcmaDesc;
            yyVal = desc;
        }

        void case_49()
        {
            var desc = yyVals[-1 + yyTop] as EcmaDesc;
            (desc.ExplicitImplMember ?? desc).MemberArguments = SafeReverse(yyVals[0 + yyTop] as List<EcmaDesc>);
            yyVal = desc;
        }

        static readonly short[] yyLhs = {              -1,
    0,    0,    0,    0,    0,    0,    0,    0,    8,    8,
    2,    1,   10,    9,   12,   12,   11,   11,   11,   15,
   15,   13,   13,   16,   16,   14,   14,   14,   17,   17,
    3,    3,    3,   18,   18,   20,   21,   21,   21,   21,
   22,   22,   22,    4,    4,    4,    5,    7,    6,   23,
   19,   19,
  };
        static readonly short[] yyLen = {           2,
    3,    3,    3,    3,    3,    3,    3,    3,    1,    3,
    1,    2,    2,    4,    0,    2,    0,    2,    3,    1,
    3,    0,    4,    0,    2,    0,    2,    4,    1,    1,
    5,    3,    3,    2,    4,    2,    0,    1,    1,    1,
    0,    1,    3,    1,    3,    3,    1,    1,    2,    1,
    0,    3,
  };
        static readonly short[] yyDefRed = {            0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    1,    0,
    2,   11,    0,    3,    0,    0,    4,    0,   47,    5,
    0,    6,    7,   48,    8,    0,    0,    0,   12,    0,
    0,    0,    0,    0,    0,    0,   50,   49,   10,   20,
    0,   18,    0,    0,    0,   33,   32,   45,   46,    0,
    0,    0,    0,   19,    0,   16,    0,    0,    0,   38,
   39,   40,   36,    0,   52,   21,   13,    0,    0,    0,
   14,   31,   43,   25,    0,   30,   29,    0,   23,    0,
    0,   28,    0,    0,   35,
  };
        protected static readonly short[] yyDgoto = {             9,
   23,   21,   24,   27,   30,   32,   35,   20,   39,   66,
   40,   54,   68,   81,   51,   79,   88,   92,   47,   61,
   73,   62,   48,
  };
        protected static readonly short[] yySindex = {          -32,
 -231, -228, -202, -201, -200, -199, -198, -195,    0, -190,
 -190, -190, -190, -190, -190, -190, -190, -189,    0, -207,
    0,    0, -257,    0, -207, -248,    0, -207,    0,    0,
 -197,    0,    0,    0,    0, -190, -190, -187,    0, -188,
 -185, -190, -224, -184, -190, -190,    0,    0,    0,    0,
 -210,    0, -182, -192, -207,    0,    0,    0,    0, -259,
 -183, -186, -190,    0, -207,    0, -181, -180, -197,    0,
    0,    0,    0, -190,    0,    0,    0, -181, -191, -216,
    0,    0,    0,    0, -192,    0,    0, -178,    0, -175,
 -207,    0, -176, -175,    0,
  };
        protected static readonly short[] yyRindex = {            0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    1,    0,  144,
    0,    0,    0,    0,  128,    0,    0,  129,    0,    0,
   85,    0,    0,    0,    0,    0,    0,    0,    0,   33,
    0,    0,   92,    0,    0, -179,    0,    0,    0,    0,
    0,    0,    0,   65,    4,    0,    0,    0,    0, -252,
 -174,    0,    0,    0,   17,    0, -172,   81,   85,    0,
    0,    0,    0, -179,    0,    0,    0, -172,    0,    0,
    0,    0,    0,    0,   65,    0,    0,   97,    0,    0,
   49,    0,  112,    0,    0,
  };
        protected static readonly short[] yyGindex = {            0,
   -5,    0,   12,   -9,    0,    0,    0,    8,   21,    0,
  -25,    0,    2,    0,    0,   10,    0,   -4,  -41,    0,
    0,   22,    0,
  };
        protected static readonly short[] yyTable = {            43,
    9,   57,   41,   17,   19,   31,   33,   26,   37,   26,
   26,   44,   70,   71,   72,   37,   17,   42,   22,   25,
   28,   25,   28,   28,   25,   29,   45,   82,   34,   69,
   10,   50,   15,   11,    5,   59,    7,    4,   53,   26,
   60,   86,   46,   49,    3,    2,    8,    6,   17,   25,
   63,    1,   28,   56,   64,   87,   37,   76,   38,   12,
   13,   14,   15,   16,   22,   93,   17,   18,   60,   46,
   36,   52,   55,   58,   53,   65,   67,   74,   85,   78,
   26,   75,   91,   94,   51,   77,   89,   84,   41,   95,
   80,   51,   90,   42,    0,   83,   27,   24,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,   34,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,   17,   44,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,   17,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,
    0,    9,    0,    9,    9,    9,    9,    9,    9,    9,
   17,    9,    9,    9,    9,    9,   17,   17,    0,   17,
    0,   17,    0,    0,   17,   17,    0,   17,   17,   17,
   17,   17,   15,   15,    0,    0,    0,   15,    0,    0,
   15,   15,    0,   15,   15,   15,   15,   15,   17,   17,
    0,    0,    0,   17,    0,    0,   17,   17,    0,   17,
   17,   17,   17,   17,   22,   22,    0,    0,    0,   22,
    0,    0,   22,    0,    0,   22,   22,   22,   22,   22,
   26,   26,    0,    0,    0,   26,    0,    0,   26,   26,
    0,   15,   26,   26,   26,   26,   27,   27,    0,    0,
   15,   27,   15,    0,   27,   27,   15,    0,   27,   27,
   27,   27,   34,    0,    0,    0,   34,    0,    0,   34,
   34,    0,   34,   34,   34,   34,   34,   17,   17,    0,
   17,   17,    0,    0,   17,   44,   17,   17,   17,   17,
    0,    0,   17,   17,   17,    0,   17,    0,   17,    0,
    0,   17,   17,    0,   17,   17,   17,   17,
  };
        protected static readonly short[] yyCheck = {            25,
    0,   43,  260,    0,   10,   15,   16,   13,  261,   15,
   16,  260,  272,  273,  274,  268,    0,  275,   11,   12,
   13,   14,   15,   16,   17,   14,  275,   69,   17,   55,
  262,   37,    0,  262,   67,   45,   69,   70,  263,   45,
   46,  258,  267,   36,   77,   78,   79,   80,    0,   42,
  261,   84,   45,   42,  265,  272,  264,   63,  266,  262,
  262,  262,  262,  262,    0,   91,  262,  258,   74,  267,
  260,  259,  258,  258,  263,  258,  269,  261,  270,  261,
    0,  268,  258,  260,    0,   65,   85,   78,  268,   94,
  271,    0,  271,  268,   -1,   74,    0,  270,   -1,   -1,
   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
   -1,    0,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,   -1,   -1,   -1,    0,    0,   -1,
   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
   -1,   -1,   -1,    0,   -1,   -1,   -1,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,   -1,
   -1,  261,   -1,  263,  264,  265,  266,  267,  268,  269,
  267,  271,  272,  273,  274,  275,  260,  261,   -1,  263,
   -1,  265,   -1,   -1,  268,  269,   -1,  271,  272,  273,
  274,  275,  260,  261,   -1,   -1,   -1,  265,   -1,   -1,
  268,  269,   -1,  271,  272,  273,  274,  275,  260,  261,
   -1,   -1,   -1,  265,   -1,   -1,  268,  269,   -1,  271,
  272,  273,  274,  275,  260,  261,   -1,   -1,   -1,  265,
   -1,   -1,  268,   -1,   -1,  271,  272,  273,  274,  275,
  260,  261,   -1,   -1,   -1,  265,   -1,   -1,  268,  269,
   -1,  260,  272,  273,  274,  275,  260,  261,   -1,   -1,
  269,  265,  271,   -1,  268,  269,  275,   -1,  272,  273,
  274,  275,  261,   -1,   -1,   -1,  265,   -1,   -1,  268,
  269,   -1,  271,  272,  273,  274,  275,  260,  260,   -1,
  263,  263,   -1,   -1,  267,  267,  269,  269,  271,  271,
   -1,   -1,  275,  275,  261,   -1,  263,   -1,  265,   -1,
   -1,  268,  269,   -1,  271,  272,  273,  274,
  };

    }
}
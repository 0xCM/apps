//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;
    using static AsmSigTokens;
    using static AsmSigTokens.BCastComposite;
    using static AsmSigTokens.KRmToken;
    using static AsmSigTokens.GpRmToken;
    using static AsmSigTokens.VecRmToken;
    using static AsmSigTokens.GpRegTriple;
    using static AsmSigTokens.GpRmTriple;
    using static AsmSigTokens.MemToken;
    using static AsmSigTokens.MaskRegToken;


    using K = AsmSigTokenKind;


    public class AsmSigDatasets
    {
        public static ConstLookup<uint,AsmSigOp> sigops(AsmSigTokenSet ts)
        {
            var tokens = ts.View;
            var count = (uint)tokens.Length;
            var kinds = Symbols.index<AsmSigTokenKind>();
            var dst = dict<uint,AsmSigOp>();
            for(var i=0; i<count; i++)
            {
                ref readonly var symtoken = ref skip(tokens,i);
                ref readonly var @class = ref symtoken.Class;
                if(kinds.ExprKind(@class.Kind, out var kind))
                {
                    var sigtoken = new AsmSigOp(kind, (byte)symtoken.Value);
                    dst[sigtoken.Id] = sigtoken;
                }
                else
                    Errors.Throw(string.Format("Kind for {0} not found", @class.Kind));
            }

            return dst;
        }

        [MethodImpl(Inline)]
        public static AsmSigToken token<T>(AsmSigTokenKind kind, T value)
            where T : unmanaged
                => new AsmSigToken(kind, u8(value));

        public static ConstLookup<uint,AsmSigNonterminal> nonterminals()
        {
            var buffer = span<AsmSigNonterminal>(256);
            var count = nonterminals(buffer);
            var src = slice(buffer,0,count);
            var dst = dict<uint,AsmSigNonterminal>();
            for(var i=0; i<count;i++)
            {
                ref readonly var nonterm = ref skip(src,i);
                if(!dst.TryAdd(nonterm.Source.Id, nonterm))
                    Errors.Throw(string.Format("Duplicate source: {0} | {1} | {2}", nonterm.Source.Id, nonterm.Source.Kind, nonterm.Source.Value));
            }

            return dst;
        }

        public static uint nonterminals(Span<AsmSigNonterminal> buffer)
        {
            var i=0u;
            var dst = new AsmSigNonterminal();
            dst.Source = token(K.BCastComposite, x128x32bcst);
            dst.Term1 = token(K.VecReg, VRegToken.xmm);
            dst.Term2 = token(K.Mem, m128);
            dst.Term3 = token(K.BCastMem, BCastMem.m32bcst);
            seek(buffer,i++) = dst;

            dst.Source = token(K.BCastComposite, x128x64bcst);
            dst.Term1 = token(K.VecReg, VRegToken.xmm);
            dst.Term2 = token(K.Mem, m128);
            dst.Term3 = token(K.BCastMem, BCastMem.m64bcst);
            seek(buffer,i++) = dst;

            dst.Source = token(K.BCastComposite, y256x32bcst);
            dst.Term1 = token(K.VecReg, VRegToken.ymm);
            dst.Term2 = token(K.Mem, m256);
            dst.Term3 = token(K.BCastMem, BCastMem.m32bcst);
            seek(buffer,i++) = dst;

            dst.Source = token(K.BCastComposite, y256x64bcst);
            dst.Term1 = token(K.VecReg, VRegToken.ymm);
            dst.Term2 = token(K.Mem, m256);
            dst.Term3 = token(K.BCastMem, BCastMem.m64bcst);
            seek(buffer,i++) = dst;

            dst.Source = token(K.BCastComposite, z512x32bcst);
            dst.Term1 = token(K.VecReg, VRegToken.zmm);
            dst.Term2 = token(K.Mem, m512);
            dst.Term3 = token(K.BCastMem, BCastMem.m32bcst);
            seek(buffer,i++) = dst;

            dst.Source = token(K.BCastComposite, z512x64bcst);
            dst.Term1 = token(K.VecReg, VRegToken.zmm);
            dst.Term2 = token(K.Mem, m512);
            dst.Term3 = token(K.BCastMem, BCastMem.m64bcst);
            seek(buffer,i++) = dst;

            dst.Source = token(K.GpRm, rm8);
            dst.Term1 = token(K.GpReg, GpRegToken.r8);
            dst.Term2 = token(K.Mem, m8);
            dst.Term3 = AsmSigToken.Empty;
            seek(buffer,i++) = dst;

            dst.Source = token(K.GpRm, rm16);
            dst.Term1 = token(K.GpReg, GpRegToken.r16);
            dst.Term2 = token(K.Mem, m16);
            dst.Term3 = AsmSigToken.Empty;
            seek(buffer,i++) = dst;

            dst.Source = token(K.GpRm, rm32);
            dst.Term1 = token(K.GpReg, GpRegToken.r32);
            dst.Term2 = token(K.Mem, m32);
            dst.Term3 = AsmSigToken.Empty;
            seek(buffer,i++) = dst;

            dst.Source = token(K.GpRm, rm64);
            dst.Term1 = token(K.GpReg, GpRegToken.r64);
            dst.Term2 = token(K.Mem, m64);
            dst.Term3 = AsmSigToken.Empty;
            seek(buffer,i++) = dst;

            dst.Source = token(K.GpRm, r16m16);
            dst.Term1 = token(K.GpReg, GpRegToken.r16);
            dst.Term2 = token(K.Mem, m16);
            dst.Term3 = AsmSigToken.Empty;
            seek(buffer,i++) = dst;

            dst.Source = token(K.GpRm, r32m8);
            dst.Term1 = token(K.GpReg, GpRegToken.r32);
            dst.Term2 = token(K.Mem, m8);
            dst.Term3 = AsmSigToken.Empty;
            seek(buffer,i++) = dst;

            dst.Source = token(K.GpRm, r32m16);
            dst.Term1 = token(K.GpReg, GpRegToken.r32);
            dst.Term2 = token(K.Mem, m16);
            dst.Term3 = AsmSigToken.Empty;
            seek(buffer,i++) = dst;

            dst.Source = token(K.GpRm, r32m32);
            dst.Term1 = token(K.GpReg, GpRegToken.r32);
            dst.Term2 = token(K.Mem, m32);
            dst.Term3 = AsmSigToken.Empty;
            seek(buffer,i++) = dst;

            dst.Source = token(K.GpRm, r64m16);
            dst.Term1 = token(K.GpReg, GpRegToken.r64);
            dst.Term2 = token(K.Mem, m16);
            dst.Term3 = AsmSigToken.Empty;
            seek(buffer,i++) = dst;

            dst.Source = token(K.GpRm, r64m32);
            dst.Term1 = token(K.GpReg, GpRegToken.r64);
            dst.Term2 = token(K.Mem, m32);
            dst.Term3 = AsmSigToken.Empty;
            seek(buffer,i++) = dst;

            dst.Source = token(K.GpRm, r64m64);
            dst.Term1 = token(K.GpReg, GpRegToken.r64);
            dst.Term2 = token(K.Mem, m64);
            dst.Term3 = AsmSigToken.Empty;
            seek(buffer,i++) = dst;

            dst.Source = token(K.GpRm, regm8);
            dst.Term1 = token(K.GpReg, GpRegToken.r8);
            dst.Term2 = token(K.Mem, m8);
            dst.Term3 = AsmSigToken.Empty;
            seek(buffer,i++) = dst;

            dst.Source = token(K.GpRm, regm16);
            dst.Term1 = token(K.GpReg, GpRegToken.r16);
            dst.Term2 = token(K.Mem, m16);
            dst.Term3 = AsmSigToken.Empty;
            seek(buffer,i++) = dst;

            dst.Source = token(K.KRm, km8);
            dst.Term1 = token(K.GpReg, k1);
            dst.Term2 = token(K.Mem, m8);
            dst.Term3 = AsmSigToken.Empty;
            seek(buffer,i++) = dst;

            dst.Source = token(K.KRm, km16);
            dst.Term1 = token(K.GpReg, k1);
            dst.Term2 = token(K.Mem, m16);
            dst.Term3 = AsmSigToken.Empty;
            seek(buffer,i++) = dst;

            dst.Source = token(K.KRm, km32);
            dst.Term1 = token(K.GpReg, k1);
            dst.Term2 = token(K.Mem, m32);
            dst.Term3 = AsmSigToken.Empty;
            seek(buffer,i++) = dst;

            dst.Source = token(K.KRm, km64);
            dst.Term1 = token(K.GpReg, k1);
            dst.Term2 = token(K.Mem, m64);
            dst.Term3 = AsmSigToken.Empty;
            seek(buffer,i++) = dst;

            dst.Source = token(K.VecRm, xmm8);
            dst.Term1 = token(K.GpReg, VRegToken.xmm);
            dst.Term2 = token(K.Mem, m8);
            dst.Term3 = AsmSigToken.Empty;
            seek(buffer,i++) = dst;

            dst.Source = token(K.VecRm, xmm16);
            dst.Term1 = token(K.GpReg, VRegToken.xmm);
            dst.Term2 = token(K.Mem, m16);
            dst.Term3 = AsmSigToken.Empty;
            seek(buffer,i++) = dst;

            dst.Source = token(K.VecRm, xmm32);
            dst.Term1 = token(K.GpReg, VRegToken.xmm);
            dst.Term2 = token(K.Mem, m32);
            dst.Term3 = AsmSigToken.Empty;
            seek(buffer,i++) = dst;

            dst.Source = token(K.VecRm, xmm64);
            dst.Term1 = token(K.GpReg, VRegToken.xmm);
            dst.Term2 = token(K.Mem, m64);
            dst.Term3 = AsmSigToken.Empty;
            seek(buffer,i++) = dst;

            dst.Source = token(K.VecRm, xmm128);
            dst.Term1 = token(K.GpReg, VRegToken.xmm);
            dst.Term2 = token(K.Mem, m128);
            dst.Term3 = AsmSigToken.Empty;
            seek(buffer,i++) = dst;

            dst.Source = token(K.VecRm, ymm256);
            dst.Term1 = token(K.GpReg, VRegToken.ymm);
            dst.Term2 = token(K.Mem, m256);
            dst.Term3 = AsmSigToken.Empty;
            seek(buffer,i++) = dst;

            dst.Source = token(K.VecRm, zmm512);
            dst.Term1 = token(K.GpReg, VRegToken.zmm);
            dst.Term2 = token(K.Mem, m512);
            dst.Term3 = AsmSigToken.Empty;
            seek(buffer,i++) = dst;

            dst.Source = token(K.GpRegTriple, r16r32r64);
            dst.Term1 = token(K.GpReg, GpRegToken.r16);
            dst.Term2 = token(K.Mem, GpRegToken.r32);
            dst.Term3 = token(K.Mem, GpRegToken.r64);
            seek(buffer,i++) = dst;

            dst.Source = token(K.GpRmTriple, r16r32m16);
            dst.Term1 = token(K.GpReg, GpRegToken.r16);
            dst.Term2 = token(K.Mem, GpRegToken.r32);
            dst.Term3 = token(K.Mem, m16);
            seek(buffer,i++) = dst;

            dst.Source = token(K.MmxRm, MmxRmToken.mm32);
            dst.Term1 = token(K.GpReg, MmxRegToken.mm);
            dst.Term2 = token(K.Mem, m32);
            dst.Term3 = AsmSigToken.Empty;
            seek(buffer,i++) = dst;

            dst.Source = token(K.MmxRm, MmxRmToken.mm64);
            dst.Term1 = token(K.GpReg, MmxRegToken.mm);
            dst.Term2 = token(K.Mem, m64);
            dst.Term3 = AsmSigToken.Empty;
            seek(buffer,i++) = dst;

            return i;
        }

        public Index<AsmSigOp> Tokens {get; private set;}

        //public ConstLookup<AsmSigTokenKind,Index<AsmSigOp>> OpsByKind {get; private set;}

        public ConstLookup<uint,string> TokenExpressions {get; private set;}

        public ConstLookup<uint,string> TokenIdentifiers {get; private set;}

        public ConstLookup<string,AsmSigOp> OpsByExpression {get; private set;}

        public Symbols<AsmModifierKind> Modifers {get; private set;}

        //public ConstLookup<Type,AsmSigTokenKind> TypeKinds {get; private set;}

        public ConstLookup<uint,AsmSigNonterminal> Nonterminals {get; private set;}

        // public AsmSigTokenKind Kind(Type src)
        //     => TypeKinds[src];

        // public ReadOnlySpan<AsmSigTokenKind> Kinds
        //     => TypeKinds.Values;

        AsmSigDatasets()
        {
        }

        static AsmSigDatasets _Instance;

        static object locker = new object();


        public static AsmSigDatasets load()
        {
            lock(locker)
            {
                if(_Instance == null)
                {
                    var dst = new AsmSigDatasets();
                    var kinds = Symbols.index<AsmSigTokenKind>();
                    var ts = AsmSigTokenSet.create();
                    //dst.TypeKinds = ts.TypeKinds();
                    var symtokens = ts.View;
                    var count = (uint)symtokens.Length;
                    dst.Tokens = alloc<AsmSigOp>(count);

                    var tokenExpr = dict<uint,string>();
                    var tokenIds = dict<uint,string>();
                    var exprToken = dict<string,AsmSigOp>();
                    var j=0;

                    for(var i=0; i<count; i++)
                    {
                        ref readonly var symtoken = ref skip(symtokens,i);
                        ref readonly var @class = ref symtoken.Class;
                        if(kinds.ExprKind(@class.Kind, out var kind))
                        {
                            var sigtoken = new AsmSigOp(kind, (byte)symtoken.Value);
                            var xpr = symtoken.Expr.Text;
                            dst.Tokens[j++] = sigtoken;
                            tokenExpr[sigtoken.Id] = xpr;
                            exprToken[xpr] = sigtoken;
                            if(!tokenIds.TryAdd(sigtoken.Id, symtoken.Name))
                                Errors.Throw(string.Format("Duplicate token - {0}:{1}", kind, symtoken.Name));
                        }
                        else
                            Errors.Throw(string.Format("Kind for {0} not found", @class.Kind));
                    }

                    //dst.OpsByKind = dst.Tokens.GroupBy(t => t.Kind).Select(x => (x.Key, (Index<AsmSigOp>)x.Array())).ToDictionary();
                    dst.TokenExpressions = tokenExpr;
                    dst.OpsByExpression = exprToken;
                    dst.TokenIdentifiers = tokenIds;
                    dst.Modifers = Symbols.index<AsmModifierKind>();
                    dst.Nonterminals = nonterminals();
                    //dst.Nonterminals = dict<uint,AsmSigNonterminal>();
                    _Instance = dst;
                }

                return _Instance;
            }
        }
    }
}
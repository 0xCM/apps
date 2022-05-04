//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedModels;

    partial class XedRules
    {
        public readonly struct InstCells : IIndex<CellValue>
        {
            [MethodImpl(Inline), Op]
            public static InstCells sort(in InstCells src)
            {
                var data = src.Data;
                var count = (byte)data.Count;
                var eCount = z8;
                var lCount = z8;
                for(var i=z8; i<count; i++)
                {
                    ref var field = ref data[i];
                    if(field.IsExpr)
                        eCount++;
                    else
                        lCount++;
                }

                var lIx = z8;
                var eIx = lCount;
                for(var i=z8; i<count; i++)
                {
                    ref var field = ref data[i];
                    if(field.IsExpr)
                        field = field.WithPosition(eIx++);
                    else
                        field = field.WithPosition(lIx++);
                }

                return new InstCells(data.Sort(), lCount);
            }

            public static VexClass vex(in InstCells src)
            {
                var result = VexClass.None;
                if(src.Count != 0)
                {
                    var k = (VexClass)src.First.AsIntLit();
                    switch(k)
                    {
                        case VexClass.VV1:
                        case VexClass.EVV:
                        case VexClass.XOPV:
                        case VexClass.KVV:
                            result = k;
                        break;
                    }
                }
                return result;
            }

            [MethodImpl(Inline), Op]
            public static FieldSet usage(in InstCells src)
            {
                var dst = FieldSet.create();
                for(var j=0; j<src.Count; j++)
                    dst = dst.Include(src[j].Field);
                return dst;
            }

            [MethodImpl(Inline), Op]
            public static XedOpCode opcode(in InstCells src)
                => XedOpCodes.opcode(src);

            [MethodImpl(Inline), Op]
            public static LockIndicator @lock(in InstCells src)
                => new (lockable(src), locked(src));

            [MethodImpl(Inline), Op]
            public static ChipCode chip(in InstCells src)
            {
                var dst = ChipCode.INVALID;
                for(var i=0; i<src.Count; i++)
                {
                    ref readonly var f = ref src[i];

                    if(f.IsExpr && f.Field == FieldKind.CHIP)
                    {
                        dst = f.ToCellExpr().Value;
                        break;
                    }
                }
                return dst;
            }

            [MethodImpl(Inline), Op]
            public static bit lockable(in InstCells src)
            {
                var result = bit.Off;
                for(var i=0; i<src.Count; i++)
                {
                    ref readonly var field = ref src[i];
                    result = field.Field == FieldKind.LOCK;
                    if(result)
                        break;
                }
                return result;
            }

            [MethodImpl(Inline), Op]
            public static bit @locked(in InstCells src)
            {
                var result = bit.Off;
                for(var i=0; i<src.Count; i++)
                {
                    ref readonly var field = ref src[i];
                    if(field.Field == FieldKind.LOCK)
                    {
                        result = field.ToCellExpr().Value;
                        break;
                    }
                }
                return result;
            }

            [MethodImpl(Inline), Op]
            public static BitIndicator rexr(in InstCells src)
            {
                var dst = BitIndicator.Empty;
                for(var i=0; i<src.Count; i++)
                {
                    ref readonly var f = ref src[i];
                    if(f.IsExpr && f.Field == FieldKind.REXR)
                    {
                        dst = BitIndicator.defined(f.ToCellExpr().Value);
                        break;
                    }
                }
                return dst;
            }

            [MethodImpl(Inline), Op]
            public static BitIndicator rexb(in InstCells src)
            {
                var dst = BitIndicator.Empty;
                for(var i=0; i<src.Count; i++)
                {
                    ref readonly var f = ref src[i];
                    if(f.IsExpr && f.Field == FieldKind.REXB)
                    {
                        dst = BitIndicator.defined(f.ToCellExpr().Value);
                        break;
                    }
                }
                return dst;
            }

            [MethodImpl(Inline), Op]
            public static BitIndicator rexx(in InstCells src)
            {
                var dst = BitIndicator.Empty;
                for(var i=0; i<src.Count; i++)
                {
                    ref readonly var f = ref src[i];
                    if(f.IsExpr && f.Field == FieldKind.REXX)
                    {
                        dst = BitIndicator.defined(f.ToCellExpr().Value);
                        break;
                    }
                }
                return dst;
            }

            [MethodImpl(Inline), Op]
            public static ModIndicator mod(in InstCells src)
            {
                var result = false;
                var dst = ModIndicator.Empty;
                for(var i=0; i<src.Count; i++)
                {
                    ref readonly var field = ref src[i];
                    if(field.Field == FieldKind.MOD && field.IsExpr)
                    {
                        var expr = field.ToCellExpr();
                        if(expr.Operator == OperatorKind.Ne)
                        {
                            dst = ModKind.NE3;
                            result = true;
                            break;
                        }
                        else if(expr.Operator == OperatorKind.Eq)
                        {
                            dst = ModKind.MOD3;
                            result = true;
                            break;
                        }
                    }
                }
                return dst;
            }

            [MethodImpl(Inline), Op]
            public static BitIndicator rexw(in InstCells src)
            {
                var dst = BitIndicator.Empty;
                for(var i=0; i<src.Count; i++)
                {
                    ref readonly var f = ref src[i];
                    if(f.IsExpr && f.Field == FieldKind.REXW)
                    {
                        dst = BitIndicator.defined(f.ToCellExpr().Value);
                        break;
                    }
                }
                return dst;
            }

            [MethodImpl(Inline), Op]
            public static RepIndicator @rep(in InstCells src)
            {
                var dst = RepIndicator.Empty;
                for(var i=0; i<src.Count; i++)
                {
                    ref readonly var field = ref src[i];
                    if(field.Field == FieldKind.REP)
                    {
                        dst = (RepPrefix)field.ToCellExpr().Value;
                        break;
                    }
                }
                return dst;
            }

            [MethodImpl(Inline), Op]
            public static MachineMode mode(in InstCells src)
            {
                var result = ModeClass.Default;
                for(var i=0; i<src.Count; i++)
                {
                    ref readonly var f = ref src[i];
                    if(f.IsExpr && f.Field == FieldKind.MODE)
                        result = f.ToCellExpr().Value;
                }
                return result;
            }

            public readonly Index<CellValue> Data;

            public readonly byte LayoutCount;

            [MethodImpl(Inline)]
            public InstCells(CellValue[] src, byte lCount)
            {
                Data = src;
                LayoutCount = lCount;
            }

            public ReadOnlySpan<CellValue> Layout
            {
                [MethodImpl(Inline)]
                get => IsEmpty ? default : core.slice(Data.View, 0, LayoutCount);
            }

            public ReadOnlySpan<CellValue> Expr
            {
                [MethodImpl(Inline)]
                get => IsEmpty ?  default :core.slice(Data.View, LayoutCount);
            }

            public CellValue[] Storage
            {
                [MethodImpl(Inline)]
                get => Data;
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Data.IsEmpty;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get =>  Data.IsNonEmpty;
            }

            public ref CellValue First
            {
                [MethodImpl(Inline)]
                get => ref Data.First;
            }

            public ref CellValue this[int i]
            {
                [MethodImpl(Inline)]
                get => ref Data[i];
            }

            public ref CellValue this[uint i]
            {
                [MethodImpl(Inline)]
                get => ref Data[i];
            }

            public byte Count
            {
                [MethodImpl(Inline)]
                get => (byte)Data.Count;
            }

            public byte ExprCount
            {
                [MethodImpl(Inline)]
                get => (byte)(Count - LayoutCount);
            }

            public string Format()
                => this.Delimit(Chars.Space).Format();

            public override string ToString()
                => Format();
        }
    }
}
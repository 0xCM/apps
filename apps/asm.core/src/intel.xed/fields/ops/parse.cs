//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static XedModels;
    using static XedRules;
    using static core;

    using R = XedRules;
    using C = XedRules.FormatCode;
    using K = XedRules.FieldKind;

    partial class XedFields
    {
        public static Outcome parse(FieldKind kind, string src, out R.FieldValue dst)
        {
            Outcome result = (false,AppMsg.ParseFailure.Format(kind.ToString(), src));
            dst = R.FieldValue.Empty;
            switch(kind)
            {
                case K.MOD:
                {
                    if(XedParsers.parse(src, out byte a))
                        dst = value(kind,a);
                }
                break;
                case K.VEXVALID:
                {
                    if(XedParsers.parse(src, out VexClass a))
                        dst = value(kind,a);
                }
                break;
                case K.VEX_PREFIX:
                {
                    if(XedParsers.parse(src, out VexKind a))
                        dst = value(kind,a);
                }
                break;
                case K.EASZ:
                {
                    if(XedParsers.parse(src, out EASZ a))
                        dst = value(kind,a);
                    else
                    {
                        if(XedParsers.parse(src, out byte b))
                            dst = b switch{
                                16 => value(kind, 1),
                                32 => value(kind, 2),
                                64 => value(kind, 3),
                                _ => R.FieldValue.Empty
                            };
                    }
                }
                break;
                case K.SMODE:
                {
                    if(XedParsers.parse(src, out SMode a))
                        dst = value(kind,a);
                    else
                    {
                        if(XedParsers.parse(src, out byte b))
                            dst = b switch{
                                16 => value(kind, 0),
                                32 => value(kind, 1),
                                64 => value(kind, 2),
                                _ => R.FieldValue.Empty
                            };
                    }
                }
                break;
                case K.MODE:
                {
                    if(XedParsers.parse(src, out byte a))
                        dst = value(kind,a);
                    else if(XedParsers.parse(src, out ModeKind b))
                        dst = value(kind,a);
                    else
                        Errors.Throw(AppMsg.ParseFailure.Format(nameof(K.MODE), src));
                }
                break;
                case K.EOSZ:
                {
                    if(XedParsers.parse(src, out EOSZ a))
                        dst = value(kind,a);
                    else
                    {
                        if(XedParsers.parse(src, out byte b))
                            dst = b switch
                            {
                                8 => value(kind,0),
                                16 => value(kind,1),
                                32 => value(kind,2),
                                64 => value(kind,3),
                                _=> R.FieldValue.Empty,
                            };
                    }
                }
                break;
            }

            if(dst.IsNonEmpty)
                result = true;

            if(result.Fail)
            {
                if(XedParsers.parse(src, out uint8b a))
                {
                    dst = value(kind, a);
                    result = true;
                }
                else if(XedParsers.parse(src, out Hex8 b))
                {
                    dst = value(kind, b);
                    result = true;
                }
                else if(XedParsers.parse(src, out byte c))
                {
                    dst = value(kind, c);
                    result = true;
                }
                else if(ushort.TryParse(src, out var d))
                {
                    dst = value(kind, d);
                    result = true;
                }
            }

            return result;
        }
    }
}
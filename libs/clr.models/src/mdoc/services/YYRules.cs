//-----------------------------------------------------------------------------
// Origin: (c) 1998 Axel.Schreiner@informatik.uni-osnabrueck.de
//-----------------------------------------------------------------------------
namespace Monodoc.Ecma
{
    // Put this array into a separate class so it is only initialized if debugging is actually used
    // Use MarshalByRefObject to disable inlining
    class YYRules : MarshalByRefObject
    {
        public static readonly string[] yyRule = {
        "$accept : expression",
        "expression : 'T' COLON type_expression",
        "expression : 'N' COLON namespace_expression",
        "expression : 'M' COLON method_expression",
        "expression : 'F' COLON simple_member_expression",
        "expression : 'C' COLON constructor_expression",
        "expression : 'P' COLON property_expression",
        "expression : 'E' COLON simple_member_expression",
        "expression : 'O' COLON operator_expression",
        "dot_expression : IDENTIFIER",
        "dot_expression : IDENTIFIER DOT dot_expression",
        "namespace_expression : dot_expression",
        "type_expression : dot_expression type_expression_suffix",
        "reduced_type_expression : IDENTIFIER type_expression_suffix",
        "type_expression_suffix : opt_generic_type_suffix opt_inner_type_description opt_array_definition opt_etc",
        "opt_inner_type_description :",
        "opt_inner_type_description : INNER_TYPE_SEPARATOR reduced_type_expression",
        "opt_generic_type_suffix :",
        "opt_generic_type_suffix : OP_GENERICS_BACKTICK DIGIT",
        "opt_generic_type_suffix : OP_GENERICS_LT generic_type_arg_list OP_GENERICS_GT",
        "generic_type_arg_list : type_expression",
        "generic_type_arg_list : generic_type_arg_list COMMA type_expression",
        "opt_array_definition :",
        "opt_array_definition : OP_ARRAY_OPEN opt_array_definition_list OP_ARRAY_CLOSE opt_array_definition",
        "opt_array_definition_list :",
        "opt_array_definition_list : COMMA opt_array_definition_list",
        "opt_etc :",
        "opt_etc : SLASH_SEPARATOR etc_identifier",
        "opt_etc : SLASH_SEPARATOR etc_identifier SLASH_SEPARATOR reduced_member_expression",
        "etc_identifier : STAR",
        "etc_identifier : IDENTIFIER",
        "method_expression : type_expression DOT IDENTIFIER opt_generic_type_suffix opt_arg_list_suffix",
        "method_expression : dot_expression opt_generic_type_suffix opt_arg_list_suffix",
        "method_expression : type_expression EXPLICIT_IMPL_SEP method_expression",
        "reduced_member_expression : IDENTIFIER opt_generic_type_suffix",
        "reduced_member_expression : IDENTIFIER opt_generic_type_suffix DOT reduced_member_expression",
        "arg_type_expression : type_expression opt_arg_type_suffix",
        "opt_arg_type_suffix :",
        "opt_arg_type_suffix : STAR",
        "opt_arg_type_suffix : REF_ARG",
        "opt_arg_type_suffix : OUT_ARG",
        "type_expression_list :",
        "type_expression_list : arg_type_expression",
        "type_expression_list : arg_type_expression COMMA type_expression_list",
        "simple_member_expression : dot_expression",
        "simple_member_expression : type_expression DOT IDENTIFIER",
        "simple_member_expression : type_expression EXPLICIT_IMPL_SEP simple_member_expression",
        "constructor_expression : method_expression",
        "operator_expression : method_expression",
        "property_expression : simple_member_expression opt_property_indexer",
        "opt_property_indexer : opt_arg_list_suffix",
        "opt_arg_list_suffix :",
        "opt_arg_list_suffix : OP_OPEN_PAREN type_expression_list OP_CLOSE_PAREN",
        };

        public static string getRule(int index)
        {
            return yyRule[index];
        }
    }   
}

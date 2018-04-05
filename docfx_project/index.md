# Albatross Expression Api

## Summary
This is an expression parsing and evaluation Api.  The api can parse groups of single statement expressions.  It supports math operations as well as some of the programming and string operations such as ``if, left, right, max, min`` etc.

## Release
* Current
    * Not yet released
    * Breaking Changes
        * Mininum target framework has been changed from net40 to net45.
        * Precedence for ``and, or`` operations has been set to the lowest (30, 20) among all infix operations.  As the result of this change, the following expression will now return true: ``2 > 1 and 3 > 1``.
        * [IParser](xref:Albatross.Expression.IParser) interface no longer has the ``SetVariableToken`` and ``SetStringLiteralToken`` methods.  That means Variabletoken or StringLiteralToken types can no longer be changed after thge parser has been created.
        * Change to the constructor of the [Parser](xref:Albatross.Expression.Parser) class to require two additional parameter [IVariableToken](xref:Albatross.Expression.Tokens.IVariableToken) and [IStringLiteralToken](xref:Albatross.Expression.Tokens.IVariableToken).
    * [ParserOperationAttribute](xref:Albatross.Expression.ParserOperationAttribute) (new)
        * A custom attribute used to mark the operations so that it will be used by the Factory class when constructing a parser object.
    * [Factory](xref:Albatross.Expression.Factory) class (new)
        * Allow quick creation of a Parser instance.
        * The class can scan an assembly and register any parser operation class with [ParserOperationAttribute](xref:Albatross.Expression.ParserOperationAttribute) attribute.
    * [ExpressionBuilder](xref:Albatross.Expression.ExpressionBuilder) is marked as Obsolete.
    * Add additional target framework netstandard2.0
    * Strengthen Unit testing.
    * Add lots of documentation.
* 1.3.6218.36673 - Orignal release
    * Created: 1/10/2017
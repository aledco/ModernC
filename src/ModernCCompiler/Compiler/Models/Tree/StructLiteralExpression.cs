using Compiler.ErrorHandling;
using Compiler.Models.Context;
using Compiler.Models.NameResolution;
using Compiler.Models.NameResolution.Types;

namespace Compiler.Models.Tree
{
    public class StructLiteralExpression : ComplexLiteralExpression
    {
        public IList<StructLiteralField> Fields { get; }
        public StructDefinition? StructDefinition { get; private set; }
        public int Offset { get; set; }

        public StructLiteralExpression(Span span, IList<StructLiteralField> fields) : base(span)
        {
            Fields = fields;
        }

        public void MapDefaultExpressionsFromDefinition(StructType type, StructDefinition definition)
        {
            
            StructDefinition = definition;
            foreach (var fieldDefinition in definition.Fields)
            {
                var field = Fields.Where(f => f.Id.Value == fieldDefinition.Id.Value).FirstOrDefault();
                if (field == null)
                {
                    if (fieldDefinition.DefaultExpression == null)
                    {
                        ErrorHandler.Throw("Struct fields without default expressions must be initialized in a struct literal", this);
                    }
                    else
                    {
                        field = fieldDefinition.CreateDefaultLiteralField(Span);
                        Fields.Add(field);
                    }
                }
            }
        }

        public void MapOffsetsFromDefinition()
        {
            foreach (var fieldDefinition in StructDefinition!.Fields)
            {
                var field = Fields.Where(f => f.Id.Value == fieldDefinition.Id.Value).FirstOrDefault();
                field!.Offset = fieldDefinition.Offset;
            }
        }

        public override Expression Copy(Span span)
        {
            return new StructLiteralExpression(span, Fields)
            {
                StructDefinition = StructDefinition
            };
        }

        public override SemanticType GlobalTypeCheck(GlobalTypeCheckContext context)
        {
            var variableAssignmentType = context.VariableAssignmentType;
            if (variableAssignmentType?.BaseType is UserDefinedType userDefinedType)
            {
                var (structType, definition) = SymbolTable.LookupTypeAndDefinition<StructType, StructDefinition>(userDefinedType, Span);
                MapDefaultExpressionsFromDefinition(structType, definition);
                foreach (var field in Fields)
                {
                    var fieldDefinition = definition.Fields.Where(f => field.Id.Value == f.Id.Value).FirstOrDefault();
                    if (fieldDefinition == null)
                    {
                        ErrorHandler.Throw("Struct does not have a definition for this field", this);
                    }

                    var fieldDefinitionType = fieldDefinition!.Type.ToSemanticType();

                    context.VariableAssignmentType = fieldDefinitionType;
                    var type = field.Expression.GlobalTypeCheck(context);
                    if (!fieldDefinition!.Type.ToSemanticType().TypeEquals(type))
                    {
                        ErrorHandler.Throw("Type does not match field definition", this);
                    }
                }

                context.VariableAssignmentType = variableAssignmentType;
                Type = structType;
                return Type;
            }

            ErrorHandler.Throw("Struct literal cannot be assigned to this type", this);
            throw ErrorHandler.FailedToExit;
        }
    }
}

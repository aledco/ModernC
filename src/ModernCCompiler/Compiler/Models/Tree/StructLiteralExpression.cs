using Compiler.Context;
using Compiler.ErrorHandling;
using Compiler.Models.NameResolution;
using Compiler.Models.NameResolution.Types;

namespace Compiler.Models.Tree
{
    /// <summary>
    /// The struct literal expression.
    /// </summary>
    public class StructLiteralExpression : ComplexLiteralExpression
    {
        /// <summary>
        /// Gets the struct literal fields.
        /// </summary>
        public IList<StructLiteralField> Fields { get; }

        /// <summary>
        /// Gets or sets the struct defintion.
        /// </summary>
        public StructDefinition? StructDefinition { get; private set; }
        
        /// <summary>
        /// Gets or sets the offset for code generation.
        /// </summary>
        public int Offset { get; set; }

        /// <summary>
        /// Initializes a new instance of a <see cref="StructLiteralExpression"/>.
        /// </summary>
        /// <param name="span">The span of the node.</param>
        /// <param name="fields">The fields.</param>
        public StructLiteralExpression(Span span, IList<StructLiteralField> fields) : base(span)
        {
            Fields = fields;
        }

        /// <summary>
        /// Maps defaults expressions from the definition to the literal.
        /// </summary>
        /// <param name="definition">The struct definition.</param>
        public void MapDefaultExpressionsFromDefinition(StructDefinition definition)
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

        /// <summary>
        /// Maps offsets from the definiton.
        /// </summary>
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

        public override SemanticType CheckGlobalSemantics(GlobalSemanticCheckContext context)
        {
            return CheckSemantics(context);
        }

        public override SemanticType CheckLocalSemantics(LocalSemanticCheckContext context)
        {
            return CheckSemantics(context);
        }

        /// <summary>
        /// Checks the semantics of the struct literal.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>The type.</returns>
        private SemanticType CheckSemantics(SemanticCheckContext context)
        {
            var assignmentLeftHandSideType = context.AssignmentLeftHandSideType;
            if (assignmentLeftHandSideType?.BaseType is UserDefinedType userDefinedType)
            {
                var (structType, definition) = SymbolTable.LookupTypeAndDefinition<StructType, StructDefinition>(userDefinedType, Span);
                MapDefaultExpressionsFromDefinition(definition);
                foreach (var field in Fields)
                {
                    var fieldDefinition = definition.Fields.Where(f => field.Id.Value == f.Id.Value).FirstOrDefault();
                    if (fieldDefinition == null)
                    {
                        ErrorHandler.Throw("Struct does not have a definition for this field", this);
                    }

                    var fieldDefinitionType = fieldDefinition!.Type.ToSemanticType();
                    context.AssignmentLeftHandSideType = fieldDefinitionType;
                    var type = field.Expression.CheckSemanticsInferred(context);
                    if (!fieldDefinition!.Type.ToSemanticType().TypeEquals(type))
                    {
                        ErrorHandler.Throw("Type does not match field definition", this);
                    }
                }

                context.AssignmentLeftHandSideType = assignmentLeftHandSideType;
                Type = structType;
                return Type;
            }

            ErrorHandler.Throw("Struct literal cannot be assigned to this type", this);
            throw ErrorHandler.FailedToExit;
        }
    }
}

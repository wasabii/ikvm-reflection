using System;
using System.Collections.Immutable;
using System.Reflection.Metadata;

namespace IKVM.Reflection.Metadata
{

    /// <summary>
    /// Decodes a metadata signature from a metadata module.
    /// </summary>
    internal class MetadataSignatureTypeProvider : ISignatureTypeProvider<TypeSignature, MetadataGenericContext>
    {

        readonly MetadataModule module;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="module"></param>
        public MetadataSignatureTypeProvider(MetadataModule module)
        {
            this.module = module ?? throw new ArgumentNullException(nameof(module));
        }

        public TypeSignature GetArrayType(TypeSignature elementType, ArrayShape shape)
        {
            var dimensions = new ArrayDimension[shape.Rank];
            for (int i = 0; i < shape.Rank; i++)
                dimensions[i] = new ArrayDimension(shape.Sizes.Length > i ? shape.Sizes[i] : null, shape.LowerBounds.Length > i ? shape.LowerBounds[i] : null);

            return new ArrayTypeSignature(elementType, dimensions);
        }

        public TypeSignature GetByReferenceType(TypeSignature elementType)
        {
            return new ByRefTypeSignature(elementType);
        }

        public TypeSignature GetFunctionPointerType(MethodSignature<TypeSignature> signature)
        {
            return new FunctionPointerTypeSignature(module.GetMethodSignature(signature));
        }

        public TypeSignature GetGenericInstantiation(TypeSignature genericType, ImmutableArray<TypeSignature> typeArguments)
        {
            return new GenericInstanceTypeSignature(genericType, typeArguments);
        }

        public TypeSignature GetGenericTypeParameter(MetadataGenericContext genericContext, int index)
        {
            return new GenericParameterTypeSignature(GenericParameterScope.Type, index);
        }

        public TypeSignature GetGenericMethodParameter(MetadataGenericContext genericContext, int index)
        {
            return new GenericParameterTypeSignature(GenericParameterScope.Method, index);
        }

        public TypeSignature GetModifiedType(TypeSignature modifier, TypeSignature unmodifiedType, bool isRequired)
        {
            return new CustomModifierTypeSignature(unmodifiedType, modifier, isRequired);
        }

        public TypeSignature GetPinnedType(TypeSignature elementType)
        {
            return new PinnedTypeSignature(elementType);
        }

        public TypeSignature GetPointerType(TypeSignature elementType)
        {
            return new PointerTypeSignature(elementType);
        }

        public TypeSignature GetPrimitiveType(System.Reflection.Metadata.PrimitiveTypeCode typeCode)
        {
            return new TypeRefTypeSignature(module.GetOrCreatePrimitiveTypeRef(typeCode));
        }

        public TypeSignature GetSZArrayType(TypeSignature elementType)
        {
            return new SzArrayTypeSignature(elementType);
        }

        public TypeSignature GetTypeFromDefinition(MetadataReader reader, TypeDefinitionHandle handle, byte rawTypeKind)
        {
            return new TypeDefTypeSignature(module.GetOrCreateType(handle));
        }

        public TypeSignature GetTypeFromReference(MetadataReader reader, TypeReferenceHandle handle, byte rawTypeKind)
        {
            return new TypeRefTypeSignature(module.GetOrCreateTypeRef(handle));
        }

        public TypeSignature GetTypeFromSpecification(MetadataReader reader, MetadataGenericContext genericContext, TypeSpecificationHandle handle, byte rawTypeKind)
        {
            return module.DecodeTypeSignature((EntityHandle)handle, genericContext);
        }

    }

}

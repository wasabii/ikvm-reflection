using System;
using System.Collections.Immutable;
using System.Reflection.Metadata;

namespace IKVM.Reflection.Metadata
{

    /// <summary>
    /// Decodes a metadata signature from a metadata module.
    /// </summary>
    internal class MetadataSignatureTypeProvider : ISignatureTypeProvider<TypeSig, MetadataGenericContext>
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

        public TypeSig GetArrayType(TypeSig elementType, ArrayShape shape)
        {
            var dimensions = new ArrayDimension[shape.Rank];
            for (int i = 0; i < shape.Rank; i++)
                dimensions[i] = new ArrayDimension(shape.Sizes.Length > i ? shape.Sizes[i] : null, shape.LowerBounds.Length > i ? shape.LowerBounds[i] : null);

            return new ArrayTypeSignature(elementType, dimensions);
        }

        public TypeSig GetByReferenceType(TypeSig elementType)
        {
            return new ByRefTypeSignature(elementType);
        }

        public TypeSig GetFunctionPointerType(MethodSignature<TypeSig> signature)
        {
            return new FunctionPointerTypeSignature(module.GetMethodSignature(signature));
        }

        public TypeSig GetGenericInstantiation(TypeSig genericType, ImmutableArray<TypeSig> typeArguments)
        {
            return new GenericInstanceTypeSignature(genericType, typeArguments);
        }

        public TypeSig GetGenericTypeParameter(MetadataGenericContext genericContext, int index)
        {
            return new GenericParameterTypeSignature(GenericParameterScope.Type, index);
        }

        public TypeSig GetGenericMethodParameter(MetadataGenericContext genericContext, int index)
        {
            return new GenericParameterTypeSignature(GenericParameterScope.Method, index);
        }

        public TypeSig GetModifiedType(TypeSig modifier, TypeSig unmodifiedType, bool isRequired)
        {
            return new CustomModifierTypeSignature(unmodifiedType, modifier, isRequired);
        }

        public TypeSig GetPinnedType(TypeSig elementType)
        {
            return new PinnedTypeSig(elementType);
        }

        public TypeSig GetPointerType(TypeSig elementType)
        {
            return new PointerTypeSig(elementType);
        }

        public TypeSig GetPrimitiveType(System.Reflection.Metadata.PrimitiveTypeCode typeCode)
        {
            return new TypeDefOrRefSignature(module.GetOrCreatePrimitiveTypeRef(typeCode));
        }

        public TypeSig GetSZArrayType(TypeSig elementType)
        {
            return new SzArrayTypeSig(elementType);
        }

        public TypeSig GetTypeFromDefinition(MetadataReader reader, TypeDefinitionHandle handle, byte rawTypeKind)
        {
            return new TypeDefTypeSignature(module.GetOrCreateType(handle));
        }

        public TypeSig GetTypeFromReference(MetadataReader reader, TypeReferenceHandle handle, byte rawTypeKind)
        {
            return new TypeDefOrRefSignature(module.GetOrCreateTypeRef(handle));
        }

        public TypeSig GetTypeFromSpecification(MetadataReader reader, MetadataGenericContext genericContext, TypeSpecificationHandle handle, byte rawTypeKind)
        {
            return module.DecodeTypeSignature((EntityHandle)handle, genericContext);
        }

    }

}

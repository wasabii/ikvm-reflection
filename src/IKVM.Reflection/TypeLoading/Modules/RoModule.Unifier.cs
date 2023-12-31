// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Concurrent;

namespace IKVM.Reflection.TypeLoading
{
    internal abstract partial class RoModule
    {
        //
        // SzArrays
        //
        internal RoArrayType GetUniqueArrayType(RoType elementType)
        {
            // Modified types do not support Equals\GetHashCode.
            return elementType is RoModifiedType ?
                s_szArrayTypeFactory(elementType) :
                _szArrayDict.GetOrAdd(elementType, s_szArrayTypeFactory);
        }
        private static readonly Func<RoType, RoArrayType> s_szArrayTypeFactory = (e) => new RoArrayType(e, multiDim: false, rank: 1);
        private readonly ConcurrentDictionary<RoType, RoArrayType> _szArrayDict = new ConcurrentDictionary<RoType, RoArrayType>();

        //
        // MdArrays
        //
        internal RoArrayType GetUniqueArrayType(RoType elementType, int rank)
        {
            // Modified types do not support Equals\GetHashCode.
            RoArrayType.Key key = new(elementType, rank: rank);
            return elementType is RoModifiedType ?
                s_mdArrayTypeFactory(key) :
                _mdArrayDict.GetOrAdd(key, s_mdArrayTypeFactory);
        }
        private static readonly Func<RoArrayType.Key, RoArrayType> s_mdArrayTypeFactory = (k) => new RoArrayType(k.ElementType, multiDim: true, rank: k.Rank);
        private readonly ConcurrentDictionary<RoArrayType.Key, RoArrayType> _mdArrayDict = new ConcurrentDictionary<RoArrayType.Key, RoArrayType>();

        //
        // ByRefs
        //
        internal RoByRefType GetUniqueByRefType(RoType elementType)
        {
            // Modified types do not support Equals\GetHashCode.
            return elementType is RoModifiedType ?
                s_byrefTypeFactory(elementType) :
                _byRefDict.GetOrAdd(elementType, s_byrefTypeFactory);
        }
        private static readonly Func<RoType, RoByRefType> s_byrefTypeFactory = (e) => new RoByRefType(e);
        private readonly ConcurrentDictionary<RoType, RoByRefType> _byRefDict = new ConcurrentDictionary<RoType, RoByRefType>();

        //
        // Pointers
        //
        internal RoPointerType GetUniquePointerType(RoType elementType)
        {
            return elementType is RoModifiedType ?
                new RoPointerType(elementType) :
                _pointerDict.GetOrAdd(elementType, (e) => new RoPointerType(e));
        }
        private readonly ConcurrentDictionary<RoType, RoPointerType> _pointerDict = new ConcurrentDictionary<RoType, RoPointerType>();

        //
        // Constructed Generic Types
        //
        internal RoConstructedGenericType GetUniqueConstructedGenericType(RoDefinitionType genericTypeDefinition, RoType[] genericTypeArguments)
        {
            return _constructedGenericTypeDict.GetOrAdd(new RoConstructedGenericType.Key(genericTypeDefinition, genericTypeArguments), s_constructedGenericTypeFactory);
        }
        private static readonly Func<RoConstructedGenericType.Key, RoConstructedGenericType> s_constructedGenericTypeFactory =
            (k) => new RoConstructedGenericType(k.GenericTypeDefinition, k.GenericTypeArguments);
        private readonly ConcurrentDictionary<RoConstructedGenericType.Key, RoConstructedGenericType> _constructedGenericTypeDict = new ConcurrentDictionary<RoConstructedGenericType.Key, RoConstructedGenericType>();
    }
}

using System.Reflection.Emit;
using System.Runtime.InteropServices;

namespace IKVM.Reflection.Emit.Metadata
{

    internal class MetadataILGenerator : ILGenerator
    {

        readonly MetadataEmitContext context;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="context"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public MetadataILGenerator(MetadataEmitContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public override void BeginCatchBlock(Type exceptionType)
        {
            throw new NotImplementedException();
        }

        public override void BeginExceptFilterBlock()
        {
            throw new NotImplementedException();
        }

        public override Label BeginExceptionBlock()
        {
            throw new NotImplementedException();
        }

        public override void BeginFaultBlock()
        {
            throw new NotImplementedException();
        }

        public override void BeginFinallyBlock()
        {
            throw new NotImplementedException();
        }

        public override void BeginScope()
        {
            throw new NotImplementedException();
        }

        public override LocalBuilder DeclareLocal(Type localType, bool pinned)
        {
            throw new NotImplementedException();
        }

        public override LocalBuilder DeclareLocal(Type localType)
        {
            throw new NotImplementedException();
        }

        public override Label DefineLabel()
        {
            throw new NotImplementedException();
        }

        public override void Emit(OpCode opcode, LocalBuilder local)
        {
            throw new NotImplementedException();
        }

        public override void Emit(OpCode opcode, Type cls)
        {
            throw new NotImplementedException();
        }

        public override void Emit(OpCode opcode, string str)
        {
            throw new NotImplementedException();
        }

        public override void Emit(OpCode opcode, float arg)
        {
            throw new NotImplementedException();
        }

        public override void Emit(OpCode opcode, sbyte arg)
        {
            throw new NotImplementedException();
        }

        public override void Emit(OpCode opcode, MethodInfo meth)
        {
            throw new NotImplementedException();
        }

        public override void Emit(OpCode opcode, SignatureHelper signature)
        {
            throw new NotImplementedException();
        }

        public override void Emit(OpCode opcode, Label[] labels)
        {
            throw new NotImplementedException();
        }

        public override void Emit(OpCode opcode, FieldInfo field)
        {
            throw new NotImplementedException();
        }

        public override void Emit(OpCode opcode, ConstructorInfo con)
        {
            throw new NotImplementedException();
        }

        public override void Emit(OpCode opcode, long arg)
        {
            throw new NotImplementedException();
        }

        public override void Emit(OpCode opcode, int arg)
        {
            throw new NotImplementedException();
        }

        public override void Emit(OpCode opcode, short arg)
        {
            throw new NotImplementedException();
        }

        public override void Emit(OpCode opcode, double arg)
        {
            throw new NotImplementedException();
        }

        public override void Emit(OpCode opcode, byte arg)
        {
            throw new NotImplementedException();
        }

        public override void Emit(OpCode opcode)
        {
            throw new NotImplementedException();
        }

        public override void Emit(OpCode opcode, Label label)
        {
            throw new NotImplementedException();
        }

        public override void EmitCall(OpCode opcode, MethodInfo methodInfo, Type[]? optionalParameterTypes)
        {
            throw new NotImplementedException();
        }

        public override void EmitCalli(OpCode opcode, CallingConvention unmanagedCallConv, Type? returnType, Type[]? parameterTypes)
        {
            throw new NotImplementedException();
        }

        public override void EmitCalli(OpCode opcode, CallingConventions callingConvention, Type? returnType, Type[]? parameterTypes, Type[]? optionalParameterTypes)
        {
            throw new NotImplementedException();
        }

        public override void EmitWriteLine(string value)
        {
            throw new NotImplementedException();
        }

        public override void EmitWriteLine(FieldInfo fld)
        {
            throw new NotImplementedException();
        }

        public override void EmitWriteLine(LocalBuilder localBuilder)
        {
            throw new NotImplementedException();
        }

        public override void EndExceptionBlock()
        {
            throw new NotImplementedException();
        }

        public override void EndScope()
        {
            throw new NotImplementedException();
        }

        public override void MarkLabel(Label loc)
        {
            throw new NotImplementedException();
        }

        public override void ThrowException(Type excType)
        {
            throw new NotImplementedException();
        }

        public override void UsingNamespace(string usingNamespace)
        {
            throw new NotImplementedException();
        }

    }

}

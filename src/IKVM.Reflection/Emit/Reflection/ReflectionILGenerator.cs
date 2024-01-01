using System.Reflection.Emit;
using System.Runtime.InteropServices;

namespace IKVM.Reflection.Emit.Reflection
{

    internal class ReflectionILGenerator : ILGenerator
    {

        readonly ReflectionEmitContext context;
        readonly System.Reflection.Emit.ILGenerator wrapped;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="wrapped"></param>
        public ReflectionILGenerator(ReflectionEmitContext context, System.Reflection.Emit.ILGenerator wrapped)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            this.wrapped = wrapped ?? throw new ArgumentNullException(nameof(wrapped));
        }

        public System.Reflection.Emit.ILGenerator Wrapped => wrapped;

        public override void BeginCatchBlock(Type exceptionType)
        {
            wrapped.BeginCatchBlock(exceptionType);
        }

        public override void BeginExceptFilterBlock()
        {
            wrapped.BeginExceptFilterBlock();
        }

        public override Label BeginExceptionBlock()
        {
            return wrapped.BeginExceptionBlock();
        }

        public override void BeginFaultBlock()
        {
            wrapped.BeginFaultBlock();
        }

        public override void BeginFinallyBlock()
        {
            wrapped.BeginFinallyBlock();
        }

        public override void BeginScope()
        {
            wrapped.BeginScope();
        }

        public override LocalBuilder DeclareLocal(Type localType, bool pinned)
        {
            return new ReflectionLocalBuilder(context, wrapped.DeclareLocal(localType, pinned));
        }

        public override LocalBuilder DeclareLocal(Type localType)
        {
            return new ReflectionLocalBuilder(context, wrapped.DeclareLocal(localType));
        }

        public override Label DefineLabel()
        {
            return wrapped.DefineLabel();
        }

        public override void Emit(OpCode opcode, LocalBuilder local)
        {
            if (local is ReflectionLocalBuilder b)
                wrapped.Emit(opcode, b.Wrapped);

            throw new ArgumentException("Emit requires a LocalBuilder derived from the Reflection provider.");
        }

        public override void Emit(OpCode opcode, Type cls)
        {
            wrapped.Emit(opcode, cls);
        }

        public override void Emit(OpCode opcode, string str)
        {
            wrapped.Emit(opcode, str);
        }

        public override void Emit(OpCode opcode, float arg)
        {
            wrapped.Emit(opcode, arg);
        }

        public override void Emit(OpCode opcode, sbyte arg)
        {
            wrapped.Emit(opcode, arg);
        }

        public override void Emit(OpCode opcode, MethodInfo meth)
        {
            wrapped.Emit(opcode, meth);
        }

        public override void Emit(OpCode opcode, SignatureHelper signature)
        {
            if (signature is ReflectionSignatureHelper b)
                wrapped.Emit(opcode, b.Wrapped);

            throw new ArgumentException("Emit requires a SignatureHelper derived from the Reflection provider.");
        }

        public override void Emit(OpCode opcode, Label[] labels)
        {
            wrapped.Emit(opcode, labels);
        }

        public override void Emit(OpCode opcode, FieldInfo field)
        {
            wrapped.Emit(opcode, field);
        }

        public override void Emit(OpCode opcode, ConstructorInfo con)
        {
            wrapped.Emit(opcode, con);
        }

        public override void Emit(OpCode opcode, long arg)
        {
            wrapped.Emit(opcode, arg);
        }

        public override void Emit(OpCode opcode, int arg)
        {
            wrapped.Emit(opcode, arg);
        }

        public override void Emit(OpCode opcode, short arg)
        {
            wrapped.Emit(opcode, arg);
        }

        public override void Emit(OpCode opcode, double arg)
        {
            wrapped.Emit(opcode, arg);
        }

        public override void Emit(OpCode opcode, byte arg)
        {
            wrapped.Emit(opcode, arg);
        }

        public override void Emit(OpCode opcode)
        {
            wrapped.Emit(opcode);
        }

        public override void Emit(OpCode opcode, Label label)
        {
            wrapped.Emit(opcode, label);
        }

        public override void EmitCall(OpCode opcode, MethodInfo methodInfo, Type[]? optionalParameterTypes)
        {
            wrapped.EmitCall(opcode, methodInfo, optionalParameterTypes);
        }

#if NETFRAMEWORK || NET

        public override void EmitCalli(OpCode opcode, CallingConvention unmanagedCallConv, Type? returnType, Type[]? parameterTypes)
        {
            wrapped.EmitCalli(opcode, unmanagedCallConv, returnType, parameterTypes);
        }

        public override void EmitCalli(OpCode opcode, CallingConventions callingConvention, Type? returnType, Type[]? parameterTypes, Type[]? optionalParameterTypes)
        {
            wrapped.EmitCalli(opcode, callingConvention, returnType, parameterTypes, optionalParameterTypes);
        }

#endif

        public override void EmitWriteLine(string value)
        {
            wrapped.EmitWriteLine(value);
        }

        public override void EmitWriteLine(FieldInfo fld)
        {
            wrapped.EmitWriteLine(fld);
        }

        public override void EmitWriteLine(LocalBuilder localBuilder)
        {
            if (localBuilder is ReflectionLocalBuilder b)
                wrapped.EmitWriteLine(b.Wrapped);

            throw new ArgumentException("EmitWriteLine requires a LocalBuilder derived from the Reflection provider.");
        }

        public override void EndExceptionBlock()
        {
            wrapped.EndExceptionBlock();
        }

        public override void EndScope()
        {
            wrapped.EndScope();
        }

        public override void MarkLabel(Label loc)
        {
            wrapped.MarkLabel(loc);
        }

        public override void ThrowException(Type excType)
        {
            wrapped.ThrowException(excType);
        }

        public override void UsingNamespace(string usingNamespace)
        {
            wrapped.UsingNamespace(usingNamespace);
        }

        public override string ToString() => Wrapped.ToString();

    }

}

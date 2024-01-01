namespace IKVM.Reflection.Emit.Reflection
{

    internal class ReflectionEventBuilder : EventBuilder
    {

        readonly ReflectionEmitContext context;
        readonly System.Reflection.Emit.EventBuilder wrapped;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="wrapped"></param>
        public ReflectionEventBuilder(ReflectionEmitContext context, System.Reflection.Emit.EventBuilder wrapped)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            this.wrapped = wrapped ?? throw new ArgumentNullException(nameof(wrapped));
        }

        public System.Reflection.Emit.EventBuilder Wrapped => wrapped;

        public override void AddOtherMethod(MethodBuilder mdBuilder)
        {
            if (mdBuilder is  ReflectionMethodBuilder b)
                wrapped.AddOtherMethod(b.Wrapped);

            throw new ArgumentException("AddOtherMethod requires a MethodBuilder derived from the Reflection provider.");
        }

        public override void SetAddOnMethod(MethodBuilder mdBuilder)
        {
            if (mdBuilder is  ReflectionMethodBuilder b)
                wrapped.SetAddOnMethod(b.Wrapped);

            throw new ArgumentException("SetAddOnMethod requires a MethodBuilder derived from the Reflection provider.");
        }

        public override void SetCustomAttribute(CustomAttributeBuilder customBuilder)
        {
            if (customBuilder is  ReflectionCustomAttributeBuilder b)
                wrapped.SetCustomAttribute(b.Wrapped);

            throw new ArgumentException("SetCustomAttribute requires a CustomAttributeBuilder derived from the Reflection provider.");
        }

        public override void SetCustomAttribute(ConstructorInfo con, byte[] binaryAttribute)
        {
            wrapped.SetCustomAttribute(con, binaryAttribute);
        }

        public override void SetRaiseMethod(MethodBuilder mdBuilder)
        {
            if (mdBuilder is  ReflectionMethodBuilder b)
                wrapped.SetRaiseMethod(b.Wrapped);

            throw new ArgumentException("SetRaiseMethod requires a MethodBuilder derived from the Reflection provider.");
        }

        public override void SetRemoveOnMethod(MethodBuilder mdBuilder)
        {
            if (mdBuilder is ReflectionMethodBuilder b)
                wrapped.SetRemoveOnMethod(b.Wrapped);

            throw new ArgumentException("SetRemoveOnMethod requires a MethodBuilder derived from the Reflection provider.");
        }

        /// <inheritdoc />
        public override string ToString() => Wrapped.ToString();
    }

}

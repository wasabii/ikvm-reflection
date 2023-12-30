using System;

namespace IKVM.Reflection.Util
{

    /// <summary>
    /// Represents a variable that can be lazily initialized and/or assigned a new value.
    /// </summary>
    /// <typeparam name="TValue">The type of the values that the variable stores.</typeparam>
    public struct LazyVar<TValue>
    {

        TValue value;
        bool isInitialized;

        /// <summary>
        /// Creates a new lazy variable and initialize it with a constant.
        /// </summary>
        /// <param name="value">The value to initialize the variable with.</param>
        public LazyVar(TValue value)
        {
            this.value = value;
            this.isInitialized = true;
        }

        /// <summary>
        /// Gets a value indicating the value has been initialized.
        /// </summary>
        public readonly bool IsInitialized => isInitialized;

        /// <summary>
        /// Gets the value of the variable.
        /// </summary>
        /// <returns></returns>
        public TValue Get(object sync, Func<TValue> create)
        {
            if (isInitialized == false)
            {
                lock (sync)
                {
                    if (isInitialized == false)
                    {
                        value = create();
                        isInitialized = true;
                    }
                }
            }

            return value;
        }

    }

}

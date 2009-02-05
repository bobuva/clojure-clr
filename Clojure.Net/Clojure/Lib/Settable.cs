﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace clojure.lang
{
    /// <summary>
    ///  Represents an object with a value that can be set.
    /// </summary>
    public interface Settable
    {
        /// <summary>
        /// Sets the value.
        /// </summary>
        /// <param name="val">The new value</param>
        /// <returns>The new value.</returns>
        /// <remarks>Can only be called in a transaction or with a binding on the stack, else throws an exception.</remarks>
        object doSet(object val);

        /// <summary>
        /// Sets the root value.
        /// </summary>
        /// <param name="val">The new value</param>
        /// <returns>The new value.</returns>
        object doReset(object val);
    }
}
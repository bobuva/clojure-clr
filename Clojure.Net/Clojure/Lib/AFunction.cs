﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace clojure.lang
{
    /// <summary>
    /// Base class providing IComparer implementation on top of <see cref="AFn">AFn</see>.  Internal use by compiler.
    /// </summary>
    public abstract class AFunction : AFn, Fn, IComparer
    {
        #region Ctors and factory methods

        /// <summary>
        /// Initialize an <see cref="AFunction">AFunction</see> to have the given metadata.
        /// </summary>
        /// <param name="meta">The metadata to attach.</param>
        public AFunction(IPersistentMap meta)
            : base(meta)
        {
        }

        /// <summary>
        /// Initialize an <see cref="AFunction">AFunction</see> to have the null metadata.
        /// </summary>
        public AFunction()
            : base()
        {
        }

        #endregion

        #region IComparer Members

        /// <summary>
        /// Compares two objects and returns a value indicating whether one is less than, equal to, or greater than the other.
        /// </summary>
        /// <param name="x">The first object to compare.</param>
        /// <param name="y">The second object to compare.</param>
        /// <returns>x?y:-1 if less than, 0 if equal, 1 if greater</returns>
        /// <remarks>Uses the two-parameter invoke.  
        /// Return type can be <code>bool</code> with <value>true</value> meaning less-than, or an int.</remarks>
        public int Compare(object x, object y)
        {
            Object o = invoke(x, y);

            if (o is Boolean)
            {
                if (RT.BooleanCast(o))
                    return -1;
                return RT.BooleanCast(invoke(y, x)) ? 1 : 0;
            }
            return Util.ConvertToInt(o);
        }

        #endregion
    
    }
}
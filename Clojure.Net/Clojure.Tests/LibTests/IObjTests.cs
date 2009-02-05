﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;
using Rhino.Mocks;
using clojure.lang;

namespace Clojure.Tests.LibTests
{
    /// <summary>
    /// Base class for testing the IMeta interface functionality.
    /// </summary>
    public abstract class IObjTests : AssertionHelper
    {
        /// <summary>
        /// Object to test for null meta.  Set null if no test.  Initialize in Setup.
        /// </summary>
        protected IObj _objWithNullMeta;


        /// <summary>
        /// The object to test.  Initialize in Setup.
        /// </summary>
        protected IObj _obj;

        /// <summary>
        /// Expected type of return from withMeta.  Set null if no test.  Initialize in Setup.
        /// </summary>
        protected Type _expectedType;


        MockRepository _mocks = null;
        IPersistentMap _meta = null;

        void InitMocks()
        {
            _mocks = new MockRepository();
            _meta = _mocks.StrictMock<IPersistentMap>();
            _mocks.ReplayAll();
        }
            

        [Test]
        public void withMeta_has_correct_meta()
        {
            InitMocks();
            IObj obj2 = _obj.withMeta(_meta);
            Expect(obj2.meta(), SameAs(_meta));
            _mocks.VerifyAll();
        }

        [Test]
        public void withMeta_returns_correct_type()
        {
            if (_expectedType == null)
                return;

            InitMocks();
            IObj obj2 = _obj.withMeta(_meta);
            Expect(obj2, TypeOf(_expectedType));
            _mocks.VerifyAll();
        }

        [Test]
        public void withMeta_returns_self_if_no_change()
        {
            IObj obj2 = _obj.withMeta(_obj.meta());
            Expect(obj2, SameAs(_obj));
        }

        [Test]
        public void Verify_Null_Meta()
        {
            if (_objWithNullMeta == null)
                return;
            Expect(_objWithNullMeta.meta(), Null);
        }
    }
}
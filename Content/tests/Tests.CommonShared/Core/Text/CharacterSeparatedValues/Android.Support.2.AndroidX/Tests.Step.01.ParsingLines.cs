﻿// /*
//    Copyright (c) 2017-12
//
//    moljac
//    Test.cs
//
//    Permission is hereby granted, free of charge, to any person
//    obtaining a copy of this software and associated documentation
//    files (the "Software"), to deal in the Software without
//    restriction, including without limitation the rights to use,
//    copy, modify, merge, publish, distribute, sublicense, and/or sell
//    copies of the Software, and to permit persons to whom the
//    Software is furnished to do so, subject to the following
//    conditions:
//
//    The above copyright notice and this permission notice shall be
//    included in all copies or substantial portions of the Software.
//
//    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
//    EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
//    OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
//    NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
//    HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
//    WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
//    FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
//    OTHER DEALINGS IN THE SOFTWARE.
// */
using System;

using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Globalization;

#if XUNIT
using Xunit;
// NUnit aliases
using Test = Xunit.FactAttribute;
// XUnit aliases
using TestClass = HolisticWare.Core.Testing.UnitTests.UnitTestsCompatibilityAliasAttribute;
#elif NUNIT
using NUnit.Framework;
// MSTest aliases
using TestInitialize = NUnit.Framework.SetUpAttribute;
using TestProperty = NUnit.Framework.PropertyAttribute;
using TestClass = NUnit.Framework.TestFixtureAttribute;
using TestMethod = NUnit.Framework.TestAttribute;
using TestCleanup = NUnit.Framework.TearDownAttribute;
using TestContext = System.Object;
// XUnit aliases
using Fact=NUnit.Framework.TestAttribute;
#elif MSTEST
using Microsoft.VisualStudio.TestTools.UnitTesting;
// NUnit aliases
using Test = Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute;
// XUnit aliases
using Fact = Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute;
#endif

using Core.Text;

namespace UnitTests.Core.Text.CharacterSeparatedValuesSamples.AndroidSupport2AndroidX
{
    public partial class Tests01
    {

        [Test()]
        public void ParseAndroidxClassMappings()
        {

            //-----------------------------------------------------------------------------------------
            // Arrange
            CharacterSeparatedValues csv = new CharacterSeparatedValues()
            {
                Text = TextContent,
                Separators = new string[] { "," }
            };
            //-----------------------------------------------------------------------------------------
            // Act
            sw.Start();
            IEnumerable<IEnumerable<string>> mapping = null; //csv.Parse()
            IEnumerable<
                            (
                                string AndroidSupportArtifact,
                                string AndroidXArtifact
                            )
                        > mapping_strongly_typed = Convert_GoogleArtifactMappings(mapping);
            sw.Reset();
            ConsoleOutput(mapping);
            //-----------------------------------------------------------------------------------------
            // Assert
            #if NUNIT
            foreach (IEnumerable<string> item in mapping)
            {
                Assert.AreEqual(item.Count(), 2);
            }

            Assert.AreEqual(mapping.Count(), mapping_strongly_typed.Count());
            #elif XUNIT
            foreach (IEnumerable<string> item in mapping)
            {
                Assert.Equal(item.Count(), 2);
            }
            Assert.Equal(mapping.Count(), mapping_strongly_typed.Count());
            #elif MSTEST
            foreach (IEnumerable<string> item in mapping)
            {
                Assert.AreEqual(item.Count(), 2);
            }

            Assert.AreEqual(mapping.Count(), mapping_strongly_typed.Count());
            #endif
            //-----------------------------------------------------------------------------------------

            return;
        }


        private static
                IEnumerable<
                            (
                                string AndroidSupportArtifact,
                                string AndroidXArtifact
                            )
                        >
                Convert_GoogleArtifactMappings(IEnumerable<IEnumerable<string>> untyped_data)
        {
            foreach (IEnumerable<string> row in untyped_data)
            {
                yield return
                        (
                            AndroidSupportArtifact: row.ElementAt(0),
                            AndroidXArtifact: row.ElementAt(1)
                        );
            }
        }


    }
}

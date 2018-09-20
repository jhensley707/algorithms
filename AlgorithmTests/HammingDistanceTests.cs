using System;
using AlgorithmLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmTests
{
    public class HammingDistanceTests
    {
        public class HammingDistanceTestBase
        {
            public HammingDistance Algorithm;
            public const string InputRamp = "ramp";
            public const string InputRam = "ram";
            public const string InputMom = "mom";
        }

        [TestClass]
        public class ConstructorWithMismatchStrings : HammingDistanceTestBase
        {
            [TestMethod]
            [ExpectedException(typeof(InvalidOperationException))]
            public void ShouldThrowException()
            {
                Algorithm = new HammingDistance(InputRamp, InputRam);
            }
        }

        [TestClass]
        public class ConstructorWithRamAndMom : HammingDistanceTestBase
        {
            [TestMethod]
            public void ShouldReturnHammingDistanceInstance()
            {
                Algorithm = new HammingDistance(InputRam, InputMom);

                Assert.IsNotNull(Algorithm);
            }

            [TestMethod]
            public void ShouldSetHammingDistanceInput1()
            {
                Algorithm = new HammingDistance(InputRam, InputMom);

                Assert.AreEqual(InputRam, Algorithm.Input1);
            }

            [TestMethod]
            public void ShouldSetHammingDistanceInput2()
            {
                Algorithm = new HammingDistance(InputRam, InputMom);

                Assert.AreEqual(InputMom, Algorithm.Input2);
            }
        }

        [TestClass]
        public class CalculateMethodWithMismatchStrings : HammingDistanceTestBase
        {
            [TestMethod]
            [ExpectedException(typeof(InvalidOperationException))]
            public void ShouldThrowException()
            {
                var result = HammingDistance.Calculate(InputRamp, InputRam);
            }
        }

        [TestClass]
        public class CalculateMethodWithRamAndRam : HammingDistanceTestBase
        {
            [TestMethod]
            public void ShouldReturnHammingDistanceOf0()
            {
                var result = HammingDistance.Calculate(InputRam, InputRam);

                Assert.AreEqual(0, result);
            }
        }

        [TestClass]
        public class CalculateMethodWithRamAndMom : HammingDistanceTestBase
        {
            [TestMethod]
            public void ShouldReturnHammingDistanceOf2()
            {
                var result = HammingDistance.Calculate(InputRam, InputMom);

                Assert.AreEqual(2, result);
            }
        }
    }
}

using System;
using AlgorithmLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmTests
{
    public class LevenshteinDistanceTests
    {
        public class LevenshteinDistanceTestBase
        {
            public LevenshteinDistance Algorithm;
            public const string InputArm = "arm";
            public const string InputRam = "ram";
            public const string InputReam = "ream";
            public const string InputMom = "mom";
        }

        public class Constructor : LevenshteinDistanceTestBase
        {
            [TestMethod]
            public void ShouldReturnLevenshteinDistanceInstance()
            {
                Algorithm = new LevenshteinDistance(InputRam, InputMom);

                Assert.IsNotNull(Algorithm);
            }

            [TestMethod]
            public void ShouldSetLevenshteinDistanceInput1()
            {
                Algorithm = new LevenshteinDistance(InputRam, InputMom);

                Assert.AreEqual(InputRam, Algorithm.Input1);
            }

            [TestMethod]
            public void ShouldSetLevenshteinDistanceInput2()
            {
                Algorithm = new LevenshteinDistance(InputRam, InputMom);

                Assert.AreEqual(InputMom, Algorithm.Input2);
            }
        }

        public class CalculateMethodWithArmAndArm : LevenshteinDistanceTestBase
        {
            [TestMethod]
            public void ShouldReturnLevenshteinDistanceOf0()
            {
                var result = LevenshteinDistance.Calculate(InputArm, InputArm);

                Assert.AreEqual(0, result);
            }
        }

        [TestClass]
        public class CalculateMethodWithArmAndRam : LevenshteinDistanceTestBase
        {
            [TestMethod]
            public void ShouldReturnLevenshteinDistanceOf2()
            {
                var result = LevenshteinDistance.Calculate(InputArm, InputRam);

                Assert.AreEqual(2, result);
            }
        }

        [TestClass]
        public class CalculateMethodWithRamAndReam : LevenshteinDistanceTestBase
        {
            [TestMethod]
            public void ShouldReturnLevenshteinDistanceOf1()
            {
                var result = LevenshteinDistance.Calculate(InputRam, InputReam);

                Assert.AreEqual(1, result);
            }
        }

        [TestClass]
        public class CalculateMethodWithRamAndMom : LevenshteinDistanceTestBase
        {
            [TestMethod]
            public void ShouldReturnLevenshteinDistanceOf2()
            {
                var result = LevenshteinDistance.Calculate(InputRam, InputArm);

                Assert.AreEqual(2, result);
            }
        }
    }
}

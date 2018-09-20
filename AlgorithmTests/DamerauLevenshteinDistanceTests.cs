using System;
using AlgorithmLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmTests
{
    public class DamerauLevenshteinDistanceTests
    {
        public class DamerauLevenshteinDistanceTestBase
        {
            public DamerauLevenshteinDistance Algorithm;
            public const string InputArm = "arm";
            public const string InputRam = "ram";
            public const string InputReam = "ream";
            public const string InputMom = "mom";
        }

        [TestClass]
        public class Constructor : DamerauLevenshteinDistanceTestBase
        {
            [TestMethod]
            public void ShouldReturnDamerauLevenshteinDistanceInstance()
            {
                Algorithm = new DamerauLevenshteinDistance(InputArm, InputRam);

                Assert.IsNotNull(Algorithm);
            }

            [TestMethod]
            public void ShouldSetDamerauLevenshteinDistanceInput1()
            {
                Algorithm = new DamerauLevenshteinDistance(InputRam, InputArm);

                Assert.AreEqual(InputRam, Algorithm.Input1);
            }

            [TestMethod]
            public void ShouldSetDamerauLevenshteinDistanceInput2()
            {
                Algorithm = new DamerauLevenshteinDistance(InputRam, InputArm);

                Assert.AreEqual(InputArm, Algorithm.Input2);
            }
        }

        [TestClass]
        public class CalculateMethodWithArmAndArm : DamerauLevenshteinDistanceTestBase
        {
            [TestMethod]
            public void ShouldReturnDamerauLevenshteinDistanceOf0()
            {
                var result = DamerauLevenshteinDistance.Calculate(InputArm, InputArm);

                Assert.AreEqual(0, result);
            }
        }

        [TestClass]
        public class CalculateMethodWithArmAndRam : DamerauLevenshteinDistanceTestBase
        {
            [TestMethod]
            public void ShouldReturnDamerauLevenshteinDistanceOf1()
            {
                var result = DamerauLevenshteinDistance.Calculate(InputArm, InputRam);

                Assert.AreEqual(1, result);
            }
        }

        [TestClass]
        public class CalculateMethodWithRamAndReam : DamerauLevenshteinDistanceTestBase
        {
            [TestMethod]
            public void ShouldReturnDamerauLevenshteinDistanceOf1()
            {
                var result = DamerauLevenshteinDistance.Calculate(InputRam, InputReam);

                Assert.AreEqual(1, result);
            }
        }

        [TestClass]
        public class CalculateMethodWithRamAndMom : DamerauLevenshteinDistanceTestBase
        {
            [TestMethod]
            public void ShouldReturnDamerauLevenshteinDistanceOf2()
            {
                var result = DamerauLevenshteinDistance.Calculate(InputRam, InputMom);

                Assert.AreEqual(2, result);
            }
        }

        [TestClass]
        public class DamLevMethodWithArmAndArm : DamerauLevenshteinDistanceTestBase
        {
            [TestMethod]
            public void ShouldReturnDamerauLevenshteinDistanceOf0()
            {
                var result = DamerauLevenshteinDistance.DamLev(InputArm, InputArm);

                Assert.AreEqual(0, result);
            }
        }

        [TestClass]
        public class DamLevMethodWithArmAndRam : DamerauLevenshteinDistanceTestBase
        {
            [TestMethod]
            public void ShouldReturnDamerauLevenshteinDistanceOf1()
            {
                var result = DamerauLevenshteinDistance.Calculate(InputArm, InputRam);

                Assert.AreEqual(1, result);
            }
        }

        [TestClass]
        public class DamLevMethodWithRamAndReam : DamerauLevenshteinDistanceTestBase
        {
            [TestMethod]
            public void ShouldReturnDamerauLevenshteinDistanceOf1()
            {
                var result = DamerauLevenshteinDistance.DamLev(InputRam, InputReam);

                Assert.AreEqual(1, result);
            }
        }

        [TestClass]
        public class DamLevMethodWithRamAndMom : DamerauLevenshteinDistanceTestBase
        {
            [TestMethod]
            public void ShouldReturnDamerauLevenshteinDistanceOf2()
            {
                var result = DamerauLevenshteinDistance.DamLev(InputRam, InputMom);

                Assert.AreEqual(2, result);
            }
        }

        [TestClass]
        public class DamLevMethodWithRamAndMomAndMaxOf1 : DamerauLevenshteinDistanceTestBase
        {
            [TestMethod]
            public void ShouldReturnDamerauLevenshteinDistanceOfNegative1()
            {
                var result = DamerauLevenshteinDistance.DamLev(InputRam, InputMom, 1);

                Assert.AreEqual(-1, result);
            }
        }
    }
}

using System;
using AlgorithmLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmTests
{
    public class JaroWinklerDistanceTests
    {
        public class JaroWinklerDistanceTestBase
        {
            public JaroWinklerDistance Algorithm;
            public const double WeightThresholdPoint8 = 0.8;
            public const int PrefixLength = 3;
            public const string InputPassword = "Password";
            public const string InputPasswrod = "Passwrod";
            public const string InputUsername = "Username";
            public const string InputU = "U";
        }

        [TestClass]
        public class Constructor : JaroWinklerDistanceTestBase
        {
            [TestMethod]
            public void ShouldReturnJaroWinklerDistanceInstance()
            {
                Algorithm = new JaroWinklerDistance(InputPassword, InputPasswrod);

                Assert.IsNotNull(Algorithm);
            }

            [TestMethod]
            public void ShouldSetJaroWinklerDistanceInput1()
            {
                Algorithm = new JaroWinklerDistance(InputPassword, InputPasswrod);

                Assert.AreEqual(InputPassword, Algorithm.Input1);
            }

            [TestMethod]
            public void ShouldSetJaroWinklerDistanceInput2()
            {
                Algorithm = new JaroWinklerDistance(InputPassword, InputPasswrod);

                Assert.AreEqual(InputPasswrod, Algorithm.Input2);
            }

            [TestMethod]
            public void ShouldSetJaroWinklerDistanceWeightThresholdPoint8()
            {
                Algorithm = new JaroWinklerDistance(InputPassword, InputPasswrod, WeightThresholdPoint8);

                Assert.AreEqual(WeightThresholdPoint8, Algorithm.WeightThreshold);
            }

            [TestMethod]
            public void ShouldSetJaroWinklerDistanceWeightPrefixLength3()
            {
                Algorithm = new JaroWinklerDistance(InputPassword, InputPasswrod, prefixLength:PrefixLength);

                Assert.AreEqual(PrefixLength, Algorithm.PrefixLength);
            }
        }

        [TestClass]
        public class ProximityMethodWithPasswordAndPassword : JaroWinklerDistanceTestBase
        {
            [TestMethod]
            public void ShouldReturnJaroWinklerDistanceOf1()
            {
                var result = JaroWinklerDistance.CalculateProximity(InputPassword, InputPassword);

                Assert.IsTrue(Math.Abs(result - 1.0) < 0.0000001);
            }
        }

        [TestClass]
        public class ProximityMethodWithPasswordAndPasswrod : JaroWinklerDistanceTestBase
        {
            [TestMethod]
            public void ShouldReturnJaroWinklerDistanceOfPoint975()
            {
                var result = JaroWinklerDistance.CalculateProximity(InputPassword, InputPasswrod);

                Assert.IsTrue(Math.Abs(result - 0.975) < 0.0000001);
            }
        }

        [TestClass]
        public class ProximityMethodWithPasswordAndUsername : JaroWinklerDistanceTestBase
        {
            [TestMethod]
            public void ShouldReturnJaroWinklerDistanceOfPoint5()
            {
                var result = JaroWinklerDistance.CalculateProximity(InputPassword, InputUsername);

                Assert.IsTrue(Math.Abs(result - 0.500) < 0.0000001);
            }
        }

        [TestClass]
        public class ProximityMethodWithPasswordAndU : JaroWinklerDistanceTestBase
        {
            [TestMethod]
            public void ShouldReturnJaroWinklerDistanceOf0()
            {
                var result = JaroWinklerDistance.CalculateProximity(InputPassword, InputU);

                Assert.IsTrue(Math.Abs(result - 0.0) < 0.0000001);
            }
        }

        [TestClass]
        public class DistanceMethodWithPasswordAndPassword : JaroWinklerDistanceTestBase
        {
            [TestMethod]
            public void ShouldReturnJaroWinklerDistanceOf0()
            {
                var result = JaroWinklerDistance.CalculateDistance(InputPassword, InputPassword);

                Assert.IsTrue(Math.Abs(result - 0.0) < 0.0000001);
            }
        }

        [TestClass]
        public class DistanceMethodWithPasswordAndPasswrod : JaroWinklerDistanceTestBase
        {
            [TestMethod]
            public void ShouldReturnJaroWinklerDistanceOfPoint025()
            {
                var result = JaroWinklerDistance.CalculateDistance(InputPassword, InputPasswrod);

                Assert.IsTrue(Math.Abs(result - 0.025) < 0.0000001);
            }
        }

        [TestClass]
        public class DistanceMethodWithPasswordAndUsername : JaroWinklerDistanceTestBase
        {
            [TestMethod]
            public void ShouldReturnJaroWinklerDistanceOfPoint5()
            {
                var result = JaroWinklerDistance.CalculateDistance(InputPassword, InputUsername);

                Assert.IsTrue(Math.Abs(result - 0.5) < 0.0000001);
            }
        }

        [TestClass]
        public class DistanceMethodWithPasswordAndU : JaroWinklerDistanceTestBase
        {
            [TestMethod]
            public void ShouldReturnJaroWinklerDistanceOf1()
            {
                var result = JaroWinklerDistance.CalculateDistance(InputPassword, InputU);

                Assert.IsTrue(Math.Abs(result - 1.0) < 0.0000001);
            }
        }
    }
}

using System;
using AlgorithmLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmTests
{
    public class BoyerMooreAlgorithmTests
    {
        [TestClass]
        public class GetIndexMethod
        {
            [TestMethod]
            public void TestMethod1()
            {
                var result = BoyerMooreAlgorithm.GetIndex("This is a string describing farm life in the city of San Jose", "farm");

                Assert.AreEqual(28, result);
            }
        }

        [TestClass]
        public class MakeCharTableMethod
        {
            [TestMethod]
            public void ShouldReturn3WithAbcdAndA()
            {
                var result = BoyerMooreAlgorithm.MakeCharTable("abcd");

                Assert.AreEqual(3, result['a']);
            }

            [TestMethod]
            public void ShouldReturn2WithAbcdAndB()
            {
                var result = BoyerMooreAlgorithm.MakeCharTable("abcd");

                Assert.AreEqual(2, result['b']);
            }

            [TestMethod]
            public void ShouldReturn1WithAbcdAndC()
            {
                var result = BoyerMooreAlgorithm.MakeCharTable("abcd");

                Assert.AreEqual(1, result['c']);
            }

            [TestMethod]
            public void ShouldReturn4WithAbcdAndD()
            {
                var result = BoyerMooreAlgorithm.MakeCharTable("abcd");

                Assert.AreEqual(4, result['d']);
            }

            [TestMethod]
            public void ShouldReturn4WithAbcdAndE()
            {
                var result = BoyerMooreAlgorithm.MakeCharTable("abcd");

                Assert.AreEqual(4, result['e']);
            }

            [TestMethod]
            public void ShouldReturn1WithAbadAndA()
            {
                var result = BoyerMooreAlgorithm.MakeCharTable("abad");

                Assert.AreEqual(1, result['a']);
            }
        }

        [TestClass]
        public class MakeOffsetTableMethod
        {
            [TestMethod]
            public void ShouldReturnIndex0Of1WithHoHo()
            {
                var result = BoyerMooreAlgorithm.MakeOffsetTable("HoHo");

                Assert.AreEqual(1, result[0]);
            }

            [TestMethod]
            public void ShouldReturnIndex1Of5WithHoHo()
            {
                var result = BoyerMooreAlgorithm.MakeOffsetTable("HoHo");

                Assert.AreEqual(5, result[1]);
            }

            [TestMethod]
            public void ShouldReturnIndex2Of4WithHoHo()
            {
                var result = BoyerMooreAlgorithm.MakeOffsetTable("HoHo");

                Assert.AreEqual(4, result[2]);
            }

            [TestMethod]
            public void ShouldReturnIndex3Of5WithHoHo()
            {
                var result = BoyerMooreAlgorithm.MakeOffsetTable("HoHo");

                Assert.AreEqual(5, result[3]);
            }

            [TestMethod]
            public void ShouldReturnIndex0Of2WithTree()
            {
                var result = BoyerMooreAlgorithm.MakeOffsetTable("Tree");

                Assert.AreEqual(2, result[0]);
            }

            [TestMethod]
            public void ShouldReturnIndex1Of2WithTree()
            {
                var result = BoyerMooreAlgorithm.MakeOffsetTable("Tree");

                Assert.AreEqual(2, result[1]);
            }

            [TestMethod]
            public void ShouldReturnIndex2Of6WithTree()
            {
                var result = BoyerMooreAlgorithm.MakeOffsetTable("Tree");

                Assert.AreEqual(6, result[2]);
            }

            [TestMethod]
            public void ShouldReturnIndex3Of7WithTree()
            {
                var result = BoyerMooreAlgorithm.MakeOffsetTable("Tree");

                Assert.AreEqual(7, result[3]);
            }

            [TestMethod]
            public void ShouldReturnIndex0Of1WithNeeded()
            {
                var result = BoyerMooreAlgorithm.MakeOffsetTable("Needed");

                Assert.AreEqual(1, result[0]);
            }

            [TestMethod]
            public void ShouldReturnIndex1Of7WithNeeded()
            {
                var result = BoyerMooreAlgorithm.MakeOffsetTable("Needed");

                Assert.AreEqual(7, result[1]);
            }

            [TestMethod]
            public void ShouldReturnIndex2Of4WithNeeded()
            {
                var result = BoyerMooreAlgorithm.MakeOffsetTable("Needed");

                Assert.AreEqual(4, result[2]);
            }

            [TestMethod]
            public void ShouldReturnIndex9Of7WithNeeded()
            {
                var result = BoyerMooreAlgorithm.MakeOffsetTable("Needed");

                Assert.AreEqual(9, result[3]);
            }

            [TestMethod]
            public void ShouldReturnIndex10Of8WithNeeded()
            {
                var result = BoyerMooreAlgorithm.MakeOffsetTable("Needed");

                Assert.AreEqual(10, result[4]);
            }

            [TestMethod]
            public void ShouldReturnIndex11Of9WithNeeded()
            {
                var result = BoyerMooreAlgorithm.MakeOffsetTable("Needed");

                Assert.AreEqual(11, result[5]);
            }

            [TestMethod]
            public void ShouldReturnIndex0Of1WithAbcde()
            {
                var result = BoyerMooreAlgorithm.MakeOffsetTable("Abcde");

                Assert.AreEqual(1, result[0]);
            }

            [TestMethod]
            public void ShouldReturnIndex1Of6WithAbcde()
            {
                var result = BoyerMooreAlgorithm.MakeOffsetTable("Abcde");

                Assert.AreEqual(6, result[1]);
            }

            [TestMethod]
            public void ShouldReturnIndex2Of7WithAbcde()
            {
                var result = BoyerMooreAlgorithm.MakeOffsetTable("Abcde");

                Assert.AreEqual(7, result[2]);
            }

            [TestMethod]
            public void ShouldReturnIndex3Of8WithAbcde()
            {
                var result = BoyerMooreAlgorithm.MakeOffsetTable("Abcde");

                Assert.AreEqual(8, result[3]);
            }

            [TestMethod]
            public void ShouldReturnIndex4Of9WithAbcde()
            {
                var result = BoyerMooreAlgorithm.MakeOffsetTable("Abcde");

                Assert.AreEqual(9, result[4]);
            }
        }

        [TestClass]
        public class IsPrefixMethod
        {
            [TestMethod]
            public void ShouldReturnTrueWithHoHoAndPointerOf0()
            {
                var result = BoyerMooreAlgorithm.IsPrefix("HoHo", 0);

                Assert.IsTrue(result);
            }

            [TestMethod]
            public void ShouldReturnFalseWithHoHoAndPointerOf1()
            {
                var result = BoyerMooreAlgorithm.IsPrefix("HoHo", 1);

                Assert.IsFalse(result);
            }

            [TestMethod]
            public void ShouldReturnTrueWithHoHoAndPointerOf2()
            {
                var result = BoyerMooreAlgorithm.IsPrefix("HoHo", 2);

                Assert.IsTrue(result);
            }

            [TestMethod]
            public void ShouldReturnFalseWithHoHoAndPointerOf3()
            {
                var result = BoyerMooreAlgorithm.IsPrefix("HoHo", 3);

                Assert.IsFalse(result);
            }

            [TestMethod]
            public void ShouldReturnTrueWithHoHoAndPointerOf4()
            {
                var result = BoyerMooreAlgorithm.IsPrefix("HoHo", 4);

                Assert.IsTrue(result);
            }
        }

        [TestClass]
        public class SuffixLengthMethod
        {
            [TestMethod]
            public void ShouldReturn0WithTreeAndPointerOf0()
            {
                var result = BoyerMooreAlgorithm.SuffixLength("tree", 0);

                Assert.AreEqual(0, result);
            }

            [TestMethod]
            public void ShouldReturn0WithTreeAndPointerOf1()
            {
                var result = BoyerMooreAlgorithm.SuffixLength("tree", 1);

                Assert.AreEqual(0, result);
            }

            [TestMethod]
            public void ShouldReturn1WithTreeAndPointerOf2()
            {
                var result = BoyerMooreAlgorithm.SuffixLength("tree", 2);

                Assert.AreEqual(1, result);
            }

            [TestMethod]
            public void ShouldReturn4WithTreeAndPointerOf3()
            {
                var result = BoyerMooreAlgorithm.SuffixLength("tree", 3);

                Assert.AreEqual(4, result);
            }

            [TestMethod]
            public void ShouldReturn0WithTreeAndPointerOf4()
            {
                var result = BoyerMooreAlgorithm.SuffixLength("tree", 4);

                Assert.AreEqual(0, result);
            }

            [TestMethod]
            public void ShouldReturn0WithNeededAndPointerOf0()
            {
                var result = BoyerMooreAlgorithm.SuffixLength("needed", 0);

                Assert.AreEqual(0, result);
            }

            [TestMethod]
            public void ShouldReturn0WithNeededAndPointerOf1()
            {
                var result = BoyerMooreAlgorithm.SuffixLength("needed", 1);

                Assert.AreEqual(0, result);
            }

            [TestMethod]
            public void ShouldReturn0WithNeededAndPointerOf2()
            {
                var result = BoyerMooreAlgorithm.SuffixLength("needed", 2);

                Assert.AreEqual(0, result);
            }

            [TestMethod]
            public void ShouldReturn2WithNeededAndPointerOf3()
            {
                var result = BoyerMooreAlgorithm.SuffixLength("needed", 3);

                Assert.AreEqual(2, result);
            }

            [TestMethod]
            public void ShouldReturn0WithNeededAndPointerOf4()
            {
                var result = BoyerMooreAlgorithm.SuffixLength("needed", 4);

                Assert.AreEqual(0, result);
            }

            [TestMethod]
            public void ShouldReturn6WithNeededAndPointerOf5()
            {
                var result = BoyerMooreAlgorithm.SuffixLength("needed", 5);

                Assert.AreEqual(6, result);
            }
        }
    }
}

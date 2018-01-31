using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TomExtensions.Collections;

namespace Tests
{
  [TestClass]
  public class EnumerableExtensionTests
  {
    [TestMethod]
    public void TestNone()
    {
      var empty = new List<int>();
      var listHalfFull = new List<int>() { 0 };

      Assert.IsTrue(empty.None());
      Assert.IsFalse(listHalfFull.None());
    }

    [TestMethod]
    public void TestNonePredicate()
    {
      var lower = new List<int>() { 0, 1, 2, 1, -3, 0 };
      var upper = new List<int>() { 0, 10, 1, 3, -6 };

      var predicate = new Predicate<int>((i) => i > 3);

      Assert.IsTrue(lower.None(predicate));
      Assert.IsFalse(upper.None(predicate));
    }

    [TestMethod]
    public void TestNoneFunc()
    {
      var lower = new List<int>() { 0, 1, 2, 1, -3, 0 };
      var upper = new List<int>() { 0, 10, 1, 3, -6 };

      var func = new Func<int, bool>((i) => i > 3);

      Assert.IsTrue(lower.None(func));
      Assert.IsFalse(upper.None(func));
    }

    [TestMethod]
    public void TestAnyPredicate()
    {
      var lower = new List<int>() { 0, 1, 2, 1, -3, 0 };
      var upper = new List<int>() { 0, 10, 1, 3, -6 };

      var predicate = new Predicate<int>((i) => i > 3);

      Assert.IsFalse(lower.Any(predicate));
      Assert.IsTrue(upper.Any(predicate));
    }

    [TestMethod]
    public void TestRangeOneArg()
    {
      var extRange = EnumerableExtensions.Range(4);
      var range = Enumerable.Range(0, 4);

      Assert.IsTrue(extRange.SequenceEqual(range));
    }

    [TestMethod]
    public void TestGenerate()
    {
      var i = 0;
      var generator = new Func<int>(() => i++);

      //not calling ToList() on the generated enumerable will cause WEIRD behavior in debugging, 
      //since every time it's enumerated, it will generate new values
      var generated = EnumerableExtensions.Generate(generator, 5).ToList();

      var range = Enumerable.Range(0, 5);

      Assert.IsTrue(generated.SequenceEqual(range));
    }
  }
}

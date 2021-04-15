using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Helpers.Test
{
    [TestClass]
    public class StringLibraryTest
    {
        [TestMethod]
        public void CutStringTest()
        {
            string strCut = "Hello World, This is a test sentence";
            int intChar = 15;

            var expected = "Hello World,..."; // CutString 예상 결과
            var actual = StringLibrary.CutString(strCut, intChar);
            
            // Assert 클래스
            // : 단위 테스트 내에서 다양한 조건을 테스트하기 위한 도우미 클래스의 컬렉션입니다. 테스트 중인 조건이 충족되지 않으면 예외가 throw됩니다.
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CutStringUnicodeTest()
        {
            string strCut = "안녕하세요. 부경대학교입니다.";
            int intChar = 9;

            var expected = "안녕하세요....";
            var actual = StringLibrary.CutStringUnicode(strCut, intChar);
            
            // Assert 클래스
            // : 단위 테스트 내에서 다양한 조건을 테스트하기 위한 도우미 클래스의 컬렉션입니다. 테스트 중인 조건이 충족되지 않으면 예외가 throw됩니다.
            Assert.AreEqual(expected, actual);
        }

        // [Ignore]
        // : 단위 테스트 무시(배제)
        [Ignore]
        [TestMethod]
        public void AddTest()
        {
            var expected = 10;
            var actual = (5 + 5);

            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void IsPhotoTest()
        {
            var imagePath = @"D:\GitRepository\main.png";
            bool result = BoardLibrary.IsPhoto(imagePath);

            Assert.IsTrue(result, "file extension must be png, jpg, gif");
        }
    }
}

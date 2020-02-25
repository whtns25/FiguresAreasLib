using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FiguresAreasLib.Tests
{
    [TestClass]
    public class FiguresAreasTests
    {
        [TestMethod]
        public void CirclesArea_5_and_3in__47_123returned()  //круг
        {
            //arrange 
            double R = 5;
            double r = 3;
            double expected = 47.124;

            //act
            FiguresAreas a = new FiguresAreas();
            double actual = a.CirclesArea(R, r);

            //assert
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void CirclesArea_5in__3in()    //эллипс
        {
            //arrange 
            double R = 5;
            double expected = 78.54;

            //act
            FiguresAreas a = new FiguresAreas();
            double actual = a.CirclesArea(R);

            //assert
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void TrianglesArea_5_6_7in__14_7returned()   //треугольник
        {
            //arrange 
            double a = 5;
            double b = 6;
            double c = 7;
            double expected = 14.697;

            //act
            FiguresAreas d = new FiguresAreas();
            double actual = d.TrianglesArea(a, b, c);

            //assert
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void TrianglesCheck_trueReturned()  //прямоугольный треугольник (чек)
        {

            //arrange 
            double a = 5;
            double b = 3;
            double c = 4;
            bool expected = true;

            //act
            FiguresAreas d = new FiguresAreas();
            bool actual = d.TrianglesCheck(a, b, c);

            //assert
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void TrianglesCheck_falseReturned() //непрямоугольный треугольник (чек)
        {
            //arrange 
            double a = 6;
            double b = 6;
            double c = 6;
            bool expected = false;

            //act
            FiguresAreas d = new FiguresAreas();
            bool actual = d.TrianglesCheck(a, b, c);

            //assert
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void CustomFiguresArea_8coords_16returned() //кастомная фигура, квадрат
        {
            //arrange 
            const int a = 8;
            int[] coords = new int[a] { 0, 0, 0, 4, 4, 4, 4, 0 };
            double expected = 16;

            //act
            FiguresAreas d = new FiguresAreas();
            double actual = d.CustomFiguresArea(coords);

            //assert
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void CustomFiguresArea_14coords_39returned() //кастомная фигура, произвольный семиугольник
        {
            //arrange 
            const int a = 14;
            int[] coords = new int[a] { -5, -2, -5, 2, -2, 5, 1, 5, 2, 2, 0, -1, -3, -3 };
            double expected = 39;

            //act
            FiguresAreas d = new FiguresAreas();
            double actual = d.CustomFiguresArea(coords);

            //assert
            Assert.AreEqual(expected, actual);
        }

    }
}

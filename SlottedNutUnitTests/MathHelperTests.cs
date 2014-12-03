using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MathLogic;

namespace SlottedNutUnitTests
{
    /// <summary>
    /// Класс, тестрирующий  методы класса  MathHelper
    /// </summary>
    [TestClass]
    public class MathHelperTests
    {   
        /// <summary>
        /// Точность
        /// </summary>
        private const double Epsilon = 0.01;

        /// <summary>
        /// Список тестовых образующих координат шлицев для четырешлицевой гайки
        /// </summary>
        private readonly List<Point> _testCoordsByFourSlot = new List<Point>
        {
            new Point(9.5,2.0),new Point(9.5,-2.0), new Point( 10.816,2.0),
            new Point( 10.816,-2.0), new Point(-2.000,9.499), new Point(1.999,9.500),
            new Point(-2.000,10.817), new Point(1.999,10.816), new Point(-9.499,
            -2.000), new Point(-9.500,1.999), new Point(-10.816,-2.000), new Point(-10.816,1.999), new Point(2.000,-9.499),
            new Point(-1.999, -9.500), new Point(2.000,-10.816), new Point(-1.999,-10.816)
        };

        /// <summary>
        /// Список тестовых образующих координат шлицев для шестишлицевой гайки
        /// </summary>
        private readonly List<Point> _testCoordsBySixSlot = new List<Point>
        {
            new Point(32.0,4.0),new Point(32.0,-4.0), new Point( 34.770,4.0),
            new Point(34.770,-4.0), new Point( 12.535,29.712), new Point(19.464,25.712),
            new Point(13.921,32.112), new Point(20.849,28.112), new Point(-19.464,25.712),
            new Point( -12.536,29.712), new Point(-20.849,28.112), new Point(-13.921,32.112), new Point(-31.999,-4.000),
            new Point( -32.000,3.999), new Point(-34.770,-4.000), new Point(-34.770,3.999), new Point(-12.535,-29.712), 
            new Point(-19.463,-25.713),new Point(-13.920,-32.112), new Point( -20.849,-28.112), new Point( 19.464,
                  -25.712), new Point(12.536,-29.712), new Point(20.849,-28.112), new Point(13.921,-32.112)
        };


        /// <summary>
        /// Список тестовых координат средних углов
        /// </summary>
        /// <returns></returns>
        private readonly List<double> _testCoordsForMediumAngles = new List<double> {0, 1.047, 2.094, 3.141, 4.188, 5.236};
           
        

        /// <summary>
        /// Тестирование на корректность работы метода GetCoordForSlots при четырех шлицах с точностью 0.001
        /// </summary>
        [TestMethod]
        public void GetCoordForSlotsTestByFourSlots()

        {
            var coordsOfSlot = MathHelper.GetCoordForSlots(22.0,4.0,1.5,4);
            var actualCountOfCoords =  coordsOfSlot.Count;
            
            for(int i = 0; i < coordsOfSlot.Count; i++)
            {
                Assert.IsTrue(Math.Abs(coordsOfSlot[i].X- _testCoordsByFourSlot[i].X) <= Epsilon);
                Assert.IsTrue(Math.Abs(coordsOfSlot[i].Y - _testCoordsByFourSlot[i].Y) <= Epsilon);
            }
            Assert.AreEqual(actualCountOfCoords,16);
        }

        /// <summary>
        /// Тестирование на корректность работы метода GetCoordForSlots при шести шлицах с точностью 0.001
        /// </summary>
        [TestMethod]
        public void GetCoordForSlotsTestBySixSlots()
        {
            var coordsOfSlot = MathHelper.GetCoordForSlots(70.0, 8.0, 3.0, 6);
            var actualCountOfCoords = coordsOfSlot.Count;
            for (int i = 0; i < coordsOfSlot.Count; i++)
            {
                Assert.IsTrue(Math.Abs(coordsOfSlot[i].X - _testCoordsBySixSlot[i].X) < Epsilon);
                Assert.IsTrue(Math.Abs(coordsOfSlot[i].Y - _testCoordsBySixSlot[i].Y) < Epsilon);
            }
            
            Assert.AreEqual(actualCountOfCoords, 24); 

        }

        /// <summary>
        /// Тестирование на корректность работы метода GetMediumAnglesByRadian с заданной точностью 0.001
        /// </summary>
        [TestMethod]
        public void GetMediumAnglesByRadianTest()
        {
            var valuesByByMediumAngles = MathHelper.GetMediumAnglesByRadian(6);
            var actualCountOfCoords = valuesByByMediumAngles.Count;
           
            Assert.AreEqual(actualCountOfCoords, 6);
            for (int i = 0; i < valuesByByMediumAngles.Count; i++)
            {
                Assert.IsTrue(Math.Abs(valuesByByMediumAngles[i] - _testCoordsForMediumAngles[i]) < Epsilon);
            }
        }
    }
}

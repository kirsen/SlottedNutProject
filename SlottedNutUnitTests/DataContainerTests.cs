using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataOrganizer;

namespace SlottedNutUnitTests
{
    /// <summary>
    /// Класс, тестирующий класс DataContainer
    /// </summary>
    [TestClass]
    public class DataContainerTests
    {   
        /// <summary>
        /// Тестовые данные для внешнего диаметра
        /// </summary>
        private readonly List<double> _testDatesForOutsideDiameter = new List<double>
        {   
            16.0, 22.0, 24.0, 26.0, 28.0, 30.0, 32.0, 34.0, 
            38.0, 42.0,45.0, 48.0, 52.0, 55.0, 60.0, 65.0, 70.0, 75.0, 78.0, 80.0, 85.0, 
            90.0, 95.0, 100.0, 105.0, 110.0, 115.0
        };

        /// <summary>
        /// Тестовые данные для диаметра основания
        /// </summary>
        private readonly List<double> _testDatesForBaseDiameter = new List<double>
        {
            11.5, 13.5, 15.5, 17.5, 18.5, 22.5, 24.0, 26.0, 29.0, 31.0, 35.0, 38.0, 40.0, 42.0, 48.0, 52.0, 55.0,
            58.0, 61.0, 65.0, 70.0, 75.0, 80.0, 95.0, 100.0
        };

        /// <summary>
        /// Тестовые данные для высоты гайки
        /// </summary>
        private readonly List<double> _testDatesForHeightNut = new List<double> { 5.0, 6.0, 8.0, 10.0, 12.0, 15.0 };

        /// <summary>
        /// Тестовые данные для диаметра резьбы
        /// </summary>
        private readonly List<double> _testDatesForThreadDiameter = new List<double>
        {
              6.0, 8.0, 10.0, 12.0, 14.0, 16.0, 18.0, 20.0, 22.0, 24.0
             , 27.0, 30.0, 33.0, 36.0, 39.0, 42.0, 45.0, 48.0, 50.0
             , 52.0, 56.0, 58.0, 60.0, 62.0, 64.0, 68.0, 70.0, 72.0, 76.0, 80.0
        };

        /// <summary>
        /// Тестовые данные для высоты шлица
        /// </summary>
        private readonly List<double> _testDatesForHeightSlot = new List<double> { 1.5, 2.0, 2.5, 3.0, 3.5, 4.0 };

        /// <summary>
        /// Тестовые данные для ширины шлица
        /// </summary>
        private readonly List<double> _testDatesForWidthSlot = new List<double> { 4.0,6.0,8.0,10.0};

        /// <summary>
        /// Тестовые данные для шага резьбы
        /// </summary>
        private readonly List<double> _testDatesForStepOfThread = new List<double> {0.5,1.0,1.25,1.5,2.0 };

        /// <summary>
        /// Тестовые данные для диаметра скругления
        /// </summary>
        private readonly List<double> _testDatesForRoundingDiameter= new List<double> {0.6,1.0,1.6 };

        /// <summary>
        /// Тестирование структуры NutDescription на корректность работы
        /// </summary>
        [TestMethod]
        public void NutDescriptionTest()
        {
           var nutDescription = new DataContainer.NutDescription(70.0,55.0,10.0,3.0,8.0,45.0,1.5,1.0,6);
           Assert.AreEqual(nutDescription.OutsideDiameter, 70.0);
           Assert.AreEqual(nutDescription.BaseDiameter, 55.0);
           Assert.AreEqual(nutDescription.HeightNut, 10.0);
           Assert.AreEqual(nutDescription.HeightSlot, 3.0);
           Assert.AreEqual(nutDescription.WidthSlot, 8.0);
           Assert.AreEqual(nutDescription.ThreadDiameter, 45.0);
           Assert.AreEqual(nutDescription.ThreadStep, 1.5);
           Assert.AreEqual(nutDescription.RoundingDiameter, 1.0);
           Assert.AreEqual(nutDescription.CountOfSlot, 6.0);
        }
       
        /// <summary>
        /// Тестирование на корректность реализации свойства OutsideDiameters
        /// </summary>
        [TestMethod]
        public void TestPropertyOutsideDiameters()
        {
            var dataContainer = new DataContainer();
            var actualOutsideDiameters = dataContainer.OusideDiameters;
            var outsideDiameters = actualOutsideDiameters as IList<double> ?? actualOutsideDiameters.ToList();

            for (int i = 0; i < outsideDiameters.Count; i++)
            {
                Assert.AreEqual(outsideDiameters[i], _testDatesForOutsideDiameter[i]);
            }
    
            Assert.AreEqual(outsideDiameters.Count, 27);
           

        }
       
        /// <summary>
        /// Тестирование на корректность реализации свойства BaseDiameters
        /// </summary>
        [TestMethod]
        public void TestPropertyBaseDiameters()
        {

            var dataContainer = new DataContainer();
            var actualBaseDiameters = dataContainer.BaseDiameters;

            var baseDiameters = actualBaseDiameters as IList<double> ?? actualBaseDiameters.ToList();
            
            for (int i = 0; i < baseDiameters.Count; i++)
            {
                Assert.AreEqual(baseDiameters[i], _testDatesForBaseDiameter[i]);
            }

            Assert.AreEqual(baseDiameters.Count, 25);
        }

        /// <summary>
        /// Тестирование на корректность реализации свойства HeightNuts
        /// </summary>
        [TestMethod]
        public void TestPropertyHeightNuts()
        {

            var dataContainer = new DataContainer();
            var actualHeightNut = dataContainer.HeightNuts;

            var heightNuts = actualHeightNut as IList<double> ?? actualHeightNut.ToList();
            for (int i = 0; i < heightNuts.Count; i++)
            {
                Assert.AreEqual(heightNuts[i], _testDatesForHeightNut[i]);
            }

            Assert.AreEqual(heightNuts.Count, 6);
        }

        /// <summary>
        /// Тестирование на корректность реализации свойства HeightSlots
        /// </summary>
        [TestMethod]
        public void TestPropertyHeightSlots()
        {

            var dataContainer = new DataContainer();
            var actualHeightSlots = dataContainer.HeighSlots;


            var heightSlots = actualHeightSlots as IList<double> ?? actualHeightSlots.ToList();
            for (int i = 0; i < heightSlots.Count; i++)
            {
                Assert.AreEqual(heightSlots[i], _testDatesForHeightSlot[i]);
            }
            Assert.AreEqual(heightSlots.Count, 6);
        }

        /// <summary>
        /// Тестирование на корректность реализации свойства WidthSlots
        /// </summary>
        [TestMethod]
        public void TestPropertyWidthSlots()
        {

            var dataContainer = new DataContainer();
            var actualWidthSlots = dataContainer.WidthSlots;
            var widthSlots = actualWidthSlots as IList<double> ?? actualWidthSlots.ToList();
            for (int i = 0; i < widthSlots.Count; i++)
            {
                Assert.AreEqual(widthSlots[i], _testDatesForWidthSlot[i]);
            }

            Assert.AreEqual(widthSlots.Count, 4);
        }

        /// <summary>
        /// Тестирование на корректность реализации свойства ThreadDiameters
        /// </summary>
        [TestMethod]
        public void TestPropertyThreadDiameters()
        {
            var dataContainer = new DataContainer();
            var actualThreadDiameters = dataContainer.ThreadDiameters;
            var threadDiameters = actualThreadDiameters as IList<double> ?? actualThreadDiameters.ToList();

            for (int i = 0; i < threadDiameters.Count; i++)
            {
                Assert.AreEqual(threadDiameters[i], _testDatesForThreadDiameter[i]);
            }

            Assert.AreEqual(threadDiameters.Count, 30);

        }

        /// <summary>
        /// Тестирование на корректность реализации свойства ThreadSteps
        /// </summary>
        [TestMethod]
        public void TestPropertyThreadSteps()
        {
            var dataContainer = new DataContainer();
            var actualThreadSteps = dataContainer.ThreadSteps;
            var threadSteps = actualThreadSteps as IList<double> ?? actualThreadSteps.ToList();
            for (int i = 0; i < threadSteps.Count; i++)
            {
                Assert.AreEqual(threadSteps[i], _testDatesForStepOfThread[i]);
            }
            Assert.AreEqual(threadSteps.Count, 5);
        }

        /// <summary>
        /// Тестирование на корректность реализации свойства RoundingDameters
        /// </summary>
        [TestMethod]
        public void TestPropertyRoundingDiameters()
        {

            var dataContainer = new DataContainer();
            var actualRoundingDiameters = dataContainer.RoundingDiameters;
            var roundingDiameters = actualRoundingDiameters as IList<double> ?? actualRoundingDiameters.ToList();
            for (int i = 0; i < roundingDiameters.Count; i++)
            {
                Assert.AreEqual(roundingDiameters[i], _testDatesForRoundingDiameter[i]);
            }
            Assert.AreEqual(roundingDiameters.Count, 3);
        }
    }
}

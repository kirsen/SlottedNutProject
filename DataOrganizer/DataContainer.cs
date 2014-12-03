using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DataOrganizer
{
    /// <summary>
    /// Класс хранения и описания данных
    /// </summary>
  public  class DataContainer
  {
      #region Properties
     /* /// <summary>
      /// Свойство,возвращающее экземпляры структуры, описывающие параметры гайки
      /// </summary>
        public virtual List<NutDescription> SlottedNutSamples
        {
            get { return new List<NutDescription>(); }
            
        }*/

      public  List<NutDescription> SlottedNutSamples
      {
          get
          {
              var samples = new List<NutDescription>
                {
                    new NutDescription(16, 11.5, 5, 1.5, 4, 6, 0.5, 0.6,4),
                    new NutDescription(22, 13.5, 6, 1.5, 4, 8, 1.0, 0.6,4),
                    new NutDescription(24, 15.5, 8, 1.5, 4, 10, 1.25, 0.6,4),
                    new NutDescription(26, 17.5, 8, 1.5, 6, 12, 1.25, 0.6,4),
                    new NutDescription(28, 18.5, 8, 2.0, 6, 14, 1.5, 0.6,4),
                    new NutDescription(30, 22.5, 8, 2.0, 6, 16, 1.5, 0.6,4),
                    new NutDescription(32, 24.0, 8, 2.0, 6, 18, 1.5, 1, 4),
                    new NutDescription(34, 26.0, 8, 2.0, 6, 20, 1.5, 1,4),
                    new NutDescription(38, 29.0, 10, 2.5, 6, 22, 1.5, 1,4),
                    new NutDescription(42, 31.0, 10, 2.5, 6, 24, 1.5, 1,4),
                    new NutDescription(45, 35.0, 10, 2.5, 6, 27, 1.5, 1,4),
                    new NutDescription(48, 38.0, 10, 2.5, 6, 30, 1.5, 1,4),
                    new NutDescription(52, 40.0, 10, 3, 8, 33, 1.5, 1,4),
                    new NutDescription(55, 42.0, 10, 3, 8, 36, 1.5, 1,4),
                    new NutDescription(60, 48.0, 10, 3, 8, 39, 1.5, 1,4),
                    new NutDescription(65, 52.0, 10, 3, 8, 42, 1.5, 1,4),
                    new NutDescription(70, 55.0, 10, 3, 8, 45, 1.5, 1,6),
                    new NutDescription(75, 58.0, 12, 3.5, 8, 48, 1.5, 1,6),
                    new NutDescription(78, 61.0, 12, 3.5, 8, 50, 1.5, 1,6),
                    new NutDescription(80, 61.0, 12, 3.5, 10, 52, 1.5, 1,6),
                    new NutDescription(85, 65.0, 12, 4, 10, 56, 2, 1.6,6),
                    new NutDescription(90, 70.0, 12, 4, 10, 58, 2, 1.6,6),
                    new NutDescription(90, 70.0, 12, 4, 10, 60, 2, 1.6,6),
                    new NutDescription(95, 75.0, 12, 4, 10, 62, 2, 1.6,6),
                    new NutDescription(95, 75.0, 12, 4, 10, 64, 2, 1.6,6),
                    new NutDescription(100, 80.0, 15, 4, 10, 68, 2, 1.6,6),
                    new NutDescription(100, 80.0, 15, 4, 10, 70, 2, 1.6,6),
                    new NutDescription(105, 95, 15, 4, 10, 72, 2, 1.6,6),
                    new NutDescription(110, 95, 15, 4, 10, 76, 2, 1.6,6),
                    new NutDescription(115, 100, 15, 4, 10, 80, 2, 1.6,6)
                };
              return samples;
          }

      }

        /// <summary>
        /// Свойство,возвращающее варианты внешних диаметров экземпляров гайки
        /// </summary>
        public  IEnumerable<double> OusideDiameters
        {
            get { return  new List<double>(from sample in SlottedNutSamples select sample.OutsideDiameter).Distinct(); }
        }

        /// <summary>
        /// Свойство,возвращающее варианты диаметар основания экземпляров гайки
        /// </summary>
        public IEnumerable<double> BaseDiameters
        {
            get { return new List<double>(from sample in SlottedNutSamples select sample.BaseDiameter).Distinct(); }
        }

        /// <summary>
        /// Свойство,возвращающее варианты высоты  экземпляров гайки
        /// </summary>
        public IEnumerable<double> HeightNuts
        {
            get { return new List<double>(from sample in SlottedNutSamples select sample.HeightNut).Distinct(); }
        }
        
        /// <summary>
        /// Свойство,возвращающее варианты высоты шлица  экземпляров гайки
        /// </summary>
        public IEnumerable<double> HeighSlots
        {
            get { return new List<double>(from sample in SlottedNutSamples select sample.HeightSlot).Distinct(); }
        }

        /// <summary>
        /// Свойство,возвращающее варианты ширины шлица  экземпляров гайки
        /// </summary>
        public IEnumerable<double> WidthSlots
        {
            get { return new List<double>(from sample in SlottedNutSamples select sample.WidthSlot).Distinct(); }
        }

        /// <summary>
        /// Свойство,возвращающее варианты диаметра резьбы  экземпляров гайки
        /// </summary>
        public IEnumerable<double> ThreadDiameters
        {
            get { return new List<double>(from sample in SlottedNutSamples select sample.ThreadDiameter).Distinct(); }
        }

        /// <summary>
        /// Свойство,возвращающее варианты шага резьбы  экземпляров гайки
        /// </summary>
        public IEnumerable<double> ThreadSteps
        {
            get { return new List<double>(from sample in SlottedNutSamples select sample.ThreadStep).Distinct(); }
        }

        /// <summary>
        /// Свойство,возвращающее варианты диаметра скругления экземпляров гайки
        /// </summary>
        public IEnumerable<double> RoundingDiameters
        {
            get { return new List<double>(from sample in SlottedNutSamples select sample.RoundingDiameter).Distinct(); }
        }

        /// <summary>
        /// Свойство,возвращающее варианты количества шлицев
        /// </summary>
      public IEnumerable<int> CountOfSlot
      {
          get { return new List<int>(from sample in SlottedNutSamples select sample.CountOfSlot).Distinct(); }
      }

      #endregion

      #region NutDescription
      /// <summary>
      /// Структура, описывающая гайку по параметрам
      /// </summary>
      public struct NutDescription
        {
           /// <summary>
           /// Внешний диаметр
           /// </summary>
            public double OutsideDiameter;

          /// <summary>
          /// Диаметр основания
          /// </summary>
            public double BaseDiameter;

          /// <summary>
          /// Высота гайки
          /// </summary>
            public double HeightNut;

          /// <summary>
          /// Высота шлица
          /// </summary>
            public double HeightSlot;

          /// <summary>
          /// Ширина шлица
          /// </summary>
            public double WidthSlot;

          /// <summary>
          /// Диаметр резьбы
          /// </summary>
            public double ThreadDiameter;

          /// <summary>
          /// Шаг резьбы
          /// </summary>
            public double ThreadStep;

          /// <summary>
          /// Диаметр резьбы
          /// </summary>
            public double RoundingDiameter;

          /// <summary>
          /// Количество шлицев
          /// </summary>
            public int CountOfSlot;

          /// <summary>
          /// Конструктор структуры
          /// </summary>
          /// <param name="outsideDiameter">Внешний диаметр</param>
          /// <param name="baseDiaemeter">Диаметр основания</param>
          /// <param name="heightNut">Высота гайки</param>
          /// <param name="heightSlot">Высота шлица</param>
          /// <param name="widthSlot">Ширина шлица</param>
          /// <param name="threadDiameter">Диаметр резьбы</param>
          /// <param name="threadStep">Шаг резьбы</param>
          /// <param name="roundingDiaemeter">Диаметр скругления</param>
          /// <param name="countOfSlot">Количество шлицев</param>
            public NutDescription(double outsideDiameter, double baseDiaemeter, double heightNut, double heightSlot,
                double widthSlot, double threadDiameter,
                double threadStep, double roundingDiaemeter,int countOfSlot)
            {
                this.OutsideDiameter = outsideDiameter;
                this.BaseDiameter = baseDiaemeter;
                this.HeightNut = heightNut;
                this.HeightSlot = heightSlot;
                this.WidthSlot = widthSlot;
                this.ThreadDiameter = threadDiameter;
                this.ThreadStep = threadStep;
                this.RoundingDiameter = roundingDiaemeter;
                this.CountOfSlot = countOfSlot;

            }



        }
      #endregion
  }
}

using System;
using System.Collections.Generic;

namespace MathLogic
{
    /// <summary>
    ///  Статический, вспомогательныx математических операций
    /// </summary>
    public static class MathHelper
    {
        /// <summary>
        /// Получение координаты пересечения прямой и окружности
        /// </summary>
        /// <param name="radius">Радиус окружности</param>
        /// <param name="coord1">Координата (входная) по х или у </param>C:\Users\kira\slottednut\SlottedNut\MathLogic\MathHelper.cs
        /// <param name="flag">Определяет знак координаты</param>
        /// <returns>Координата, выраженная через входную</returns>
        private static double GetCoordIntersectLineByCircule(double radius, double coord1, bool flag)
        {
           //Выражение координы через входную координату на основе уравнения окружности
           var coord2 = Math.Abs(Math.Pow((Math.Pow(radius, 2) - Math.Pow(coord1, 2)), 0.5));
            return flag ? coord2 : -coord2;
        }
        #region MultiplyMatrix
        /// <summary>
        /// Умножение матриц
        /// </summary>
        /// <param name="matrixA">Матрица- первый множитель</param>
        /// <param name="matrixB">Матрица - второй множитель</param>
        /// <returns>Выходная матрица как результат умножения</returns>
        private static List<Point> MultiplyMatrix(List<Point> matrixA, List<Point> matrixB)
        {
            var matrixC = new List<Point>();// Произведение

            //Инициализация матрицы произведения
            for (int i = 0; i < 4; i++)
            {
                var matrix = new Point {X = 0, Y = 0};

                matrixC.Add(matrix);
            }   
            // Подсчет произведения матриц
            for (int i = 0; i < matrixA.Count; i++)
            {

                    var sum = new Point(0, 0);
                    sum.X += matrixA[i].X*matrixB[0].X + matrixA[i].Y*matrixB[1].X; //matrixA[i][k] * matrixB[k][j];
                    sum.Y += matrixA[i].X*matrixB[0].Y + matrixA[i].Y*matrixB[1].Y;
                
                matrixC[i] = sum;
                
            }
            return matrixC;
        }
        #endregion
        #region RotateMatrix
        /// <summary>
        /// Получение матрицы вращения
        /// </summary>
        /// <param name="angle">Угол вращения</param>
        /// <returns>матрица вращения по заданному углу</returns>
        private static List<Point> GetRotateMatrix(double angle)
        {
            var angleByRadian = angle * Math.PI / 180; //Перевод в радианы

            var rotateMatrix = new List<Point> { new Point(Math.Cos(angleByRadian),Math.Sin(angleByRadian) ), 
                new Point(-Math.Sin(angleByRadian),Math.Cos(angleByRadian))};
        

            return rotateMatrix;
        }
#endregion
        
        #region MediumAnglesByRadian
        /// <summary>
        /// Получение промежуточныч углов между шлицами в радианах
        /// </summary>
        /// <param name="countOfAngle">Количество углов</param>
        /// <returns>Промежуточные углы в радианах</returns>
        public static List<double> GetMediumAnglesByRadian(int countOfAngle)
        {
           var rotateAngle = 360/countOfAngle;//  Получение количества углов
            var mediumAngles = new List<double>();
            var angle = 0;
            for (int i = 0; i < countOfAngle; i++)
            {
                mediumAngles.Add(angle * Math.PI / 180);
                angle += rotateAngle;
            }
           

            return mediumAngles;
        }
        #endregion

        #region GetBaseSlotCoords
        /// <summary>
        /// Получения первых базовых координат шлица
        /// </summary>
        /// <param name="outsideDiameter">Внешний диаметр</param>
        /// <param name="slotWeight">Ширина шлица</param>
        /// <param name="slotHeight">Высота шлица</param>
        /// <returns>Базовые координаты</returns>
        private static List<Point> GetBaseSlotCoords(double outsideDiameter, double slotWeight, double slotHeight)
        {
            double radius = (outsideDiameter / 2);

            var baseSlotDotCoords = new List<Point>();
            var pointLeftDown = new Point(radius - slotHeight, slotWeight / 2);
            var pointRightDown = new Point(radius - slotHeight, -slotWeight / 2);
            var pointLeftUp = new Point(GetCoordIntersectLineByCircule(radius, (slotWeight / 2),true), slotWeight / 2);
            var pointRightUp = new Point(GetCoordIntersectLineByCircule(radius, (slotWeight / 2), true), -slotWeight / 2);

           
            baseSlotDotCoords.Add(pointLeftDown);
            baseSlotDotCoords.Add(pointRightDown);
            baseSlotDotCoords.Add(pointLeftUp);
            baseSlotDotCoords.Add(pointRightUp);

            return baseSlotDotCoords;
        }
        #endregion
        #region GetCoordsForSlots
        /// <summary>
        /// Получение координат шлицев
        /// </summary>
        /// <returns>краевые координаты шлицев</returns>
        public static List<Point>  GetCoordForSlots(double outsideDiamter, double slotWidth,double slotHeght, int countOfSlot)
        {
            var angle = 360/countOfSlot;
        
           var baseAngle = angle;
           
           var coordDots = new List<Point>();

           //Получение первых базовых координат для вращения
           var baseDots = GetBaseSlotCoords(outsideDiamter, slotWidth, slotHeght);

          //  Добавление базовых в основной список координат
           coordDots.AddRange(baseDots);
          
            //Получение последующих координат согласно количества шлицев
            for (int i = 1; i < countOfSlot; i++)
            {
              // Получение матрицы вращения
               var rotateMatrix = GetRotateMatrix(angle);
              
              //Вращение текущих координат умножением на матрицу вращения
               angle += baseAngle;

               coordDots.AddRange(MultiplyMatrix(baseDots, rotateMatrix));
            }
        

            return coordDots;
        }
        #endregion
    }


    public struct Point
    {
        public double X;
        public double Y;

        public Point(double x, double y)
        {
            X = x;
            Y = y;

        }
    }
}

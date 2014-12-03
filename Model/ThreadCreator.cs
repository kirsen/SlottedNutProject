using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kompas6API5;
using Kompas6Constants3D;

namespace Model
{
   /// <summary>
   /// Статический, вспомогательный класс для создания резьбы
   /// </summary>
   public static class ThreadCreator
   {
       #region CreateSpiral
       /// <summary>
       /// Создание спирали по которой будет создаваться резьба
       /// </summary>
       /// <param name="part">Ссылка на интерфейс элемента модели</param>
       /// <param name="doc">Ссылка на редактируемый документ сборки</param>
       /// <param name="step">Шаг резьбы</param>
       /// <param name="depth">Глубина резьбы </param>
       /// <param name="threadDiameter">Внешний диаметр</param>
       /// <returns>Ссылка на интерфейс элемента спираль</returns>
       static private ksEntity CreateSpiral(ksPart part, ksDocument3D doc, double step, double depth, double threadDiameter)
        {
           //Получение интерфейса для создаваемого объекта спираль
            var entitySpiral = (ksEntity)part.NewEntity((short)Obj3dType.o3d_cylindricSpiral);
         
           if (entitySpiral != null)
            {
               //Получение интерфейса параметров объекта
                var sketchDefinition = (ksCylindricSpiralDefinition)entitySpiral.GetDefinition();
               
               if (sketchDefinition != null)
                {
                    //Получение базовой плоскости для установления спирали
                    var basePlane = (ksEntity)part.GetDefaultEntity((short)Obj3dType.o3d_planeXOY);
                 
                   //Установление плоскости
                    sketchDefinition.SetPlane(basePlane);


                    sketchDefinition.buildDir = true;  //Направление резьбы
                    sketchDefinition.buildMode = 1;
                    sketchDefinition.step = step;  //Шаг резьбы
                    sketchDefinition.height = depth; //Глубина резьбы
                    sketchDefinition.firstAngle = 0;
                    sketchDefinition.diam = threadDiameter;
                    entitySpiral.Create();
                }
            }
         
           return entitySpiral;
        }
       #endregion

       #region CutEvolution
       /// <summary>
       /// Кинематическое вырезание
       /// </summary>
       /// <param name="part">Ссылка на интерфейс элемента модели</param>
       /// <param name="entitySketch">Ссылка на эскиз</param>
       /// <param name="entitySpiral">Ссылка на интерфейс объекта спираль</param>
       static void CutEvolution(ksPart part, ksEntity entitySketch, ksEntity entitySpiral)
       {
           var entityCutEvolution = (ksEntity)part.NewEntity((short)Obj3dType.o3d_cutEvolution);

          // Получение параметров кинематической операции вырезания
           var cutEvolutionDefinition = (ksCutEvolutionDefinition)entityCutEvolution.GetDefinition();
           
           cutEvolutionDefinition.cut = true; //Вычитание объектов
           cutEvolutionDefinition.sketchShiftType = 1;//Тип движения
           cutEvolutionDefinition.SetSketch(entitySketch);// Устанавливаем эскиз сечения
           var entityCollection = (ksEntityCollection)cutEvolutionDefinition.PathPartArray();// Получаем массив объектов
           entityCollection.Clear();
           entityCollection.Add(entitySpiral);
           entityCutEvolution.Create();// Создаем операцию

       }
       #endregion
       #region CreateSemiCircule
       /// <summary>
       /// Создания полукруга, который вырезает резьбу по спирали
       /// </summary>
       /// <param name="part">Ссылка на интерфейс элемента модели</param>
       /// <param name="threadDiameter">Диаметр резьбы</param>
       /// <param name="step">Шаг резьбы</param>
       /// <returns>Ссылка на эскиз полукруга</returns>
       static private ksEntity CreateSemiCircule(ksPart part, double threadDiameter, double step)
        {
            var entitySketch = (ksEntity)part.NewEntity((short)Obj3dType.o3d_sketch);
            var sketchDefinition = (ksSketchDefinition)entitySketch.GetDefinition();

                if (sketchDefinition != null)
                {
                    var basePlane = (ksEntity) part.GetDefaultEntity((short)Obj3dType.o3d_planeXOZ);
                   
                    sketchDefinition.SetPlane(basePlane);
                    entitySketch.Create();
                   
                    //Коррдинаты точки слева основания полукруга
                    var x1 = threadDiameter/2;
                    var y1 = (step*0.5) - 0.01; //0.01 -шаг отставания между линиями резьбы

                    //Коррдинаты центральной верхней точки дуги
                    var x2 = threadDiameter/2 + step/2;
                    var y2 = 0;
                    
                    //Коррдинаты точки справа основания полукруга
                    var x3 = threadDiameter/2;
                    var y3 = 0.01 - (step*0.5);

                   // Редактирование эскиза,создание полукруга по дуге и отрезку
                    var sketchEdit = (ksDocument2D) sketchDefinition.BeginEdit();
                    sketchEdit.ksLineSeg(x1, y1, x3, y3, 1);
                    sketchEdit.ksArcBy3Points(x1,y1,x2,y2,x3,y3,1);
                    
                    sketchDefinition.EndEdit();
                }
            return entitySketch;

        }
       #endregion
       #region CreateTriangle
       /// <summary>
       /// Создания треугольника, который вырезает резьбу по спирали
       /// </summary>
       /// <param name="part">Ссылка на интерфейс элемента модели</param>
       /// <param name="threadDiameter">Диаметр резьбы</param>
       /// <param name="step">Шаг резьбы</param>
       /// <returns>Ссылка на эскиз треугольника</returns>
        static private ksEntity CreateTriangle(ksPart part, double threadDiameter, double step)
        {
             var entitySketch = (ksEntity)part.NewEntity((short)Obj3dType.o3d_sketch);
             var sketchDefinition = (ksSketchDefinition)entitySketch.GetDefinition();
               
            if (sketchDefinition != null)
                {
                    var basePlane = (ksEntity)part.GetDefaultEntity((short)Obj3dType.o3d_planeXOZ);
                    sketchDefinition.SetPlane(basePlane);
                    entitySketch.Create();
                    
                  // Координаты вершин треугольника
                    var x1 = threadDiameter/2;
                    var y1 = (step*0.5) - 0.01; //0.01 - шаг оставания между линиями резьбы
                    var x2 = threadDiameter/2 + step;
                    var y2 = 0;
                    var x3 = threadDiameter/2;
                    var y3 = 0.01 - (step*0.5);
                    
                //Редактирование эскиза,создание треугольника по трем отрезакм
                    var sketchEdit = (ksDocument2D)sketchDefinition.BeginEdit();
                    sketchEdit.ksLineSeg(x1, y1, x2, y2, 1);
                    sketchEdit.ksLineSeg(x2, y2, x3, y3, 1);
                    sketchEdit.ksLineSeg(x3, y3, x1, y1, 1);
                    sketchDefinition.EndEdit();
                }
            return entitySketch;

        }
       #endregion
       #region CreateThread
        /// <summary>
       /// Создание резьбы
       /// </summary>
       /// <param name="part">Ссылка на интерфейса элемента модели</param>
       /// <param name="doc">Ссылка на документ сборки</param>
       /// <param name="step">Шаг резьбы</param>
       /// <param name="depth">Глубина резьбы</param>
       /// <param name="threadDiameter">Внешний диаметр</param>
       /// <param name="type">Тип резьбы 0 - треугольная, 1 - круглая</param>
        static public void CreateThread(ksPart part, ksDocument3D doc, double step, double depth, double threadDiameter, int type)
        {
            if (type == 0)
            {   
                //Создание спирали
                var entitySpiral = CreateSpiral(part, doc, step, depth, threadDiameter);
                
               // Создание треугольника
                var entitySketch = CreateTriangle(part, threadDiameter, step);
               
                //Кинематическое вырезание резьбы треугольником по траектории спирали
                CutEvolution(part, entitySketch, entitySpiral);
            }
            else
            {
                //Создание спирали
                var entitySpiral = CreateSpiral(part, doc, step, depth, threadDiameter);
                
                //Создание полуокружности
                var entitySketch = CreateSemiCircule(part, threadDiameter, step);

                //Кинематическое вырезание резьбы треугольником по траектории спирали
                CutEvolution(part, entitySketch, entitySpiral);
                
            }

        }
        #endregion
   }
}

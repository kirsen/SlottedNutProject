using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataOrganizer;
using Kompas6API5;
using Kompas6Constants3D;
using MathLogic;


namespace Model
{
    /// <summary>
    /// Базовый класс, описывающий гайку в целом
    /// </summary>
    public class SlottedNut
    {
        #region Fields
        /// <summary>
        /// Высота шлица 
        /// </summary>
        private readonly double _heightSlot;
        
        /// <summary>
        /// Ширина шлица
        /// </summary>
        private readonly double _widthSlot;
        
        /// <summary>
        /// Высота гайки
        /// </summary>
        private readonly double _heightNut;
       
        /// <summary>
        /// Внешний диаметр
        /// </summary>
        private readonly double _outsideDiameter;

        /// <summary>
        /// Диаметр скругления
        /// </summary>
        private readonly double _roundingDiameter;

        /// <summary>
        /// Диаметр резьбы
        /// </summary>
        private readonly double _threadDiameter;
       
        /// <summary>
        /// Шаг резьбы
        /// </summary>
        private readonly double _stepOfThread;
       
        /// <summary>
        /// Тип резьбы
        /// </summary>
        private int _typeOfThread;
       
        /// <summary>
        /// Ссылка на сборку
        /// </summary>
        private readonly ksDocument3D _doc3D;
        
        /// <summary>
        /// Ссылка на главный интерфейс KompasObject
        /// </summary>
        private readonly KompasObject _kompas;
       
        /// <summary>
        /// Ссылка на базовую плоскость
        /// </summary>
        private ksEntity _baseSketch;
        
        /// <summary>
        /// Ссылка на компонент сборки
        /// </summary>
        private ksPart _part;
        
        /// <summary>
        /// Количество шлицев
        /// </summary>
        private readonly int _countOfSlot;
      
        #endregion

        #region Constructor
        /// <summary>
        /// Конструктор, инициализирующий поля класса по входным параметрам
        /// </summary>
        /// <param name="document3D">Ссылка на сборку</param>
        /// <param name="kompas">Ссылка на интерфейс KompasObject</param>
        /// <param name="slottedNutSample">Экземпляр структуры, описывающий гайку</param>
        /// <param name="typeOfThread">Тип резьбы</param>
        public SlottedNut(ksDocument3D document3D, KompasObject kompas, DataContainer.NutDescription slottedNutSample,
            int typeOfThread)
        {
            this._outsideDiameter = slottedNutSample.OutsideDiameter;
            this._heightNut = slottedNutSample.HeightNut;
            this._heightSlot = slottedNutSample.HeightSlot;
            this._widthSlot = slottedNutSample.WidthSlot;
            this._threadDiameter = slottedNutSample.ThreadDiameter;
            this._stepOfThread = slottedNutSample.ThreadStep;
            this._typeOfThread = typeOfThread;
            this._doc3D = document3D;
            this._kompas = kompas;
            this._roundingDiameter = slottedNutSample.RoundingDiameter;
            this._countOfSlot = slottedNutSample.CountOfSlot;

        }
        protected SlottedNut()
        {
            // throw new NotImplementedException();
        }
        #endregion

        #region CreateBase
        /// <summary>
        /// Создание основания гайки
        /// </summary>
        protected void CreateBase()
        {
            var radius = _outsideDiameter/2; // Получение адреса по диаметру
            _part = (ksPart)_doc3D.GetPart((short) Part_Type.pTop_Part);
            ksSketchDefinition definitionSketch = null;
            ksEntity sketch = null;
            if (_part != null) // Проверка на существование компонента сборки
            {
                _baseSketch = (ksEntity) _part.NewEntity((short) Obj3dType.o3d_sketch); // Создание нового эскиз
                if (_baseSketch != null)
                {
                    definitionSketch = (ksSketchDefinition) _baseSketch.GetDefinition(); // Получение интерфейса свойств эскиза
                   
                    if (definitionSketch != null)
                    {
                        // Получение интерфейса базовой плоскости XOY
                        var planeXOY = (ksEntity) _part.GetDefaultEntity((short) Obj3dType.o3d_planeXOY);
                        definitionSketch.SetPlane(planeXOY); // Размешаем эскиз на плоскости XOY

                        _baseSketch.Create();

                        // Редактирование эскиза
                        var sketchEdit = (ksDocument2D) definitionSketch.BeginEdit(); // Интерфейс редактора эскиза
                        sketchEdit.ksCircle(0, 0, radius, 1); // Cоздание окружности
                        definitionSketch.EndEdit();

                    }
                }
            }
        }
        #endregion

        #region CreateRounding
        /// <summary>
        /// Создание скругления гайки
        /// </summary>
        protected void CreateRounding()
        {
          //  var radius1 = _threadDiameter/2 + 2.5; //&&&&&&&&&&&
            var radius = _threadDiameter/2 + _stepOfThread; //Скорректирваннй радиус для создания выреза под скругление
            var doc = (ksDocument3D)_kompas.ActiveDocument3D();
            _part = (ksPart)doc.GetPart((short)Part_Type.pTop_Part);

            
            if (_part != null)
            {
                // Получение интерфейса базовой плоскости XOY
                var planeXOY = (ksEntity)_part.GetDefaultEntity((short)Obj3dType.o3d_planeXOY);

                //Получаем интерфейс объекта "смещенная плоскость"
                var entityOffsetPlane = (ksEntity)_part.NewEntity((short)Obj3dType.o3d_planeOffset);
                var planeOffsetDefinition = (ksPlaneOffsetDefinition)entityOffsetPlane.GetDefinition();

              
                if (planeOffsetDefinition != null)
                {

                    planeOffsetDefinition.direction = true; //Прямое направление смещения 
                    planeOffsetDefinition.offset = _heightNut; //Величина смещения

                    //Устанавливаем базовую плоскость
                    planeOffsetDefinition.SetPlane(planeXOY);
                    
                    //Создаем смещенную плоскость
                    entityOffsetPlane.Create();

                    var entitySketchOffset = (ksEntity)_part.NewEntity((short)Obj3dType.o3d_sketch);

                    //Получаем интерфейс параметров эскиза
                    var sketchDefinition= (ksSketchDefinition)entitySketchOffset.GetDefinition();
                    
                    //Устанавливаем смещенную плоскость базовой для эскиза
                   sketchDefinition.SetPlane(entityOffsetPlane);
                   
                    //Создаем эскиз
                    entitySketchOffset.Create();

                    //Подготовка скруглению, выравнивание выреза после создания резьбы
                    var sketchEdit = (ksDocument2D)sketchDefinition.BeginEdit();
                    sketchEdit.ksCircle(0, 0, radius, 1);
                    sketchDefinition.EndEdit();

                    //Получаем интерфейс объекта "операция вырезание выдавливанием"
                    var entityCutExtrusion = (ksEntity)_part.NewEntity((short)Obj3dType.o3d_cutExtrusion);
                   
                    //Получаем интерфейс параметров операции
                    var cutExtrusionDefinition = (ksCutExtrusionDefinition)entityCutExtrusion.GetDefinition();
                  
                    //Вычитание элементов
                    cutExtrusionDefinition.cut = true;
                    
                    //Прямое направление
                    cutExtrusionDefinition.directionType = (short)Direction_Type.dtNormal;
                   
                    //Устанавливаем параметры выдавливания
                    cutExtrusionDefinition.SetSideParam(true, (short)End_Type.etBlind, _roundingDiameter);//2
                   
                    //Устанавливаем экиз операции
                    cutExtrusionDefinition.SetSketch(entitySketchOffset);
                   
                    //Создаем операцию вырезания выдавливанием
                    entityCutExtrusion.Create();

                
                    var entityFillet = (ksEntity)_part.NewEntity((short)Obj3dType.o3d_fillet); //Получаем интерфейс объекта "скругление"
                    var filletDefinition = (ksFilletDefinition)entityFillet.GetDefinition(); //Получаем интерфейс параметров объекта "скругление"
                        //Радиус скругления
                    filletDefinition.radius = _roundingDiameter;//Радиус скругления
                    filletDefinition.tangent = false;//Не продолжать по касательным ребрам
                        
                    //Получаем массив граней детали
                    var entityCollectionPart = (ksEntityCollection)_part.EntityCollection((short)Obj3dType.o3d_face);
                       
                    //Получаем массив скругляемых граней
                    var entityCollectionFillet = (ksEntityCollection)filletDefinition.array(); 
                    entityCollectionFillet.Clear();
                        
                    //Заполняем массив скругляемых граней
                    var count = entityCollectionPart.GetCount();
                   entityCollectionFillet.Add(entityCollectionPart.GetByIndex(count-2));//10
                   
                    //Создаем скругление
                     entityFillet.Create();
                }
            }
        }

#endregion

        #region CutSots
        /// <summary>
        /// Описание виртуального метода вырезания шлицев
        /// </summary>
        /// <param name="sketchDefinition">Ссылка на интерфейс параметров эскиза</param>
        /// <param name="entitySketch">Плоскость на которой вырезаются шлицы</param>
        protected  void CutSlots(ksSketchDefinition sketchDefinition, ksEntity entitySketch)
        {
            var radius = _outsideDiameter / 2;
            const int countOfSlotDots = 4;

            //Получение краевых координат для создания шлицев
            var slotCoords = MathHelper.GetCoordForSlots(_outsideDiameter, _widthSlot, _heightSlot, _countOfSlot);

            //Получение промежуточных углов между двумя шлицами в радианах
            var mediumAngles = MathHelper.GetMediumAnglesByRadian(_countOfSlot);

            //i - количество точек, j - колиество шлицев
            for (int i = 0, j = 0; ((i <slotCoords.Count-1) && (j < _countOfSlot)); i += countOfSlotDots, j++)
            {
                var sketchEdit = (ksDocument2D)sketchDefinition.BeginEdit();
               
                // Создание основания шлица в эскизе
                sketchEdit.ksLineSeg(slotCoords[i].X, slotCoords[i].Y, slotCoords[i + 1].X,
                    slotCoords[i + 1].Y, 1);
                sketchEdit.ksLineSeg(slotCoords[i].X, slotCoords[i].Y, slotCoords[i + 2].X,
                    slotCoords[i + 2].Y, 1);
                sketchEdit.ksLineSeg(slotCoords[i + 1].X, slotCoords[i + 1].Y, slotCoords[i + 3].X,
                    slotCoords[i + 3].Y, 1);

                sketchEdit.ksArcBy3Points(slotCoords[i + 2].X, slotCoords[i + 2].Y,
                    radius * Math.Cos(mediumAngles[j]),
                    radius * Math.Sin(mediumAngles[j]), slotCoords[i + 3].X, slotCoords[i + 3].Y, 1);

                sketchDefinition.EndEdit();
                CutObject(entitySketch);
            }
        }
        #endregion

        #region CutByPress
        /// <summary>
        /// Вырезание выдавливанием
        /// </summary>
        protected void CutByPress()
        {

            var radius = _threadDiameter/2;
            var doc = (ksDocument3D)_kompas.ActiveDocument3D();//Получение активной части документа
            _part = (ksPart)doc.GetPart((short)Part_Type.pTop_Part);

            if (_part != null)
            {
                // Получение интерфейса базовой плоскости XOY
                var planeXOY = (ksEntity)_part.GetDefaultEntity((short)Obj3dType.o3d_planeXOY);

                //Получаем интерфейс объекта "смещенная плоскость"
                var entityOffsetPlane = (ksEntity)_part.NewEntity((short)Obj3dType.o3d_planeOffset);
                var planeOffsetDefinition = (ksPlaneOffsetDefinition)entityOffsetPlane.GetDefinition();

                // definitionSketch = (ksSketchDefinition)planeOffsetDefinition.GetDefinition(); // интерфейс свойств эскиза
                if (planeOffsetDefinition != null)
                {
                    planeOffsetDefinition.direction = true; //Прямое направление смещения 
                    planeOffsetDefinition.offset = _heightNut; //Величина смещения

                    //Устанавливаем базовую плоскость
                    planeOffsetDefinition.SetPlane(planeXOY);
                    
                    //Создаем смещенную плоскость
                    entityOffsetPlane.Create();

                    var entitySketchOffset = (ksEntity)_part.NewEntity((short) Obj3dType.o3d_sketch);

                    //Получаем интерфейс параметров эскиза
                    var sketchDefinition = (ksSketchDefinition) entitySketchOffset.GetDefinition();
                   
                    //Устанавливаем смещенную плоскость базовой для эскиза
                    sketchDefinition.SetPlane(entityOffsetPlane);
                    
                    //Создаем эскиз
                    entitySketchOffset.Create();

                    // Редактируем эскиз
                    var sketchEdit = (ksDocument2D)sketchDefinition.BeginEdit();
                    sketchEdit.ksCircle(0, 0, radius, 1);
                    sketchDefinition.EndEdit();
                    
                    //Вырезание объекта
                    this.CutObject(entitySketchOffset);

                }
            }
        }
       #endregion

        #region PressBase
        /// <summary>
        /// Выдавливание основания
        /// </summary>
        protected void PressBase()
        {
            //Операция выдавливания основания;
         
            var entityExtr = (ksEntity)_part.NewEntity((short)Obj3dType.o3d_baseExtrusion);
            var sketch = (ksEntity)_part.NewEntity((short)Obj3dType.o3d_sketch);  
            var definitionSketch = (ksSketchDefinition)_baseSketch.GetDefinition(); 
            if (entityExtr != null)
            {
                // интерфейс свойств базовой операции выдавливания
                var extrusionDef = (ksBaseExtrusionDefinition)entityExtr.GetDefinition(); // интерфейс базовой операции выдавливания

                if (extrusionDef != null)
                {
                    extrusionDef.SetSideParam(true, (short)End_Type.etBlind, _heightNut);	// прямое направление, строго на глубину

                    extrusionDef.SetSketch(_baseSketch);	// Эскиз операции выдавливания
                    entityExtr.Create();				// Создать операцию

                    entityExtr.Update();               // Обновить параметры операции выдавливания
                }
            }

            definitionSketch.EndEdit();    // Завершение редактирования эскиза
            sketch.Update();               // Обновление параметров эскиза
        }
        #endregion

        #region CreateSlots
        /// <summary>
       /// Создание шлицев
       /// </summary>
        protected  void CreateSlots()
       {
           var radius = _outsideDiameter / 2;
           var doc = (ksDocument3D)_kompas.ActiveDocument3D();
           _part = (ksPart)doc.GetPart((short)Part_Type.pTop_Part);


           if (_part != null)
           {

               // Получение интерфейса базовой плоскости XOY
               var planeXOY = (ksEntity)_part.GetDefaultEntity((short)Obj3dType.o3d_planeXOY);

               //Получаем интерфейс объекта "смещенная плоскость"
               var entityOffsetPlane = (ksEntity)_part.NewEntity((short)Obj3dType.o3d_planeOffset);
               var planeOffsetDefinition = (ksPlaneOffsetDefinition)entityOffsetPlane.GetDefinition();

               // definitionSketch = (ksSketchDefinition)planeOffsetDefinition.GetDefinition(); // интерфейс свойств эскиза
               if (planeOffsetDefinition != null)
               {

                   planeOffsetDefinition.direction = true; //Прямое направление смещения 
                   planeOffsetDefinition.offset = _heightNut; //Величина смещения

                   //Устанавливаем базовую плоскость
                   planeOffsetDefinition.SetPlane(planeXOY);
                   //Создаем смещенную плоскость
                   entityOffsetPlane.Create();

                   var entitySketch2 = (ksEntity)_part.NewEntity((short)Obj3dType.o3d_sketch);

                   //Получаем интерфейс параметров эскиза
                   var sketchDefinition = (ksSketchDefinition)entitySketch2.GetDefinition();
                   //Устанавливаем смещенную плоскость базовой для эскиза
                   sketchDefinition.SetPlane(entityOffsetPlane);
                   //Создаем эскиз
                   entitySketch2.Create();
                   CutSlots(sketchDefinition,entitySketch2);

                 

               
           }
       }
     }
        #endregion

        #region CutObject
        /// <summary>
        /// Вырезать объект
        /// </summary>
        /// <param name="entitySketch">Ссылка на эскиз объекта</param>
        protected void CutObject(ksEntity entitySketch)
        {
            //Получаем интерфейс объекта "операция вырезание выдавливанием"
            var entityCutExtrusion = (ksEntity)_part.NewEntity((short)Obj3dType.o3d_cutExtrusion);

            //Получаем интерфейс параметров операции
            var cutExtrusionDefinition = (ksCutExtrusionDefinition)entityCutExtrusion.GetDefinition();
            //Вычитание элементов
            cutExtrusionDefinition.cut = true;

            //Прямое направление
            cutExtrusionDefinition.directionType = (short)Direction_Type.dtNormal;
            //Устанавливаем параметры выдавливания
            cutExtrusionDefinition.SetSideParam(true, (short)End_Type.etBlind, _heightNut);
            //Устанавливаем экиз операции
            cutExtrusionDefinition.SetSketch(entitySketch);
            //Создаем операцию вырезания выдавливанием
            entityCutExtrusion.Create();
        }
#endregion

        #region CreateChamper
        /// <summary>
        /// Создание фаски
        /// </summary>
        /// <param name="tangent"> признак продолжения скругления по касательным  ребрам</param>
        /// <param name="downDistance">расстояние нижной части фаски</param>
        /// <param name="upDistance">расстояние верхней части фаски</param>
        protected void CreateChamper(bool tangent, double downDistance, double upDistance)
        {
            // интерфейс свойств базовой операции фаска

            var chamfer = (ksEntity)_part.NewEntity((short)Obj3dType.o3d_chamfer);

            var champerDefinition = (ChamferDefinition)chamfer.GetDefinition();


            // интерфейс базовой операции фаска
            if (champerDefinition != null)
            {
                champerDefinition.tangent = tangent;  //false
                champerDefinition.SetChamferParam(/*true*/tangent, downDistance, upDistance); //false
         
                var entityColectionPart = (ksEntityCollection)_part.EntityCollection((short)Obj3dType.o3d_edge);
                var entityCollectionChamfer = (ksEntityCollection)champerDefinition.array();
                entityCollectionChamfer.Clear();

                entityCollectionChamfer.Add(entityColectionPart.GetByIndex(0));
              
                entityCollectionChamfer.Next();
                chamfer.Create();

            }
        }

#endregion  
       
       /// <summary>
       /// Создание гайки
       /// </summary>
        public void CreateNut()
        {
            //Создание основания в виде окружности
            CreateBase();

            //Выдавливание окружности в цилиндр
            PressBase();

            //Вырезание выдавливанием внутеннего отверстия в цилиндре в вде цилиндра 
            CutByPress();

            //Создание резьбы во внутреннем отверстии
            ThreadCreator.CreateThread(_part, _doc3D, _stepOfThread, _heightNut, _threadDiameter, 1);

            // Создание фаски в нижнем основании
            CreateChamper(false, _heightSlot, _heightSlot);

            // Создание фаски в верхнем основании
            CreateChamper(true, _heightSlot, _heightSlot);

            //Создание скругления
            CreateRounding();

            //Cоздание резьбы
            CreateSlots();
          
        }
    }
}

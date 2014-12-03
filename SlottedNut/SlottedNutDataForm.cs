using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Manager;
using DataOrganizer;

namespace SlottedNut
{
   /// <summary>
    /// Диалоговый класс SlottedNutDataForm
   /// </summary>
    public partial class SlottedNutDataForm : Form
    {
        #region Fields
        /// <summary>
        /// Ссылка на класс DataContainer
        /// </summary>
        public DataContainer DataContainer;

        /// <summary>
        /// Ссылка на структуру DataContainer.NutDescription 
        /// </summary>
        public DataContainer.NutDescription SlottedNutSample;

        /// <summary>
        /// Экземпляр класса Scene
        /// </summary>
        public Scene Scene = new Scene();

        /// <summary>
        /// Перечисление, характеризующее тип резьбы 0- треугольная, 1 - круглая
        /// </summary>
        public enum TypeOfThread
        {
            Triangle = 0,
            Circule = 1
        };

       // Image image;
       private Graphics _graphicsForHorizontalPicture;
       private Graphics _graphicsForFrontalPicture;
      
        /// <summary>
        /// 
        /// </summary>
       private Image _horizontalImage;
        /// <summary>
        /// 
        /// </summary>
       private Image _frontaImage;

       private IEnumerable<DataContainer.NutDescription> _listSamples = new List<DataContainer.NutDescription>();

       private  List<double> _timeList  = new List<double>();

        #endregion
        /// <summary>
        /// Конструктор диалогового класса SlottedNutDataForm
        /// </summary>
        public SlottedNutDataForm()
        {
            InitializeComponent();
        }

       #region ButtonClickEvents

       /// <summary>
       /// Обработчик нажатия кнопки "Построить деталь"
       /// </summary>
       /// <param name="sender">Объект который вызывает событие (пападание мыши на кнопку)</param>
       /// <param name="e">Событие</param>
       private void buttonCreate_Click(object sender, EventArgs e)
       {
           for (int i = 0; i < 100; i++)
           {
               timer1.Start();
               //  _time = timer1.Interval;

               if (IsAllParamatersEnter())
               {
                   //  Scene.OpenKompas();
                   switch (typeOfThreadBox.SelectedIndex)
                   {
                       case 1:
                           Scene.InitScene(SlottedNutSample, (int) TypeOfThread.Circule);
                           break;
                       case 0:
                           Scene.InitScene(SlottedNutSample, (int) TypeOfThread.Triangle);
                           break;

                   }
                   _timeList.Add(timer1.Interval);
                  // SetTime(timer1.Interval);

                   timer1.Stop();
               }
           

       else
           {
               MessageBox.Show(@"Введены не все параметры - введите все прараметры ");
           }
       }
    }

      /*  private void SetTime(int p)
        {
            _timeList.Add(p);
        }*/
        #endregion

       
       bool IsAllParamatersEnter()
       {
           bool flag = true;

           var comboBoxs = new List<ComboBox>
              {
                  outsideDiameterBox,
                  baseDiameterBox,
                  heightNutBox,
                  heightSlotBox,
                  widthSlotBox,
                  threadDiameterBox,
                  stepOfThreadBox,
                  roundingDiameterBox,
                  countOfSlotBox
              };

           // Удаление значений из всех comboBox
           foreach (var comboBox in comboBoxs)
           {
               //Удаление данных из текущего comboBox
               if (comboBox.SelectedText != "")
               {
                   flag = false;
                   break;
               }
               

           }
           return flag;
       }

        #region SelectedIndexChangedEvents
       
        /// <summary>
        /// Обработчик при выборе(выделении) элемента (диаметра основания) из списка comboBox2
        /// </summary>
        /// <param name="sender">Объект который вызывает событие (пападание мыши на кнопку)</param>
        /// <param name="e">Событие</param>
        private void baseDiameterBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            double value = Convert.ToDouble(baseDiameterBox.Text);
            _listSamples = _listSamples.Where(sample => sample.BaseDiameter == value).ToList();
            var nutDescriptions = _listSamples as IList<DataContainer.NutDescription> ?? _listSamples.ToList();
            var sampleList = nutDescriptions.ToList();
            SlottedNutSample.BaseDiameter = value;
            baseDiameterBox.SelectedValue = SlottedNutSample.BaseDiameter;
            SchemaCreator.SelectChoosedPapameter(horizontalViewPicture, frontalViewPicture, _graphicsForFrontalPicture, baseDiameterBox,  SlottedNutSample.CountOfSlot);
            UpdateAllFields(sampleList);
        }

        /// <summary>
        /// Обработчик при выборе(выделении) элемента (высоты гайки) из списка comboBox3
        /// </summary>
        /// <param name="sender">Объект который вызывает событие (пападание мыши на кнопку)</param>
        /// <param name="e">Событие</param>
        private void heightNutBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            double value = Convert.ToDouble(heightNutBox.Text);
            _listSamples = (from sample in _listSamples where sample.HeightNut == value select sample);
            var nutDescriptions = _listSamples as IList<DataContainer.NutDescription> ?? _listSamples.ToList();
            var sampleList = nutDescriptions.ToList();
            SlottedNutSample.HeightNut = value;
            SchemaCreator.SelectChoosedPapameter(horizontalViewPicture,frontalViewPicture, _graphicsForFrontalPicture, heightNutBox,  SlottedNutSample.CountOfSlot);
            UpdateAllFields(sampleList);
            
        }

        /// <summary>
        /// Обработчик при выборе(выделении) элемента (диаметра скругления) из списка comboBox9
        /// </summary>
        /// <param name="sender">Объект который вызывает событие (пападание мыши на кнопку)</param>
        /// <param name="e">Событие</param>
        private void roundingDiameterBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            double value = Convert.ToDouble(roundingDiameterBox.Text);
             _listSamples =
                (from sample in _listSamples where sample.RoundingDiameter == value select sample);
             var nutDescriptions = _listSamples as IList<DataContainer.NutDescription> ?? _listSamples.ToList();
            var sampleList = nutDescriptions.ToList();
            SlottedNutSample.RoundingDiameter = value;
            SchemaCreator.SelectChoosedPapameter(horizontalViewPicture,frontalViewPicture, _graphicsForHorizontalPicture, roundingDiameterBox, SlottedNutSample.CountOfSlot);
            UpdateAllFields(sampleList);
         
        }

        /// <summary>
        /// Обработчик при выборе(выделении) элемента (шага резьбы) из списка comboBox8
        /// </summary>
        /// <param name="sender">Объект который вызывает событие (пападание мыши на кнопку)</param>
        /// <param name="e">Событие</param>
        private void threadStepBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            double value = Convert.ToDouble(stepOfThreadBox.Text);
            _listSamples =
                (from sample in _listSamples where sample.ThreadStep == value select sample);
            var nutDescriptions = _listSamples as IList<DataContainer.NutDescription> ?? _listSamples.ToList();
            var sampleList = nutDescriptions.ToList();
            SlottedNutSample.ThreadStep = value;
            UpdateAllFields(sampleList);
         
        }

        /// <summary>
        /// Обработчик при выборе(выделении) элемента (диаметра резьбы) из списка comboBox6
        /// </summary>
        /// <param name="sender">Объект который вызывает событие (пападание мыши)</param>
        /// <param name="e">Событие</param>
        private void threadDiameterBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            double value = Convert.ToDouble(threadDiameterBox.Text);
            _listSamples =
                (from sample in _listSamples where sample.ThreadDiameter == value select sample);
            var nutDescriptions = _listSamples as IList<DataContainer.NutDescription> ?? _listSamples.ToList();
            var sampleList = nutDescriptions.ToList();
            SlottedNutSample.ThreadDiameter = value;
            SchemaCreator.SelectChoosedPapameter(horizontalViewPicture,frontalViewPicture, _graphicsForHorizontalPicture, threadDiameterBox, SlottedNutSample.CountOfSlot );
            UpdateAllFields(sampleList);
          
        }

        /// <summary>
        /// Обработчик при выборе(выделении) элемента (ширина шлица) из списка comboBox5
        /// </summary>
        /// <param name="sender">Объект который вызывает событие (пападание мыши)</param>
        /// <param name="e">Событие</param>
        private void widthSlotBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            double value = Convert.ToDouble(widthSlotBox.Text);
            _listSamples = (from sample in _listSamples where sample.WidthSlot == value select sample);
            var nutDescriptions = _listSamples as IList<DataContainer.NutDescription> ?? _listSamples.ToList();
            var sampleList = nutDescriptions.ToList();
            SlottedNutSample.WidthSlot = value;
            SchemaCreator.SelectChoosedPapameter(horizontalViewPicture,frontalViewPicture, _graphicsForHorizontalPicture, widthSlotBox,  SlottedNutSample.CountOfSlot);
            UpdateAllFields(sampleList);
         
        }

        /// <summary>
        /// Обработчик при выборе(выделении) элемента (высоты шлица) из списка comboBox4
        /// </summary>
        /// <param name="sender">Объект который вызывает событие (пападание мыши)</param>
        /// <param name="e">Событие</param>
        private void heightSlotBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            double value = Convert.ToDouble(heightSlotBox.Text);
            _listSamples =
                (from sample in _listSamples where sample.HeightSlot == value select sample);
            var nutDescriptions = _listSamples as IList<DataContainer.NutDescription> ?? _listSamples.ToList();
            var sampleList = nutDescriptions.ToList();
            SlottedNutSample.HeightSlot = value;
            SchemaCreator.SelectChoosedPapameter(horizontalViewPicture,frontalViewPicture, _graphicsForHorizontalPicture, heightSlotBox,  SlottedNutSample.CountOfSlot);
            UpdateAllFields(sampleList);
         
        }

        /// <summary>
        /// Обработчик при выборе(выделении) элемента (внешнего диаметра) из списка comboBox1
        /// </summary>
        /// <param name="sender">Объект который вызывает событие (пападание мыши на кнопку)</param>
        /// <param name="e">Событие</param>
        private void outsideDiameterBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            double value = Convert.ToDouble(outsideDiameterBox.Text);
            _listSamples =
                (from sample in _listSamples where sample.OutsideDiameter == value select sample);
            var nutDescriptions = _listSamples as IList<DataContainer.NutDescription> ?? _listSamples.ToList();
            var sampleList = nutDescriptions.ToList();
            SchemaCreator.SelectChoosedPapameter(horizontalViewPicture,frontalViewPicture, _graphicsForFrontalPicture, outsideDiameterBox,  SlottedNutSample.CountOfSlot);
            UpdateAllFields(sampleList);
            SlottedNutSample.OutsideDiameter = value;
        }

        /// <summary>
        /// Обработчик при выборе(выделении) элемента (числа шлицев) из списка comboBox10
        /// список состоит из двух элементов : по индексу 0 - хранится "4", по индексу 1 - хранится "6"
        /// </summary>
        /// <param name="sender">Объект который вызывает событие (пападание мыши на кнопку)</param>
        /// <param name="e">Событие</param>
        private void countOfSlotBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int value = Convert.ToInt32(countOfSlotBox.Text);
            DataContainer = new DataContainer();
            _listSamples =
                (from sample in DataContainer.SlottedNutSamples where sample.CountOfSlot == value select sample);
            var nutDescriptions = _listSamples as IList<DataContainer.NutDescription> ?? _listSamples.ToList();
            var sampleList = nutDescriptions.ToList();
            SchemaCreator.SelectChoosedPapameter(horizontalViewPicture,frontalViewPicture, _graphicsForHorizontalPicture, countOfSlotBox,  SlottedNutSample.CountOfSlot);//venya kartina
             SetBaseImageStates();
             UpdateAllFields(sampleList);
             SlottedNutSample.CountOfSlot = value;
        }

        #endregion

        /// <summary>
        /// Действия при загрузке формы
        /// </summary>
        /// <param name="sender">Объект, который вызывает событие</param>
        /// <param name="e">Событие</param>
        private void SlottedNutDataForm_Load(object sender, EventArgs e)
        {
             countOfSlotBox.Items.Add("4");
             countOfSlotBox.Items.Add("6");
             // Добавление типа резьбы
            typeOfThreadBox.Items.Add("Треугольная");
            typeOfThreadBox.Items.Add("Круглая");
            _graphicsForHorizontalPicture = horizontalViewPicture.CreateGraphics();
            _graphicsForFrontalPicture = frontalViewPicture.CreateGraphics();
        
        }

        /// <summary>
        /// Обновление всех полей
        /// </summary>
        /// <param name="sampleList">Список соответствующих объектов ,которые будут отображаться после обновления</param>
        private void UpdateAllFields(IEnumerable<DataContainer.NutDescription> sampleList)
        {
            ClearOldDates();
            UpdatedDates(sampleList/*, allSampleList*/);
        }

       /// <summary>
       /// Установка базовых состояний видовых изображений
       /// </summary>
       private void SetBaseImageStates()
       {
            _horizontalImage = horizontalViewPicture.Image;
            _frontaImage = frontalViewPicture.Image;
       }

        #region ClearDates
       
        /// <summary>
        /// Удаление старых данных
        /// </summary>
          private void ClearOldDates() 
          {
              
              var comboBoxs = new List<ComboBox>
              {
                  outsideDiameterBox,
                  baseDiameterBox,
                  heightNutBox,
                  heightSlotBox,
                  widthSlotBox,
                  threadDiameterBox,
                  stepOfThreadBox,
                  roundingDiameterBox,
                  countOfSlotBox
              };

             // Удаление значений из всех comboBox
              foreach (var comboBox in comboBoxs)
              {
                  //Удаление данных из текущего comboBox
                  Clear(comboBox);  

              }

              
          }
        
        /// <summary>
        /// Очищение списка данных сomboBox
        /// </summary>
        /// <param name="comboBox">Текущий сomboBox</param>
        private void Clear( ComboBox comboBox)
        {
            //Удаление с конца, кроме выбранного
            for (int i = comboBox.Items.Count-1; i >= 0; i--) 
            {
                if (comboBox.Items[i] != comboBox.SelectedItem)
                {
                    comboBox.Items.RemoveAt(i);
                }
            }
         
        }

        /// <summary>
        /// Сброс данных
        /// </summary>
       private void ResetDates(object sender, EventArgs e)
       {
           outsideDiameterBox.Items.Clear();
           baseDiameterBox.Items.Clear();
           heightNutBox.Items.Clear();
           heightSlotBox.Items.Clear();
           widthSlotBox.Items.Clear();
           threadDiameterBox.Items.Clear();
           stepOfThreadBox.Items.Clear();
           typeOfThreadBox.Items.Clear();
           roundingDiameterBox.Items.Clear();
           countOfSlotBox.Items.Clear();
           SlottedNutDataForm_Load(sender, e);
       }
        #endregion

       bool IsValidParameter(DataContainer.NutDescription tempDescription , IEnumerable<DataContainer.NutDescription> samples)
       {

           if (samples.Contains(tempDescription))
           {
               return true;
           }
           else
               return false;


       }

        #region DeleteEqualsElements
        /// <summary>
        /// Удаление повторяющихся элементов элементов после выбора какого-нибудь элемента
        /// </summary>
        /// 
        /// <param name="comboBox">Текущий сomboBox</param>
       private void DeleteEqualsElements(ComboBox comboBox)
        {
            //Получение неповторяющихся элментов из списка элементов comboBox
            IEnumerable<double> list = (from object a in comboBox.Items select Convert.ToDouble(a)).ToList().Distinct();

            //Очищение списка элементов из сomboBox за исключением выбранного
            Clear(comboBox);

            //Запись в comboBox, неповторяющихся элементов
            foreach (var value in list)
            {
                if (comboBox.Text != Convert.ToString(value))
                {
                   // comboBox.Items.Add(Convert.ToString(choosedValue));
                    comboBox.Items.Add(Convert.ToString(value));
                } 
               
               // comboBox.Items.Add(Convert.ToString(value));
            }
            

        }
        #endregion

        #region InitComboBoxs
        /// <summary>
        /// Добавление списка элементов в компонент comboBox
        /// </summary>
        /// <param name="values">Добавлямые элементы</param>
        /// <param name="comboBox">Компонент</param>
        private void AddToComboBox(IEnumerable<double> values, ComboBox comboBox)
        {
            foreach (var value in values)
            {

                comboBox.Items.Add(Convert.ToString(value));

            }
        }

        /// <summary>
        /// Инициализация базовыми данными компонентов comboBox
        /// </summary>
        /// <param name="dataContainer">экземпляр класса dataContainer</param>
        private void InitBaseDates(DataContainer dataContainer)
        {
          // Добавление списка вешних диаметров
            AddToComboBox(dataContainer.OusideDiameters, outsideDiameterBox);

            // Добавление списка  диаметров основания
            AddToComboBox(dataContainer.BaseDiameters, baseDiameterBox);

            // Добавление списка  высот гайки
            AddToComboBox(dataContainer.HeightNuts, heightNutBox);

            // Добавление списка  высот шлица
            AddToComboBox(dataContainer.HeighSlots, heightSlotBox);

            // Добавление списка  ширин шлица
            AddToComboBox(dataContainer.WidthSlots, widthSlotBox);

            // Добавление списка  диаметров резьбы
            AddToComboBox(dataContainer.ThreadDiameters, threadDiameterBox);

            // Добавление списка  шага резьбы
            AddToComboBox(dataContainer.ThreadSteps, stepOfThreadBox);

            // Добавление списка  диаметров скругления
            AddToComboBox(dataContainer.RoundingDiameters, roundingDiameterBox);
            
        }
        #endregion

     
        #region UpdateDates
        /// <summary>
       /// Обновление данных во всех компоненах comboBox после выбора какого-нибудь элемента
       /// </summary>
       /// <param name="sampleList">Объекты, удовлетворяющие выбранному параметру</param>
        private void UpdatedDates(IEnumerable<DataContainer.NutDescription> sampleList)
        {
           
           // Перебор, удовлетворяющих объектов
            foreach (var sample in sampleList)
            {
                
                
                AddUpdatedElements(sample.CountOfSlot,countOfSlotBox);//тут надо передавать параметр всех возможнхых листов и сравнива
                AddUpdatedElements(sample.OutsideDiameter, outsideDiameterBox);
                AddUpdatedElements(sample.BaseDiameter, baseDiameterBox);
                AddUpdatedElements(sample.HeightNut, heightNutBox);
                AddUpdatedElements(sample.HeightSlot, heightSlotBox);
                AddUpdatedElements(sample.WidthSlot, widthSlotBox);
                AddUpdatedElements(sample.ThreadDiameter, threadDiameterBox);
                AddUpdatedElements(sample.ThreadStep, stepOfThreadBox);
                AddUpdatedElements(sample.RoundingDiameter, roundingDiameterBox); 
            
            }

        }

        /// <summary>
        /// Добавление обновленных элементов
        /// </summary>
        /// <param name="choosedValue"> Текyщий выбраннй элемент</param>
        /// <param name="comboBox"></param>
        private void AddUpdatedElements(double choosedValue, ComboBox comboBox)
        {
         

           // Если текущий выбранный элемент не содержится в списке элементов выбора comboBox,
            //тогда его добавляем в этот список
          
            
           if (!(comboBox.Items.Contains(choosedValue)))
            {
                comboBox.Items.Add(Convert.ToString(choosedValue));
                
            } 
            DeleteEqualsElements(comboBox);

        }

        #endregion
        #region ChoosedBoxLeaveEvents

   
        /// <summary>
        /// Установоить горизонтальный вид изображения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetHorizontalViewImage(object sender, EventArgs e)
        {
            horizontalViewPicture.Image = _horizontalImage;
        }

        /// <summary>
        /// Установоить фронтальный вид изображения
        /// </summary>
        /// <param name="sender">Объект, который вызывает событие</param>
        /// <param name="e">Событие</param>
        private void SetFrontalViewImage(object sender, EventArgs e)
        {
            frontalViewPicture.Image = _frontaImage;
        }
      
        #endregion

        private void button2_Click(object sender, EventArgs e)
        {
             ResetDates(sender,e);
        }

        
    }
}

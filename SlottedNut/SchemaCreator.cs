using System.Drawing;
using System.Windows.Forms;
using SlottedNut.Properties;
using Point = System.Drawing.Point;

namespace SlottedNut
{
   /// <summary>
   /// Класс выделения размеров на чертеже ( фронтальном и горизонтальном виде)
   /// </summary>
   public static class SchemaCreator
   {
       /// <summary>
       /// Маркер,определяющий цвет и толщину линии отрисовки
       /// </summary>
       private static readonly Pen Pen = new Pen(Brushes.Black, 1);
     
       /// <summary>
       /// Выделение выбранного параметра
       /// </summary>
       /// <param name="horizontalView">Горизонтальный вид</param>
       /// <param name="frontalView">Фронтальный вид</param>
       /// <param name="graphics">Ссылка на Graphics</param>
       /// <param name="choosedBox">Выбранный элемент</param>
       /// <param name="countOfSlot">Количество шлицев</param>
       public static void SelectChoosedPapameter(PictureBox horizontalView,PictureBox frontalView, Graphics graphics, ComboBox choosedBox,int countOfSlot)
       { 
           switch (choosedBox.Name)
           {
               case "countOfSlotBox": SetPictureByCounOfSlot(choosedBox.Text,horizontalView, frontalView);
                   break;
               case "outsideDiameterBox":
                   ShowOutsideDiameter(frontalView, graphics,countOfSlot);
                   break;
               case "baseDiameterBox":
                   ShowBaseDiameter(frontalView, graphics,countOfSlot);
                   break;
               case "heightNutBox":
                  ShowHeightNut(frontalView, graphics,countOfSlot);
                   break;
               case "heightSlotBox":
                   ShowHeightSlot(countOfSlot,horizontalView,graphics);
                   break;
               case "widthSlotBox":
                   ShowWidthSlot(countOfSlot,horizontalView,graphics);
                   break;
               case "threadDiameterBox":
                    ShowThreadDiameter(countOfSlot,horizontalView,graphics);
                   break;
           }
         
       }

       /// <summary>
       /// Установление рисунка по числу шлицев
       /// </summary>
       /// <param name="countOfSlot">Количество шлицев</param>
       /// <param name="horizontalView">Горизонтальный вид</param>
       /// <param name="frontalView">Фронтальный вид</param>
       private static void SetPictureByCounOfSlot(string countOfSlot, PictureBox horizontalView,PictureBox frontalView)
       { 
             switch (countOfSlot)
           {
               case "4": horizontalView.Image = (Image)Resources.fourslot1;
                         frontalView.Image = (Image)Resources.front2;         
                   break;
               case "6": horizontalView.Image = (Image)Resources.sixslot;
                         frontalView.Image = (Image)Resources.front1;
                   break;
           }     
       }

       /// <summary>
       /// Показать внешний диаметр
       /// </summary>
       /// <param name="picture">Изображение на котором показывается</param>
       /// <param name="graphics">Ссылка на графику</param>
       /// <param name="countOfSlot">Количество шлицев</param>
       private static void ShowOutsideDiameter( PictureBox picture,Graphics graphics, int countOfSlot )
       {
           switch (countOfSlot)
           {
               case 4:
                   ShowOutsideDiameterForFourSlottedNut(picture,graphics);
                   break;
               case 6:
                   ShowOutsideDiameterFourSixSlottedNut(picture,graphics);
                   break;
           }  
       }

       /// <summary>
       /// Показывает диаметр основания
       /// </summary>
       /// <param name="picture">Изображение на котором показывается</param>
       /// <param name="graphics">Ссылка на графику</param>
       /// <param name="countOfSlot">Количество шлицев</param>
       private static void ShowBaseDiameter(PictureBox picture, Graphics graphics, int countOfSlot)
       {
           switch (countOfSlot)
           {
               case 4:
                   ShowBaseDiameterForFourSlottedNut(picture,graphics);
                   break;
               case 6:
                   ShowBaseDiameterFourSixSlottedNut(picture,graphics);
                  break;
           }

          
       }

       /// <summary>
       /// Показать высоту гайки
       /// </summary>
       /// <param name="picture">Изображение на котором показывается</param>
       /// <param name="graphics">Ссылка на графику</param>
       /// <param name="countOfSlot">Количество шлицев</param>
       private static void ShowHeightNut(PictureBox picture, Graphics graphics,int countOfSlot)
       {
           switch (countOfSlot)
           {
               case 4:
                   ShowHeightNutFourSlottedNut(picture,graphics);
               break;    
               case 6:
                    ShowHeightNutForSixSlottedNut(picture, graphics);
               break;
           }
       }

       /// <summary>
       /// Показать высоту шлица
       /// </summary>
       /// <param name="picture">Изображение на котором показывается</param>
       /// <param name="graphics">Ссылка на графику</param>
       /// <param name="countOfSlot">Количество шлицев</param>
       private static void ShowHeightSlot(int countOfSlot,PictureBox picture, Graphics graphics)
       {
           switch (countOfSlot)
           {
               case 4:
                  ShowHeightSlotForFourSlottedNut(picture,graphics);
                   break;
               case 6:
                   ShowHeightSlotForSixSlottedNut(picture,graphics);
                   break;
           }
       }

       /// <summary>
       /// Показать ширину шлица
       /// </summary>
       /// <param name="picture">Изображение на котором показывается</param>
       /// <param name="graphics">Ссылка на графику</param>
       /// <param name="countOfSlot">Количество шлицев</param>
       private static void ShowWidthSlot(int countOfSlot, PictureBox picture, Graphics graphics)
       {
           switch (countOfSlot)
           {
               case 4:
                   ShowWidthSlotForFourSlottedNut(picture,graphics);
                   break;
               case 6:
                   ShowWidthSlotForSixSlottedNut(picture,graphics);
                   break;
           }   
       }

       /// <summary>
       /// Показать диаметр резьбы
       /// </summary>
       /// <param name="picture">Изображение на котором показывается</param>
       /// <param name="graphics">Ссылка на графику</param>
       /// <param name="countOfSlot">Количество шлицев</param>
       private static void ShowThreadDiameter(int countOfSlot, PictureBox picture, Graphics graphics)
       {
           switch (countOfSlot)
           {
               case 4:
                   ShowThreadDiameterForFourSlottedNut(picture,graphics);
                   break;
               case 6:
                   ShowThreadDiameterForSixSlottedNut(picture,graphics);
                   break;
           }
          
       }

 #region MethodsOfShowParametersByCountOfSlot

       /// <summary>
       ///    Показать внешний диаметр для четыршлицовой гайки
       /// </summary>
       /// <param name="picture">Изображение на котором показывается</param>
       /// <param name="graphics">ссылка на графику</param>
       private static void ShowOutsideDiameterForFourSlottedNut(PictureBox picture, Graphics graphics)
       {
                   // Вертикальные линии
                   graphics.DrawLine(Pen, new Point(0, picture.Height / 4 + 5),
                       new Point(0, picture.Height - 20));
               
                   graphics.DrawLine(Pen, new Point(picture.Width - picture.Width / 10 + 2, picture.Height / 4 + 5),
                       new Point(picture.Width - picture.Width / 10 + 2, picture.Height - 20)); //диаметр (внеш)

                   // горизонтальная линия стрелки
                   graphics.DrawLine(Pen, new Point(0, picture.Height - 20),
                      new Point(picture.Width - picture.Width / 10 + 2, picture.Height - 20)); //диаметр (внеш)

                   // конец стрелки сверху (слева)
                   graphics.DrawLine(Pen, new Point(0, picture.Height - 20),
                      new Point(5, picture.Height - 23)); //диаметр (внеш)
                  
                    // конец стрелки снизу (слева)
                   graphics.DrawLine(Pen, new Point(0, picture.Height - 20),
                      new Point(5, picture.Height - 17)); //диаметр (внеш)
                  
                    // конец стрелки сверху (справа)
                   graphics.DrawLine(Pen, new Point(picture.Width - picture.Width / 10 + 2, picture.Height - 20),
                      new Point(picture.Width - picture.Width / 10 - 3, picture.Height - 23)); //диаметр (внеш)
                   
                    // конец стрелки снизу (справа)
                   graphics.DrawLine(Pen, new Point(picture.Width - picture.Width / 10 + 2, picture.Height - 20),
                      new Point(picture.Width - picture.Width / 10 - 3, picture.Height - 17)); //диаметр (внеш)
                 
           
       }

       /// <summary>
       ///    Показать внешний диаметр для шестишлицовой гайки
       /// </summary>
       /// <param name="picture">Изображение на котором показывается</param>
       /// <param name="graphics">ссылка на графику</param>
       private static void ShowOutsideDiameterFourSixSlottedNut(PictureBox picture, Graphics graphics)
       {
           
                   // Вертикальные линии
                   graphics.DrawLine(Pen, new Point(0, picture.Height / 4 - 1), new Point(0, picture.Height - 20));
                   graphics.DrawLine(Pen, new Point(picture.Width - picture.Width / 10 - 1, picture.Height / 4 - 1),
                       new Point(picture.Width - picture.Width / 10 - 1, picture.Height - 20)); //диаметр (внеш)

                   // горизонтальная линия стрелки
                   graphics.DrawLine(Pen, new Point(0, picture.Height - 20),
                      new Point(picture.Width - picture.Width / 10 - 1, picture.Height - 20)); //диаметр (внеш)

                   // конец стрелки сверху (слева)
                   graphics.DrawLine(Pen, new Point(0, picture.Height - 20),
                      new Point(5, picture.Height - 23)); //диаметр (внеш)
                  
                    // конец стрелки снизу (слева)
                   graphics.DrawLine(Pen, new Point(0, picture.Height - 20),
                      new Point(5, picture.Height - 17)); //диаметр (внеш)
                  
                    // конец стрелки сверху (справа)
                   graphics.DrawLine(Pen, new Point(picture.Width - picture.Width / 10 - 1, picture.Height - 20),
                      new Point(picture.Width - picture.Width / 10 - 6, picture.Height - 23)); //диаметр (внеш)
                  
                    // конец стрелки снизу (справа)
                   graphics.DrawLine(Pen, new Point(picture.Width - picture.Width / 10 - 1, picture.Height - 20),
                      new Point(picture.Width - picture.Width / 10 - 6, picture.Height - 17)); //диаметр (внеш)

       }

       /// <summary>
       ///    Показать  диаметр основания для четыршлицовой гайки
       /// </summary>
       /// <param name="picture">Изображение на котором показывается</param>
       /// <param name="graphics">ссылка на графику</param>
       private static void ShowBaseDiameterForFourSlottedNut(PictureBox picture, Graphics graphics)
       {
           
                   // Вертикальные линии
                   graphics.DrawLine(Pen, new Point(8, picture.Height / 4 + 15),
                       new Point(8, picture.Height - 20));
                   //диаметр (внеш)
                   graphics.DrawLine(Pen, new Point(picture.Width - picture.Width / 10 - 1 - 6, picture.Height / 4 + 15),
                       new Point(picture.Width - picture.Width / 10 - 1 - 6, picture.Height - 20));

                   // горизонтальная линия стрелки
                   graphics.DrawLine(Pen, new Point(8, picture.Height - 20),
                      new Point(picture.Width - picture.Width / 10 - 1 - 6, picture.Height - 20));

                   // конец стрелки сверху (слева)
                   graphics.DrawLine(Pen, new Point(8, picture.Height - 20),
                      new Point(13, picture.Height - 23));
                  
                    // конец стрелки снизу (слева)
                   graphics.DrawLine(Pen, new Point(8, picture.Height - 20),
                      new Point(13, picture.Height - 17));
                  
                    // конец стрелки сверху (справа)
                   graphics.DrawLine(Pen, new Point(picture.Width - picture.Width / 10 - 7, picture.Height - 20),
                      new Point(picture.Width - picture.Width / 10 - 11, picture.Height - 23));
                  
                    // конец стрелки снизу (справа)
                   graphics.DrawLine(Pen, new Point(picture.Width - picture.Width / 10 - 7, picture.Height - 20),
                      new Point(picture.Width - picture.Width / 10 - 11, picture.Height - 17));

       }

       /// <summary>
       ///    Показать внешний диаметр для шестишлицовой гайки
       /// </summary>
       /// <param name="picture">Изображение на котором показывается</param>
       /// <param name="graphics">ссылка на графику</param>
       private static void ShowBaseDiameterFourSixSlottedNut(PictureBox picture, Graphics graphics)
       {
         
                   // Вертикальные линии
                   graphics.DrawLine(Pen, new Point(6, picture.Height / 4 + 6), new Point(6, picture.Height - 20));
                   //диаметр (внеш)
                   graphics.DrawLine(Pen, new Point(picture.Width - picture.Width / 10 - 1 - 6, picture.Height / 4 + 6),
                       new Point(picture.Width - picture.Width / 10 - 1 - 6, picture.Height - 20));

                   // горизонтальная линия стрелки
                   graphics.DrawLine(Pen, new Point(6, picture.Height - 20),
                      new Point(picture.Width - picture.Width / 10 - 1 - 6, picture.Height - 20));

                   // конец стрелки сверху (слева)
                   graphics.DrawLine(Pen, new Point(6, picture.Height - 20),
                      new Point(11, picture.Height - 23));
                   
                    // конец стрелки снизу (слева)
                   graphics.DrawLine(Pen, new Point(6, picture.Height - 20),
                      new Point(11, picture.Height - 17));
                  
                    // конец стрелки сверху (справа)
                   graphics.DrawLine(Pen, new Point(picture.Width - picture.Width / 10 - 7, picture.Height - 20),
                      new Point(picture.Width - picture.Width / 10 - 11, picture.Height - 23));
                  
                    // конец стрелки снизу (справа)
                   graphics.DrawLine(Pen, new Point(picture.Width - picture.Width / 10 - 7, picture.Height - 20),
                      new Point(picture.Width - picture.Width / 10 - 11, picture.Height - 17));

       }

       /// <summary>
       ///    Показать высоту гайки для четыршлицовой гайки
       /// </summary>
       /// <param name="picture">Изображение на котором показывается</param>
       /// <param name="graphics">ссылка на графику</param>
       private static void ShowHeightNutFourSlottedNut(PictureBox picture, Graphics graphics)
       {
           
                   // Горизонтальные линии
                   graphics.DrawLine(Pen, new Point(picture.Width - picture.Width / 10 - 5, 1),
                       new Point(picture.Width - picture.Width / 10 + 10, 1));

                   graphics.DrawLine(Pen, new Point(picture.Width - picture.Width / 10 - 5,
                       picture.Height / 4 + 17),
                       new Point(picture.Width - picture.Width / 10 + 10, picture.Height / 4 + 17));

                   // вертикальная линия стрелки
                   graphics.DrawLine(Pen, new Point(picture.Width - picture.Width / 10 + 10, 0),
                      new Point(picture.Width - picture.Width / 10 + 10, picture.Height / 4 + 17));

                   // конец стрелки слева (сверху)
                   graphics.DrawLine(Pen, new Point(picture.Width - picture.Width / 10 + 10, 0),
                      new Point(picture.Width - picture.Width / 10 + 7, 5));
                 
                    // конец стрелки справа (сверху)
                   graphics.DrawLine(Pen, new Point(picture.Width - picture.Width / 10 + 10, 0),
                      new Point(picture.Width - picture.Width / 10 + 13, 5));

                   // конец стрелки слева (снизу)
                   graphics.DrawLine(Pen, new Point(picture.Width - picture.Width / 10 + 10,
                       picture.Height / 4 + 17),
                      new Point(picture.Width - picture.Width / 10 + 7, picture.Height / 4 + 12));
                   
                    // конец стрелки справа (снизу)
                   graphics.DrawLine(Pen, new Point(picture.Width - picture.Width / 10 + 10,
                       picture.Height / 4 + 17),
                      new Point(picture.Width - picture.Width / 10 + 13, picture.Height / 4 + 12));
                   
         

       }

       /// <summary>
       ///    Показать высоту для шестишлицовой гайки
       /// </summary>
       /// <param name="picture">Изображение на котором показывается</param>
       /// <param name="graphics">ссылка на графику</param>
       private static void ShowHeightNutForSixSlottedNut(PictureBox picture, Graphics graphics)
       {
          
                   // Горизонтальные линии
                   graphics.DrawLine(Pen, new Point(picture.Width - picture.Width / 10 - 5, 0),
                       new Point(picture.Width - picture.Width / 10 + 10, 0));

                   graphics.DrawLine(Pen, new Point(picture.Width - picture.Width / 10 - 5, picture.Height / 4 + 6),
                       new Point(picture.Width - picture.Width / 10 + 10, picture.Height / 4 + 6));

                   // вертикальная линия стрелки
                   graphics.DrawLine(Pen, new Point(picture.Width - picture.Width / 10 + 10, 0),
                      new Point(picture.Width - picture.Width / 10 + 10, picture.Height / 4 + 6));

                   // конец стрелки слева (сверху)
                   graphics.DrawLine(Pen, new Point(picture.Width - picture.Width / 10 + 10, 0),
                      new Point(picture.Width - picture.Width / 10 + 7, 5));
                 
                    // конец стрелки справа (сверху)
                   graphics.DrawLine(Pen, new Point(picture.Width - picture.Width / 10 + 10, 0),
                      new Point(picture.Width - picture.Width / 10 + 13, 5));

                   // конец стрелки слева (снизу)
                   graphics.DrawLine(Pen, new Point(picture.Width - picture.Width / 10 + 10, picture.Height / 4 + 6),
                      new Point(picture.Width - picture.Width / 10 + 7, picture.Height / 4 + 1));
                  
                    // конец стрелки справа (снизу)
                   graphics.DrawLine(Pen, new Point(picture.Width - picture.Width / 10 + 10, picture.Height / 4 + 6),
                      new Point(picture.Width - picture.Width / 10 + 13, picture.Height / 4 + 1));
           

       }

       /// <summary>
       ///    Показать высоту шлица для четыршлицовой гайки
       /// </summary>
       /// <param name="picture">Изображение на котором показывается</param>
       /// <param name="graphics">ссылка на графику</param>
       private static void ShowHeightSlotForFourSlottedNut(PictureBox picture, Graphics graphics)
       {
           
                   // Вертикалные линии
                   graphics.DrawLine(Pen, new Point(picture.Width / 2 + picture.Width / 5 - 5, picture.Height / 2 - 12),
                       new Point(picture.Width / 2 + picture.Width / 5 - 5, 5));
                   graphics.DrawLine(Pen, new Point(picture.Width / 2 + picture.Width / 5 + 3, picture.Height / 2 - 12),
                       new Point(picture.Width / 2 + picture.Width / 5 + 3, 5));

                   //Горизотальные линии стрелок
                   //слева
                   graphics.DrawLine(Pen, new Point(picture.Width / 2 + picture.Width / 5 - 13, 5)
                       , new Point(picture.Width / 2 + picture.Width / 5 - 3, 5));
                   //справа
                   graphics.DrawLine(Pen, new Point(picture.Width / 2 + picture.Width / 5 + 13, 5)
                       , new Point(picture.Width / 2 + picture.Width / 5 + 3, 5));

                   //Обоначение стрелки cнизу слева (левая горизонатльная линия)
                   graphics.DrawLine(Pen, new Point(picture.Width / 2 + picture.Width / 5 - 8, 8)
                       , new Point(picture.Width / 2 + picture.Width / 5 - 3, 5));

                   //Обоначение стрелки сверху слева (левая горизонатльная линия)
                   graphics.DrawLine(Pen, new Point(picture.Width / 2 + picture.Width / 5 - 8, 2)
                       , new Point(picture.Width / 2 + picture.Width / 5 - 3, 5));

                   //Обоначение стрелки cнизу слева (правая горизонатльная линия)
                   graphics.DrawLine(Pen, new Point(picture.Width / 2 + picture.Width / 5 + 8, 8)
                       , new Point(picture.Width / 2 + picture.Width / 5 + 3, 5));

                   //Обоначение стрелки сверху слева (правая горизонатльная линия)
                   graphics.DrawLine(Pen, new Point(picture.Width / 2 + picture.Width / 5 + 8, 2)
                       , new Point(picture.Width / 2 + picture.Width / 5 + 3, 5));

                
       }

       /// <summary>
       ///    Показать высоту шлица для четыршлицовой гайки
       /// </summary>
       /// <param name="picture">Изображение на котором показывается</param>
       /// <param name="graphics">ссылка на графику</param>
       private static void ShowHeightSlotForSixSlottedNut( PictureBox picture, Graphics graphics)
       {
           
                   // Вертикалные линии
                   graphics.DrawLine(Pen, new Point(picture.Width / 2 + picture.Width / 5 - 3, picture.Height / 2 - 8),
                       new Point(picture.Width / 2 + picture.Width / 5 - 3, 5));
                   graphics.DrawLine(Pen, new Point(picture.Width / 2 + picture.Width / 5 + 3, picture.Height / 2 - 8),
                       new Point(picture.Width / 2 + picture.Width / 5 + 3, 5));

                   //Горизотальные линии стрелок
                   //слева
                   graphics.DrawLine(Pen, new Point(picture.Width / 2 + picture.Width / 5 - 13, 5)
                       , new Point(picture.Width / 2 + picture.Width / 5 - 3, 5));
                   //справа
                   graphics.DrawLine(Pen, new Point(picture.Width / 2 + picture.Width / 5 + 13, 5)
                       , new Point(picture.Width / 2 + picture.Width / 5 + 3, 5));

                   //Обоначение стрелки cнизу слева (левая горизонатльная линия)
                   graphics.DrawLine(Pen, new Point(picture.Width / 2 + picture.Width / 5 - 8, 8)
                       , new Point(picture.Width / 2 + picture.Width / 5 - 3, 5));

                   //Обоначение стрелки сверху слева (левая горизонатльная линия)
                   graphics.DrawLine(Pen, new Point(picture.Width / 2 + picture.Width / 5 - 8, 2)
                       , new Point(picture.Width / 2 + picture.Width / 5 - 3, 5));

                   //Обоначение стрелки cнизу слева (правая горизонатльная линия)
                   graphics.DrawLine(Pen, new Point(picture.Width / 2 + picture.Width / 5 + 8, 8)
                       , new Point(picture.Width / 2 + picture.Width / 5 + 3, 5));

                   //Обоначение стрелки сверху слева (правая горизонатльная линия)
                   graphics.DrawLine(Pen, new Point(picture.Width / 2 + picture.Width / 5 + 8, 2)
                       , new Point(picture.Width / 2 + picture.Width / 5 + 3, 5));

                   
           
       }

       /// <summary>
       ///    Показать ширину шлица для четыршлицовой гайки
       /// </summary>
       /// <param name="picture">Изображение на котором показывается</param>
       /// <param name="graphics">ссылка на графику</param>
       private static void ShowWidthSlotForFourSlottedNut( PictureBox picture, Graphics graphics)
       {
          
                   // Горизонтальные линии
                   graphics.DrawLine(Pen, new Point(picture.Width / 2 + picture.Width / 5 - 4, picture.Height / 2 - 12),
                       new Point(picture.Width - 20, picture.Height / 2 - 12));

                   graphics.DrawLine(Pen, new Point(picture.Width / 2 + picture.Width / 5 - 4, picture.Height / 2 + 11),
                         new Point(picture.Width - 20, picture.Height / 2 + 11));

                   // вертикальная линия стрелки
                   graphics.DrawLine(Pen, new Point(picture.Width - 20, picture.Height / 2 - 12),
                        new Point(picture.Width - 20, picture.Height / 2 + 11));

                   // конец стрелки слева (сверху)
                   graphics.DrawLine(Pen, new Point(picture.Width - 20, picture.Height / 2 - 12),
                       new Point(picture.Width - 23, picture.Height / 2 - 7));

                   // конец стрелки справа (сверху)

                   graphics.DrawLine(Pen, new Point(picture.Width - 20, picture.Height / 2 - 12),
                       new Point(picture.Width - 17, picture.Height / 2 - 7));

                   // конец стрелки слева (снизу)
                   graphics.DrawLine(Pen, new Point(picture.Width - 20, picture.Height / 2 + 11),
                       new Point(picture.Width - 23, picture.Height / 2 + 6));

                   // конец стрелки справа (снизу)

                   graphics.DrawLine(Pen, new Point(picture.Width - 20, picture.Height / 2 + 11),
                       new Point(picture.Width - 17, picture.Height / 2 + 6));
                  

       }

       /// <summary>
       ///    Показать ширину шлица для шестишлицовой гайки
       /// </summary>
       /// <param name="picture">Изображение на котором показывается</param>
       /// <param name="graphics">ссылка на графику</param>
       private static void ShowWidthSlotForSixSlottedNut(PictureBox picture, Graphics graphics)
       {
          
                   // Горизонтальные линии
                   graphics.DrawLine(Pen, new Point(picture.Width / 2 + picture.Width / 5 - 2, picture.Height / 2 - 7),
                       new Point(picture.Width - 20, picture.Height / 2 - 7));

                   graphics.DrawLine(Pen, new Point(picture.Width / 2 + picture.Width / 5 - 2, picture.Height / 2 + 7),
                         new Point(picture.Width - 20, picture.Height / 2 + 7));

                   // вертикальная линия стрелки
                   graphics.DrawLine(Pen, new Point(picture.Width - 20, picture.Height / 2 - 7),
                        new Point(picture.Width - 20, picture.Height / 2 + 7));

                   // конец стрелки слева (сверху)
                   graphics.DrawLine(Pen, new Point(picture.Width - 20, picture.Height / 2 - 7),
                       new Point(picture.Width - 23, picture.Height / 2 - 2));

                   // конец стрелки справа (сверху)

                   graphics.DrawLine(Pen, new Point(picture.Width - 20, picture.Height / 2 - 7),
                       new Point(picture.Width - 17, picture.Height / 2 - 2));

                   // конец стрелки слева (снизу)
                   graphics.DrawLine(Pen, new Point(picture.Width - 20, picture.Height / 2 + 7),
                       new Point(picture.Width - 23, picture.Height / 2 + 2));

                   // конец стрелки справа (снизу)

                   graphics.DrawLine(Pen, new Point(picture.Width - 20, picture.Height / 2 + 7),
                       new Point(picture.Width - 17, picture.Height / 2 + 2));
                   
           

       }

       /// <summary>
       ///    Показать  диаметр резьбы  для четырешлицовой гайки
       /// </summary>
       /// <param name="picture">Изображение на котором показывается</param>
       /// <param name="graphics">ссылка на графику</param>
       private static void ShowThreadDiameterForFourSlottedNut(PictureBox picture, Graphics graphics)
       {
          
                   //Горизонтальная линия
                   graphics.DrawLine(Pen, new Point(picture.Width / 4 - 2, picture.Height / 2),
                       new Point(picture.Width / 2 - 4, picture.Height / 2));

                   //Обозначение стрелок снизу(слева)
                   graphics.DrawLine(Pen, new Point(picture.Width / 4 - 2, picture.Height / 2),
                       new Point(picture.Width / 4 + 3, picture.Height / 2 + 3));
                 
                    //Обозначение стрелок сверху(слева)
                   graphics.DrawLine(Pen, new Point(picture.Width / 4 - 2, picture.Height / 2),
                        new Point(picture.Width / 4 + 3, picture.Height / 2 - 3));


                   //Обозначение стрелок снизу(справа)
                   graphics.DrawLine(Pen, new Point(picture.Width / 2 - 4, picture.Height / 2),
                       new Point(picture.Width / 2 - 9, picture.Height / 2 + 3));
                  
                    //Обозначение стрелок сверху(справа)
                   graphics.DrawLine(Pen, new Point(picture.Width / 2 - 4, picture.Height / 2),
                        new Point(picture.Width / 2 - 9, picture.Height / 2 - 3));
              
        }

       /// <summary>
       ///    Показать внешний диаметр для шестишлицовой гайки
       /// </summary>
       /// <param name="picture">Изображение на котором показывается</param>
       /// <param name="graphics">ссылка на графику</param>
       private static void ShowThreadDiameterForSixSlottedNut(PictureBox picture, Graphics graphics)
       {
     
                   //Горизонтальная линия
                   graphics.DrawLine(Pen, new Point(picture.Width / 4 - 9, picture.Height / 2),
                       new Point(picture.Width / 2 +3, picture.Height / 2));

                   //Обозначение стрелок снизу(слева)
                   graphics.DrawLine(Pen, new Point(picture.Width / 4 - 9, picture.Height / 2),
                       new Point(picture.Width / 4 - 4, picture.Height / 2 + 3));
                  
                    //Обозначение стрелок сверху(слева)
                   graphics.DrawLine(Pen, new Point(picture.Width / 4 - 9, picture.Height / 2),
                        new Point(picture.Width / 4 - 4, picture.Height / 2 - 3));

                   //Обозначение стрелок снизу(справа)
                   graphics.DrawLine(Pen, new Point(picture.Width / 2 +3, picture.Height / 2),
                       new Point(picture.Width / 2 - 2, picture.Height / 2 + 3));
                 
                    //Обозначение стрелок сверху(справа)
                   graphics.DrawLine(Pen, new Point(picture.Width / 2+3, picture.Height / 2),
                        new Point(picture.Width / 2 - 2, picture.Height / 2 - 3));
       }

#endregion



    }
}

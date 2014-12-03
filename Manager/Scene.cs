using System;
using DataOrganizer;
using Model;
using Kompas6API5;
using System.Windows.Forms;

namespace Manager
{
    public class Scene
    {
        /// <summary>
        /// Ссылка на объект KOMПАС-3D
        /// </summary>
        private  KompasObject _kompas;

        /// <summary>
        /// 
        /// </summary>
        private  SlottedNut _slottedNut;

        /// <summary>
        /// 
        /// </summary>
        private ksDocument3D _document3D;
     
        public  void InitScene(DataContainer.NutDescription slottedNutSample, int typeOfThread)
        {
          
            OpenKompas();

            if (_kompas != null)
            {
                if (_document3D == null)
                {
                     CreateDocument();
                    _slottedNut = new SlottedNut(_document3D, _kompas, slottedNutSample, typeOfThread);
                    _slottedNut.CreateNut();
                }
                //удалить старый объект 
                else
                {
                    if (IsTempDocumentNotEmpty())
                    {
                        _document3D.close();
                        CreateDocument();
                        _slottedNut = new SlottedNut(_document3D, _kompas, slottedNutSample, typeOfThread);
                        _slottedNut.CreateNut();
                    }
                    else
                    {
                        CreateDocument();
                        _slottedNut = new SlottedNut(_document3D, _kompas, slottedNutSample, typeOfThread);
                        _slottedNut.CreateNut();
                        
                    }
                    
                }
            }
            else
            {

                MessageBox.Show("КОМПАС не запущен.Пожалуйста, запустите КОМПАС");
            }
        }

        private bool IsTempDocumentNotEmpty()
        {
            
            const string message = "Документ не пустой, закрыть документ?";
            const string caption = "Form Closing";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

           // If the no button was pressed ...
            if (result == DialogResult.No)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void CreateDocument()
        {
            // Создаем сборку
            _document3D = (ksDocument3D)_kompas.Document3D();
            _document3D.Create(false, true); //falseтут нужно выбирать либо на текущем или заново создавать деталь
            _document3D = (ksDocument3D)_kompas.ActiveDocument3D();
            
        }

        /// <summary>
        /// Открыть Компас
        /// </summary>
        private void OpenKompas()
        {
            if (_kompas == null)
            {
                Type type = Type.GetTypeFromProgID("KOMPAS.Application.5");

                _kompas = (KompasObject)Activator.CreateInstance(type);
            }

            if (_kompas != null)
            {
                _kompas.Visible = true;
                _kompas.ActivateControllerAPI();
            }
        }
    }
}

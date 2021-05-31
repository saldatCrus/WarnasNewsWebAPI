using DevExpress.Mvvm;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WarnasNewsTestApp.ViewModels
{
    class AddNewsPageViewModel : BindableBase
    {
        public byte[] ConvertedImage { get; set; }
        
        public string NewsHead { get; set; }

        public string NewsBody { get; set; }

        public string NewsLink { get; set; }


        public AddNewsPageViewModel() 
        {

        }

        public ICommand UploadImageButton => new DelegateCommand(async () =>
        {
            var ofd = new OpenFileDialog();
            ofd.Filter = "Image (*.Jpeg, *.jpg ) | *.Jpeg; *.Jpg;";
            var result = ofd.ShowDialog();

            if (result == true)
            {
                Image img = Image.FromFile(ofd.FileName);

                using (MemoryStream ms = new MemoryStream())
                {
                    img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    ConvertedImage = ms.ToArray();
                }
            }
        });   

        public ICommand AddNewsOnServer => new DelegateCommand(async() =>
        {
           
        }); 



    }
}

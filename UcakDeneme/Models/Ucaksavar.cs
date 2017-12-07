using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UcakDeneme.Models
{
    sealed class Ucaksavar:Nesne
    {
        public Ucaksavar()
        {
            Resim.ImageLocation = "Resources/ucaksavar.PNG";
            Resim.SizeMode = PictureBoxSizeMode.StretchImage;
            Resim.BackColor = Color.Transparent;
            Boyut = new Size(70, 70);
        }
    }
}

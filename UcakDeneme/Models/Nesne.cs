using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UcakDeneme.Models
{
    abstract  class Nesne
    {
        public virtual void init(int x, int y)
        {
            Resim.SizeMode = PictureBoxSizeMode.StretchImage;
            Resim.BackColor = Color.Transparent;
            Boyut = new Size(x, y);
        }
        public PictureBox Resim { get; set; } = new PictureBox();

        public Point Konum
        {
            get
            {
                return Resim.Location;
            }

            set
            {
                Resim.Location = value;
            }
        }

        public Size Boyut
        {
            get
            {
                return Resim.Size;
            }
            set
            {
                Resim.Size = value;
            }
        }
    }
}

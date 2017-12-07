using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UcakDeneme.Interfaces;
namespace UcakDeneme.Models
{
    class Mermi:Nesne,IHareketEdebilme,IYokOlabilme
    {
        public Mermi()
        {
            init(30,30);
        }
        public int Hiz { get; set; }

        public void AsagiGit()
        {
            throw new NotImplementedException();
        }

        public void SagaGit()
        {
            throw new NotImplementedException();
        }

        public void SolaGit()
        {
            throw new NotImplementedException();
        }

        public void YokOl()
        {
            Resim.Dispose();
        }

        public void YukariGit()
        {
            Konum = new Point(Konum.X, Konum.Y - Hiz);
        }
        public override void init(int x, int y)
        {
            base.init(x, y);
            Resim.ImageLocation = "Resources/mermi.PNG";
            Hiz = 7;
        }
    }
}

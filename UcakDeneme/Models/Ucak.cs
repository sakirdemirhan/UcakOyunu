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
    class Ucak:Nesne,IHareketEdebilme,IYokOlabilme
    {
        public Ucak()
        {
            init(50, 50);
        }
        public int Hiz { get; set; }

        public void AsagiGit()
        {
            Konum = new Point(Konum.X, Konum.Y + Hiz);
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
            throw new NotImplementedException();
        }

        public override void init(int x, int y)
        {
            base.init(x, y);
            Resim.ImageLocation = "Resources/ucak.PNG";
            Hiz = 5;
        }
    }
}

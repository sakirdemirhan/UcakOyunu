using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UcakDeneme.Models;
namespace UcakDeneme
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private int skor = 0;
        List<Ucak> dusmanlar = new List<Ucak>();
        List<Mermi> mermiler = new List<Mermi>();
        private SoundPlayer s;
        Ucaksavar ucaksavar;
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            ucaksavar.Konum = new Point(e.X-40, this.ClientSize.Height - ucaksavar.Boyut.Height);
        }
         
        private void Form1_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(47, 79, 79);
            ucaksavar = new Ucaksavar();
            this.Controls.Add(ucaksavar.Resim);
            //Konum (x,y)
            ucaksavar.Konum = new Point(100, this.ClientSize.Height - ucaksavar.Boyut.Height);

            this.Text = "Vurulan Uçak Sayısı: ";

            s = new SoundPlayer {SoundLocation = "Resources/bomb-small.wav"};


            timer1.Enabled = true;
            timer1.Interval = 60;
            timer2.Enabled = true;
            timer2.Interval = 1600;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (Ucak item in dusmanlar)
            {
                item.AsagiGit();
                
                if (YereDustuMu(item))
                {
                    timer1.Stop();
                    timer2.Stop();
                    MessageBox.Show("Düşman uçakları sınırı işgal etti. Skorun: "+skor.ToString(),"Oyun Bitti !");
                    GameOver();
                }
            }

            foreach (Mermi item in mermiler)
            {
                item.YukariGit();
            }

            try
            {
                foreach (var dusman in dusmanlar)
                {
                    foreach (var mermi in mermiler)
                    {
                        if (Carpisma(dusman, mermi))
                        {
                            skor++;
                            s.Play();
                            dusman.YokOl();
                            mermi.YokOl();
                            mermiler.Remove(mermi);
                            dusmanlar.Remove(dusman);
                            this.Text = "Vurulan Uçak Sayısı: "+skor.ToString();
                           timer1.Interval -= 5;
                           timer2.Interval -= 100;
                            if (timer1.Interval <= 10)
                            {
                                timer1.Interval += 5;
                            }
                            if (timer2.Interval <= 100)
                            {
                                timer2.Interval += 100;
                            }
                            
                        }
                    }
                }
            }
            catch (Exception)
            {

                
            }

            
            
        }
        
        private void timer2_Tick(object sender, EventArgs e)
        {
            Ucak ucak = new Ucak();
            dusmanlar.Add(ucak);
            this.Controls.Add(ucak.Resim);
            //Konum (x,y)
            ucak.Konum = new Point(new Random().Next(0, this.ClientSize.Height));
            
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            Mermi mermi = new Mermi();
            mermiler.Add(mermi);
            this.Controls.Add(mermi.Resim);
            //Konum (x,y)
            var mermiKonum = new Point(ucaksavar.Konum.X + 20,ucaksavar.Konum.Y);
            mermi.Konum = mermiKonum;
            

        }

        bool YereDustuMu(Ucak u)
        {
            if (u.Konum.Y+u.Boyut.Height >= this.ClientSize.Height)
            {
                return true;
            }
            else
                return false;
        }

        bool Carpisma(Ucak u, Mermi m)
        {
            if ((m.Konum.X + m.Boyut.Width > u.Konum.X && u.Konum.X+u.Boyut.Width>m.Konum.X) && (u.Konum.Y + u.Boyut.Height >= m.Konum.Y))
            {
                return true;
            }
            else
                return false;
        }

        void GameOver()
        {
            
            Application.Exit();
        }

       
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.P)
            {
                timer1.Stop();
                timer2.Stop();
                DialogResult dialogResult = MessageBox.Show("Oyun Durdu. Devam Et ?", "Oyun Durdu !", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    timer1.Start();
                    timer2.Start();
                }
                else if (dialogResult == DialogResult.No)
                {
                    Application.Exit();
                }
            }

            

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e, MouseEventArgs ee)
        {
            Form1_MouseClick(sender, ee);
        }
    }
}

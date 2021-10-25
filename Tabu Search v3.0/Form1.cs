using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Tabu_Search_v3._0
{
    public partial class Form1 : Form
    {
        #region Değişkenler

       
        public static int iterasyonsayısı;

        string harfsırala;
        string sayısıralama;
        string stoplam; // Sözel toplama işlemini göstermek için
        int itoplam; // Değerlerin sayısal toplamı için.
        int eniyiçözüm;

        int x, y, z, t, u, v; // Makineden gelen değerler.

        int x1;

        int m = 0, n = 1; // dizi değerleri değişimini sağlamak için.

        int seçimsayısı = 0;

        #endregion


        #region Tanımlamalar

        string[] makineisimleri = { "", "A", "B", "C", "D", "E", "F" };
        public static int[] makine1 = new int[6];
        public static int[] makine2 = new int[6];
        public static int[] makine3 = new int[6];
        public static int[] makine4 = new int[6];
        public static int[] makine5 = new int[6];
        public static int[] makine6 = new int[6];

        public static int[] dizi1 = new int[6]; // İlk işlemde rasgele seçimin sayısal değerlerini tutacak.

        ArrayList seçimlistesi = new ArrayList();
        ArrayList eniyiçözümlist1 = new ArrayList();
        ArrayList eniyiçözümlist2 = new ArrayList();

        ArrayList ilkseçim = new ArrayList();
        ArrayList seçimyenile = new ArrayList();

        Random r = new Random();

        #endregion


        #region Metodlar



        #endregion


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            #region Makine Değerlerini Al

            makine1[0] = int.Parse(textBox1.Text);
            makine1[1] = int.Parse(textBox2.Text);
            makine1[2] = int.Parse(textBox3.Text);
            makine1[3] = int.Parse(textBox4.Text);
            makine1[4] = int.Parse(textBox5.Text);
            makine1[5] = int.Parse(textBox6.Text);
            makine2[0] = int.Parse(textBox7.Text);
            makine2[1] = int.Parse(textBox8.Text);
            makine2[2] = int.Parse(textBox9.Text);
            makine2[3] = int.Parse(textBox10.Text);
            makine2[4] = int.Parse(textBox11.Text);
            makine2[5] = int.Parse(textBox12.Text);
            makine3[0] = int.Parse(textBox13.Text);
            makine3[1] = int.Parse(textBox14.Text);
            makine3[2] = int.Parse(textBox15.Text);
            makine3[3] = int.Parse(textBox16.Text);
            makine3[4] = int.Parse(textBox17.Text);
            makine3[5] = int.Parse(textBox18.Text);
            makine4[0] = int.Parse(textBox19.Text);
            makine4[1] = int.Parse(textBox20.Text);
            makine4[2] = int.Parse(textBox21.Text);
            makine4[3] = int.Parse(textBox22.Text);
            makine4[4] = int.Parse(textBox23.Text);
            makine4[5] = int.Parse(textBox24.Text);
            makine5[0] = int.Parse(textBox25.Text);
            makine5[1] = int.Parse(textBox26.Text);
            makine5[2] = int.Parse(textBox27.Text);
            makine5[3] = int.Parse(textBox28.Text);
            makine5[4] = int.Parse(textBox29.Text);
            makine5[5] = int.Parse(textBox30.Text);
            makine6[0] = int.Parse(textBox31.Text);
            makine6[1] = int.Parse(textBox32.Text);
            makine6[2] = int.Parse(textBox33.Text);
            makine6[3] = int.Parse(textBox34.Text);
            makine6[4] = int.Parse(textBox35.Text);
            makine6[5] = int.Parse(textBox36.Text);

            iterasyonsayısı = int.Parse(textBox37.Text);
            
            #endregion

            #region İlk İşlem

            for (int i = 0; i < 6; i++)
            {
                do
                {
                    x1 = r.Next(1, 7);
                } while (Array.IndexOf(dizi1, x1) != -1);
                dizi1[i] = x1;
                seçimlistesi.Add(makineisimleri[x1]);
                ilkseçim.Add(makineisimleri[x1]);

                harfsırala += makineisimleri[x1] + ",";
                sayısıralama += dizi1[i] + ",";
            }

            sayısıralama = sayısıralama.Substring(0, 11);
            harfsırala = harfsırala.Substring(0, 11);

            listBox2.Items.Add(sayısıralama);
            listBox3.Items.Add(harfsırala);

            #endregion

            #region İlk Değer Alma

            for (int i = 0; i < 6; i++)
            {
                switch (dizi1[i])
                {

                    case 1:
                        x = makine1[i]; stoplam += x + "+"; break;
                    case 2:
                        y = makine2[i]; stoplam += y + "+"; break;
                    case 3:
                        z = makine3[i]; stoplam += z + "+"; break;
                    case 4:
                        t = makine4[i]; stoplam += t + "+"; break;
                    case 5:
                        u = makine5[i]; stoplam += u + "+"; break;
                    case 6:
                        v = makine6[i]; stoplam += v + "+"; break;
                }
            }

            seçimsayısı++;
            listBox1.Items.Add(seçimsayısı);
            stoplam = stoplam.Substring(0, stoplam.Length - 1);
            listBox4.Items.Add(stoplam);

            itoplam = x + y + z + t + u + v;
            eniyiçözüm = x + y + z + t + u + v;
            listBox5.Items.Add(itoplam);
            listBox6.Items.Add(eniyiçözüm);


            #endregion

            #region Tabu Döngüsü

            for (int i = 0; i < iterasyonsayısı; i++)
            {
                for (int z1 = 0; z1 < 5; z1++)
                {
                    seçimyenile.Clear();

                    #region Komşuluk Bulma

                    if (z1 == 0)
                    {
                        seçimyenile.Add(ilkseçim[n]);
                        seçimyenile.Add(ilkseçim[m]);
                        seçimyenile.Add(ilkseçim[n + 1]);
                        seçimyenile.Add(ilkseçim[n + 2]);
                        seçimyenile.Add(ilkseçim[n + 3]);
                        seçimyenile.Add(ilkseçim[n + 4]);
                    }

                    else if (z1 == 1)
                    {
                        seçimyenile.Add(ilkseçim[n + 1]);
                        seçimyenile.Add(ilkseçim[n]);
                        seçimyenile.Add(ilkseçim[m]);
                        seçimyenile.Add(ilkseçim[n + 2]);
                        seçimyenile.Add(ilkseçim[n + 3]);
                        seçimyenile.Add(ilkseçim[n + 4]);
                    }

                    else if (z1 == 2)
                    {
                        seçimyenile.Add(ilkseçim[n + 2]);
                        seçimyenile.Add(ilkseçim[n]);
                        seçimyenile.Add(ilkseçim[n + 1]);
                        seçimyenile.Add(ilkseçim[m]);
                        seçimyenile.Add(ilkseçim[n + 3]);
                        seçimyenile.Add(ilkseçim[n + 4]);
                    }

                    else if (z1 == 3)
                    {
                        seçimyenile.Add(ilkseçim[n + 3]);
                        seçimyenile.Add(ilkseçim[n]);
                        seçimyenile.Add(ilkseçim[n + 1]);
                        seçimyenile.Add(ilkseçim[n+2]);
                        seçimyenile.Add(ilkseçim[m]);
                        seçimyenile.Add(ilkseçim[n + 4]);
                    }

                    else if (z1 == 4)
                    {
                        seçimyenile.Add(ilkseçim[n + 4]);
                        seçimyenile.Add(ilkseçim[n]);
                        seçimyenile.Add(ilkseçim[n + 1]);
                        seçimyenile.Add(ilkseçim[n + 2]);
                        seçimyenile.Add(ilkseçim[n+3]);
                        seçimyenile.Add(ilkseçim[m]);
                    }
                    ilkseçim.Clear();
                    harfsırala = "";
                    sayısıralama = "";

                    #endregion

                    #region Yeni Yer Seçimi

                    for (int j = 0; j < 6; j++)
                    {
                        if (seçimyenile[j] == "A")
                        {
                            dizi1[j] = 1;
                            seçimlistesi.Add(makineisimleri[1]);
                            ilkseçim.Add(makineisimleri[1]);
                            harfsırala += makineisimleri[1] + ",";
                            sayısıralama += dizi1[j] + ",";


                        }

                        else if (seçimyenile[j] == "B")
                        {
                            dizi1[j] = 2;
                            seçimlistesi.Add(makineisimleri[2]);
                            ilkseçim.Add(makineisimleri[2]);
                            harfsırala += makineisimleri[2] + ",";
                            sayısıralama += dizi1[j] + ",";


                        }

                        else if (seçimyenile[j] == "C")
                        {
                            dizi1[j] = 3;
                            seçimlistesi.Add(makineisimleri[3]);
                            ilkseçim.Add(makineisimleri[3]);
                            harfsırala += makineisimleri[3] + ",";
                            sayısıralama += dizi1[j] + ",";
                        }

                        else if (seçimyenile[j] == "D")
                        {
                            dizi1[j] = 4;
                            seçimlistesi.Add(makineisimleri[4]);
                            ilkseçim.Add(makineisimleri[4]);
                            harfsırala += makineisimleri[4] + ",";
                            sayısıralama += dizi1[j] + ",";
                        }

                        else if (seçimyenile[j] == "E")
                        {
                            dizi1[j] = 5;
                            seçimlistesi.Add(makineisimleri[5]);
                            ilkseçim.Add(makineisimleri[5]);
                            harfsırala += makineisimleri[5] + ",";
                            sayısıralama += dizi1[j] + ",";
                        }

                        else if (seçimyenile[j] == "F")
                        {
                            dizi1[j] = 6;
                            seçimlistesi.Add(makineisimleri[6]);
                            ilkseçim.Add(makineisimleri[6]);
                            harfsırala += makineisimleri[6] + ",";
                            sayısıralama += dizi1[j] + ",";
                        }

                    }

                    sayısıralama = sayısıralama.Substring(0, 11);
                    harfsırala = harfsırala.Substring(0, 11);

                    listBox2.Items.Add(sayısıralama);
                    listBox3.Items.Add(harfsırala);
                    stoplam = "";

                    for (int z2 = 0; z2 < 6; z2++)
                    {
                        switch (dizi1[z2])
                        {

                            case 1:
                                x = makine1[z2]; stoplam += x + "+"; break;
                            case 2:
                                y = makine2[z2]; stoplam += y + "+"; break;
                            case 3:
                                z = makine3[z2]; stoplam += z + "+"; break;
                            case 4:
                                t = makine4[z2]; stoplam += t + "+"; break;
                            case 5:
                                u = makine5[z2]; stoplam += u + "+"; break;
                            case 6:
                                v = makine6[z2]; stoplam += v + "+"; break;
                        }
                    }

                    seçimsayısı++;
                    listBox1.Items.Add(seçimsayısı);
                    stoplam = stoplam.Substring(0, stoplam.Length - 1);
                    listBox4.Items.Add(stoplam);

                    itoplam = x + y + z + t + u + v;
                    if (itoplam < eniyiçözüm)
                    {
                        eniyiçözüm = itoplam;
                        listBox6.Items.Add(eniyiçözüm);
                    }

                    listBox5.Items.Add(itoplam);
                    listBox6.Items.Add("-");


                    #endregion
                }

            }

            #endregion
        }
    }
}

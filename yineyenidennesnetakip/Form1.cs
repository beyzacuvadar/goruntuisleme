using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Windows.Forms;
using AForge;
using AForge.Imaging;
using AForge.Imaging.Filters;
using AForge.Video;
using AForge.Video.DirectShow;



namespace yineyenidennesnetakip
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int sayac;
        int R, G, B;
        int X, Y;
        Graphics g;
        int mode;
        Bitmap imge1,imge2;

        private FilterInfoCollection CaptureDevice;
        private VideoCaptureDevice FinalFrame;

        private void Form1_Load(object sender, EventArgs e)
        {
            portBox.DataSource = SerialPort.GetPortNames();
            int sayi = portBox.Items.Count;
            if (sayi == 0)
            {
                toolStripLabel1.Text = "Aygıt bulunamadı. Bağlantıyı kontrol et!!";
                portBox.Enabled = false;
            }
            else if (sayi > 0)
            {
                toolStripLabel1.Text = sayi + "tane port var";
            }

            string[] Portlar = SerialPort.GetPortNames();
            foreach (string port in Portlar)
            
            CaptureDevice = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo Device in CaptureDevice)
            {
                webcamBox.Items.Add(Device.Name);

            }

            webcamBox.SelectedIndex = 0;
            FinalFrame = new VideoCaptureDevice();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (FinalFrame.IsRunning == true)
            {
                FinalFrame.Stop();
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = (Bitmap)pictureBox1.Image.Clone();
            {
                mode = 1;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            serialPort1.BaudRate = 9600;
            if (serialPort1.IsOpen)
            {
                toolStrip1.Text = portBox.SelectedItem.ToString() + "Portuna bağlandı";
            }
        }
        private void portBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            serialPort1.PortName = portBox.SelectedItem.ToString();
            serialPort1.Open();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            FinalFrame = new VideoCaptureDevice(CaptureDevice[webcamBox.SelectedIndex].MonikerString);

            FinalFrame.NewFrame += FinalFrame_NewFrame;
            FinalFrame.Start();
        }

        private void FinalFrame_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            imge1 = (Bitmap)eventArgs.Frame.Clone();  
            Bitmap imge2 = (Bitmap)eventArgs.Frame.Clone();

            if (radioButton1.Checked)
            {
                EuclideanColorFiltering filter = new EuclideanColorFiltering();
                filter.CenterColor = new RGB(Color.FromArgb(225, 0, 0));
                filter.Radius = 100;
                filter.ApplyInPlace(imge2);
            }
            if (radioButton2.Checked)
            {
                EuclideanColorFiltering filter = new EuclideanColorFiltering();

                filter.CenterColor = new RGB(Color.FromArgb(0, 255, 0));
                filter.Radius = 100;
                filter.ApplyInPlace(imge2);

            }
            if (radioButton3.Checked)
            {
                EuclideanColorFiltering filter = new EuclideanColorFiltering();

                filter.CenterColor = new RGB(Color.FromArgb(0, 0, 255));
                filter.Radius = 100;
                filter.ApplyInPlace(imge2);
            }
            switch (mode)
            {
                case 2:
                    {
                        g = Graphics.FromImage(imge2);
                        g.DrawString(sayac.ToString(), new Font("Arial", 100), new SolidBrush(Color.Black), new PointF(2, 2));
                        g.Dispose();

                    }
                    break;

                case 1:
                    {
                        BlobCounter blob = new BlobCounter();
                        blob.MinHeight = 15;
                        blob.MinWidth = 15;
                        blob.ObjectsOrder = ObjectsOrder.Size;
                        blob.ProcessImage(imge2);
                        Rectangle[] rects = blob.GetObjectsRectangles();
                        if (rects.Length > 0)
                        {
                            Rectangle obje = rects[0];
                            Graphics g = Graphics.FromImage(imge2);
                            using (Pen pen = new Pen(Color.Black, 3))
                            {
                                g.DrawRectangle(pen, obje);
                            }
                            X = obje.X;
                            Y = obje.Y;

                            g = Graphics.FromImage(imge2);

                            if (X <= 320)


                            {
                                serialPort1.Write("l");
                            }
                            if (X > 320)
                            {
                                serialPort1.Write("r");

                        }
                            g.DrawString(X.ToString() + "X" + Y.ToString() + "Y" , new Font("Arial", 12), Brushes.Red, new System.Drawing.Point(1, 1));
                            g.Dispose();
                        }
                        pictureBox2.Image = imge2;

                    }
                    break;
            }

            pictureBox1.Image = imge1;

        }
    }
}
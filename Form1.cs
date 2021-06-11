using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Puzzle
{
    public partial class frmBubblePuzzle : Form
    {
        PictureBox pbxFinalImage = null;
        PictureBox pbxPuzzleImage = null;
        PictureBox ClickBox1 = null;
        PictureBox ClickBox2 = null;
        PictureBox[] PuzzlePieces = null;

        Image imageFinal;
        Image imagePuzzle;
        Image[] Images = null;

        OpenFileDialog ofdFileDialog = null;
        System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();

        int numberOfMoves = 0;
        Point[] Locations = null;


        public frmBubblePuzzle()
        {
            InitializeComponent();
            lblTimer.Text = "00:00:00";
            lblMoves.Text = "0";
        }

        private void btnAddImage_Click(object sender, EventArgs e)
        {
            btnEasy.Enabled = true;
            btnMedium.Enabled = true;
            btnHard.Enabled = true; 

            if (ofdFileDialog == null)
            {
                ofdFileDialog = new OpenFileDialog();
            }

            if (ofdFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                if (pbxFinalImage == null)
                {
                    pbxFinalImage = new PictureBox();
                    pbxFinalImage.Height = gbImage.Height;
                    pbxFinalImage.Width = gbImage.Width;
                    gbImage.Controls.Add(pbxFinalImage);
                }
                if (pbxPuzzleImage == null)
                {
                    pbxPuzzleImage = new PictureBox();
                    pbxPuzzleImage.Height = gbPuzzle.Height;
                    pbxPuzzleImage.Width = gbPuzzle.Width;
                    gbPuzzle.Controls.Add(pbxPuzzleImage);
                }
                imageFinal = ProcessImage(Image.FromFile(ofdFileDialog.FileName), gbImage);
                pbxFinalImage.Image = imageFinal;

                imagePuzzle = ProcessImage(Image.FromFile(ofdFileDialog.FileName), gbPuzzle);
                pbxPuzzleImage.Image = imagePuzzle;
            }
        }


        private Bitmap ProcessImage(Image Image, GroupBox groupBox)
        {
            Bitmap bmpImg = new Bitmap(groupBox.Width, groupBox.Height);
            Graphics graphics = Graphics.FromImage(bmpImg);
            graphics.Clear(Color.White);
            graphics.DrawImage(Image, new Rectangle(0, 0, groupBox.Width, groupBox.Height));
            graphics.Flush();

            return bmpImg;
        }


        private void SliceImage(Image image, Image[] images, int index, int numberRows, int numberColumns, int pieceX, int pieceY)
        {
            images[index] = new Bitmap(pieceX, pieceY);
            Graphics graphics = Graphics.FromImage(images[index]);
            graphics.Clear(Color.White);
            graphics.DrawImage(image, new Rectangle(0,0,pieceX,pieceY), new Rectangle(pieceX * (index%numberColumns), pieceY * (index / numberColumns),pieceX,pieceY),GraphicsUnit.Pixel);
            graphics.Flush();
        }

        private void Shuffle(ref int [] array)
        {
           Random rnd = new Random();
           int i=array.Length;
           while(i > 1)
           {
               int j = rnd.Next(i);  
               i--;
               int tmp = array[j];
               array[j] = array[i];
               array[i] = tmp;
           }
        }

        public void PuzzleClick(object sender, EventArgs e)
        {
            if (ClickBox1 == null)
            {
                ClickBox1 = (PictureBox)sender;
            }

            else if (ClickBox2 == null)
            {
                ClickBox2 = (PictureBox)sender;
                SwapImages(ClickBox1, ClickBox2);
                ClickBox1 = null;
                ClickBox2 = null;
                numberOfMoves++;
                lblMoves.Text = numberOfMoves.ToString();
                if (IsComplete())
                {
                    Console.WriteLine("Puzzle Complete !!!");
                    Win();
                }
            }
            else
            {
                ClickBox1 = ClickBox2;
                ClickBox2 = (PictureBox)sender;
                SwapImages(ClickBox1, ClickBox2);
                ClickBox1 = null;
                ClickBox2 = null;
                numberOfMoves++;
                lblMoves.Text = numberOfMoves.ToString();
            }
        }


        public void SwapImages(PictureBox picture1, PictureBox picture2)
        {
            Point temp = picture1.Location;
            picture1.Location = picture2.Location;
            picture2.Location = temp;
        }


        private bool IsComplete()
        {
            for (int i = 0; i < PuzzlePieces.Length; i++)
            {
                // Proveri dali sekoe delce e na tocnata pozicija spored mesanjeto na slozuvalkata
                if (PuzzlePieces[i].Location != Locations[i])
                    return false;
            }
            return true;
        }


        private void btnEasy_Click(object sender, EventArgs e)
        {
            btnMedium.Enabled = false;
            btnHard.Enabled = false;
            btnReset.Enabled = true;
            btnAddImage.Enabled = false;

            tmrTimeElapsed.Start();
            stopwatch.Start();

            if (pbxPuzzleImage != null)
            {
                gbPuzzle.Controls.Remove(pbxPuzzleImage);
                pbxPuzzleImage.Dispose();
                pbxPuzzleImage = null;
            }

            if (pbxPuzzleImage == null)
            {
                Images = new Image[4];
                PuzzlePieces = new PictureBox[4];
                Locations = new Point[4];
            } 

            int pieceX = gbPuzzle.Width / 2;
            int pieceY = gbPuzzle.Height / 2;
            int[] tmpArray = new int[4];
            for (int i = 0; i < 4; i++)
            {
                tmpArray[i] = i;
                if (PuzzlePieces[i] == null)
                {
                    PuzzlePieces[i] = new PictureBox();
                    PuzzlePieces[i].Click +=new EventHandler(PuzzleClick);
                    PuzzlePieces[i].BorderStyle = BorderStyle.Fixed3D;
                }

                PuzzlePieces[i].Height = pieceY;
                PuzzlePieces[i].Width = pieceX;

                SliceImage(imagePuzzle, Images, i, 2, 2, pieceX, pieceY);

                PuzzlePieces[i].Location = new Point(pieceX * (i % 2), pieceY * (i / 2));
                

                if (!gbPuzzle.Controls.Contains(PuzzlePieces[i]))
                {
                    gbPuzzle.Controls.Add(PuzzlePieces[i]);
                }
            }

            Shuffle(ref tmpArray);
            for (int i = 0; i < 4; i++)
            {
                PuzzlePieces[i].Image = Images[tmpArray[i]];
                Locations[i] = PuzzlePieces[tmpArray[i]].Location;
            }
               


        }

        private void btnMedium_Click(object sender, EventArgs e)
        {
            btnEasy.Enabled = false;
            btnHard.Enabled = false;
            btnReset.Enabled = true;
            btnAddImage.Enabled = false;

            tmrTimeElapsed.Start();
            stopwatch.Start();

            if (pbxPuzzleImage != null)
            {
                gbPuzzle.Controls.Remove(pbxPuzzleImage);
                pbxPuzzleImage.Dispose();
                pbxPuzzleImage = null;
            }

            if (pbxPuzzleImage == null)
            {
                Images = new Image[16];
                PuzzlePieces = new PictureBox[16];
                Locations = new Point[16];
            }

            int pieceX = gbPuzzle.Width / 4;
            int pieceY = gbPuzzle.Height / 4;
            int[] tmpArray = new int[16];
            for (int i = 0; i < 16; i++)
            {
                tmpArray[i] = i;
                if (PuzzlePieces[i] == null)
                {
                    PuzzlePieces[i] = new PictureBox();
                    PuzzlePieces[i].Click += new EventHandler(PuzzleClick);
                    PuzzlePieces[i].BorderStyle = BorderStyle.Fixed3D;
                }

                PuzzlePieces[i].Height = pieceY;
                PuzzlePieces[i].Width = pieceX;

                SliceImage(imagePuzzle, Images, i, 4, 4, pieceX, pieceY);

                PuzzlePieces[i].Location = new Point(pieceX * (i % 4), pieceY * (i / 4));
                if (!gbPuzzle.Controls.Contains(PuzzlePieces[i]))
                {
                    gbPuzzle.Controls.Add(PuzzlePieces[i]);
                }
            }

            Shuffle(ref tmpArray);
            for (int i = 0; i < 16; i++)
            {
                PuzzlePieces[i].Image = Images[tmpArray[i]];
                Locations[i] = PuzzlePieces[tmpArray[i]].Location;
            }

        }

        private void btnHard_Click(object sender, EventArgs e)
        {
            btnMedium.Enabled = false;
            btnEasy.Enabled = false;
            btnReset.Enabled = true;
            btnAddImage.Enabled = false;

            tmrTimeElapsed.Start();
            stopwatch.Start();

            if (pbxPuzzleImage != null)
            {
                gbPuzzle.Controls.Remove(pbxPuzzleImage);
                pbxPuzzleImage.Dispose();
                pbxPuzzleImage = null;
            }

            if (pbxPuzzleImage == null)
            {
                Images = new Image[25];
                PuzzlePieces = new PictureBox[25];
                Locations = new Point[25];
            }

            int pieceX = gbPuzzle.Width / 5;
            int pieceY = gbPuzzle.Height / 5;
            int[] tmpArray = new int[25];
            for (int i = 0; i < 25; i++)
            {
                tmpArray[i] = i;
                if (PuzzlePieces[i] == null)
                {
                    PuzzlePieces[i] = new PictureBox();
                    PuzzlePieces[i].Click += new EventHandler(PuzzleClick);
                    PuzzlePieces[i].BorderStyle = BorderStyle.Fixed3D;
                }

                PuzzlePieces[i].Height = pieceY;
                PuzzlePieces[i].Width = pieceX;

                SliceImage(imagePuzzle, Images, i, 5, 5, pieceX, pieceY);

                PuzzlePieces[i].Location = new Point(pieceX * (i % 5), pieceY * (i / 5));
                if (!gbPuzzle.Controls.Contains(PuzzlePieces[i]))
                {
                    gbPuzzle.Controls.Add(PuzzlePieces[i]);
                }
            }

            Shuffle(ref tmpArray);
            for (int i = 0; i < 25; i++)
            {
                PuzzlePieces[i].Image = Images[tmpArray[i]];
                Locations[i] = PuzzlePieces[tmpArray[i]].Location;
            }

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            btnMedium.Enabled = false;
            btnHard.Enabled = false;
            btnEasy.Enabled = false;
            btnAddImage.Enabled = true;

            DialogResult YesOrNo = new DialogResult();
            if (lblTimer.Text != "00:00:00")
            {
                YesOrNo = MessageBox.Show("Are You Sure ?", "Bubble Puzzle", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }

            if (YesOrNo == DialogResult.Yes || lblTimer.Text == "00:00:00")
            {
                // Izbrisi ja slikata Final
                if (pbxFinalImage != null)
                {
                    gbImage.Controls.Remove(pbxFinalImage);
                    pbxFinalImage.Dispose();
                    pbxFinalImage = null;
                }

                // Izbrisi gi slikata Puzzle, ili malite Sliki delchinja na Puzzle, vo zavisnost sto ima vo leviot gbPuzzle
                if (pbxPuzzleImage != null)
                {
                    gbPuzzle.Controls.Remove(pbxPuzzleImage);
                    pbxPuzzleImage.Dispose();
                    pbxPuzzleImage = null;
                }
                else
                {

                    for (int i = 0; i < PuzzlePieces.Length; i++)
                    {
                        gbPuzzle.Controls.Remove(PuzzlePieces[i]);
                        PuzzlePieces[i] = null;
                    }
                    PuzzlePieces = null;
                }
                // Resetiraj go tajmerot i displeite za vreme i cekori
                stopwatch.Reset();
                lblTimer.Text = "00:00:00";
                numberOfMoves = 0;
                lblMoves.Text = "0";
            }

        }

        private void Win ()
        {
            stopwatch.Stop();

            DialogResult drOK = new DialogResult();
            drOK = MessageBox.Show("Puzzle Solved !!", "Bubble Puzzle", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
           

            if (drOK == DialogResult.OK)
            {
                // Izbrisi ja slikata Final
                if (pbxFinalImage != null)
                {
                    gbImage.Controls.Remove(pbxFinalImage);
                    pbxFinalImage.Dispose();
                    pbxFinalImage = null;
                }

                // Izbrisi gi slikata Puzzle, ili malite Sliki delchinja na Puzzle, vo zavisnost sto ima vo leviot gbPuzzle
                if (pbxPuzzleImage != null)
                {
                    gbPuzzle.Controls.Remove(pbxPuzzleImage);
                    pbxPuzzleImage.Dispose();
                    pbxPuzzleImage = null;
                }
                else
                {

                    for (int i = 0; i < PuzzlePieces.Length; i++)
                    {
                        gbPuzzle.Controls.Remove(PuzzlePieces[i]);
                        PuzzlePieces[i] = null;
                    }
                    PuzzlePieces = null;
                }

                //Iskluci gi site kopcinja osven toa za doavanje nova slika
                btnMedium.Enabled = false;
                btnHard.Enabled = false;
                btnEasy.Enabled = false;
                btnReset.Enabled = false;
                btnAddImage.Enabled = true;

                // Resetiraj go tajmerot i displeite za vreme i cekori
                stopwatch.Reset();
                lblTimer.Text = "00:00:00";
                numberOfMoves = 0;
                lblMoves.Text = "0";
            }

        }

        private void frmBubblePuzzle_Load(object sender, EventArgs e)
        {

        }

        private void tmrTimeElapsed_Tick(object sender, EventArgs e)
        {
            if (stopwatch.Elapsed.ToString() != "00:00:00")
                lblTimer.Text = stopwatch.Elapsed.ToString().Remove(8);
        }

        
    }
}

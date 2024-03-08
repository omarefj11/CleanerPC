using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
        int nLeftRect, // x-coordinate of upper-left corner
        int nTopRect, // y-coordinate of upper-left corner
        int nRightRect, // x-coordinate of lower-right corner
        int nBottomRect, // y-coordinate of lower-right corner
        int nWidthEllipse, // height of ellipse
        int nHeightEllipse // width of ellipse
        );
        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;

            //poner bordes
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            btnCerrar.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, btnCerrar.Width, btnCerrar.Height, 20, 20));
            btnMaximizar.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, btnMaximizar.Width, btnMaximizar.Height, 20, 20));
            btnMinimizar.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, btnMinimizar.Width, btnMinimizar.Height, 20, 20));
            btnEliminarArch.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, btnEliminarArch.Width, btnEliminarArch.Height, 20, 20));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
        }

        private void btnEliminarArch_Click(object sender, EventArgs e)
        {
            

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }

        private void cbxPrefetch_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxPrefetch.Checked == true)
            {
                DialogResult respuesta = MessageBox.Show("Tipo de almacenamiento recomendado:\n" +
                    "SSD: Recomendable\n" +
                    "HHD: No recomendable ya que podria influir en el rencimiento de la PC", "Tips", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (respuesta == DialogResult.Cancel)
                {
                    cbxPrefetch.Checked = false;
                }
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            cbxDesc.Checked = true;
            cbxTempUser.Checked = true;
            cbxTempWin.Checked = true;
        }

        private void btnEliminarArch_Click_1(object sender, EventArgs e)
        {
            FuncOptimizar Optim = new FuncOptimizar();

            //eliminar temporales de windows
            if (cbxTempWin.Checked == true)
            {
                Optim.TempWin();
            }

            //eliminar temporales del usuario
            if (cbxTempUser.Checked == true)
            {
                Optim.TempUser();
            }

            //Borrar prefetch
            if (cbxPrefetch.Checked == true)
            {
                Optim.OptiPrefetch();
            }

            //borrar descargas
            if (cbxDesc.Checked == true)
            {
                Optim.OptiDowl();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;
        }
    }
}

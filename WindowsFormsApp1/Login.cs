using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Login : Form
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
        public Login()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            btnLCerrar.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, btnLCerrar.Width, btnLCerrar.Height, 20, 20));
            pnlLogin.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, pnlLogin.Width, pnlLogin.Height, 20, 20));
            pnlRegister.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, pnlRegister.Width, pnlRegister.Height, 20, 20));
            ptbProfile.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, ptbProfile.Width, ptbProfile.Height, 20, 20));
            pnlIlogin.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, pnlIlogin.Width, pnlIlogin.Height, 20, 20));
            btnLogin.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, btnLogin.Width, btnLogin.Height, 20, 20));
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void Login_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void label4_Click(object sender, EventArgs e)
        {
            pnlRegister.BackColor = Color.FromArgb(110, 104, 228);
            pnlLogin.BackColor = Color.FromArgb(44, 54, 57);
        }

        private void txtEmail_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text == "Email")
            {
                txtEmail.Text = null;
            }
            if (txtPassword.Text == null || txtPassword.Text == "")
            {
                txtPassword.Text = "Password";
                txtPassword.PasswordChar = '\0';
            }
            
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {     
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPassword_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Password")
            {
                txtPassword.Text = null;
                txtPassword.PasswordChar = '*';
            }
            if (txtEmail.Text == null || txtEmail.Text == "")
            {
                txtEmail.Text = "Email";
            }
            
            
        }
    }
}

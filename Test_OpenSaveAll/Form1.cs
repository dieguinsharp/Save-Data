/* 
* Created by: Distek ///
* Dev: Diego Soares ///
* Programa fruto de aprendizagem ///
* e lógica de programação em c# /// 
* Criptografia usada: AES ///
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;

namespace Test_OpenSaveAll
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int cont, cont2, cont4, contOpen2, y;
        int cont3 = 1;
        int contOpen = 1;
        string result1 = "";
        string[] email = new string[999];
        string[] senha = new string[999];
        string[] celular = new string[999];
        string[] anotacao = new string[999];
        string[] site = new string[999];
        GroupBox[] caixa = new GroupBox[999];
        Button[] btnEmail = new Button[999];
        Button[] btnSenha = new Button[999];
        Button[] btnCelular = new Button[999];
        Button[] btnAnotacoes = new Button[999];
        Button[] btnSite = new Button[999];
        Button[] btnVer = new Button[999];
        Button[] btnCripto = new Button[999];
        private TextBox[] txtCripto = new TextBox[999];
        TextBox[] txtSenha = new TextBox[999];
        TextBox[] txtEmail = new TextBox[999];
        TextBox[] txtCelular = new TextBox[999];
        TextBox[] txtAnotacoes = new TextBox[999];
        TextBox[] txtSite = new TextBox[999];
        

       public void btnAbrir_Click(object sender, EventArgs e)
       {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Title = "Localizar Arquivos";
            openFileDialog1.DefaultExt = "dstk";
            openFileDialog1.Filter = "Dstk files(*.dstk)|*.dstk|All files (*.*)|*.*";
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.CheckPathExists = true;
            string local;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                cont2 = 1;
                local = Path.GetDirectoryName(openFileDialog1.FileName) + @"\" + Path.GetFileName(openFileDialog1.FileName);
                int numeroLinhas = System.IO.File.ReadAllLines(local).Length;
                StreamReader sr = new StreamReader(openFileDialog1.FileName);
                string[] txt = sr.ReadToEnd().Split('|');
                while (numeroLinhas >= contOpen)
                {         
                        email[contOpen] = txt[contOpen2].Split('|')[0];
                        contOpen2 = contOpen2 + 1;
                        senha[contOpen] = txt[contOpen2].Split('|')[0];
                        contOpen2 = contOpen2 + 1;
                        celular[contOpen] = txt[contOpen2].Split('|')[0];
                        contOpen2 = contOpen2 + 1;
                        anotacao[contOpen] = txt[contOpen2].Split('|')[0];
                        contOpen2 = contOpen2 + 1;
                        site[contOpen] = txt[contOpen2].Split('|')[0];
                        contOpen2 = contOpen2 + 1;
                        contOpen = contOpen + 1;              
                }
                sr.Close();
                open_1();
                contOpen2 = 1;
                contOpen = 1;
            }
            else if (openFileDialog1.ShowDialog() != DialogResult.OK)
            {
                MessageBox.Show("Algo de errado aconteceu!", "Distek", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
       }
        public void btnCript_Click(object sender, EventArgs e)
        {
            if (btnCript.BackColor == Color.DimGray)
            {
                MessageBox.Show("Cuidado, criptografar o texto já criptografado pode gerar erros futuros!", "Security AES", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                btnDecrypt.BackColor = Color.Gray;
                btnCript.BackColor = Color.DimGray;
            }          
            for (int n = 1; n <= cont; n++)
            {
                if (txtEmail[n].Text == "")
                {
                    txtEmail[n].Text = "...";
                }
                if (txtSenha[n].Text == "")
                {
                    txtSenha[n].Text = "...";
                }
                if (txtCelular[n].Text == "")
                {
                    txtCelular[n].Text = "...";
                }
                if (txtAnotacoes[n].Text == "")
                {
                    txtAnotacoes[n].Text = "...";
                }
                if (txtSite[n].Text == "")
                {
                    txtSite[n].Text = "...";
                }
            }
            if (MessageBox.Show("Deseja usar (" + txtCripto[1].Text + ") como sua senha de segurança? (Você deverá memoriza-lá para poder visualizar seus dados quando precisar!", "Security AES", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                EncryptData(txtCripto[1].Text);
            }
            else if (DialogResult == DialogResult.Cancel)
            {
                MessageBox.Show("Por favor, digite uma senha de criptografia válida!", "Security AES");
            }
        }
        public void open_1()
        {
            int open_2 = 1;
            while (open_2 <= cont)
                {
                    caixa[open_2].Controls.Clear();
                    this.Controls.Remove(caixa[open_2]);
                    open_2 = open_2 + 1;
                }
            contOpen = contOpen - 1;
            cont = 0;
            y = 40;
            cont4 = 1;
            while (contOpen >= cont4)
            {
                caixa[cont4] = new GroupBox();
                caixa[cont4].Location = new Point(12, y);
                caixa[cont4].Text = "Caixa de Dados:";
                caixa[cont4].FlatStyle = FlatStyle.Flat;
                caixa[cont4].BackColor = Color.Transparent;
                caixa[cont4].ForeColor = Color.White;
                caixa[cont4].Font = btnCriar.Font;
                caixa[cont4].AutoSize = false;
                caixa[cont4].Size = new Size(460, 195);
                caixa[cont4].Visible = true;
                Controls.Add(caixa[cont4]);
                y = y + 200;

                btnEmail[cont4] = new Button();
                btnEmail[cont4].Location = new Point(6, 19);
                btnEmail[cont4].Text = "E-mail:";
                btnEmail[cont4].BackColor = Color.Gray;
                btnEmail[cont4].FlatStyle = FlatStyle.Flat;
                btnEmail[cont4].AutoSize = false;
                btnEmail[cont4].Size = new Size(75, 23);
                btnEmail[cont4].Visible = true;
                caixa[cont4].Controls.Add(btnEmail[cont4]);

                btnSenha[cont4] = new Button();
                btnSenha[cont4].Location = new Point(6, 48);
                btnSenha[cont4].Text = "Senha:";
                btnSenha[cont4].FlatStyle = FlatStyle.Flat;
                btnSenha[cont4].BackColor = Color.Gray;
                btnSenha[cont4].AutoSize = false;
                btnSenha[cont4].Size = new Size(75, 23);
                btnSenha[cont4].Visible = true;
                caixa[cont4].Controls.Add(btnSenha[cont4]);

                btnCelular[cont4] = new Button();
                btnCelular[cont4].Location = new Point(6, 77);
                btnCelular[cont4].Text = "Celular:";
                btnCelular[cont4].FlatStyle = FlatStyle.Flat;
                btnCelular[cont4].BackColor = Color.Gray;
                btnCelular[cont4].AutoSize = false;
                btnCelular[cont4].Size = new Size(75, 23);
                btnCelular[cont4].Visible = true;
                caixa[cont4].Controls.Add(btnCelular[cont4]);

                btnAnotacoes[cont4] = new Button();
                btnAnotacoes[cont4].Location = new Point(6, 106);
                btnAnotacoes[cont4].Text = "Anotações:";
                btnAnotacoes[cont4].FlatStyle = FlatStyle.Flat;
                btnAnotacoes[cont4].BackColor = Color.Gray;
                btnAnotacoes[cont4].AutoSize = false;
                btnAnotacoes[cont4].Size = new Size(75, 23);
                btnAnotacoes[cont4].Visible = true;
                caixa[cont4].Controls.Add(btnAnotacoes[cont4]);

                btnSite[cont4] = new Button();
                btnSite[cont4].Location = new Point(6, 136);
                btnSite[cont4].Text = "Site:";
                btnSite[cont4].FlatStyle = FlatStyle.Flat;
                btnSite[cont4].AutoSize = false;
                btnSite[cont4].BackColor = Color.Gray;
                btnSite[cont4].Size = new Size(75, 23);
                btnSite[cont4].Visible = true;
                caixa[cont4].Controls.Add(btnSite[cont4]);

                btnCripto[cont4] = new Button();
                btnCripto[cont4].Location = new Point(6, 165);
                btnCripto[cont4].Text = "Senha p/ Criptografar/Descriptografar";
                btnCripto[cont4].BackColor = Color.Gray;
                btnCripto[cont4].FlatStyle = FlatStyle.Flat;
                btnCripto[cont4].AutoSize = false;
                btnCripto[cont4].Size = new Size(233, 23);
                btnCripto[cont4].Visible = true;
                caixa[cont4].Controls.Add(btnCripto[cont4]);

                btnVer[cont4] = new Button();
                btnVer[cont4].Location = new Point(410, 165);
                btnVer[cont4].Text = "Ver";
                btnVer[cont4].BackColor = Color.Gray;
                btnVer[cont4].ForeColor = Color.Black;
                btnVer[cont4].FlatStyle = FlatStyle.Flat;
                btnVer[cont4].AutoSize = false;
                btnVer[cont4].FlatAppearance.BorderColor = Color.White;
                btnVer[cont4].FlatAppearance.BorderSize = 1;
                btnVer[cont4].Size = new Size(43, 23);
                btnVer[cont4].Visible = true;               
                btnVer[cont4].Click += new EventHandler(clickVer_Click);
                btnVer[cont4].Cursor = Cursors.Hand;
                caixa[cont4].Controls.Add(btnVer[cont4]);

                txtEmail[cont4] = new TextBox();
                txtEmail[cont4].Size = new Size(365, 20);
                txtEmail[cont4].Location = new Point(87, 21);
                txtEmail[cont4].BackColor = SystemColors.Control;
                txtEmail[cont4].Text = email[cont4];
                caixa[cont4].Controls.Add(txtEmail[cont4]);

                txtSenha[cont4] = new TextBox();
                txtSenha[cont4].Size = new Size(365, 20);
                txtSenha[cont4].Location = new Point(87, 51);
                txtSenha[cont4].BackColor = SystemColors.Control;
                txtSenha[cont4].Text = senha[cont4];
                caixa[cont4].Controls.Add(txtSenha[cont4]);

                txtCelular[cont4] = new TextBox();
                txtCelular[cont4].Size = new Size(365, 20);
                txtCelular[cont4].Location = new Point(87, 79);
                txtCelular[cont4].BackColor = SystemColors.Control;
                txtCelular[cont4].Text = celular[cont4];
                caixa[cont4].Controls.Add(txtCelular[cont4]);

                txtAnotacoes[cont4] = new TextBox();
                txtAnotacoes[cont4].Size = new Size(365, 20);
                txtAnotacoes[cont4].Location = new Point(87, 108);
                txtAnotacoes[cont4].BackColor = SystemColors.Control;
                txtAnotacoes[cont4].Text = anotacao[cont4];
                caixa[cont4].Controls.Add(txtAnotacoes[cont4]);

                txtSite[cont4] = new TextBox();
                txtSite[cont4].Size = new Size(365, 20);
                txtSite[cont4].Location = new Point(87, 138);
                txtSite[cont4].BackColor = SystemColors.Control;
                txtSite[cont4].Text = site[cont4];
                caixa[cont4].Controls.Add(txtSite[cont4]);

                txtCripto[cont4] = new TextBox();
                txtCripto[cont4].Size = new Size(159, 20);
                txtCripto[cont4].Location = new Point(245, 167);
                txtCripto[cont4].PasswordChar = '*';
                txtCripto[cont4].BackColor = SystemColors.Control;
                caixa[cont4].Controls.Add(txtCripto[cont4]);

                if (cont4 == 1)
                {
                    txtCripto[cont4].Text = "#bG%6&(";
                }
                else
                {
                    txtCripto[cont4].Enabled = false;
                    btnVer[cont4].Enabled = false;
                    btnCripto[cont4].Size = new Size(447, 23);
                    btnCripto[cont4].Text = "A mesma senha para todas as caixas de texto!";
                }

                btnEmail[cont4].Enabled = false;
                btnSenha[cont4].Enabled = false;
                btnAnotacoes[cont4].Enabled = false;
                btnCelular[cont4].Enabled = false;
                btnSite[cont4].Enabled = false;
                btnCripto[cont4].Enabled = false;

                btnCript.Enabled = true;
                btnDecrypt.Enabled = true;

                if (cont >= 4)
                {
                    this.Size = new Size(520, 686);
                }
                cont4 = cont4 + 1;              
            }
            cont = cont4 - 1;
        }
        public void button2_Click(object sender, EventArgs e)
        {

            if (cont <= 0)
            {
                MessageBox.Show("Você precisa adicionar uma caixa de dados para poder salva-los!", "Distek", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                string[] email = new string[999];
                string[] senha = new string[999];
                string[] celular = new string[999];
                string[] anotacao = new string[999];
                string[] site = new string[999];
                cont3 = 1;
                result1 = "";
                while (cont3 <= cont)
                {

                    if (txtEmail[cont3].Text == "")
                    {
                        txtEmail[cont3].Text = "...";
                    }
                    if (txtSenha[cont3].Text == "")
                    {
                        txtSenha[cont3].Text = "...";
                    }
                    if (txtCelular[cont3].Text == "")
                    {
                        txtCelular[cont3].Text = "...";
                    }
                    if (txtAnotacoes[cont3].Text == "")
                    {
                        txtAnotacoes[cont3].Text = "...";
                    }
                    if (txtSite[cont3].Text == "")
                    {
                        txtSite[cont3].Text = "...";
                    }

                    email[cont3] = txtEmail[cont3].Text;
                    senha[cont3] = txtSenha[cont3].Text;
                    celular[cont3] = txtCelular[cont3].Text;
                    anotacao[cont3] = txtAnotacoes[cont3].Text;
                    site[cont3] = txtSite[cont3].Text;

                    cont3 = cont3 + 1;
                }

                SaveFileDialog SaveFileDialog1 = new SaveFileDialog();
                SaveFileDialog1.Title = "Salvar Arquivos";
                SaveFileDialog1.DefaultExt = "dstk";
                SaveFileDialog1.Filter = "Txt files(*.dstk)|*.dstk|All files (*.*)|*.*";
                SaveFileDialog1.CheckPathExists = true;

                if (SaveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    cont2 = 1;
                    while (cont2 <= cont)
                    {
                        result1 = result1 + email[cont2].Replace('\r', '\n') + "|" + senha[cont2].Replace('\r', '\n') + "|" + celular[cont2].Replace('\r', '\n') + "|" + anotacao[cont2].Replace('\r', '\n') + "|" + site[cont2].Replace('\r', '\n') + "|" + Environment.NewLine;
                        cont2 = cont2 + 1;
                    }
                    StreamWriter sw = new StreamWriter(SaveFileDialog1.FileName);
                    StringBuilder sb = new StringBuilder();
                    sb.Append(result1);
                    sw.Write(sb.ToString());
                    sw.Close();
                    MessageBox.Show("Salvo com sucesso!", "Distek", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else if (SaveFileDialog1.ShowDialog() != DialogResult.OK)
                {
                    MessageBox.Show("Algo de errado aconteceu!", "Distek", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }         
        public void button3_Click(object sender, EventArgs e)
        {
            GetCriarCaixa();
        }
        public void GetCriarCaixa()
        {
            cont = cont + 1;

            caixa[cont] = new GroupBox();
            caixa[cont].Location = new Point(12, y);
            caixa[cont].Text = "Caixa de Dados:";
            caixa[cont].ForeColor = Color.White;
            caixa[cont].Font = btnCriar.Font;
            caixa[cont].BackColor = Color.Transparent;
            caixa[cont].FlatStyle = FlatStyle.Flat;
            caixa[cont].AutoSize = false;
            caixa[cont].Size = new Size(460, 195);
            caixa[cont].Visible = true;
            Controls.Add(caixa[cont]);
            y = y + 200;

            btnEmail[cont] = new Button();
            btnEmail[cont].Location = new Point(6, 19);
            btnEmail[cont].BackColor = Color.Gray;
            btnEmail[cont].Text = "E-mail:";
            btnEmail[cont].FlatStyle = FlatStyle.Flat;
            btnEmail[cont].AutoSize = false;
            btnEmail[cont].Size = new Size(75, 23);
            btnEmail[cont].Visible = true;
            caixa[cont].Controls.Add(btnEmail[cont]);

            btnSenha[cont] = new Button();
            btnSenha[cont].Location = new Point(6, 48);
            btnSenha[cont].Text = "Senha:";
            btnSenha[cont].BackColor = Color.Gray;
            btnSenha[cont].FlatStyle = FlatStyle.Flat;
            btnSenha[cont].AutoSize = false;
            btnSenha[cont].Size = new Size(75, 23);
            btnSenha[cont].Visible = true;
            caixa[cont].Controls.Add(btnSenha[cont]);

            btnCelular[cont] = new Button();
            btnCelular[cont].Location = new Point(6, 77);
            btnCelular[cont].Text = "Celular:";
            btnCelular[cont].BackColor = Color.Gray;
            btnCelular[cont].FlatStyle = FlatStyle.Flat;
            btnCelular[cont].AutoSize = false;
            btnCelular[cont].Size = new Size(75, 23);
            btnCelular[cont].Visible = true;
            caixa[cont].Controls.Add(btnCelular[cont]);

            btnAnotacoes[cont] = new Button();
            btnAnotacoes[cont].Location = new Point(6, 106);
            btnAnotacoes[cont].Text = "Anotações:";
            btnAnotacoes[cont].BackColor = Color.Gray;
            btnAnotacoes[cont].FlatStyle = FlatStyle.Flat;
            btnAnotacoes[cont].AutoSize = false;
            btnAnotacoes[cont].Size = new Size(75, 23);
            btnAnotacoes[cont].Visible = true;
            caixa[cont].Controls.Add(btnAnotacoes[cont]);

            btnSite[cont] = new Button();
            btnSite[cont].Location = new Point(6, 136);
            btnSite[cont].Text = "Site:";
            btnSite[cont].FlatStyle = FlatStyle.Flat;
            btnSite[cont].BackColor = Color.Gray;
            btnSite[cont].AutoSize = false;
            btnSite[cont].Size = new Size(75, 23);
            btnSite[cont].Visible = true;
            caixa[cont].Controls.Add(btnSite[cont]);

            btnCripto[cont] = new Button();
            btnCripto[cont].Location = new Point(6, 165);
            btnCripto[cont].Text = "Senha p/ Criptografar/Descriptografar";
            btnCripto[cont].BackColor = Color.Gray;
            btnCripto[cont].FlatStyle = FlatStyle.Flat;
            btnCripto[cont].AutoSize = false;
            btnCripto[cont].Size = new Size(233, 23);
            btnCripto[cont].Visible = true;
            caixa[cont].Controls.Add(btnCripto[cont]);

            btnVer[cont] = new Button();
            btnVer[cont].Location = new Point(410, 165);
            btnVer[cont].Text = "Ver";
            btnVer[cont].FlatAppearance.BorderColor = Color.White;
            btnVer[cont].FlatAppearance.BorderSize = 1;
            btnVer[cont].BackColor = Color.Gray;
            btnVer[cont].ForeColor = Color.Black;
            btnVer[cont].FlatStyle = FlatStyle.Flat;
            btnVer[cont].AutoSize = false;
            btnVer[cont].Size = new Size(43, 23);
            btnVer[cont].Visible = true;
            caixa[cont].Controls.Add(btnVer[cont]);
            btnVer[cont].Click += new EventHandler(clickVer_Click);
            btnVer[cont].Cursor = Cursors.Hand;

            txtEmail[cont] = new TextBox();
            txtEmail[cont].Size = new Size(365, 20);
            txtEmail[cont].Location = new Point(87, 21);
            txtEmail[cont].BackColor = SystemColors.Control;
            caixa[cont].Controls.Add(txtEmail[cont]);

            txtSenha[cont] = new TextBox();
            txtSenha[cont].Size = new Size(365, 20);
            txtSenha[cont].Location = new Point(87, 51);
            txtSenha[cont].BackColor = SystemColors.Control;
            caixa[cont].Controls.Add(txtSenha[cont]);

            txtCelular[cont] = new TextBox();
            txtCelular[cont].Size = new Size(365, 20);
            txtCelular[cont].Location = new Point(87, 79);
            txtCelular[cont].BackColor = SystemColors.Control;
            caixa[cont].Controls.Add(txtCelular[cont]);

            txtAnotacoes[cont] = new TextBox();
            txtAnotacoes[cont].Size = new Size(365, 20);
            txtAnotacoes[cont].Location = new Point(87, 108);
            txtAnotacoes[cont].BackColor = SystemColors.Control;
            caixa[cont].Controls.Add(txtAnotacoes[cont]);

            txtSite[cont] = new TextBox();
            txtSite[cont].Size = new Size(365, 20);
            txtSite[cont].Location = new Point(87, 138);
            txtSite[cont].BackColor = SystemColors.Control;
            caixa[cont].Controls.Add(txtSite[cont]);

            txtCripto[cont] = new TextBox();
            txtCripto[cont].Size = new Size(159, 20);
            txtCripto[cont].Location = new Point(245, 167);
            txtCripto[cont].PasswordChar = '*';
            txtCripto[cont].BackColor = SystemColors.Control;
            caixa[cont].Controls.Add(txtCripto[cont]);          

            if (cont == 1)
            {
                txtCripto[cont].Text = "#bG%6&(";
            }
            else
            {
                txtCripto[cont].Enabled = false;
                btnVer[cont].Enabled = false;
                btnCripto[cont].Size = new Size(447, 23);
                btnCripto[cont].Text = "A mesma senha para todas as caixas de texto!";
            }

            btnEmail[cont].Enabled = false;
            btnSenha[cont].Enabled = false;
            btnAnotacoes[cont].Enabled = false;
            btnCelular[cont].Enabled = false;
            btnSite[cont].Enabled = false;
            btnCripto[cont].Enabled = false;

            btnCript.Enabled = true;
            btnDecrypt.Enabled = true;

            if (cont >= 4)
            {
                this.Size = new Size(520, 686);
            }
            

        }
        int cont7 = 0;
        public void clickVer_Click(object sender, EventArgs e)
        {
            
            if (cont7%2 == 1)
            {
                txtCripto[1].PasswordChar = '*';
                cont7 = cont7 + 1;
            }
            else
            {
                txtCripto[1].PasswordChar = '\u0000';
                cont7 = cont7 + 1;
            }
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            if (btnDecrypt.BackColor == Color.DimGray)
            {
                MessageBox.Show("Cuidado, descriptografar o mesmo texto já descriptografado pode gerar erros futuros!", "Security AES", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                btnDecrypt.BackColor = Color.DimGray;
                btnCript.BackColor = Color.Gray;
            }
            if (MessageBox.Show("Deseja usar (" + txtCripto[1].Text + ") como sua senha de segurança?", "Security AES", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                Decrypt(txtCripto[1].Text);
            }
            else if (DialogResult == DialogResult.Cancel)
            {
                MessageBox.Show("Por favor, digite sua senha caso queira desembaralhar seus dados!", "Security AES");
            }
        }

        public void Form1_Load(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja conhecer o criador do Security Files?", "Security Files", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                System.Diagnostics.Process.Start("https://www.facebook.com/MWStek");
            }
            y = 40;
            btnCript.Enabled = false;
            btnDecrypt.Enabled = false;
        }
        public byte[] DataToDecrypt;
        public int contDecryptALL;
        public void Decrypt(dynamic pass)
        {
            int contDecrypt;
            contDecryptALL = 1;
            while (contDecryptALL <= cont)
            {
                contDecrypt = 1;
                while (contDecrypt == 1)
                {
                    byte[] Results;
                    System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();
                    MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
                    byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(pass));
                    TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();
                    TDESAlgorithm.Key = TDESKey;
                    TDESAlgorithm.Mode = CipherMode.ECB;
                    TDESAlgorithm.Padding = PaddingMode.PKCS7;
                    try
                    {
                        DataToDecrypt = Convert.FromBase64String(txtEmail[contDecryptALL].Text);
                    }
                    catch(FormatException)
                    {
                        if (contDecryptALL == 1)
                        {
                            MessageBox.Show("Formato de texto inválido para desembaralhar! Tente novamente!", "Distek", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }                    
                    }
                    finally
                    {
                    try
                    {
                        ICryptoTransform Decryptor = TDESAlgorithm.CreateDecryptor();
                        Results = Decryptor.TransformFinalBlock(DataToDecrypt, 0, DataToDecrypt.Length);
                        txtEmail[contDecryptALL].Text = UTF8.GetString(Results);
                    }
                    catch(CryptographicException)
                    {
                            if (contDecryptALL == 1)
                            {
                                MessageBox.Show("Senha de criptografia incorreta!", "Security AES");                                 
                            }
                        }
                    catch(NullReferenceException)
                        {

                        }
                    finally
                    {
                        TDESAlgorithm.Clear();
                        HashProvider.Clear();
                    } 
                    }
                                 
                    contDecrypt = contDecrypt + 1;
                }
                contDecrypt = 1;
                while (contDecrypt == 1)
                {
                    byte[] Results;
                    System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();
                    MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
                    byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(pass));
                    TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();
                    TDESAlgorithm.Key = TDESKey;
                    TDESAlgorithm.Mode = CipherMode.ECB;
                    TDESAlgorithm.Padding = PaddingMode.PKCS7;
                    try
                    {
                        DataToDecrypt = Convert.FromBase64String(txtSenha[contDecryptALL].Text);
                    }
                    catch (FormatException)
                    {
                    }
                    finally
                    {
                        try
                        {
                            ICryptoTransform Decryptor = TDESAlgorithm.CreateDecryptor();
                            Results = Decryptor.TransformFinalBlock(DataToDecrypt, 0, DataToDecrypt.Length);
                            txtSenha[contDecryptALL].Text = UTF8.GetString(Results);
                        }
                        catch (CryptographicException)
                        {
                        }
                        catch (NullReferenceException)
                        {
                        }
                        finally
                        {
                            TDESAlgorithm.Clear();
                            HashProvider.Clear();
                        }
                    }

                    contDecrypt = contDecrypt + 1;
                }
                contDecrypt = 1;
                while (contDecrypt == 1)
                {
                    byte[] Results;
                    System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();
                    MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
                    byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(pass));
                    TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();
                    TDESAlgorithm.Key = TDESKey;
                    TDESAlgorithm.Mode = CipherMode.ECB;
                    TDESAlgorithm.Padding = PaddingMode.PKCS7;
                    try
                    {
                        DataToDecrypt = Convert.FromBase64String(txtCelular[contDecryptALL].Text);
                    }
                    catch (FormatException)
                    {
                    }
                    finally
                    {
                        try
                        {
                            ICryptoTransform Decryptor = TDESAlgorithm.CreateDecryptor();
                            Results = Decryptor.TransformFinalBlock(DataToDecrypt, 0, DataToDecrypt.Length);
                            txtCelular[contDecryptALL].Text = UTF8.GetString(Results);
                        }
                        catch (CryptographicException)
                        {
                        }
                        catch (NullReferenceException)
                        {
                        }
                        finally
                        {
                            TDESAlgorithm.Clear();
                            HashProvider.Clear();
                        }
                    }

                    contDecrypt = contDecrypt + 1;
                }
                contDecrypt = 1;
                while (contDecrypt == 1)
                {
                    byte[] Results;
                    System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();
                    MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
                    byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(pass));
                    TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();
                    TDESAlgorithm.Key = TDESKey;
                    TDESAlgorithm.Mode = CipherMode.ECB;
                    TDESAlgorithm.Padding = PaddingMode.PKCS7;
                    try
                    {
                        DataToDecrypt = Convert.FromBase64String(txtSite[contDecryptALL].Text);
                    }
                    catch (FormatException)
                    {
                    }
                    finally
                    {
                        try
                        {
                            ICryptoTransform Decryptor = TDESAlgorithm.CreateDecryptor();
                            Results = Decryptor.TransformFinalBlock(DataToDecrypt, 0, DataToDecrypt.Length);
                            txtSite[contDecryptALL].Text = UTF8.GetString(Results);
                        }
                        catch (CryptographicException)
                        {
                        }
                        catch (NullReferenceException)
                        {
                        }
                        finally
                        {
                            TDESAlgorithm.Clear();
                            HashProvider.Clear();
                        }
                    }

                    contDecrypt = contDecrypt + 1;
                }
                contDecrypt = 1;
                while (contDecrypt == 1)
                {
                    byte[] Results;
                    System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();
                    MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
                    byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(pass));
                    TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();
                    TDESAlgorithm.Key = TDESKey;
                    TDESAlgorithm.Mode = CipherMode.ECB;
                    TDESAlgorithm.Padding = PaddingMode.PKCS7;
                    try
                    {
                        DataToDecrypt = Convert.FromBase64String(txtAnotacoes[contDecryptALL].Text);
                    }
                    catch (FormatException)
                    {
                        txtEmail[contDecryptALL].Text = "Error :(";
                        txtSenha[contDecryptALL].Text = "Error :(";
                        txtCelular[contDecryptALL].Text = "Error :(";
                        txtSite[contDecryptALL].Text = "Error :(";
                        txtAnotacoes[contDecryptALL].Text = "Error :(";
                    }
                    finally
                    {
                        try
                        {
                            ICryptoTransform Decryptor = TDESAlgorithm.CreateDecryptor();
                            Results = Decryptor.TransformFinalBlock(DataToDecrypt, 0, DataToDecrypt.Length);
                            txtAnotacoes[contDecryptALL].Text = UTF8.GetString(Results);
                        }
                        catch (CryptographicException)
                        {
                        }
                        catch (NullReferenceException)
                        {
                        }
                        finally
                        {
                            TDESAlgorithm.Clear();
                            HashProvider.Clear();
                        }
                    }
                    contDecrypt = contDecrypt + 1;
                }
                contDecryptALL = contDecryptALL + 1;
                contDecrypt = 1;
            }
            contDecrypt = 1;
            contDecryptALL = 1;
        }
        public int contCript, contCriptALL = 1;
        public void EncryptData(dynamic pass)
        {
           
            while (contCriptALL <= cont)
            {
                contCript = 1;
                while (contCript == 1)
                {
                    byte[] Results;
                    System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();
                    MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
                    byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(pass));
                    TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();
                    TDESAlgorithm.Key = TDESKey;
                    TDESAlgorithm.Mode = CipherMode.ECB;
                    TDESAlgorithm.Padding = PaddingMode.PKCS7;
                    byte[] DataToEncrypt = UTF8.GetBytes(txtEmail[contCriptALL].Text);
                    try
                    {
                        ICryptoTransform Encryptor = TDESAlgorithm.CreateEncryptor();
                        Results = Encryptor.TransformFinalBlock(DataToEncrypt, 0, DataToEncrypt.Length);
                        txtEmail[contCriptALL].Text = Convert.ToBase64String(Results);
                    }
                    catch (CryptographicException)
                    {
                        if (contCriptALL == 1)
                        {
                            MessageBox.Show("Algo de errado aconteceu! Reinicie o aplicativo.", "Security AES");
                        }                        
                    }
                    finally
                    {
                        TDESAlgorithm.Clear();
                        HashProvider.Clear();
                    }
                    
                    contCript = contCript + 1;
                }
                contCript = 1;
                while (contCript == 1)
                {
                    byte[] Results;
                    System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();
                    MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
                    byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(pass));
                    TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();
                    TDESAlgorithm.Key = TDESKey;
                    TDESAlgorithm.Mode = CipherMode.ECB;
                    TDESAlgorithm.Padding = PaddingMode.PKCS7;
                    byte[] DataToEncrypt = UTF8.GetBytes(txtSenha[contCriptALL].Text);
                    try
                    {
                        ICryptoTransform Encryptor = TDESAlgorithm.CreateEncryptor();
                        Results = Encryptor.TransformFinalBlock(DataToEncrypt, 0, DataToEncrypt.Length);
                        txtSenha[contCriptALL].Text = Convert.ToBase64String(Results);
                    }
                    catch (CryptographicException)
                    {
                    }
                    finally
                    {
                        TDESAlgorithm.Clear();
                        HashProvider.Clear();
                    }
                    
                    contCript = contCript + 1;
                }
                contCript = 1;
                while (contCript == 1)
                {
                    byte[] Results;
                    System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();
                    MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
                    byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(pass));
                    TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();
                    TDESAlgorithm.Key = TDESKey;
                    TDESAlgorithm.Mode = CipherMode.ECB;
                    TDESAlgorithm.Padding = PaddingMode.PKCS7;
                    byte[] DataToEncrypt = UTF8.GetBytes(txtCelular[contCriptALL].Text);
                    try
                    {
                        ICryptoTransform Encryptor = TDESAlgorithm.CreateEncryptor();
                        Results = Encryptor.TransformFinalBlock(DataToEncrypt, 0, DataToEncrypt.Length);
                        txtCelular[contCriptALL].Text = Convert.ToBase64String(Results);
                    }
                    catch (CryptographicException)
                    {
                    }
                    finally
                    {
                        TDESAlgorithm.Clear();
                        HashProvider.Clear();
                    }
                    
                    contCript = contCript + 1;
                }
                contCript = 1;
                while (contCript == 1)
                {
                    byte[] Results;
                    System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();
                    MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
                    byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(pass));
                    TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();
                    TDESAlgorithm.Key = TDESKey;
                    TDESAlgorithm.Mode = CipherMode.ECB;
                    TDESAlgorithm.Padding = PaddingMode.PKCS7;
                    byte[] DataToEncrypt = UTF8.GetBytes(txtSite[contCriptALL].Text);
                    try
                    {
                        ICryptoTransform Encryptor = TDESAlgorithm.CreateEncryptor();
                        Results = Encryptor.TransformFinalBlock(DataToEncrypt, 0, DataToEncrypt.Length);
                        txtSite[contCriptALL].Text = Convert.ToBase64String(Results);
                    }
                    catch (CryptographicException)
                    {
                    }
                    finally
                    {
                        TDESAlgorithm.Clear();
                        HashProvider.Clear();
                    }
                    
                    contCript = contCript + 1;
                }
                contCript = 1;
                while (contCript == 1)
                {
                    byte[] Results;
                    System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();
                    MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
                    byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(pass));
                    TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();
                    TDESAlgorithm.Key = TDESKey;
                    TDESAlgorithm.Mode = CipherMode.ECB;
                    TDESAlgorithm.Padding = PaddingMode.PKCS7;
                    byte[] DataToEncrypt = UTF8.GetBytes(txtAnotacoes[contCriptALL].Text);
                    try
                    {
                        ICryptoTransform Encryptor = TDESAlgorithm.CreateEncryptor();
                        Results = Encryptor.TransformFinalBlock(DataToEncrypt, 0, DataToEncrypt.Length);
                        txtAnotacoes[contCriptALL].Text = Convert.ToBase64String(Results);
                    }
                    catch (CryptographicException)
                    {
                    }
                    finally
                    {
                        TDESAlgorithm.Clear();
                        HashProvider.Clear();
                    }
                    
                    contCript = contCript + 1;
                }
                contCriptALL = contCriptALL + 1;
                contCript = 1;
            }
            contCript = 1;
            contCriptALL = 1;
        }
    }
}
 
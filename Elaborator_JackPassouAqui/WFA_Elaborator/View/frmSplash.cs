using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFA_tcc
{
    public partial class Form1 : Form
    {
        Model.ConectaBD classe = new Model.ConectaBD();

        public Form1()
        {
            InitializeComponent();
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {
            
        }

        private void tmrsplash_Tick(object sender, EventArgs e)
        {
            
        }

        private void progress(object sender, EventArgs e)
        {
            // Valor a ser incrementado na barra de progresso por cada tempo.
            progressBar1.PerformStep();
            // Verifica se barra de progresso está completa
            //Verifica valor atual se é igual ao valor maximo.

            if (progressBar1.Value == progressBar1.Maximum)
            {
                // Para o timer.
                tmrsplash.Stop();
                //this.Hide();
                this.Dispose();
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tmrsplash.Tick += new EventHandler(progress);
            progressBar1.Minimum = 0;
            progressBar1.Maximum = tmrsplash.Interval;
            progressBar1.Value = 1;
            progressBar1.Step = 1;

            if (classe.verificaBD())
            {
                tmrsplash.Interval = 30;
                //MessageBox.Show("tem BD");
                tmrsplash.Start();
            }
            else
            {
                tmrsplash.Stop();
                DialogResult resultado = MessageBox.Show("Erro na conexão com o Banco de Dados. Banco de Dados inexistente!\nDeseja criá-lo?", "Verificação de Banco de Dados", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (resultado == DialogResult.Yes)
                {
                    pcbImage1.Visible = true;
                    tmrsplash.Interval = 100;
                    classe.criaBD();
                    tmrsplash.Start();
                }
                else if (resultado == DialogResult.No)
                {
                    progressBar1.Value = 0;
                    this.Close();
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
    }
    


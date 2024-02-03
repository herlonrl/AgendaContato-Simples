using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgendaWF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //DALAgenda.path = "alterar caminho do banco de dados";
            DALAgenda.CriarBancoSQLite();
            DALAgenda.CriarTabelaSQLite();
            ExibirDados();
            lbDados.Text = DALAgenda.path;
        }

        private void ExibirDados()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = DALAgenda.GetContatos();
                dgvDados.DataSource = dt;
            }
            catch (Exception ex)
            {

                MessageBox.Show("ERROR:" + ex.Message);
            }
        }

        private void btInserir_Click(object sender, EventArgs e)
        {
            try
            {
                Contato contato = new Contato();
                contato.Id = Convert.ToInt32(txtId.Text);
                contato.Nome = txtNome.Text;
                contato.Email = txtEmail.Text;

                DALAgenda.Add(contato);
                ExibirDados();

                txtId.Clear();
                txtNome.Clear();
                txtEmail.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR:" + ex.Message);
            }
        }

        private void btAlterar_Click(object sender, EventArgs e)
        {
            try
            {
                Contato contato = new Contato();
                contato.Id = Convert.ToInt32(txtId.Text);
                contato.Nome = txtNome.Text;
                contato.Email = txtEmail.Text;

                DALAgenda.Update(contato);
                ExibirDados();

                txtId.Clear();
                txtNome.Clear();
                txtEmail.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR:" + ex.Message);
            }
        }

        private void btExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(txtId.Text);
                DALAgenda.Delete(id);
                ExibirDados();

                txtId.Clear();
                txtNome.Clear();
                txtEmail.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR:" + ex.Message);
            }
        }

        private void btLocalizar_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                if (txtId.Text != "")
                {
                    int id = Convert.ToInt32(txtId.Text);
                    dt = DALAgenda.GetContato(id);
                }else
                {
                    string nome = txtNome.Text;
                    dt = DALAgenda.GetContatos(nome);
                }
                dgvDados.DataSource = dt;

                txtId.Clear();
                txtNome.Clear();
                txtEmail.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR:" + ex.Message);
            }
        }
    }
}

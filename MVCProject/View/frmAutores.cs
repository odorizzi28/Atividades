using MVCProject.View.Adicionar;
using MVCProject.View.Edicao;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MVCProject.View
{
    public partial class frmAutores : Form
    {
        public frmAutores()
        {
            InitializeComponent();
        }

        private void FrmAdutores_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'baseDeDadosBibliotecaDataSet.Autores' table. You can move, or remove it, as needed.
            this.autoresTableAdapter1.Fill(this.baseDeDadosBibliotecaDataSet.Autores);
            // TODO: This line of code loads data into the 'sistemaBibliotecaDBDataSet.Autores' table. You can move, or remove it, as needed.
            //this.autoresTableAdapter.Fill(this.sistemaBibliotecaDBDataSet.Autores);

        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var AutorSel = ((System.Data.DataRowView)
            this.dataGridView1.Rows[e.RowIndex].DataBoundItem).Row
            as MVCProject.BaseDeDadosBibliotecaDataSet.AutoresRow;

            switch (e.ColumnIndex)
            {
                case 0:
                    {
                        frmEdicaoAutor addAutor = new frmEdicaoAutor();
                        addAutor.autoresRow = AutorSel;
                        addAutor.ShowDialog();
                      
                        this.autoresTableAdapter1.Update (addAutor.autoresRow);
                    }
                    break;
                
            }
            this.autoresTableAdapter1.Fill(this.baseDeDadosBibliotecaDataSet.Autores);


        }

        private void Button1_Click(object sender, EventArgs e)
        {
            frmAdicionarAutores addAutores = new frmAdicionarAutores();
            addAutores.ShowDialog();

            this.autoresTableAdapter1.Insert( addAutores.autor.Nome,addAutores.autor.Descricao);

            this.autoresTableAdapter1.Fill(this.baseDeDadosBibliotecaDataSet.Autores);
        }
    }
}

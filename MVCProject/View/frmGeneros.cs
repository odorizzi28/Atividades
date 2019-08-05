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
    public partial class frmGeneros : Form
    {
        public frmGeneros()
        {
            InitializeComponent();
        }

        private void FrmGeneros_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'baseDeDadosBibliotecaDataSet.Generos' table. You can move, or remove it, as needed.
            this.generosTableAdapter1.Fill(this.baseDeDadosBibliotecaDataSet.Generos);
            // TODO: This line of code loads data into the 'sistemaBibliotecaDBDataSet.Generos' table. You can move, or remove it, as needed.
            //this.generosTableAdapter.Fill(this.sistemaBibliotecaDBDataSet.Generos);

        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var Genero = ((System.Data.DataRowView)
            this.dataGridView1.Rows[e.RowIndex].DataBoundItem).Row
            as MVCProject.BaseDeDadosBibliotecaDataSet.GenerosRow;

            switch (e.ColumnIndex)
            {
                case 0:
                    {
                        frmEdicaoGenero addGenero = new frmEdicaoGenero();
                        addGenero.generorow = Genero;
                        addGenero.ShowDialog();

                        this.generosTableAdapter1.Update(addGenero.generorow);
                    }
                    break;

            }
            this.generosTableAdapter1.Fill(this.baseDeDadosBibliotecaDataSet.Generos);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            frmAdicionarGeneros addGenero = new frmAdicionarGeneros();
            addGenero.ShowDialog();

            this.generosTableAdapter1.Insert(addGenero.genero.Tipo, addGenero.genero.Descricao);

            this.generosTableAdapter1.Fill(this.baseDeDadosBibliotecaDataSet.Generos);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExpensesTracker.DAO;

namespace ExpensesTracker.UI
{
    public partial class CategoryForm : Form
    {
        private ICategoryDAO CategoryDAO;

        public CategoryForm()
        {
            InitializeComponent();
            CategoryDAO = new CategoryDAOImpl();
        }

        private void CategoryForm_Load(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void LoadGrid()
        {
            dataGridView1.Rows.Clear();
            foreach(var category in CategoryDAO.GetAll())
            {
                dataGridView1.Rows.Add(category.GetId(),category.GetName(),category.GetCatType() , "Edit" , "Delete");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 4)
            {
                CategoryDAO.Delete(int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString()));
                LoadGrid();
            }
        }
    }
}

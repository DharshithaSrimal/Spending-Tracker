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
using ExpensesTracker.Models;
namespace ExpensesTracker.UI
{
    public partial class CategoryForm : Form
    {
        private ICategoryDAO CategoryDAO;
        private Category TempCategory;

        public CategoryForm()
        {
            InitializeComponent();
            CategoryDAO = new CategoryDAOImpl();
        }

        private void CategoryForm_Load(object sender, EventArgs e)
        {
            LoadGrid();
            TempCategory = new Category();
        }

        private void LoadGrid()
        {
            dataGridView1.Rows.Clear();
            foreach(var category in CategoryDAO.GetAll())
            {
                dataGridView1.Rows.Add(category.GetId(),category.GetName(),category.GetCatType());
            }
        }

        private void LoadGridWithSearch(string text)
        {
            dataGridView1.Rows.Clear();
            foreach (var category in CategoryDAO.Search(text))
            {
                dataGridView1.Rows.Add(category.GetId(), category.GetName(), category.GetCatType());
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            TempCategory = new Category();
            txtName.Clear();
            txtType.Clear();
            txtName.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            TempCategory.SetName(txtName.Text);
            TempCategory.SetCatType(txtType.Text);  

            if(TempCategory.GetId() == 0)
            {
                var response = CategoryDAO.Insert(TempCategory);
                if(response == "SUCCESS")
                {
                    MessageBox.Show("Category Saved.","Success",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    txtName.Clear();
                    txtType.Clear();
                    LoadGrid();
                    TempCategory = new Category();
                }
                else
                {
                    MessageBox.Show(response,"Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                var response = CategoryDAO.Update(TempCategory);
                if (response == "SUCCESS")
                {
                    MessageBox.Show("Category Updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtName.Clear();
                    txtType.Clear();
                    LoadGrid();
                    TempCategory = new Category();
                }
                else
                {
                    MessageBox.Show(response, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a row first", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var response = CategoryDAO.Delete(int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString()));
                if (response == "SUCCESS")
                {
                    MessageBox.Show("Category Deleted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadGrid();
                }
                else
                {
                    MessageBox.Show(response, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a row first", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                TempCategory = CategoryDAO.GetById(int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString()));
                txtName.Text = TempCategory.GetName();
                txtType.Text = TempCategory.GetCatType();
            }
        }

        private void txtSearch_MouseClick(object sender, MouseEventArgs e)
        {
            if(txtSearch.Text == "Enter to Search")
            {
                txtSearch.Clear();
            }
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtSearch.Text))
            {
                txtSearch.Text = "Enter to Search";
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if(txtSearch.Text == "Enter to Search")
            {
                return;
            }
            else if(string.IsNullOrEmpty(txtSearch.Text))
            {
                LoadGrid();
            }
            else
            {
                LoadGridWithSearch(txtSearch.Text);
            }
        }
    }
}

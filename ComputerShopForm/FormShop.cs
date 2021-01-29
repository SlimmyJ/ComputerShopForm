﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;


namespace ComputerShopForm
{
    public partial class FormShop : Form
    {
        private IProductsRepo _repo;
        private IShoppingCart _cart;
        private IList<UserControlShop> _controls;

        public FormShop()
        {
            InitializeComponent();
            _repo = new ProductsRepo();
            _cart = ShoppingCart.GetShoppingCart();
            _controls = new List<UserControlShop>();

            var products = _repo.CreateProductList();
            GenerateProductControls(products);
        }

        private void GenerateProductControls(IEnumerable<IProduct> products)
        {
            foreach (IProduct product in products)
            {
                UserControlShop usercontrol = new UserControlShop
                {
                    ProductName = product.Name,
                    ProductPrice = product.Price,
                    ProductImagePath = product.ProductImagePath,
                    Id = product.Id,
                };
                
                usercontrol.AddToCartButtonClicked += AddToCartClickedInUserControl;
                _controls.Add(usercontrol);
            }
            flowLayoutPanel1.Controls.AddRange( _controls.ToArray());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormShoppingCart cart = new FormShoppingCart();
            cart.Show();
        }

        private void AddToCartClickedInUserControl(object sender, EventArgs e)
        {
            var userControl = sender as UserControlShop;
            var product = _repo.GetProduct(userControl.ProductName);
            _cart.AddProductToCart(product);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (UserControlShop control in flowLayoutPanel1.Controls)
            {
                if (control.ProductName == "HP Oblivion III")
                {
                    control.Visible = false;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (UserControlShop control in flowLayoutPanel1.Controls)
            {
                control.Visible = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            foreach (UserControlShop control in flowLayoutPanel1.Controls)
            {
                control.Visible = false;
                string prodname = control.ProductName.ToLower();
                string input = textBox1.Text.ToLower();
                if (prodname.Contains(input))
                {
                    control.Visible = true;
                }
            }
            //var selectedControls = _controls.Where(x => x.ProductName.ToLower() == textBox1.Text.ToLower()).Select(y => y.Visible = true).ToList();
            //_controls.Where(x => x.ProductName.ToLower() == textBox1.Text.ToLower()).Select(y=>y.Visible=true);

        }
    }
}
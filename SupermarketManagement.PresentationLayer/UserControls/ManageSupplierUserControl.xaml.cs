using SupermarketManagement.BLL.Business;
using SupermarketManagement.BLL.IBusiness;
using SupermarketManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Supermarketmanagement.PresentationLayer.UserControls
{
    /// <summary>
    /// Interaction logic for ManageSupplierUserControl.xaml
    /// </summary>
    public partial class ManageSupplierUserControl : UserControl
    {
        private ISupplierBusiness _supplierBusiness;
        private ListSupplierUserControl _listSupplierUserControl;
        private List<Supplier> suppliers;
        public ManageSupplierUserControl()
        {
            InitializeComponent();
            _supplierBusiness = new SupplierBusiness();
            suppliers = _supplierBusiness.GetAll();
            InitializeData();
        }

        /// <summary>
        /// List the methods needed for data initialization
        /// </summary>
        private void InitializeData()
        {

            DisplayList();
            DisplayAdd();
            
        }

        private void DisplayAdd()
        {
            AddSupplierUserControl addSupplierUserControl = new AddSupplierUserControl();
            FormSupplier.Children.Clear();
            FormSupplier.Children.Add(addSupplierUserControl);
        }

        private void DisplayList()
        {
            _listSupplierUserControl = new ListSupplierUserControl();
            ListSupplier.Children.Add(_listSupplierUserControl);
            
        }



        //private void DisplayDetail(Supplier supplier)
        //{
        //    DetailSupplierUserControl detailSupplierUserControl = new DetailSupplierUserControl(supplier);
        //    FormSupplier.Children.Clear();
        //    FormSupplier.Children.Add(detailSupplierUserControl);
        //}


    }
}

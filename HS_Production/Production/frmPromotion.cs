using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FIL.Production
{
    public partial class frmPromotion : Form
    {
        PromotionManager managePromotion = new PromotionManager();
        SalesOrderManager manageSalesOrder = new SalesOrderManager();
        ProductManager manageProduct = new ProductManager();
        WarehouseManager managewarehouse = new WarehouseManager();
        DataSet dset = new DataSet();
        int PromotionId = -1;
        DataRow drMaster;
        bool IsPromotionLoad = false;
        Smartworks.DAL dataAcess = new Smartworks.DAL();

        public frmPromotion()
        {
            InitializeComponent();
        }

        private void frmPromotion_Load(object sender, EventArgs e)
        {
            ButtonRights(true);
            FillDropdown();
            //setGridSetup();
            txtCode.Text = GetNewNextNumber();
            btnNextInvioceNo.Enabled = false;
            btnPrevInvioceNo.Enabled = false;
        }

        #region Methods
        private void ButtonRights(bool Enable)
        {
            btnAdd.Enabled = Enable;
            btnUpdate.Enabled = !Enable;
            btnDelete.Enabled = !Enable;
            txtCode.ReadOnly = !Enable;
            //btnCSearch.Enabled = Enable;
            //txtCustomerCode.Enabled = Enable;
        }

        private void FillDropdown()
        {
            DataTable dtGrade = manageSalesOrder.GetGradeList();
            if (dtGrade.Rows.Count > 0)
            {
                cmbGrade.DataSource = dtGrade;
                cmbGrade.DisplayMember = "Grade";
                cmbGrade.ValueMember = "GradeId";
                cmbGrade.SelectedValue = 2; // yani B 
            }

            DataTable dtFWarehouse = new DataTable();
            dtFWarehouse = managewarehouse.GetWarehouseList();

            DataRow drFwarehouse = dtFWarehouse.NewRow();
            drFwarehouse["WarehouseId"] = -1;
            drFwarehouse["Warehouse"] = "--Select Department--";
            dtFWarehouse.Rows.InsertAt(drFwarehouse, 0);

            cmbFWarehouse.DataSource = dtFWarehouse;
            cmbFWarehouse.DisplayMember = "Warehouse";
            cmbFWarehouse.ValueMember = "WarehouseId";



            DataTable dtTWarehouse = new DataTable();
            dtTWarehouse = managewarehouse.GetWarehouseList();

            DataRow drTwarehouse = dtTWarehouse.NewRow();
            drTwarehouse["WarehouseId"] = -1;
            drTwarehouse["Warehouse"] = "--Select Department--";
            dtTWarehouse.Rows.InsertAt(drTwarehouse, 0);

            cmbTWarehouse.DataSource = dtTWarehouse;
            cmbTWarehouse.DisplayMember = "Warehouse";
            cmbTWarehouse.ValueMember = "WarehouseId";
        }
        private String GetNewNextNumber()
        {
            string NewInvoiceNo = "";
            NewInvoiceNo = managePromotion.GetMaxInvioceNo();
            if (!string.IsNullOrEmpty(NewInvoiceNo))
            {
                NewInvoiceNo = managePromotion.GetNextInvioceNo(NewInvoiceNo);
            }
            else
            {
                NewInvoiceNo = "PM-000001";
            }
            return NewInvoiceNo;
        }

        private void setGridSetup(bool IsPromotionLoaded, int TranId)
        {
            dset = new DataSet();
            if (IsPromotionLoaded)
            {

                //age koi Promotion dekh raha hu ya Edit mode per hu ya koi cheez Update kerni hai toh yeh wala structure load hoga. 
                //dono k structure same rakhy hain. lakin data ka farq hai 
                dset = managePromotion.GetPromotionStructure(TranId);
            }
            else
            {
                //agr Promotion Load hoga yani koi new entry ker raha hu ya phr koi PM load ker raha hu toh yeh wala structure aye ga .
                //dono k structure same rakhy hain. lakin data ka farq hai 
                dset = managePromotion.GetPromotionStructureBySONoAndProductCode(txtSONo.Text, manageProduct.GetProductIdByCode(txtPCode.Text));
            }

            //dset = managePromotion.GetPromotionStructure(TranId);
            dset.Tables[0].TableName = "PromotionMaster";
            dset.Tables[1].TableName = "PromotionDetail";
            dset.Tables[2].TableName = "PendingQty";


            dset.Tables["PromotionMaster"].Columns["PromotionId"].AutoIncrement = true;
            dset.Tables["PromotionMaster"].Columns["PromotionId"].AutoIncrementSeed = -1;
            dset.Tables["PromotionMaster"].Columns["PromotionId"].AutoIncrementStep = -1;

            dset.Tables["PromotionDetail"].Columns["PromotionDetailId"].AutoIncrement = true;
            dset.Tables["PromotionDetail"].Columns["PromotionDetailId"].AutoIncrementSeed = -1;
            dset.Tables["PromotionDetail"].Columns["PromotionDetailId"].AutoIncrementStep = -1;


            dset.Relations.Add("MasterRelation", dset.Tables["PromotionMaster"].Columns["PromotionId"], dset.Tables["PromotionDetail"].Columns["PromotionId"]);
            if (dset.Tables["PromotionMaster"].Rows.Count > 0)
            {
                drMaster = dset.Tables["PromotionMaster"].Rows[0];
            }
            else
            {
                drMaster = dset.Tables["PromotionMaster"].NewRow();
                dset.Tables["PromotionMaster"].Rows.Add(drMaster);
            }

            GCDetail.DataSource = dset.Tables["PromotionDetail"];
            GridSetting();
        }

        private void GridSetting()
        {
            gvDetail.Columns.ColumnByName("colPromotionDetailId").OptionsColumn.ReadOnly = true;
            gvDetail.Columns.ColumnByName("colPromotionId").OptionsColumn.ReadOnly = true;

            gvDetail.Columns.ColumnByName("colPromotionDetailId").Visible = false;
            gvDetail.Columns.ColumnByName("colPromotionId").Visible = false;

            gvDetail.Columns.ColumnByName("colS39").Caption = "S39";
            gvDetail.Columns.ColumnByName("colS40").Caption = "S40";
            gvDetail.Columns.ColumnByName("colS41").Caption = "S41";
            gvDetail.Columns.ColumnByName("colS42").Caption = "S42";
            gvDetail.Columns.ColumnByName("colS43").Caption = "S43";
            gvDetail.Columns.ColumnByName("colS44").Caption = "S44";
            gvDetail.Columns.ColumnByName("colS45").Caption = "S45";
            gvDetail.Columns.ColumnByName("colS46").Caption = "S46";
            gvDetail.Columns.ColumnByName("colS47").Caption = "S47";
            gvDetail.Columns.ColumnByName("colTotalQty").Caption = "Total Qty";


            gvDetail.Columns.ColumnByName("colTotalQty").OptionsColumn.AllowEdit = false;
            gvDetail.Columns.ColumnByName("colTotalQty").OptionsColumn.AllowFocus = false;


            gvDetail.Columns.ColumnByName("colS39").VisibleIndex = 0;
            gvDetail.Columns.ColumnByName("colS40").VisibleIndex = 1;
            gvDetail.Columns.ColumnByName("colS41").VisibleIndex = 2;
            gvDetail.Columns.ColumnByName("colS42").VisibleIndex = 3;
            gvDetail.Columns.ColumnByName("colS43").VisibleIndex = 4;
            gvDetail.Columns.ColumnByName("colS44").VisibleIndex = 5;
            gvDetail.Columns.ColumnByName("colS45").VisibleIndex = 6;
            gvDetail.Columns.ColumnByName("colS46").VisibleIndex = 7;
            gvDetail.Columns.ColumnByName("colS47").VisibleIndex = 8;
            gvDetail.Columns.ColumnByName("colTotalQty").VisibleIndex = 9;



            gvDetail.Columns.ColumnByName("colS39").Width = 40;
            gvDetail.Columns.ColumnByName("colS40").Width = 40;
            gvDetail.Columns.ColumnByName("colS41").Width = 40;
            gvDetail.Columns.ColumnByName("colS42").Width = 40;
            gvDetail.Columns.ColumnByName("colS43").Width = 40;
            gvDetail.Columns.ColumnByName("colS44").Width = 40;
            gvDetail.Columns.ColumnByName("colS45").Width = 40;
            gvDetail.Columns.ColumnByName("colS46").Width = 40;
            gvDetail.Columns.ColumnByName("colS47").Width = 40;
            gvDetail.Columns.ColumnByName("colTotalQty").Width = 80;
        }


        private void ClearFeilds()
        {
            txtCode.Text = string.Empty;
            dtp.Value = DateTime.Now;
            txtSONo.Text = string.Empty;
            txtCustomerName.Text = string.Empty;
            txtPCode.Text = string.Empty;
            txtPName.Text = string.Empty;
            txtRemarks.Text = string.Empty;
            cmbTWarehouse.SelectedValue = -1;
            cmbFWarehouse.SelectedValue = -1;
            cmbGrade.SelectedValue = 2;


            dset.Tables[0].TableName = "PromotionMaster";
            dset.Tables[1].TableName = "PromotionDetail";
            dset.Tables[2].TableName = "PendingQty";


            dset.Tables["PromotionDetail"].Rows.Clear();
            dset.Tables["PromotionMaster"].Rows.Clear();

            dset.RejectChanges();
            drMaster = dset.Tables["PromotionMaster"].NewRow();
            dset.Tables["PromotionMaster"].Rows.Add(drMaster);


            txtCode.Text = GetNewNextNumber();
            //**** for post control clear 
            btnAdd.Enabled = true;
            btnUpdate.Enabled = true;

            btnDelete.Enabled = true;


            ButtonRights(true);
            btnNextInvioceNo.Enabled = false;
            btnPrevInvioceNo.Enabled = false;
            IsPromotionLoad = false;

            //setupGrip();
            //cmbFormula.Focus();

        }


        private void LoadPromotion()
        {
            IsPromotionLoad = true;
            setGridSetup(true, PromotionId);

            txtSONo.Text = dset.Tables["PromotionMaster"].Rows[0]["SOrderNo"].ToString();
            DataTable dtProduct = new DataTable();
            dtProduct = manageProduct.GetProduct(Convert.ToInt32(dset.Tables["PromotionMaster"].Rows[0]["ProductId"]));
            if (dtProduct.Rows.Count > 0)
            {
                txtPCode.Text = dtProduct.Rows[0]["ProductCode"].ToString();
            }
            txtRemarks.Text = dset.Tables["PromotionMaster"].Rows[0]["Remarks"].ToString();
            cmbGrade.SelectedItem = dset.Tables["PromotionMaster"].Rows[0]["GradeId"].ToString();
            cmbFWarehouse.SelectedValue = dset.Tables["PromotionMaster"].Rows[0]["WarehouseFrom"].ToString();
            cmbTWarehouse.SelectedValue = dset.Tables["PromotionMaster"].Rows[0]["WarehouseTo"].ToString();
            txtCode.ReadOnly = true;

            ButtonRights(false);
            IsPromotionLoad = false;
            try
            {
                string FirstTransNo = managePromotion.GetMinInvioceNo();
                string LastTransNo = managePromotion.GetMaxInvioceNo();
                if (LastTransNo == txtCode.Text)
                {
                    btnNextInvioceNo.Enabled = false;
                }
                else
                {
                    btnNextInvioceNo.Enabled = true;
                }
                if (FirstTransNo == txtCode.Text)
                {
                    btnPrevInvioceNo.Enabled = false;
                }
                else
                {
                    btnPrevInvioceNo.Enabled = true;
                }
            }
            catch (Exception ex)
            {
            }
        }


        #endregion

        private void btnMinInvioceNo_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(managePromotion.GetMaxInvioceNo()))
            {
                txtCode.Text = managePromotion.GetMinInvioceNo();
            }

        }

        private void btnMaxInvioceNo_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(managePromotion.GetMaxInvioceNo()))
            {
                txtCode.Text = managePromotion.GetMaxInvioceNo();
            }

        }

        private void btnNextInvioceNo_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCode.Text))
            {
                string LastInvioceNo = managePromotion.GetMaxInvioceNo();
                txtCode.Text = managePromotion.GetNextInvioceNo(txtCode.Text);

                if (LastInvioceNo == txtCode.Text)
                {
                    btnNextInvioceNo.Enabled = false;
                }
                else
                {
                    btnPrevInvioceNo.Enabled = true;
                }
            }
        }

        private void btnPrevInvioceNo_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCode.Text))
            {
                string LastInvioceNo = managePromotion.GetMinInvioceNo();
                txtCode.Text = managePromotion.GetPrevInvioceNo(txtCode.Text);

                if (LastInvioceNo == txtCode.Text)
                {
                    btnPrevInvioceNo.Enabled = false;
                }
                else
                {
                    btnNextInvioceNo.Enabled = true;
                }
            }
        }

        private void btnSNo_Click(object sender, EventArgs e)
        {
            try
            {
                frmSearch search = new frmSearch();
                search.getattributes("GetSearchSalesOrders", null, "Sales Orders");
                search.ShowDialog();
                if (!string.IsNullOrEmpty(MainForm.Searched_Id))
                {
                    txtSONo.Text = MainForm.Searched_Id;
                    MainForm.Searched_Id = string.Empty;
                }

            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.Message);
            }
        }

        private void btnPSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtSONo.Text))
                {
                    MessageBox.Show("Please Select Sale Order Number.", "Sale Order is Required.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                frmSearch search = new frmSearch();
                Smartworks.ColumnField[] gSalesOrderProduct = new Smartworks.ColumnField[1];
                gSalesOrderProduct[0] = new Smartworks.ColumnField("@SaleOrderNo", txtSONo.Text);
                search.getattributes("GetProductSearchForSalesOrder", gSalesOrderProduct, "Products");
                search.ShowDialog();
                if (!string.IsNullOrEmpty(MainForm.Searched_Id))
                {
                    txtPCode.Text = MainForm.Searched_Id;
                    MainForm.Searched_Id = string.Empty;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtPCode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (IsPromotionLoad)
                {
                    return;
                }
                ProductManager manageProduct = new ProductManager();
                if (!string.IsNullOrEmpty(txtPCode.Text))
                {
                    DataTable dtProduct = new DataTable();
                    dtProduct = manageProduct.GetProduct(manageProduct.GetProductIdByCode(txtPCode.Text));
                    if (dtProduct.Rows.Count > 0)
                    {
                        txtPName.Text = dtProduct.Rows[0]["ProductName"].ToString();
                        setGridSetup(false, -1);
                    }

                }
                else
                {
                    txtPName.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtSONo_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSONo.Text))
            {
                try
                {
                    DataTable dtSOrder = manageSalesOrder.GetSaleOrderMaster(manageSalesOrder.GetSalesOrderMasterIdByCode(txtSONo.Text));
                    if (dtSOrder.Rows.Count > 0)
                    {
                        CustomerManager manageCustomer = new CustomerManager();
                        //txtPONo.Text = dtSOrder.Rows[0]["PONo"].ToString();
                        txtCustomerName.Text = manageCustomer.GetCustomer(manageCustomer.GetCustomerIdByCode(dtSOrder.Rows[0]["CustomerCode"].ToString())).Rows[0]["CustomerName"].ToString();
                    }
                }
                catch (Exception ex)
                {
                    txtCustomerName.Text = string.Empty;
                }
            }
            else
            {
                //txtCName.Text = string.Empty;
                txtPCode.Text = string.Empty;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                frmSearch search = new frmSearch();
                search.getattributes("GetSearchPromotion", null, "Promotion");
                search.ShowDialog();
                if (!string.IsNullOrEmpty(MainForm.Searched_Id))
                {
                    txtCode.Text = MainForm.Searched_Id;
                    MainForm.Searched_Id = string.Empty;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtCode_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCode.Text))
            {
                PromotionId = managePromotion.GetPromotionIdByCode(txtCode.Text);
                if (PromotionId > 0)
                {
                    LoadPromotion();
                }
            }
            else
            {
                ClearFeilds();
            }
        }

        private void gvDetail_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                DataRow dr = gvDetail.GetFocusedDataRow();
                if (dr == null)
                {
                    return;
                }

                decimal totalQty = 0;
                switch (e.Column.Name.ToString())
                {
                    case "colS39":

                        decimal S39 = 0;
                        S39 = Convert.ToDecimal(dset.Tables["PendingQty"].Rows[0]["S39"]);
                        if ((string.IsNullOrEmpty(dr["S39"].ToString()) ? 0 : Convert.ToDecimal(dr["S39"].ToString())) > S39)
                        {
                            MessageBox.Show("The Promotion Qty Should be Equal or Less Production Qty", "Invalid Quantity", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            dr["S39"] = S39;
                        }

                        break;
                    case "colS40":
                        decimal S40 = 0;
                        S40 = Convert.ToDecimal(dset.Tables["PendingQty"].Rows[0]["S40"]);
                        if ((string.IsNullOrEmpty(dr["S40"].ToString()) ? 0 : Convert.ToDecimal(dr["S40"].ToString())) > S40)
                        {
                            MessageBox.Show("The Promotion Qty Should be Equal or Less Production Qty", "Invalid Quantity", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            dr["S40"] = S40;
                        }
                        break;
                    case "colS41":
                        decimal S41 = 0;
                        S41 = Convert.ToDecimal(dset.Tables["PendingQty"].Rows[0]["S41"]);
                        if ((string.IsNullOrEmpty(dr["S41"].ToString()) ? 0 : Convert.ToDecimal(dr["S41"].ToString())) > S41)
                        {
                            MessageBox.Show("The Promotion Qty Should be Equal or Less Production Qty", "Invalid Quantity", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            dr["S41"] = S41;
                        }
                        break;

                    case "colS42":
                        decimal S42 = 0;
                        S42 = Convert.ToDecimal(dset.Tables["PendingQty"].Rows[0]["S42"]);
                        if ((string.IsNullOrEmpty(dr["S42"].ToString()) ? 0 : Convert.ToDecimal(dr["S42"].ToString())) > S42)
                        {
                            MessageBox.Show("The Promotion Qty Should be Equal or Less Production Qty", "Invalid Quantity", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            dr["S42"] = S42;
                        }
                        break;

                    case "colS43":
                        decimal S43 = 0;
                        S43 = Convert.ToDecimal(dset.Tables["PendingQty"].Rows[0]["S43"]);
                        if ((string.IsNullOrEmpty(dr["S43"].ToString()) ? 0 : Convert.ToDecimal(dr["S43"].ToString())) > S43)
                        {
                            MessageBox.Show("The Promotion Qty Should be Equal or Less Production Qty", "Invalid Quantity", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            dr["S43"] = S43;
                        }
                        break;
                    case "colS44":
                        decimal S44 = 0;
                        S44 = Convert.ToDecimal(dset.Tables["PendingQty"].Rows[0]["S44"]);
                        if ((string.IsNullOrEmpty(dr["S44"].ToString()) ? 0 : Convert.ToDecimal(dr["S44"].ToString())) > S44)
                        {
                            MessageBox.Show("The Promotion Qty Should be Equal or Less Production Qty", "Invalid Quantity", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            dr["S44"] = S44;
                        }
                        break;
                    case "colS45":
                        decimal S45 = 0;
                        S45 = Convert.ToDecimal(dset.Tables["PendingQty"].Rows[0]["S45"]);
                        if ((string.IsNullOrEmpty(dr["S45"].ToString()) ? 0 : Convert.ToDecimal(dr["S45"].ToString())) > S45)
                        {
                            MessageBox.Show("The Promotion Qty Should be Equal or Less Production Qty", "Invalid Quantity", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            dr["S45"] = S45;
                        }
                        break;
                    case "colS46":
                        decimal S46 = 0;
                        S46 = Convert.ToDecimal(dset.Tables["PendingQty"].Rows[0]["S46"]);
                        if ((string.IsNullOrEmpty(dr["S46"].ToString()) ? 0 : Convert.ToDecimal(dr["S46"].ToString())) > S46)
                        {
                            MessageBox.Show("The Promotion Qty Should be Equal or Less Production Qty", "Invalid Quantity", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            dr["S46"] = S46;
                        }
                        break;
                    case "colS47":
                        decimal S47 = 0;
                        S47 = Convert.ToDecimal(dset.Tables["PendingQty"].Rows[0]["S47"]);
                        if ((string.IsNullOrEmpty(dr["S47"].ToString()) ? 0 : Convert.ToDecimal(dr["S47"].ToString())) > S47)
                        {
                            MessageBox.Show("The Promotion Qty Should be Equal or Less Production Qty", "Invalid Quantity", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            dr["S47"] = S47;
                        }
                        break;
                }
                //decimal totalQty = 0;
                totalQty = (string.IsNullOrEmpty(dr["S39"].ToString()) ? 0 : Convert.ToDecimal(dr["S39"].ToString())) +
                    (string.IsNullOrEmpty(dr["S40"].ToString()) ? 0 : Convert.ToDecimal(dr["S40"].ToString())) +
                    (string.IsNullOrEmpty(dr["S41"].ToString()) ? 0 : Convert.ToDecimal(dr["S41"].ToString())) +
                    (string.IsNullOrEmpty(dr["S42"].ToString()) ? 0 : Convert.ToDecimal(dr["S42"].ToString())) +
                    (string.IsNullOrEmpty(dr["S43"].ToString()) ? 0 : Convert.ToDecimal(dr["S43"].ToString())) +
                    (string.IsNullOrEmpty(dr["S44"].ToString()) ? 0 : Convert.ToDecimal(dr["S44"].ToString())) +
                    (string.IsNullOrEmpty(dr["S45"].ToString()) ? 0 : Convert.ToDecimal(dr["S45"].ToString())) +
                    (string.IsNullOrEmpty(dr["S46"].ToString()) ? 0 : Convert.ToDecimal(dr["S46"].ToString())) +
                    (string.IsNullOrEmpty(dr["S47"].ToString()) ? 0 : Convert.ToDecimal(dr["S47"].ToString()));
                dr["TotalQty"] = totalQty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFeilds();
        }

        private bool Validation()
        {
            bool result = true;
            if (string.IsNullOrEmpty(txtSONo.Text))
            {
                result = false;
                MessageBox.Show("Please Select Sales Order No. Sales Order No is Required.", "Sale Order is Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return result;

            }
            if (string.IsNullOrEmpty(txtPCode.Text))
            {
                result = false;
                MessageBox.Show("Please Select Article Code. Article Code is Required.", "Article is Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return result;
            }

            if (Convert.ToInt32(cmbFWarehouse.SelectedValue) <= 0)
            {
                MessageBox.Show("Please Select From Department Name", "Department Name is Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                result = false;
                cmbFWarehouse.Focus();
                return result;
            }
            if (Convert.ToInt32(cmbTWarehouse.SelectedValue) <= 0)
            {
                MessageBox.Show("Please Select To Department Name", "Department Name is Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                result = false;
                cmbTWarehouse.Focus();
                return result;
            }

            if (dset.Tables["PromotionDetail"].Rows.Count <= 0)
            {
                result = false;
                MessageBox.Show("Promotion Detail does not Found.", "Promotion Detail is Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return result;
            }
            if ((string.IsNullOrEmpty(dset.Tables["PromotionDetail"].Rows[0]["TotalQty"].ToString()) ? 0 : Convert.ToDecimal(dset.Tables["PromotionDetail"].Rows[0]["TotalQty"])) <= 0)
            {
                result = false;
                MessageBox.Show("Promotion Detail does not Found.", "Promotion Detail is Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return result;
            }


            return result;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                try
                {
                    int ProductId = manageProduct.GetProductIdByCode(txtPCode.Text);
                    string Code = txtCode.Text;
                    dataAcess.BeginTransaction();
                    if (dataAcess.getDBCommand().Transaction == null)
                    {
                        dataAcess.SetDBTransaction();
                    }

                    DataTable dtPromotion = managePromotion.InsertPromotionMaster(dtp.Value, txtSONo.Text, ProductId, txtRemarks.Text, Convert.ToInt32(cmbGrade.SelectedValue) , Convert.ToInt32(cmbFWarehouse.SelectedValue) , Convert.ToInt32(cmbTWarehouse.SelectedValue) ,   MainForm.User_Id, DateTime.Now, "", dataAcess);
                    if (dtPromotion.Rows.Count > 0)
                    {
                        PromotionId = Convert.ToInt32(dtPromotion.Rows[0]["Id"]);
                        Code = dtPromotion.Rows[0]["Code"].ToString();
                        for (int i = 0; i < dset.Tables["PromotionDetail"].Rows.Count; i++)
                        {
                            if (dset.Tables["PromotionDetail"].Rows[i].RowState != DataRowState.Deleted)
                            {
                                int DetailId = managePromotion.InsertUpdatePromotionDetail(
                                    Convert.ToInt32(dset.Tables["PromotionDetail"].Rows[i]["PromotionDetailId"]), PromotionId,
                                    (string.IsNullOrEmpty(dset.Tables["PromotionDetail"].Rows[i]["S39"].ToString()) ? 0 : Convert.ToInt32(dset.Tables["PromotionDetail"].Rows[i]["S39"])),
                                    (string.IsNullOrEmpty(dset.Tables["PromotionDetail"].Rows[i]["S40"].ToString()) ? 0 : Convert.ToInt32(dset.Tables["PromotionDetail"].Rows[i]["S40"])),
                                    (string.IsNullOrEmpty(dset.Tables["PromotionDetail"].Rows[i]["S41"].ToString()) ? 0 : Convert.ToInt32(dset.Tables["PromotionDetail"].Rows[i]["S41"])),
                                    (string.IsNullOrEmpty(dset.Tables["PromotionDetail"].Rows[i]["S42"].ToString()) ? 0 : Convert.ToInt32(dset.Tables["PromotionDetail"].Rows[i]["S42"])),
                                    (string.IsNullOrEmpty(dset.Tables["PromotionDetail"].Rows[i]["S43"].ToString()) ? 0 : Convert.ToInt32(dset.Tables["PromotionDetail"].Rows[i]["S43"])),
                                    (string.IsNullOrEmpty(dset.Tables["PromotionDetail"].Rows[i]["S44"].ToString()) ? 0 : Convert.ToInt32(dset.Tables["PromotionDetail"].Rows[i]["S44"])),
                                    (string.IsNullOrEmpty(dset.Tables["PromotionDetail"].Rows[i]["S45"].ToString()) ? 0 : Convert.ToInt32(dset.Tables["PromotionDetail"].Rows[i]["S45"])),
                                    (string.IsNullOrEmpty(dset.Tables["PromotionDetail"].Rows[i]["S46"].ToString()) ? 0 : Convert.ToInt32(dset.Tables["PromotionDetail"].Rows[i]["S46"])),
                                    (string.IsNullOrEmpty(dset.Tables["PromotionDetail"].Rows[i]["S47"].ToString()) ? 0 : Convert.ToInt32(dset.Tables["PromotionDetail"].Rows[i]["S47"])), dataAcess
                                    );

                                int SizeId = -1;
                                //warehouse wala kaam kerna hai sab jaga 
                                //for Size 39
                                SizeId = manageProduct.GetProductSizeIdByString("39");
                                if (SizeId > 0)
                                {
                                    if (Convert.ToDecimal(dset.Tables["PromotionDetail"].Rows[i]["S39"]) > 0)
                                    {
                                        manageProduct.InsertProductLedger(ProductId, Convert.ToDateTime(dtp.Value), Code, DetailId, "O",
                                            Convert.ToDecimal(dset.Tables["PromotionDetail"].Rows[i]["S39"]), 0, 0, 0, 0, 0, MainForm.User_Id, DateTime.Now.Date, "", "", null, "Size 39 Out from Promotion", Convert.ToInt32(cmbFWarehouse.SelectedValue), SizeId, ((Convert.ToInt32(cmbGrade.SelectedValue) == 1 )? "B" : "A"), dataAcess);

                                        manageProduct.InsertProductLedger(ProductId, Convert.ToDateTime(dtp.Value), Code, DetailId ,"I",
                                                                   Convert.ToDecimal(dset.Tables["PromotionDetail"].Rows[i]["S39"]), 0, 0, 0, 0, 0, MainForm.User_Id, DateTime.Now.Date, "", "", null, "Size 39 Inn from Promotion", Convert.ToInt32(cmbTWarehouse.SelectedValue), SizeId, ((Convert.ToInt32(cmbGrade.SelectedValue) == 1) ? "A" : "B"), dataAcess);
                                    }
                                }

                                //for Size 40
                                SizeId = manageProduct.GetProductSizeIdByString("40");
                                if (SizeId > 0)
                                {
                                    if (Convert.ToDecimal(dset.Tables["PromotionDetail"].Rows[i]["S40"]) > 0)
                                    {
                                        manageProduct.InsertProductLedger(ProductId, Convert.ToDateTime(dtp.Value), Code, DetailId, "O",
                                            Convert.ToDecimal(dset.Tables["PromotionDetail"].Rows[i]["S40"]), 0, 0, 0, 0, 0, MainForm.User_Id, DateTime.Now.Date, "", "", null, "Size 40 Out from Promotion", Convert.ToInt32(cmbFWarehouse.SelectedValue) , SizeId, ((Convert.ToInt32(cmbGrade.SelectedValue) == 1) ? "B" : "A"), dataAcess);

                                        manageProduct.InsertProductLedger(ProductId, Convert.ToDateTime(dtp.Value), Code, DetailId, "I",
                                                                   Convert.ToDecimal(dset.Tables["PromotionDetail"].Rows[i]["S40"]), 0, 0, 0, 0, 0, MainForm.User_Id, DateTime.Now.Date, "", "", null, "Size 40 Inn from Promotion", Convert.ToInt32(cmbTWarehouse.SelectedValue), SizeId, ((Convert.ToInt32(cmbGrade.SelectedValue) == 1) ? "A" : "B"), dataAcess);
                                    }
                                }

                                //for Size 41
                                SizeId = manageProduct.GetProductSizeIdByString("41");
                                if (SizeId > 0)
                                {
                                    if (Convert.ToDecimal(dset.Tables["PromotionDetail"].Rows[i]["S41"]) > 0)
                                    {
                                        manageProduct.InsertProductLedger(ProductId, Convert.ToDateTime(dtp.Value), Code, DetailId, "O",
                                            Convert.ToDecimal(dset.Tables["PromotionDetail"].Rows[i]["S41"]), 0, 0, 0, 0, 0, MainForm.User_Id, DateTime.Now.Date, "", "", null, "Size 41 Out from Promotion", Convert.ToInt32(cmbFWarehouse.SelectedValue), SizeId, ((Convert.ToInt32(cmbGrade.SelectedValue) == 1) ? "B" : "A"), dataAcess);

                                        manageProduct.InsertProductLedger(ProductId, Convert.ToDateTime(dtp.Value), Code, DetailId, "I",
                                                                   Convert.ToDecimal(dset.Tables["PromotionDetail"].Rows[i]["S41"]), 0, 0, 0, 0, 0, MainForm.User_Id, DateTime.Now.Date, "", "", null, "Size 41 Inn from Promotion", Convert.ToInt32(cmbTWarehouse.SelectedValue), SizeId, ((Convert.ToInt32(cmbGrade.SelectedValue) == 1) ? "A" : "B"), dataAcess);
                                    }
                                }

                                //for Size 42
                                SizeId = manageProduct.GetProductSizeIdByString("42");
                                if (SizeId > 0)
                                {
                                    if (Convert.ToDecimal(dset.Tables["PromotionDetail"].Rows[i]["S42"]) > 0)
                                    {
                                        manageProduct.InsertProductLedger(ProductId, Convert.ToDateTime(dtp.Value), Code, DetailId, "O",
                                           Convert.ToDecimal(dset.Tables["PromotionDetail"].Rows[i]["S42"]), 0, 0, 0, 0, 0, MainForm.User_Id, DateTime.Now.Date, "", "", null, "Size 42 Out from Promotion", Convert.ToInt32(cmbFWarehouse.SelectedValue), SizeId, ((Convert.ToInt32(cmbGrade.SelectedValue) == 1) ? "B" : "A"), dataAcess);

                                        manageProduct.InsertProductLedger(ProductId, Convert.ToDateTime(dtp.Value), Code, DetailId, "I",
                                                                   Convert.ToDecimal(dset.Tables["PromotionDetail"].Rows[i]["S42"]), 0, 0, 0, 0, 0, MainForm.User_Id, DateTime.Now.Date, "", "", null, "Size 42 Inn from Promotion", Convert.ToInt32(cmbTWarehouse.SelectedValue), SizeId, ((Convert.ToInt32(cmbGrade.SelectedValue) == 1) ? "A" : "B"), dataAcess);
                                    }
                                }


                                //for Size 43
                                SizeId = manageProduct.GetProductSizeIdByString("43");
                                if (SizeId > 0)
                                {
                                    if (Convert.ToDecimal(dset.Tables["PromotionDetail"].Rows[i]["S43"]) > 0)
                                    {
                                        manageProduct.InsertProductLedger(ProductId, Convert.ToDateTime(dtp.Value), Code, DetailId, "O",
                                           Convert.ToDecimal(dset.Tables["PromotionDetail"].Rows[i]["S43"]), 0, 0, 0, 0, 0, MainForm.User_Id, DateTime.Now.Date, "", "", null, "Size 43 Out from Promotion", Convert.ToInt32(cmbFWarehouse.SelectedValue), SizeId, ((Convert.ToInt32(cmbGrade.SelectedValue) == 1) ? "B" : "A"), dataAcess);

                                        manageProduct.InsertProductLedger(ProductId, Convert.ToDateTime(dtp.Value), Code, DetailId, "I",
                                                                   Convert.ToDecimal(dset.Tables["PromotionDetail"].Rows[i]["S43"]), 0, 0, 0, 0, 0, MainForm.User_Id, DateTime.Now.Date, "", "", null, "Size 43 Inn from Promotion", Convert.ToInt32(cmbTWarehouse.SelectedValue), SizeId, ((Convert.ToInt32(cmbGrade.SelectedValue) == 1) ? "A" : "B"), dataAcess);
                                    }
                                }

                                //for Size 44
                                SizeId = manageProduct.GetProductSizeIdByString("44");
                                if (SizeId > 0)
                                {
                                    if (Convert.ToDecimal(dset.Tables["PromotionDetail"].Rows[i]["S44"]) > 0)
                                    {
                                        manageProduct.InsertProductLedger(ProductId, Convert.ToDateTime(dtp.Value), Code, DetailId, "O",
                                           Convert.ToDecimal(dset.Tables["PromotionDetail"].Rows[i]["S44"]), 0, 0, 0, 0, 0, MainForm.User_Id, DateTime.Now.Date, "", "", null, "Size 44 Out from Promotion", Convert.ToInt32(cmbFWarehouse.SelectedValue), SizeId, ((Convert.ToInt32(cmbGrade.SelectedValue) == 1) ? "B" : "A"), dataAcess);

                                        manageProduct.InsertProductLedger(ProductId, Convert.ToDateTime(dtp.Value), Code, DetailId, "I",
                                                                   Convert.ToDecimal(dset.Tables["PromotionDetail"].Rows[i]["S44"]), 0, 0, 0, 0, 0, MainForm.User_Id, DateTime.Now.Date, "", "", null, "Size 44 Inn from Promotion", Convert.ToInt32(cmbTWarehouse.SelectedValue), SizeId, ((Convert.ToInt32(cmbGrade.SelectedValue) == 1) ? "A" : "B"), dataAcess);
                                    }
                                }

                                //for Size 45
                                SizeId = manageProduct.GetProductSizeIdByString("45");
                                if (SizeId > 0)
                                {
                                    if (Convert.ToDecimal(dset.Tables["PromotionDetail"].Rows[i]["S45"]) > 0)
                                    {
                                        manageProduct.InsertProductLedger(ProductId, Convert.ToDateTime(dtp.Value), Code, DetailId, "O",
                                           Convert.ToDecimal(dset.Tables["PromotionDetail"].Rows[i]["S45"]), 0, 0, 0, 0, 0, MainForm.User_Id, DateTime.Now.Date, "", "", null, "Size 45 Out from Promotion", Convert.ToInt32(cmbFWarehouse.SelectedValue), SizeId, ((Convert.ToInt32(cmbGrade.SelectedValue) == 1) ? "B" : "A"), dataAcess);

                                        manageProduct.InsertProductLedger(ProductId, Convert.ToDateTime(dtp.Value), Code, DetailId, "I",
                                                                   Convert.ToDecimal(dset.Tables["PromotionDetail"].Rows[i]["S45"]), 0, 0, 0, 0, 0, MainForm.User_Id, DateTime.Now.Date, "", "", null, "Size 45 Inn from Promotion", Convert.ToInt32(cmbTWarehouse.SelectedValue), SizeId, ((Convert.ToInt32(cmbGrade.SelectedValue) == 1) ? "A" : "B"), dataAcess);
                                    }
                                }


                                //for Size 46
                                SizeId = manageProduct.GetProductSizeIdByString("46");
                                if (SizeId > 0)
                                {
                                    if (Convert.ToDecimal(dset.Tables["PromotionDetail"].Rows[i]["S46"]) > 0)
                                    {
                                        manageProduct.InsertProductLedger(ProductId, Convert.ToDateTime(dtp.Value), Code, DetailId, "O",
                                            Convert.ToDecimal(dset.Tables["PromotionDetail"].Rows[i]["S46"]), 0, 0, 0, 0, 0, MainForm.User_Id, DateTime.Now.Date, "", "", null, "Size 46 Out from Promotion", Convert.ToInt32(cmbFWarehouse.SelectedValue), SizeId, ((Convert.ToInt32(cmbGrade.SelectedValue) == 1) ? "B" : "A"), dataAcess);

                                        manageProduct.InsertProductLedger(ProductId, Convert.ToDateTime(dtp.Value), Code, DetailId, "I",
                                                                   Convert.ToDecimal(dset.Tables["PromotionDetail"].Rows[i]["S46"]), 0, 0, 0, 0, 0, MainForm.User_Id, DateTime.Now.Date, "", "", null, "Size 46 Inn from Promotion", Convert.ToInt32(cmbTWarehouse.SelectedValue), SizeId, ((Convert.ToInt32(cmbGrade.SelectedValue) == 1) ? "A" : "B"), dataAcess);
                                    }
                                }

                                //for Size 47
                                SizeId = manageProduct.GetProductSizeIdByString("47");
                                if (SizeId > 0)
                                {
                                    if (Convert.ToDecimal(dset.Tables["PromotionDetail"].Rows[i]["S47"]) > 0)
                                    {
                                        manageProduct.InsertProductLedger(ProductId, Convert.ToDateTime(dtp.Value), Code, DetailId, "O",
                                           Convert.ToDecimal(dset.Tables["PromotionDetail"].Rows[i]["S47"]), 0, 0, 0, 0, 0, MainForm.User_Id, DateTime.Now.Date, "", "", null, "Size 47 Out from Promotion", Convert.ToInt32(cmbFWarehouse.SelectedValue), SizeId, ((Convert.ToInt32(cmbGrade.SelectedValue) == 1) ? "B" : "A"), dataAcess);

                                        manageProduct.InsertProductLedger(ProductId, Convert.ToDateTime(dtp.Value), Code, DetailId, "I",
                                                                   Convert.ToDecimal(dset.Tables["PromotionDetail"].Rows[i]["S47"]), 0, 0, 0, 0, 0, MainForm.User_Id, DateTime.Now.Date, "", "", null, "Size 47 Inn from Promotion", Convert.ToInt32(cmbTWarehouse.SelectedValue), SizeId, ((Convert.ToInt32(cmbGrade.SelectedValue) == 1) ? "A" : "B"), dataAcess);
                                    }
                                }
                            }
                        }

                    }
                    else
                    {
                        throw new Exception("Data does not Insert.");
                    }
                    dataAcess.TransCommit();
                    MessageBox.Show("Promotion Data Insert Sucessfully..", "Record Inserted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearFeilds();
                }
                catch (SqlException sqlex)
                {
                    dataAcess.TransRollback();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    dataAcess.ConnectionClose();
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                try
                {
                    int ProductId = manageProduct.GetProductIdByCode(txtPCode.Text);
                    string Code = txtCode.Text;

                    dataAcess.BeginTransaction();
                    if (dataAcess.getDBCommand().Transaction == null)
                    {
                        dataAcess.SetDBTransaction();
                    }
                    PromotionId = managePromotion.UpdatePromotionMaster(PromotionId, dtp.Value, txtSONo.Text, ProductId, txtRemarks.Text, Convert.ToInt32(cmbGrade.SelectedValue), Convert.ToInt32(cmbFWarehouse.SelectedValue) , Convert.ToInt32(cmbTWarehouse.SelectedValue) , MainForm.User_Id, DateTime.Now, "", dataAcess);
                    manageProduct.DeleteProductLedgerByTransNo(txtCode.Text, dataAcess);
                   
                    if (PromotionId > 0)
                    {   
                        for (int i = 0; i < dset.Tables["PromotionDetail"].Rows.Count; i++)
                        {
                            if (dset.Tables["PromotionDetail"].Rows[i].RowState != DataRowState.Deleted)
                            {
                                int DetailId = managePromotion.InsertUpdatePromotionDetail(
                                    Convert.ToInt32(dset.Tables["PromotionDetail"].Rows[i]["PromotionDetailId"]), PromotionId,
                                    (string.IsNullOrEmpty(dset.Tables["PromotionDetail"].Rows[i]["S39"].ToString()) ? 0 : Convert.ToInt32(dset.Tables["PromotionDetail"].Rows[i]["S39"])),
                                    (string.IsNullOrEmpty(dset.Tables["PromotionDetail"].Rows[i]["S40"].ToString()) ? 0 : Convert.ToInt32(dset.Tables["PromotionDetail"].Rows[i]["S40"])),
                                    (string.IsNullOrEmpty(dset.Tables["PromotionDetail"].Rows[i]["S41"].ToString()) ? 0 : Convert.ToInt32(dset.Tables["PromotionDetail"].Rows[i]["S41"])),
                                    (string.IsNullOrEmpty(dset.Tables["PromotionDetail"].Rows[i]["S42"].ToString()) ? 0 : Convert.ToInt32(dset.Tables["PromotionDetail"].Rows[i]["S42"])),
                                    (string.IsNullOrEmpty(dset.Tables["PromotionDetail"].Rows[i]["S43"].ToString()) ? 0 : Convert.ToInt32(dset.Tables["PromotionDetail"].Rows[i]["S43"])),
                                    (string.IsNullOrEmpty(dset.Tables["PromotionDetail"].Rows[i]["S44"].ToString()) ? 0 : Convert.ToInt32(dset.Tables["PromotionDetail"].Rows[i]["S44"])),
                                    (string.IsNullOrEmpty(dset.Tables["PromotionDetail"].Rows[i]["S45"].ToString()) ? 0 : Convert.ToInt32(dset.Tables["PromotionDetail"].Rows[i]["S45"])),
                                    (string.IsNullOrEmpty(dset.Tables["PromotionDetail"].Rows[i]["S46"].ToString()) ? 0 : Convert.ToInt32(dset.Tables["PromotionDetail"].Rows[i]["S46"])),
                                    (string.IsNullOrEmpty(dset.Tables["PromotionDetail"].Rows[i]["S47"].ToString()) ? 0 : Convert.ToInt32(dset.Tables["PromotionDetail"].Rows[i]["S47"])), dataAcess
                                    );

                                int SizeId = -1;
                                //warehouse wala kaam kerna hai sab jaga 
                                //for Size 39
                                SizeId = manageProduct.GetProductSizeIdByString("39");
                                if (SizeId > 0)
                                {
                                    if (Convert.ToDecimal(dset.Tables["PromotionDetail"].Rows[i]["S39"]) > 0)
                                    {
                                        manageProduct.InsertProductLedger(ProductId, Convert.ToDateTime(dtp.Value), Code, DetailId, "O",
                                            Convert.ToDecimal(dset.Tables["PromotionDetail"].Rows[i]["S39"]), 0, 0, 0, 0, 0, MainForm.User_Id, DateTime.Now.Date, "", "", null, "Size 39 Out from Promotion", -1, SizeId, ((Convert.ToInt32(cmbGrade.SelectedValue) == 1) ? "B" : "A"), dataAcess);

                                        manageProduct.InsertProductLedger(ProductId, Convert.ToDateTime(dtp.Value), Code, DetailId, "I",
                                                                   Convert.ToDecimal(dset.Tables["PromotionDetail"].Rows[i]["S39"]), 0, 0, 0, 0, 0, MainForm.User_Id, DateTime.Now.Date, "", "", null, "Size 39 Inn from Promotion", -1, SizeId, ((Convert.ToInt32(cmbGrade.SelectedValue) == 1) ? "A" : "B"), dataAcess);
                                    }
                                }

                                //for Size 40
                                SizeId = manageProduct.GetProductSizeIdByString("40");
                                if (SizeId > 0)
                                {
                                    if (Convert.ToDecimal(dset.Tables["PromotionDetail"].Rows[i]["S40"]) > 0)
                                    {
                                        manageProduct.InsertProductLedger(ProductId, Convert.ToDateTime(dtp.Value), Code, DetailId, "O",
                                            Convert.ToDecimal(dset.Tables["PromotionDetail"].Rows[i]["S40"]), 0, 0, 0, 0, 0, MainForm.User_Id, DateTime.Now.Date, "", "", null, "Size 40 Out from Promotion", -1, SizeId, ((Convert.ToInt32(cmbGrade.SelectedValue) == 1) ? "B" : "A"), dataAcess);

                                        manageProduct.InsertProductLedger(ProductId, Convert.ToDateTime(dtp.Value), Code, DetailId, "I",
                                                                   Convert.ToDecimal(dset.Tables["PromotionDetail"].Rows[i]["S40"]), 0, 0, 0, 0, 0, MainForm.User_Id, DateTime.Now.Date, "", "", null, "Size 40 Inn from Promotion", -1, SizeId, ((Convert.ToInt32(cmbGrade.SelectedValue) == 1) ? "A" : "B"), dataAcess);
                                    }
                                }

                                //for Size 41
                                SizeId = manageProduct.GetProductSizeIdByString("41");
                                if (SizeId > 0)
                                {
                                    if (Convert.ToDecimal(dset.Tables["PromotionDetail"].Rows[i]["S41"]) > 0)
                                    {
                                        manageProduct.InsertProductLedger(ProductId, Convert.ToDateTime(dtp.Value), Code, DetailId, "O",
                                            Convert.ToDecimal(dset.Tables["PromotionDetail"].Rows[i]["S41"]), 0, 0, 0, 0, 0, MainForm.User_Id, DateTime.Now.Date, "", "", null, "Size 41 Out from Promotion", -1, SizeId, ((Convert.ToInt32(cmbGrade.SelectedValue) == 1) ? "B" : "A"), dataAcess);

                                        manageProduct.InsertProductLedger(ProductId, Convert.ToDateTime(dtp.Value), Code, DetailId, "I",
                                                                   Convert.ToDecimal(dset.Tables["PromotionDetail"].Rows[i]["S41"]), 0, 0, 0, 0, 0, MainForm.User_Id, DateTime.Now.Date, "", "", null, "Size 41 Inn from Promotion", -1, SizeId, ((Convert.ToInt32(cmbGrade.SelectedValue) == 1) ? "A" : "B"), dataAcess);
                                    }
                                }

                                //for Size 42
                                SizeId = manageProduct.GetProductSizeIdByString("42");
                                if (SizeId > 0)
                                {
                                    if (Convert.ToDecimal(dset.Tables["PromotionDetail"].Rows[i]["S42"]) > 0)
                                    {
                                        manageProduct.InsertProductLedger(ProductId, Convert.ToDateTime(dtp.Value), Code, DetailId, "O",
                                           Convert.ToDecimal(dset.Tables["PromotionDetail"].Rows[i]["S42"]), 0, 0, 0, 0, 0, MainForm.User_Id, DateTime.Now.Date, "", "", null, "Size 42 Out from Promotion", -1, SizeId, ((Convert.ToInt32(cmbGrade.SelectedValue) == 1) ? "B" : "A"), dataAcess);

                                        manageProduct.InsertProductLedger(ProductId, Convert.ToDateTime(dtp.Value), Code, DetailId, "I",
                                                                   Convert.ToDecimal(dset.Tables["PromotionDetail"].Rows[i]["S42"]), 0, 0, 0, 0, 0, MainForm.User_Id, DateTime.Now.Date, "", "", null, "Size 42 Inn from Promotion", -1, SizeId, ((Convert.ToInt32(cmbGrade.SelectedValue) == 1) ? "A" : "B"), dataAcess);
                                    }
                                }


                                //for Size 43
                                SizeId = manageProduct.GetProductSizeIdByString("43");
                                if (SizeId > 0)
                                {
                                    if (Convert.ToDecimal(dset.Tables["PromotionDetail"].Rows[i]["S43"]) > 0)
                                    {
                                        manageProduct.InsertProductLedger(ProductId, Convert.ToDateTime(dtp.Value), Code, DetailId, "O",
                                           Convert.ToDecimal(dset.Tables["PromotionDetail"].Rows[i]["S43"]), 0, 0, 0, 0, 0, MainForm.User_Id, DateTime.Now.Date, "", "", null, "Size 43 Out from Promotion", -1, SizeId, ((Convert.ToInt32(cmbGrade.SelectedValue) == 1) ? "B" : "A"), dataAcess);

                                        manageProduct.InsertProductLedger(ProductId, Convert.ToDateTime(dtp.Value), Code, DetailId, "I",
                                                                   Convert.ToDecimal(dset.Tables["PromotionDetail"].Rows[i]["S43"]), 0, 0, 0, 0, 0, MainForm.User_Id, DateTime.Now.Date, "", "", null, "Size 43 Inn from Promotion", -1, SizeId, ((Convert.ToInt32(cmbGrade.SelectedValue) == 1) ? "A" : "B"), dataAcess);
                                    }
                                }

                                //for Size 44
                                SizeId = manageProduct.GetProductSizeIdByString("44");
                                if (SizeId > 0)
                                {
                                    if (Convert.ToDecimal(dset.Tables["PromotionDetail"].Rows[i]["S44"]) > 0)
                                    {
                                        manageProduct.InsertProductLedger(ProductId, Convert.ToDateTime(dtp.Value), Code, DetailId, "O",
                                           Convert.ToDecimal(dset.Tables["PromotionDetail"].Rows[i]["S44"]), 0, 0, 0, 0, 0, MainForm.User_Id, DateTime.Now.Date, "", "", null, "Size 44 Out from Promotion", -1, SizeId, ((Convert.ToInt32(cmbGrade.SelectedValue) == 1) ? "B" : "A"), dataAcess);

                                        manageProduct.InsertProductLedger(ProductId, Convert.ToDateTime(dtp.Value), Code, DetailId, "I",
                                                                   Convert.ToDecimal(dset.Tables["PromotionDetail"].Rows[i]["S44"]), 0, 0, 0, 0, 0, MainForm.User_Id, DateTime.Now.Date, "", "", null, "Size 44 Inn from Promotion", -1, SizeId, ((Convert.ToInt32(cmbGrade.SelectedValue) == 1) ? "A" : "B"), dataAcess);
                                    }
                                }

                                //for Size 45
                                SizeId = manageProduct.GetProductSizeIdByString("45");
                                if (SizeId > 0)
                                {
                                    if (Convert.ToDecimal(dset.Tables["PromotionDetail"].Rows[i]["S45"]) > 0)
                                    {
                                        manageProduct.InsertProductLedger(ProductId, Convert.ToDateTime(dtp.Value), Code, DetailId, "O",
                                           Convert.ToDecimal(dset.Tables["PromotionDetail"].Rows[i]["S45"]), 0, 0, 0, 0, 0, MainForm.User_Id, DateTime.Now.Date, "", "", null, "Size 45 Out from Promotion", -1, SizeId, ((Convert.ToInt32(cmbGrade.SelectedValue) == 1) ? "B" : "A"), dataAcess);

                                        manageProduct.InsertProductLedger(ProductId, Convert.ToDateTime(dtp.Value), Code, DetailId, "I",
                                                                   Convert.ToDecimal(dset.Tables["PromotionDetail"].Rows[i]["S45"]), 0, 0, 0, 0, 0, MainForm.User_Id, DateTime.Now.Date, "", "", null, "Size 45 Inn from Promotion", -1, SizeId, ((Convert.ToInt32(cmbGrade.SelectedValue) == 1) ? "A" : "B"), dataAcess);
                                    }
                                }


                                //for Size 46
                                SizeId = manageProduct.GetProductSizeIdByString("46");
                                if (SizeId > 0)
                                {
                                    if (Convert.ToDecimal(dset.Tables["PromotionDetail"].Rows[i]["S46"]) > 0)
                                    {
                                        manageProduct.InsertProductLedger(ProductId, Convert.ToDateTime(dtp.Value), Code, DetailId, "O",
                                            Convert.ToDecimal(dset.Tables["PromotionDetail"].Rows[i]["S46"]), 0, 0, 0, 0, 0, MainForm.User_Id, DateTime.Now.Date, "", "", null, "Size 46 Out from Promotion", -1, SizeId, ((Convert.ToInt32(cmbGrade.SelectedValue) == 1) ? "B" : "A"), dataAcess);

                                        manageProduct.InsertProductLedger(ProductId, Convert.ToDateTime(dtp.Value), Code, DetailId, "I",
                                                                   Convert.ToDecimal(dset.Tables["PromotionDetail"].Rows[i]["S46"]), 0, 0, 0, 0, 0, MainForm.User_Id, DateTime.Now.Date, "", "", null, "Size 46 Inn from Promotion", -1, SizeId, ((Convert.ToInt32(cmbGrade.SelectedValue) == 1) ? "A" : "B"), dataAcess);
                                    }
                                }

                                //for Size 47
                                SizeId = manageProduct.GetProductSizeIdByString("47");
                                if (SizeId > 0)
                                {
                                    if (Convert.ToDecimal(dset.Tables["PromotionDetail"].Rows[i]["S47"]) > 0)
                                    {
                                        manageProduct.InsertProductLedger(ProductId, Convert.ToDateTime(dtp.Value), Code, DetailId, "O",
                                           Convert.ToDecimal(dset.Tables["PromotionDetail"].Rows[i]["S47"]), 0, 0, 0, 0, 0, MainForm.User_Id, DateTime.Now.Date, "", "", null, "Size 47 Out from Promotion", -1, SizeId, ((Convert.ToInt32(cmbGrade.SelectedValue) == 1) ? "B" : "A"), dataAcess);

                                        manageProduct.InsertProductLedger(ProductId, Convert.ToDateTime(dtp.Value), Code, DetailId, "I",
                                                                   Convert.ToDecimal(dset.Tables["PromotionDetail"].Rows[i]["S47"]), 0, 0, 0, 0, 0, MainForm.User_Id, DateTime.Now.Date, "", "", null, "Size 47 Inn from Promotion", -1, SizeId, ((Convert.ToInt32(cmbGrade.SelectedValue) == 1) ? "A" : "B"), dataAcess);
                                    }
                                }
                            }
                        }

                    }
                    else
                    {
                        throw new Exception("Data does not Insert.");
                    }
                    dataAcess.TransCommit();
                    MessageBox.Show("Promotion Data Update Sucessfully..", "Record Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearFeilds();
                }
                catch (SqlException sqlex)
                {
                    dataAcess.TransRollback();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    dataAcess.ConnectionClose();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure want to Delete it?", "Promotion Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            switch (result)
            {
                case DialogResult.No:
                    {

                        break;
                    }
                case DialogResult.Yes:
                    {
                        //DeleteSalesOrder();
                        break;
                    }

            }
        }

    }
}

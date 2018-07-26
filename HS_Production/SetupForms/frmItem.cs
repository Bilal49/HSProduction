using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace FIL
{
    public partial class frmItem : Form
    {
        int ProductId = -1;
        ProductManager manageProduct = new ProductManager();
        Utility clsUtility = new Utility();
        Smartworks.DAL dataAcess = new Smartworks.DAL();

        public frmItem()
        {
            InitializeComponent();
        }

        private void frmProduct_Load(object sender, EventArgs e)
        {
            try
            {
                FillDropDown();
                ButtonRights(true);
                txtProductCode.Text = GetNewNextNumber();
                btnNextInvioceNo.Enabled = false;
                btnPrevInvioceNo.Enabled = false;
                txtProductName.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #region Method

        DataSet dsMain = null;
        private void FillDropDown()
        {
            //Category , Type ,  ColorId , SizeId , UnitId , Nature
            dsMain = manageProduct.GetAllProductDropDown();
            dsMain.Tables[0].TableName = "ProductCategory";
            dsMain.Tables[1].TableName = "ProductType";
            dsMain.Tables[2].TableName = "ProductColor";
            dsMain.Tables[3].TableName = "ProductSize";
            dsMain.Tables[4].TableName = "ProductUnit";
            dsMain.Tables[5].TableName = "ProductNature";


            DataRow drCatagory = dsMain.Tables["ProductCategory"].NewRow();
            drCatagory["ProductCategoryId"] = -1;
            drCatagory["CategoryName"] = "---Select Catagory---";
            dsMain.Tables["ProductCategory"].Rows.InsertAt(drCatagory, 0);
            cmbProductCatagory.DataSource = dsMain.Tables["ProductCategory"];
            cmbProductCatagory.DisplayMember = "CategoryName";
            cmbProductCatagory.ValueMember = "ProductCategoryId";

            DataTable dtSubCategory = dsMain.Tables["ProductCategory"].Clone();
            DataRow drSubCatagory = dtSubCategory.NewRow();
            drSubCatagory["ProductCategoryId"] = -1;
            drSubCatagory["CategoryName"] = "---Select Sub Catagory---";
            dtSubCategory.Rows.InsertAt(drSubCatagory, 0);
            cmbSubCategory.DataSource = dtSubCategory;
            cmbSubCategory.DisplayMember = "CategoryName";
            cmbSubCategory.ValueMember = "ProductCategoryId";


            //cmbSubCategory.DataSource = dvCategory;
            //cmbSubCategory.DisplayMember = "CategoryName";
            //cmbSubCategory.ValueMember = "ProductCategoryId";


            DataRow drType = dsMain.Tables["ProductType"].NewRow();
            drType["ProductTypeId"] = -1;
            drType["ProductType"] = "---Select Type---";
            dsMain.Tables["ProductType"].Rows.InsertAt(drType, 0);
            cmbProductType.DataSource = dsMain.Tables["ProductType"];
            cmbProductType.DisplayMember = "ProductType";
            cmbProductType.ValueMember = "ProductTypeId";


            DataRow drColor = dsMain.Tables["ProductColor"].NewRow();
            drColor["ColorId"] = -1;
            drColor["ColorName"] = "---Select Color---";
            dsMain.Tables["ProductColor"].Rows.InsertAt(drColor, 0);
            cmbColor.DataSource = dsMain.Tables["ProductColor"];
            cmbColor.DisplayMember = "ColorName";
            cmbColor.ValueMember = "ColorId";


            DataRow drSize = dsMain.Tables["ProductSize"].NewRow();
            drSize["SizeId"] = -1;
            drSize["SizeName"] = "---Select Size---";
            dsMain.Tables["ProductSize"].Rows.InsertAt(drSize, 0);
            cmbSize.DataSource = dsMain.Tables["ProductSize"];
            cmbSize.DisplayMember = "SizeName";
            cmbSize.ValueMember = "SizeId";


            DataRow drUnit = dsMain.Tables["ProductUnit"].NewRow();
            drUnit["MesurementId"] = -1;
            drUnit["MesurementName"] = "---Select Unit---";
            dsMain.Tables["ProductUnit"].Rows.InsertAt(drUnit, 0);
            cmbUnit.DataSource = dsMain.Tables["ProductUnit"];
            cmbUnit.DisplayMember = "MesurementName";
            cmbUnit.ValueMember = "MesurementId";


            DataRow drNature = dsMain.Tables["ProductNature"].NewRow();
            // drNature["ProductNature"] = -1;
            drNature["ProductNature"] = "---Select Nature---";
            dsMain.Tables["ProductNature"].Rows.InsertAt(drNature, 0);
            cmbNature.DataSource = dsMain.Tables["ProductNature"];
            cmbNature.DisplayMember = "ProductNature";
            cmbNature.ValueMember = "ProductNature";


        }

        private void ButtonRights(bool Enable)
        {
            btnAdd.Enabled = Enable;
            btnUpdate.Enabled = !Enable;
            btnDelete.Enabled = !Enable;
            txtProductCode.ReadOnly = !Enable;
        }

        private void ClearFeilds()
        {
            txtProductCode.Text = string.Empty;
            txtProductName.Text = string.Empty;
            txtProfitMargin.Text = string.Empty;
            txtCostPrice.Text = string.Empty;
            txtRetailPrice.Text = string.Empty;
            txtBarcode.Text = string.Empty;
            txtQtyInHand.Text = "0";
            cmbProductCatagory.SelectedValue = -1;
            cmbProductType.SelectedValue = -1;
            cmbColor.SelectedValue = -1;
            cmbSize.SelectedValue = -1;
            cmbUnit.SelectedValue = -1;
            cmbNature.SelectedIndex = 0;
            txtDiscPerc.Text = string.Empty;
            txtReportName.Text = string.Empty;
            chkAutoBarcode.Checked = true;
            chkAutoBarcode.Enabled = true;
            btnGenrateBarcode.Enabled =  true;
            chkNotification.Checked = false;
            ButtonRights(true);
            txtProductCode.Text = GetNewNextNumber();
            txtProductName.Focus();
            //pbitem.SizeMode = PictureBoxSizeMode.StretchImage;
            pbitem.Image = FIL.Properties.Resources.User;
            IsPictureUploaded = false;
            btnNextInvioceNo.Enabled = false;
            btnPrevInvioceNo.Enabled = false;
        }

        private String GetNewNextNumber()
        {
            string NewCodeNo = "";
            NewCodeNo = manageProduct.GetMaxCodeNo();
            if (!string.IsNullOrEmpty(NewCodeNo))
            {
                NewCodeNo = manageProduct.GetNextCodeNo(NewCodeNo);
            }
            else
            {
                NewCodeNo = "P-0001";
            }
            return NewCodeNo;
        }

        private bool Validation()
        {
            bool result = true;

            if (string.IsNullOrEmpty(txtProductName.Text))
            {
                MessageBox.Show("Please Enter Product Name.", "Product Name is Required.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                result = false;
                txtProductName.Focus();
                return result;
            }
            if (Convert.ToInt32(cmbProductCatagory.SelectedValue) <= 0)
            {
                MessageBox.Show("Please Select Product Categoy.", "Product Category is Required.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                result = false;
                cmbProductCatagory.Focus();
                return result;
            }
            if (cmbNature.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Product Nature.", "Product Nature is Required.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                result = false;
                cmbNature.Focus();
                return result;
            }

            if (ProductId <= 0)
            {
                if (manageProduct.ProductExists(txtProductName.Text))
                {
                    MessageBox.Show(txtProductName.Text + Environment.NewLine + "Same Name Alredy Exists in Program.", "Please Put Different Name of Product.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    result = false;
                    cmbNature.Focus();
                    return result;
                }
            }
            else
            {
                if (manageProduct.ProductExists(txtProductName.Text, ProductId))
                {
                    MessageBox.Show(txtProductName.Text + Environment.NewLine + "Same Name Alredy Exists in Program.", "Please Put Different Name of Product.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    result = false;
                    cmbNature.Focus();
                    return result;
                }
            }

            //else if (string.IsNullOrEmpty(txtRetailPrice.Text))
            //{
            //    MessageBox.Show("Please Enter Retail Price", "Retail Price is Required.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    result = false;
            //    txtRetailPrice.Focus();
            //    return result;
            //}
            //else if (Convert.ToDecimal(txtRetailPrice.Text) <= 0)
            //{
            //    MessageBox.Show("Retail Amount should be greater then zero", "Invalid Amount", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    result = false;
            //    txtRetailPrice.Focus();
            //    return result;
            //}
            return result;
        }

        public string ImageToBase64(Image image,
          System.Drawing.Imaging.ImageFormat format)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                // Convert Image to byte[]
                image.Save(ms, format);
                byte[] imageBytes = ms.ToArray();

                // Convert byte[] to Base64 String
                string base64String = Convert.ToBase64String(imageBytes);
                return base64String;
            }
        }

        public Image Base64ToImage(string base64String)
        {
            // Convert Base64 String to byte[]
            byte[] imageBytes = Convert.FromBase64String(base64String);
            MemoryStream ms = new MemoryStream(imageBytes, 0,
              imageBytes.Length);

            // Convert byte[] to Image
            ms.Write(imageBytes, 0, imageBytes.Length);
            Image image = Image.FromStream(ms, true);
            return image;
        }

        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }

        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        public static byte[] ImageToByteArray(Image img)
        {
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }

        public Image GetDataToImage(byte[] pData)
        {
            //try
            //{
            ImageConverter imgConverter = new ImageConverter();
            return imgConverter.ConvertFrom(pData) as Image;
            //}
            //catch (Exception ex)
            //{
            //    //MsgBox.Show(ex.Message, "Error", MsgBox.Buttons.OK, MsgBox.Icon.Error);
            //    return null;
            //}
        }

        private void LoadProduct(int ProductId)
        {
            DataTable dtProduct = manageProduct.GetProduct(ProductId);
            if (dtProduct.Rows.Count > 0)
            {
                txtProductCode.Text = dtProduct.Rows[0]["ProductCode"].ToString();
                txtProductName.Text = dtProduct.Rows[0]["ProductName"].ToString();
                cmbProductCatagory.SelectedValue = dtProduct.Rows[0]["ProductCatagoryId"].ToString();
                if (!string.IsNullOrEmpty(dtProduct.Rows[0]["ProductSubCatagoryId"].ToString()))
                {
                    cmbSubCategory.SelectedValue = dtProduct.Rows[0]["ProductSubCatagoryId"].ToString();
                }
                else
                {
                    cmbSubCategory.SelectedValue = -1;
                }

                cmbProductType.SelectedValue = dtProduct.Rows[0]["ProductTypeId"].ToString();

                cmbColor.SelectedValue = dtProduct.Rows[0]["ProductColorId"].ToString();
                cmbSize.SelectedValue = dtProduct.Rows[0]["ProductSizeId"].ToString();
                cmbUnit.SelectedValue = dtProduct.Rows[0]["MesurementUnitId"].ToString();
                cmbNature.SelectedValue = dtProduct.Rows[0]["ProductNature"].ToString();

                txtCostPrice.Text = dtProduct.Rows[0]["CostPrice"].ToString();
                txtRetailPrice.Text = dtProduct.Rows[0]["RetailPrice"].ToString();
                txtProfitMargin.Text = dtProduct.Rows[0]["ProfitMargin"].ToString();
                txtDiscPerc.Text = dtProduct.Rows[0]["DiscountPerc"].ToString();
                txtQtyInHand.Text = dtProduct.Rows[0]["QtyInHand"].ToString();
                txtBarcode.Text = dtProduct.Rows[0]["Barcode"].ToString();
                if (!string.IsNullOrEmpty(dtProduct.Rows[0]["Picture"].ToString()))
                {
                    try
                    {
                        //pbitem.Image = GetDataToImage((byte[])dtProduct.Rows[0]["Picture"]);
                        pbitem.Image = Base64ToImage(dtProduct.Rows[0]["Picture"].ToString());
                        IsPictureUploaded = true;
                        //
                        //if (!string.IsNullOrEmpty(dtProduct.Rows[0]["PictureImage"].ToString()))
                        //{
                        //    pbitem.Image = TestImage((byte[])dtProduct.Rows[0]["PictureImage"]);
                        //}
                        
                    }
                    catch
                    {
                        pbitem.Image = FIL.Properties.Resources.User;
                        IsPictureUploaded = false;
                    }

                }
                else
                {
                    pbitem.Image = FIL.Properties.Resources.User;

                }
                txtReportName.Text = dtProduct.Rows[0]["ReportName"].ToString();
                chkAutoBarcode.Enabled = false;
                chkAutoBarcode.Checked = true;
                btnGenrateBarcode.Enabled = false;
                txtBarcode.ReadOnly = true;
                if (!string.IsNullOrEmpty(dtProduct.Rows[0]["IsNotification"].ToString()))
                {
                    chkNotification.Checked = Convert.ToBoolean(dtProduct.Rows[0]["IsNotification"]);
                }
                else
                {
                    chkNotification.Checked = false;
                }
                
                ButtonRights(false);

                //for Navigation Works*******
                try
                {
                    string FirstTransNo = manageProduct.GetMinCodeNo();
                    string LastTransNo = manageProduct.GetMaxCodeNo();
                    if (LastTransNo == txtProductCode.Text)
                    {
                        btnNextInvioceNo.Enabled = false;
                    }
                    else
                    {
                        btnNextInvioceNo.Enabled = true;
                    }
                    if (FirstTransNo == txtProductCode.Text)
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
                

                //***************************
            }
        }

        //private Image TestImage(byte[] byteArrayIn)
        //{
        //    using (var ms = new MemoryStream(byteArrayIn))
        //    {
        //        return Image.FromStream(ms);
        //    }
        //}
        
        private int InsertProduct(string ProductName, decimal CostPrice, int ProductCatagoryId, int ProductTypeId, int ProductColorId, int ProductSizeId, int MesurementUnitId, string ProductNature, decimal RetailPrice, decimal ProfitMargin, decimal DiscountPerc, string Barcode, string ProductImage, string ReportName, int SubCatagorId, bool IsNotification ,  byte[] pictureImage, Smartworks.DAL customDataAcess)
        {
            ProductId = manageProduct.InsertProduct(ProductName, CostPrice, ProductCatagoryId, ProductTypeId, ProductColorId, ProductSizeId, MesurementUnitId, ProductNature, RetailPrice, ProfitMargin, DiscountPerc, Barcode, MainForm.User_Id, DateTime.Now, "", ProductImage, ReportName, SubCatagorId, IsNotification ,  pictureImage, customDataAcess);
            return ProductId;
        }

        private void UpdateProduct(int ProductId, string ProductName, int ProductCatagoryId, int ProductTypeId, int ProductColorId, int ProductSizeId, int MesurementUnitId, string ProductNature, decimal CostPrice, decimal RetailPrice, decimal ProfitMargin, decimal DiscountPerc, string Barcode, string ProductImage, string ReportName, int SubCatagoryId,  bool IsNotification ,  byte[] pictureImage, Smartworks.DAL customDataAcess)
        {
            manageProduct.UpdateProduct(ProductId, ProductName, ProductCatagoryId, ProductTypeId, ProductColorId, ProductSizeId, MesurementUnitId, ProductNature, CostPrice, RetailPrice, ProfitMargin, DiscountPerc, MainForm.User_Id, DateTime.Now, "", Barcode, ProductImage, ReportName, SubCatagoryId, IsNotification ,  pictureImage, customDataAcess);
        }

        private void DeleteProduct(int ProductId)
        {
            if (manageProduct.DeleteProduct(ProductId))
            {
                MessageBox.Show("Product Record Delete Successfull.", "Product Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFeilds();
            }
            else
            {
                MessageBox.Show("Error While Delete Item." + Environment.NewLine + "Item Alredy are in Used.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        #endregion

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                GenrateBarcode();
                if (string.IsNullOrEmpty(txtBarcode.Text))
                {
                    MessageBox.Show("SKU Code does not found.", "SKU Code Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                Image productImage = null;
                byte[] pictureimage = null;
                if (!IsPictureUploaded)
                {
                    productImage = null;
                }
                else
                {
                    productImage = pbitem.Image;
                    pictureimage = imageToByteArray(pbitem.Image);
                }
                try
                {
                    dataAcess.BeginTransaction();
                    ProductId = InsertProduct(txtProductName.Text, (string.IsNullOrEmpty(txtCostPrice.Text) ? 0 : Convert.ToDecimal(txtCostPrice.Text)), Convert.ToInt32(cmbProductCatagory.SelectedValue), Convert.ToInt32(cmbProductType.SelectedValue),
                        Convert.ToInt32(cmbColor.SelectedValue), Convert.ToInt32(cmbSize.SelectedValue), Convert.ToInt32(cmbUnit.SelectedValue), cmbNature.SelectedValue.ToString(),
                        (string.IsNullOrEmpty(txtRetailPrice.Text) ? 0 : Convert.ToDecimal(txtRetailPrice.Text)),
                        (string.IsNullOrEmpty(txtProfitMargin.Text) ? 0 : Convert.ToDecimal(txtProfitMargin.Text)),
                        (string.IsNullOrEmpty(txtDiscPerc.Text) ? 0 : Convert.ToDecimal(txtDiscPerc.Text)),
                        txtBarcode.Text,
                        (productImage == null ? null : ImageToBase64(productImage, System.Drawing.Imaging.ImageFormat.Jpeg)), txtReportName.Text, Convert.ToInt32(cmbSubCategory.SelectedValue) , chkNotification.Checked ,  (pictureimage == null ? null : pictureimage), dataAcess);
                    dataAcess.TransCommit();
                    MessageBox.Show("Product Insert Succesfull", "Product Insterted", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ClearFeilds();
                    if (ProductId > 0)
                    {
                        LoadProduct(ProductId);
                    }

                }
                catch (SqlException sqlex)
                {
                    dataAcess.TransRollback();
                    MessageBox.Show(sqlex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
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
                GenrateBarcode();
                if (string.IsNullOrEmpty(txtBarcode.Text))
                {
                    MessageBox.Show("SKU Code does not found.", "SKU Code Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                Image productImage = null;
                byte[] pictureimage = null;
                if (!IsPictureUploaded)
                {
                    productImage = null;
                }
                else
                {
                    productImage = pbitem.Image;
                    pictureimage = imageToByteArray(pbitem.Image);
                }

                try
                {
                    dataAcess.BeginTransaction();
                    UpdateProduct(ProductId, txtProductName.Text, Convert.ToInt32(cmbProductCatagory.SelectedValue), Convert.ToInt32(cmbProductType.SelectedValue), Convert.ToInt32(cmbColor.SelectedValue), Convert.ToInt32(cmbSize.SelectedValue), Convert.ToInt32(cmbUnit.SelectedValue), cmbNature.SelectedValue.ToString(), (string.IsNullOrEmpty(txtCostPrice.Text) ? 0 : Convert.ToDecimal(txtCostPrice.Text)), (string.IsNullOrEmpty(txtRetailPrice.Text) ? 0 : Convert.ToDecimal(txtRetailPrice.Text)), (string.IsNullOrEmpty(txtProfitMargin.Text) ? 0 : Convert.ToDecimal(txtProfitMargin.Text)), (string.IsNullOrEmpty(txtDiscPerc.Text) ? 0 : Convert.ToDecimal(txtDiscPerc.Text)), txtBarcode.Text, (productImage == null ? null : ImageToBase64(productImage, System.Drawing.Imaging.ImageFormat.Jpeg)), txtReportName.Text, Convert.ToInt32(cmbSubCategory.SelectedValue), chkNotification.Checked , (pictureimage == null ? null : pictureimage), dataAcess);
                    dataAcess.TransCommit();
                    MessageBox.Show("Product Record Updated Successfull.", "Product Updated.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearFeilds();


                }
                catch (SqlException sqlex)
                {
                    dataAcess.TransRollback();
                    MessageBox.Show(sqlex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    dataAcess.ConnectionClose();
                }

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure want to Delete it.", "Product Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            switch (result)
            {
                case DialogResult.No:
                    {
                        return;
                        break;
                    }
                case DialogResult.Yes:
                    {
                        DeleteProduct(ProductId);
                        break;
                    }

            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFeilds();
        }

        private void txtProductCode_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtProductCode.Text))
            {
                ProductId = manageProduct.GetProductIdByCode(txtProductCode.Text);
                if (ProductId > 0)
                {
                    LoadProduct(ProductId);
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {

                frmSearch search = new frmSearch();
                search.getattributes("GetProductSearch", null, "Products");
                search.ShowDialog();
                if (!string.IsNullOrEmpty(MainForm.Searched_Id))
                {
                    txtProductCode.Text = MainForm.Searched_Id;
                    MainForm.Searched_Id = string.Empty;
                }
                else
                {
                    //txtProductCode.Text = string.Empty;
                    //txtProductCode.Focus();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtProductCode_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtProductCode.Text))
            {
                ProductId = manageProduct.GetProductIdByCode(txtProductCode.Text);
                if (ProductId > 0)
                {
                    LoadProduct(ProductId);
                }
            }
        }

        private void chkAutoBarcode_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAutoBarcode.Checked)
            {
                txtBarcode.Text = string.Empty;
                txtBarcode.ReadOnly = true;
            }
            else
            {
                txtBarcode.Text = string.Empty;
                txtBarcode.ReadOnly = false;
            }
        }

        private void txtCostPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsUtility.setOnlyNumberic(txtCostPrice, true, e);
        }

        private void txtRetailPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsUtility.setOnlyNumberic(txtRetailPrice, true, e);
        }

        private void txtProfitMargin_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsUtility.setOnlyNumberic(txtProfitMargin, true, e);
        }

        private void txtDiscPerc_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsUtility.setOnlyNumberic(txtDiscPerc, true, e);
        }

        private void txtCostPrice_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtCostPrice.Text))
            {
                if (String.IsNullOrEmpty(txtRetailPrice.Text))
                {
                    txtRetailPrice.Text = txtCostPrice.Text;
                }
                else if (Convert.ToDecimal(txtCostPrice.Text) > Convert.ToDecimal(txtRetailPrice.Text))
                {
                    txtRetailPrice.Text = txtCostPrice.Text;
                }
            }

            if (!String.IsNullOrEmpty(txtCostPrice.Text))
            {
                if (!String.IsNullOrEmpty(txtRetailPrice.Text))
                {
                    try
                    {
                        txtProfitMargin.Text = (((Convert.ToDecimal(txtRetailPrice.Text) - Convert.ToDecimal(txtCostPrice.Text)) / Convert.ToDecimal(txtCostPrice.Text)) * 100).ToString("n2");
                    }
                    catch (Exception ex)
                    {
                        txtProfitMargin.Text = "0";
                    }

                }
            }
        }

        private void txtRetailPrice_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtCostPrice.Text))
            {
                if (!String.IsNullOrEmpty(txtRetailPrice.Text))
                {
                    if (Convert.ToDecimal(txtRetailPrice.Text) < Convert.ToDecimal(txtCostPrice.Text))
                    {
                        MessageBox.Show("Retail Amount should be greater then or equal to Cost Amount", "Invalid Amount", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtRetailPrice.Text = txtCostPrice.Text;

                    }
                    try
                    {
                        txtProfitMargin.Text = (((Convert.ToDecimal(txtRetailPrice.Text) - Convert.ToDecimal(txtCostPrice.Text)) / Convert.ToDecimal(txtCostPrice.Text)) * 100).ToString("n2");
                    }
                    catch (Exception ex)
                    {
                        txtProfitMargin.Text = "0";
                    }

                }
            }
        }

        private void txtProfitMargin_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtCostPrice.Text))
            {
                if (!String.IsNullOrEmpty(txtProfitMargin.Text))
                {
                    txtRetailPrice.Text = (((Convert.ToDecimal(txtCostPrice.Text) / 100) * Convert.ToDecimal(txtProfitMargin.Text)) + Convert.ToDecimal(txtCostPrice.Text)).ToString("n2");
                }
            }

        }

        private void txtCostPrice_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void btnGenrateBarcode_Click(object sender, EventArgs e)
        {
            GenrateBarcode();
        }

        private void GenrateBarcode()
        {
            if (string.IsNullOrEmpty(txtProductCode.Text))
            {
                txtBarcode.Text = string.Empty;
                return;
            }

            string ProductCode = txtProductCode.Text.Split('-')[1];
            string Category = "01";
            string Type = "01";
            string Color = "01";
            string Size = "01";
            string Unit = "01";
            string SKUCode = string.Empty;



            if (Convert.ToInt32(cmbProductCatagory.SelectedValue) > 0)
            {
                if (cmbProductCatagory.SelectedValue.ToString().Length == 1)
                {
                    Category = "0" + cmbProductCatagory.SelectedValue.ToString();
                }
                else
                {
                    Category = cmbProductCatagory.SelectedValue.ToString();
                }
            }
            if (Convert.ToInt32(cmbProductType.SelectedValue) > 0)
            {
                if (cmbProductType.SelectedValue.ToString().Length == 1)
                {
                    Type = "0" + cmbProductType.SelectedValue.ToString();
                }
                else
                {
                    Type = cmbProductType.SelectedValue.ToString();
                }
            }
            if (Convert.ToInt32(cmbColor.SelectedValue) > 0)
            {
                if (cmbColor.SelectedValue.ToString().Length == 1)
                {
                    Color = "0" + cmbColor.SelectedValue.ToString();
                }
                else
                {
                    Color = cmbColor.SelectedValue.ToString();
                }
            }
            if (Convert.ToInt32(cmbSize.SelectedValue) > 0)
            {
                if (cmbSize.SelectedValue.ToString().Length == 1)
                {
                    Size = "0" + cmbSize.SelectedValue.ToString();
                }
                else
                {
                    Size = cmbSize.SelectedValue.ToString();
                }
            }
            if (Convert.ToInt32(cmbUnit.SelectedValue) > 0)
            {
                if (cmbUnit.SelectedValue.ToString().Length == 1)
                {
                    Unit = "0" + cmbUnit.SelectedValue.ToString();
                }
                else
                {
                    Unit = cmbUnit.SelectedValue.ToString();
                }
            }
            SKUCode = Category + Type + Color + Size + Unit + ProductCode;
            //txtBarcode.Text = manageProduct.GetNewGenerateBarcode();
            txtBarcode.Text = SKUCode;
        }

        private void txtBarcode_TextChanged(object sender, EventArgs e)
        {
            if (!chkAutoBarcode.Checked)
            {
                if (!manageProduct.IsValidBarcode(txtBarcode.Text))
                {
                    txtBarcode.Text = string.Empty;
                }
            }
        }

        private void btnMinInvioceNo_Click(object sender, EventArgs e)
        {
            txtProductCode.Text = manageProduct.GetMinCodeNo();
            if (!string.IsNullOrEmpty(txtProductCode.Text))
            {
                ProductId = manageProduct.GetProductIdByCode(txtProductCode.Text);
                if (ProductId > 0)
                {
                    //LoadProduct(ProductId);
                    //btnNextInvioceNo.Enabled = true;
                    //btnPrevInvioceNo.Enabled = false;
                }
            }

        }

        private void btnPrevInvioceNo_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtProductCode.Text))
            {
                string LastProductNo = manageProduct.GetMinCodeNo();
                txtProductCode.Text = manageProduct.GetPrevCodeNo(txtProductCode.Text);

                ProductId = manageProduct.GetProductIdByCode(txtProductCode.Text);
                if (ProductId > 0)
                {
                    //LoadProduct(ProductId);

                    if (LastProductNo == txtProductCode.Text)
                    {
                        btnPrevInvioceNo.Enabled = false;
                    }
                    else
                    {
                        btnNextInvioceNo.Enabled = true;
                    }
                }


            }
        }

        private void btnNextInvioceNo_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtProductCode.Text))
            {
                string LastProductNo = manageProduct.GetMaxCodeNo();
                txtProductCode.Text = manageProduct.GetNextCodeNo(txtProductCode.Text);
                ProductId = manageProduct.GetProductIdByCode(txtProductCode.Text);
                if (ProductId > 0)
                {
                    //LoadProduct(ProductId);
                    if (LastProductNo == txtProductCode.Text)
                    {
                        btnNextInvioceNo.Enabled = false;
                    }
                    else
                    {
                        btnPrevInvioceNo.Enabled = true;
                    }
                }


            }
        }

        private void btnMaxInvioceNo_Click(object sender, EventArgs e)
        {
            txtProductCode.Text = manageProduct.GetMaxCodeNo();
            if (!string.IsNullOrEmpty(txtProductCode.Text))
            {
                ProductId = manageProduct.GetProductIdByCode(txtProductCode.Text);
                if (ProductId > 0)
                {
                    //LoadProduct(ProductId);
                    //btnNextInvioceNo.Enabled = false;
                    //btnPrevInvioceNo.Enabled = true;
                }

            }
        }

        private void frmItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F6)
            {
                ClearFeilds();
            }
            else if (e.KeyCode == Keys.F3)
            {
                if (btnAdd.Enabled)
                {
                    btnAdd.PerformClick();
                }
                else if (btnUpdate.Enabled)
                {
                    btnUpdate.PerformClick();
                }
            }
            else if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
            else if (e.KeyCode == Keys.F2)
            {
                btnSearch.PerformClick();
            }

        }

        private void txtProductCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                btnSearch.PerformClick();
            }
        }

        bool IsPictureUploaded = false;
        private void pbitem_Click(object sender, EventArgs e)
        {
            OpenFileDialog OFD = new OpenFileDialog();
            OFD.Title = "Browse Image File";
            OFD.RestoreDirectory = true;
            OFD.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            OFD.Multiselect = false;

            if (OFD.ShowDialog() == DialogResult.OK)
            {
                //pbitem.SizeMode = PictureBoxSizeMode.Normal;
                pbitem.Image = Image.FromFile(OFD.FileName);
                IsPictureUploaded = true;
            }
            else
            {
                IsPictureUploaded = false;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            FillDropDown();
        }

        private void btnImportProduct_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "Excel Files|*.xls;*.xlsx;";
            of.Multiselect = false;
            if (of.ShowDialog() == DialogResult.OK)
            {
                string FilePath = of.FileName;
                bool IsImported = ImportExcelData(FilePath);
                if (IsImported)
                {
                    MessageBox.Show("Product Import Successfull.", "Record Imported", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private bool ImportExcelData(string strFilePath)
        {
            bool result = true;
            string sSheetName = null;
            string sConnection = null;
            DataTable dtTablesList = new DataTable();


            OleDbCommand oleExcelCommand = new OleDbCommand();
            OleDbDataReader oleExcelReader;
            OleDbConnection oleExcelConnection = new OleDbConnection();
            DataTable dtExcelData = new DataTable();
            DataTable dtExcelDataFinal = new DataTable();
            Smartworks.DAL dataAccess = new Smartworks.DAL();

            string extension = Path.GetExtension(strFilePath);
            switch (extension)
            {
                case ".xls":
                    //sConnection = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + strFilePath + ";Extended Properties='Excel 8.0;HDR=Yes;IMEX=1;'";
                    sConnection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + strFilePath + ";Extended Properties=Excel 12.0;";
                    break;
                case ".xlsx":
                    sConnection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + strFilePath + ";Extended Properties='Excel 12.0;HDR=Yes;IMEX=1;'";
                    break;
                default:
                    sConnection = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + strFilePath + ";Extended Properties='Excel 8.0;HDR=Yes;IMEX=1;'";
                    break;
            }
            //String constr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + strFilePath + ";Extended Properties='Excel 8.0;HDR=YES;';";
            // sConnection = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + strFilePath + ";Extended Properties='Excel 8.0;HDR=YES;';";
            oleExcelConnection = new OleDbConnection(sConnection);
            try
            {
                oleExcelConnection.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "File does not read.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            dtTablesList = oleExcelConnection.GetSchema("Tables");
            int SheetIndex = 0;
            foreach (DataRow drSheet in dtTablesList.Rows)
            {
                SheetIndex = SheetIndex + 1;
                sSheetName = drSheet["TABLE_NAME"].ToString();
                if (!sSheetName.Contains("$"))
                {
                    continue;
                }
                //dtTablesList.Clear();
                //dtTablesList.Dispose();

                if (!string.IsNullOrEmpty(sSheetName))
                {
                    oleExcelCommand = oleExcelConnection.CreateCommand();
                    oleExcelCommand.CommandText = "Select * From [" + sSheetName + "]";
                    oleExcelCommand.CommandType = CommandType.Text;
                    oleExcelReader = oleExcelCommand.ExecuteReader();
                    dtExcelData.Load(oleExcelReader, LoadOption.PreserveChanges);
                    oleExcelReader.Close();
                }

                if (SheetIndex == dtTablesList.Rows.Count)
                {
                    oleExcelConnection.Close();
                }
                if (dtExcelData.Rows.Count > 0)
                {
                    //if (dtExcelData.Columns.Count > 10 || dtExcelData.Columns.Count < 10)
                    //{
                    //    MessageBox.Show("File Format does not match. Make sure your format is as per Sample.", "Format does not match", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //    oleExcelConnection.Close();
                    //    result = false;
                    //    return result;
                    //}


                    //dtExcelData.Rows.RemoveAt(0);
                    /* yeh New format file hai */
                    dtExcelData.Columns[0].ColumnName = "ItemName";
                    dtExcelData.Columns[1].ColumnName = "CategoryName";

                    if (dtExcelDataFinal.Columns.Count == 0)
                    {
                        dtExcelDataFinal = dtExcelData.Clone();
                    }

                    foreach (DataRow dtRow in dtExcelData.Rows)
                    {
                        dtExcelDataFinal.ImportRow(dtRow);
                    }
                }

            }

            if (dtExcelDataFinal.Columns.Count > 0)
            {
                if (dtExcelDataFinal.Rows.Count > 0)
                {
                    int index = 0;
                    try
                    {
                        dataAccess.BeginTransaction();
                        for (int i = 0; i <= dtExcelDataFinal.Rows.Count - 1; i++)
                        {
                            index = i;
                            DataRow drImportRow = dtExcelDataFinal.Rows[i];
                            if (!string.IsNullOrEmpty(drImportRow["ItemName"].ToString()))
                            {
                                Smartworks.ColumnField[] importCustomer = new Smartworks.ColumnField[2];
                                importCustomer[0] = new Smartworks.ColumnField("@ItemName", drImportRow["ItemName"].ToString().Trim());
                                importCustomer[1] = new Smartworks.ColumnField("@CategoryName", drImportRow["CategoryName"].ToString().Trim());

                                dataAccess.ExecuteStoredProcedure("sp_ImportProduct", importCustomer);
                            }
                        }
                        dataAccess.TransCommit();
                        // dataAccess.TransRollback();
                    }
                    catch (SqlException sqlex)
                    {
                        dataAccess.TransRollback();
                        dataAccess.ConnectionClose();
                        //Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Error!!.. File Date not Import.');", true);
                        MessageBox.Show("Error!!.. File Data not Import", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        result = false;
                        return result;
                    }
                    catch (Exception ex)
                    {
                        dataAccess.ConnectionClose();
                        //Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Error!!.. File Date not Import.');", true);
                        MessageBox.Show("Error!!.. File Data not Import", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        result = false;
                        return result;
                    }
                }

            }
            return result;

        }

        private void cmbProductCatagory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbProductCatagory.SelectedIndex > 0)
                {

                    if (dsMain.Tables["ProductCategory"].Select("ParentId = '" + cmbProductCatagory.SelectedValue.ToString() + "'").Length > 0)
                    {
                        DataTable dtSubCategory = dsMain.Tables["ProductCategory"].Select("ParentId = '" + cmbProductCatagory.SelectedValue.ToString() + "'").CopyToDataTable();
                        DataRow drSubCatagory = dtSubCategory.NewRow();
                        drSubCatagory["ProductCategoryId"] = -1;
                        drSubCatagory["CategoryName"] = "---Select Sub Catagory---";
                        dtSubCategory.Rows.InsertAt(drSubCatagory, 0);
                        cmbSubCategory.DataSource = dtSubCategory;
                        cmbSubCategory.DisplayMember = "CategoryName";
                        cmbSubCategory.ValueMember = "ProductCategoryId";
                    }
                    else
                    {
                        DataTable dtSubCategory = dsMain.Tables["ProductCategory"].Clone();
                        DataRow drSubCatagory = dtSubCategory.NewRow();
                        drSubCatagory["ProductCategoryId"] = -1;
                        drSubCatagory["CategoryName"] = "---Select Sub Catagory---";
                        dtSubCategory.Rows.InsertAt(drSubCatagory, 0);
                        cmbSubCategory.DataSource = dtSubCategory;
                        cmbSubCategory.DisplayMember = "CategoryName";
                        cmbSubCategory.ValueMember = "ProductCategoryId";
                    }

                }
                else
                {
                    DataTable dtSubCategory = dsMain.Tables["ProductCategory"].Clone();
                    DataRow drSubCatagory = dtSubCategory.NewRow();
                    drSubCatagory["ProductCategoryId"] = -1;
                    drSubCatagory["CategoryName"] = "---Select Sub Catagory---";
                    dtSubCategory.Rows.InsertAt(drSubCatagory, 0);
                    cmbSubCategory.DataSource = dtSubCategory;
                    cmbSubCategory.DisplayMember = "CategoryName";
                    cmbSubCategory.ValueMember = "ProductCategoryId";
                }
            }
            catch (Exception ex)
            {

            }
            //if (cmbProductCatagory.SelectedIndex > 0)
            //{

            //    if (dsMain.Tables["ProductCategory"].Select("ParentId = '"+ cmbProductCatagory.SelectedValue.ToString() +"'").Length > 0)
            //    {

            //    }
            //    //dvCategory.RowFilter = "ParentId = '" + cmbProductCatagory.SelectedValue.ToString() + "'";
            //}
            //else
            //{
            //    //dvCategory.RowFilter = "ParentId = '" + -1 + "'";
            //}
        }


    }
}

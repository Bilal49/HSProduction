using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Windows.Forms;
using System.Drawing;


public class ProductManager
{
    Smartworks.DAL dataAccess = new Smartworks.DAL();
    public ProductManager()
    {

        string connString = ConfigurationManager.ConnectionStrings["HSConnectionString"].ConnectionString;
        Smartworks.DAL.ConnectionString = connString;
    }

    #region Product Setup


    public int InsertProduct(string ProductName, decimal CostPrice, int ProductCatagoryId, int ProductTypeId, int ProductColorId, int ProductSizeId,
        int MesurementUnitId, string ProductNature, decimal RetailPrice, decimal ProfitMargin, decimal DiscountPerc, string Barcode,
        int AddedBy, DateTime AddedOn, string AddedIpAddr, string ProductImage = null, string ReportName = "", int SubCatagoryId = -1, bool IsNotification = false , byte[] pictureImage = null , Smartworks.DAL customdataAcess = null )
    {
        int id = 0;

        Smartworks.ColumnField[] iProduct = null; // new Smartworks.ColumnField[19];
        if (pictureImage == null)
        {
            //with out image paramter
            iProduct = new Smartworks.ColumnField[19];
        }
        else
        {
            //With Image Parameter
            iProduct = new Smartworks.ColumnField[20];
        }

        iProduct[0] = new Smartworks.ColumnField("@ProductName", ProductName);
        iProduct[1] = new Smartworks.ColumnField("@ProductCatagoryId", ProductCatagoryId);
        iProduct[2] = new Smartworks.ColumnField("@ProductTypeId", ProductTypeId);
        iProduct[3] = new Smartworks.ColumnField("@ProductColorId", ProductColorId);
        iProduct[4] = new Smartworks.ColumnField("@ProductSizeId", ProductSizeId);
        iProduct[5] = new Smartworks.ColumnField("@MesurementUnitId", MesurementUnitId);
        iProduct[6] = new Smartworks.ColumnField("@ProductNature", ProductNature);
        iProduct[7] = new Smartworks.ColumnField("@CostPrice", CostPrice);
        iProduct[8] = new Smartworks.ColumnField("@RetailPrice", RetailPrice);
        iProduct[9] = new Smartworks.ColumnField("@ProfitMargin", ProfitMargin);
        iProduct[10] = new Smartworks.ColumnField("@DiscountPerc", DiscountPerc);
        iProduct[11] = new Smartworks.ColumnField("@Barcode", Barcode);
        iProduct[12] = new Smartworks.ColumnField("@AddedBy", AddedBy);
        iProduct[13] = new Smartworks.ColumnField("@AddedOn", AddedOn);
        iProduct[14] = new Smartworks.ColumnField("@AddedIpAddr", AddedIpAddr);
        if (ProductImage == null)
        {
            iProduct[15] = new Smartworks.ColumnField("@ProductImage", DBNull.Value, false, SqlDbType.Image);
        }
        else
        {
            iProduct[15] = new Smartworks.ColumnField("@ProductImage", ProductImage, false, SqlDbType.Image);
        }
        iProduct[16] = new Smartworks.ColumnField("@ReportName", ReportName);
        iProduct[17] = new Smartworks.ColumnField("@SubCatagoryId", SubCatagoryId);
        iProduct[18] = new Smartworks.ColumnField("@IsNotification", IsNotification);

        if (pictureImage == null)
        {
            //yeh parameter nh jye ga agr null hoga toh 
            //iProduct[18] = new Smartworks.ColumnField("@PictureImage", DBNull.Value);
        }
        else
        {
            iProduct[19] = new Smartworks.ColumnField("@PictureImage", pictureImage);
        }

        if (customdataAcess != null)
        {
            if (pictureImage == null)
            {
                //defult Insert with out Image
                id = Convert.ToInt32(customdataAcess.ExecuteStoredProcedure("dbo.InsertProduct", iProduct));
            }
            else            
            {
                id = Convert.ToInt32(customdataAcess.ExecuteStoredProcedure("dbo.InsertProductWithImage", iProduct));
            }
        }
        else
        {
            dataAccess.BeginTransaction();
            id = Convert.ToInt32(dataAccess.ExecuteStoredProcedure("dbo.InsertProduct", iProduct));
            dataAccess.TransCommit();
        }
        return id;
    }

    public void UpdateProduct(int ProductId, string ProductName, int ProductCatagoryId, int ProductTypeId, int ProductColorId, int ProductSizeId, int MesurementUnitId, string ProductNature, decimal CostPrice, decimal RetailPrice, decimal ProfitMargin, decimal DiscountPerc,
        int UpdatedBy, DateTime UpdatedOn, string UpdatedIpAddr, string Barcode, string ProductImage = null, string ReportName = "", int SubCatagoryId = -1, bool IsNotification = false , byte[] pictureImage = null, Smartworks.DAL customdataAcess = null)
    {
        Smartworks.ColumnField[] uProduct = null; // new Smartworks.ColumnField[20];
            if (pictureImage == null)
        {
            //with out image paramter
            uProduct = new Smartworks.ColumnField[20];
        }
        else
        {
            //With Image Parameter
            uProduct = new Smartworks.ColumnField[21];
        }

        uProduct[0] = new Smartworks.ColumnField("@ProductId", ProductId);
        uProduct[1] = new Smartworks.ColumnField("@ProductName", ProductName);
        uProduct[2] = new Smartworks.ColumnField("@ProductCatagoryId", ProductCatagoryId);
        uProduct[3] = new Smartworks.ColumnField("@ProductTypeId", ProductTypeId);
        uProduct[4] = new Smartworks.ColumnField("@ProductColorId", ProductColorId);
        uProduct[5] = new Smartworks.ColumnField("@ProductSizeId", ProductSizeId);
        uProduct[6] = new Smartworks.ColumnField("@MesurementUnitId", MesurementUnitId);
        uProduct[7] = new Smartworks.ColumnField("@ProductNature", ProductNature);
        uProduct[8] = new Smartworks.ColumnField("@CostPrice", CostPrice);
        uProduct[9] = new Smartworks.ColumnField("@RetailPrice", RetailPrice);
        uProduct[10] = new Smartworks.ColumnField("@ProfitMargin", ProfitMargin);
        uProduct[11] = new Smartworks.ColumnField("@DiscountPerc", DiscountPerc);
        uProduct[12] = new Smartworks.ColumnField("@UpdatedBy", UpdatedBy);
        uProduct[13] = new Smartworks.ColumnField("@UpdatedOn", UpdatedOn);
        uProduct[14] = new Smartworks.ColumnField("@UpdatedIpAddr", UpdatedIpAddr);
        uProduct[15] = new Smartworks.ColumnField("@Barcode", Barcode);

        if (ProductImage == null)
        {
            uProduct[16] = new Smartworks.ColumnField("@ProductImage", DBNull.Value, false, SqlDbType.Image);
            uProduct[16].ColumnValue = DBNull.Value;
        }
        else
        {
            uProduct[16] = new Smartworks.ColumnField("@ProductImage", ProductImage, false, SqlDbType.Image);

        }
        uProduct[17] = new Smartworks.ColumnField("@ReportName", ReportName);
        uProduct[18] = new Smartworks.ColumnField("@SubCatagoryId", SubCatagoryId);
        uProduct[19] = new Smartworks.ColumnField("@IsNotification", IsNotification);
        if (pictureImage == null)
        {
            //uProduct[19] = new Smartworks.ColumnField("@PictureImage", DBNull.Value);
        }
        else
        {
            uProduct[20] = new Smartworks.ColumnField("@PictureImage", pictureImage);
        }



        if (customdataAcess !=  null)
        {
            if (pictureImage == null)
            {
                //defult Insert with out Image
                customdataAcess.ExecuteStoredProcedure("dbo.UpdateProduct", uProduct);
            }
            else
            {
                customdataAcess.ExecuteStoredProcedure("dbo.UpdateProductWithImage", uProduct);
            }

           // customdataAcess.ExecuteStoredProcedure("dbo.UpdateProduct", uProduct);
        }
        else
        {
            dataAccess.BeginTransaction();
            dataAccess.ExecuteStoredProcedure("dbo.UpdateProduct", uProduct);
            dataAccess.TransCommit();
        }

        
    }


    public bool DeleteProduct(int ProductId)
    {
        bool result;

        Smartworks.ColumnField[] dProduct = new Smartworks.ColumnField[1];
        dProduct[0] = new Smartworks.ColumnField("@ProductId", ProductId);

        dataAccess.BeginTransaction();
        result =  Convert.ToBoolean(dataAccess.getDataTableByStoredProcedure("dbo.DeleteProduct", dProduct).Rows[0]["result"]);
        dataAccess.TransCommit();

        return result;
    }

    public void UpdateProductCostPrice(int ProductId, decimal CostPrice, Smartworks.DAL customdataAcess = null)
    {
        if (customdataAcess != null)
        {
            customdataAcess.ExecuteNonQuery("update Product set CostPrice = " + CostPrice + " where ProductId = " + ProductId + "");
        }
        else
        {
            dataAccess.ExecuteNonQuery("update Product set CostPrice = " + CostPrice + " where ProductId = " + ProductId + "");
        }
    }


    public DataTable GetProduct(int ProductId)
    {

        DataTable dt;
        dt = dataAccess.getDataTable("Select * from Product where ProductId =" + ProductId);
        return dt;
    }



    public int GetProductIdByCode(string Code)
    {
        int ProductId = -1;
        DataTable dt = new DataTable();
        dt = dataAccess.getDataTable("Select ProductId from Product where ProductCode= '" + Code + "' ");
        if (dt.Rows.Count > 0)
        {
            ProductId = (int)dt.Rows[0]["ProductId"];
        }
        return ProductId;
    }

    public int GetFinishProductIdByCode(string Code)
    {
        int ProductId = -1;
        DataTable dt = new DataTable();
        dt = dataAccess.getDataTable("Select ProductId from Product where ProductCode= '" + Code + "' and ProductNature = 'Finish'  ");
        if (dt.Rows.Count > 0)
        {
            ProductId = (int)dt.Rows[0]["ProductId"];
        }
        return ProductId;
    }

    public DataTable GetProduct()
    {

        DataTable dt;
        Smartworks.ColumnField[] gProduct = new Smartworks.ColumnField[1];
        gProduct[0] = new Smartworks.ColumnField("@result", true);

        dt = dataAccess.getDataTableByStoredProcedure("dbo.GetAllProduct", gProduct);

        return dt;
    }



    public DataTable GetProductList()
    {
        DataTable dt = new DataTable();
        dt = dataAccess.getDataTable("Select ProductId , upper(left(ProductName, 1)) + right(ProductName, len(ProductName) - 1) as ProductName  from Product Order by ProductName ");
        return dt;

    }
    public DataTable GetProductListCode()
    {
        DataTable dt = new DataTable();
        dt = dataAccess.getDataTable("Select ProductCode , upper(left(ProductName, 1)) + right(ProductName, len(ProductName) - 1) as ProductName  from Product Order by ProductName ");
        return dt;

    }

    public DataTable GetProductListForSemiAndFinish()
    {
        DataTable dt = new DataTable();
        dt = dataAccess.getDataTable("Select ProductId , upper(left(ProductName, 1)) + right(ProductName, len(ProductName) - 1) as ProductName from Product where ProductNature <> 'RawMaterial'  Order by ProductNature ,  ProductName ");
        return dt;

    }

    public DataTable GetProductListForFinish()
    {
        DataTable dt = new DataTable();
        dt = dataAccess.getDataTable("Select ProductCode , upper(left(ProductName, 1)) + right(ProductName, len(ProductName) - 1) as ProductName from Product where ProductNature = 'Finish'  Order by ProductNature ,  ProductName ");
        return dt;

    }

    public string GetNewGenerateBarcode()
    {
        string code = string.Empty;
        DataTable dt = new DataTable();
        dt = dataAccess.getDataTableByStoredProcedure("GenerateBarcode", null);
        if (dt.Rows.Count > 0)
        {
            code = dt.Rows[0][0].ToString();
        }
        return code;
    }

    public bool IsValidBarcode(string Barcode)
    {
        bool result = false;
        DataTable dt = new DataTable();
        dt = dataAccess.getDataTable("Select * from Product where Barcode = '" + Barcode + "'");
        if (dt.Rows.Count > 0)
        {
            result = true;
            return result;
        }
        return result;
    }

    public DataSet GetAllProductDropDown()
    {
        DataSet dsMain = new DataSet();
        dsMain = dataAccess.getDataSetByStoredProcedure("GetAllProductDropDown", null);
        //GetAllProductDropDown
        return dsMain;
    }


    public bool ProductExists(string ProductName)
    {
        bool result = false;
        if (dataAccess.getDataTable("Select ProductId from Product where rtrim(ltrim(ProductName)) = rtrim(ltrim('" + ProductName + "'))").Rows.Count > 0)
        {
            result = true;
            return result;
        }
        return result;
    }
    public bool ProductExists(string ProductName, int ProductId)
    {
        bool result = false;
        if (dataAccess.getDataTable("Select ProductId from Product where (rtrim(ltrim(ProductName)) = rtrim(ltrim('" + ProductName + "'))) and (ProductId not in ('" + ProductId + "')) ").Rows.Count > 0)
        {
            result = true;
            return result;
        }
        return result;
    }


    public DataTable GetShortItemList()
    {
        DataTable dt =  new DataTable();
        dt = dataAccess.getDataTableByStoredProcedure("GetShortItemList", null);
        return dt;
    }

    #endregion



    #region Product Navigation
    public string GetMinCodeNo()
    {
        string CodeNo = "";
        DataTable dt = new DataTable();

        dt = dataAccess.getDataTable("select min(ProductCode) as 'Code' from dbo.Product");
        if (dt.Rows.Count > 0)
        {
            CodeNo = (string)dt.Rows[0]["Code"];
        }
        return CodeNo;
    }

    public string GetPrevCodeNo(string Code)
    {
        string CodeNo = "";
        DataTable dt = new DataTable();

        dt = dataAccess.getDataTable("Select dbo.GetPreviousNumber('" + Code + "') as Code");
        if (dt.Rows.Count > 0)
        {
            CodeNo = (string)dt.Rows[0]["Code"].ToString();
        }
        return CodeNo;
    }

    public string GetMaxCodeNo()
    {
        string CodeNo = "";
        DataTable dt = new DataTable();

        dt = dataAccess.getDataTable("select max(ProductCode) as 'Code' from dbo.Product");
        if (dt.Rows.Count > 0)
        {
            CodeNo = dt.Rows[0]["Code"].ToString();
        }
        return CodeNo;
    }

    public string GetNextCodeNo(string Code)
    {
        string CodeNo = "";
        DataTable dt = new DataTable();
        dt = dataAccess.getDataTable("Select dbo.GetNextNumber('" + Code + "') as Code ");
        if (dt.Rows.Count > 0)
        {
            CodeNo = (string)dt.Rows[0]["Code"].ToString();
        }
        return CodeNo;
    }

    #endregion

    #region ProductCategoryMethods

    public int InsertProductCatagory(string CategoryName, int ParentId, int AddedBy, DateTime AddedOn,
                                string AddedIpAddr)
    {
        int id = 0;

        Smartworks.ColumnField[] iPCatagory = new Smartworks.ColumnField[5];
        iPCatagory[0] = new Smartworks.ColumnField("@CategoryName", CategoryName);
        iPCatagory[1] = new Smartworks.ColumnField("@ParentId", ParentId);
        iPCatagory[2] = new Smartworks.ColumnField("@AddedBy", AddedBy);
        iPCatagory[3] = new Smartworks.ColumnField("@AddedOn", AddedOn);
        iPCatagory[4] = new Smartworks.ColumnField("@AddedIpAddr", AddedIpAddr);
        dataAccess.BeginTransaction();
        id = Convert.ToInt32(dataAccess.ExecuteStoredProcedure("dbo.InsertProductCategory", iPCatagory));
        dataAccess.TransCommit();
        return id;

    }



    public void UpdateProductCategory(int ProductCategoryId, string CategoryName, int ParentId, int UpdatedBy, DateTime UpdatedOn, string UpdatedIpAddr)
    {
        Smartworks.ColumnField[] uProductCategory = new Smartworks.ColumnField[6];
        uProductCategory[0] = new Smartworks.ColumnField("@ProductCategoryId", ProductCategoryId);
        uProductCategory[1] = new Smartworks.ColumnField("@CategoryName", CategoryName);
        uProductCategory[2] = new Smartworks.ColumnField("@ParentId", ParentId);
        uProductCategory[3] = new Smartworks.ColumnField("@UpdatedBy    ", UpdatedBy);
        uProductCategory[4] = new Smartworks.ColumnField("@UpdatedOn    ", UpdatedOn);
        uProductCategory[5] = new Smartworks.ColumnField("@UpdatedIpAddr", UpdatedIpAddr);

        dataAccess.BeginTransaction();
        dataAccess.ExecuteStoredProcedure("dbo.UpdateProductCategory", uProductCategory);
        dataAccess.TransCommit();
    }


    public int DeleteProductCategory(string ProductCategoryId)
    {
        int id;

        Smartworks.ColumnField[] dProductCategory = new Smartworks.ColumnField[1];
        dProductCategory[0] = new Smartworks.ColumnField("@ProductCategoryId", ProductCategoryId);

        dataAccess.BeginTransaction();
        id = Convert.ToInt32(dataAccess.ExecuteStoredProcedure("dbo.DeleteProductCategory", dProductCategory));

        dataAccess.TransCommit();

        return id;
    }
    public DataTable GetAllProductCategory()
    {
        return dataAccess.getDataTable("select ProductCategoryId , CategoryName from ProductCategory ");
    }
    public DataTable GetProductCategory(int ProductCategoryId)
    {

        DataTable dt;
        dt = dataAccess.getDataTable("Select * from ProductCategory where ProductCategoryId  =" + ProductCategoryId);
        return dt;
    }
    public int GetProductCategoryIdByCode(int ProductCategoryId)
    {
        int GetProductCategoryId = -1;
        DataTable dt = new DataTable();
        dt = dataAccess.getDataTable("Select ProductCategoryId from ProductCategory where ProductCategoryId  = '" + ProductCategoryId + "' ");
        if (dt.Rows.Count > 0)
        {
            GetProductCategoryId = (int)dt.Rows[0]["ProductCategoryId"];
        }
        return GetProductCategoryId;
    }
    public DataTable GetProductCategoryList()
    {
        DataTable dt = new DataTable();
        dt = dataAccess.getDataTable("Select ProductCategoryId , upper(left(CategoryName, 1)) + right(CategoryName, len(CategoryName) - 1) as CategoryName  from ProductCategory Order by CategoryName ");
        return dt;

    }

    #endregion

    #region ProductTypeMethods
    public int InsertProductType(string CategoryName, int AddedBy, DateTime AddedOn,
                              string AddedIpAddr)
    {
        int id = 0;

        Smartworks.ColumnField[] iPCatagory = new Smartworks.ColumnField[4];
        iPCatagory[0] = new Smartworks.ColumnField("@Description ", CategoryName);
        iPCatagory[1] = new Smartworks.ColumnField("@AddedBy      ", AddedBy);
        iPCatagory[2] = new Smartworks.ColumnField("@AddedOn      ", AddedOn);
        iPCatagory[3] = new Smartworks.ColumnField("@AddedIpAddr  ", AddedIpAddr);
        dataAccess.BeginTransaction();
        id = Convert.ToInt32(dataAccess.ExecuteStoredProcedure("dbo.InsertProductType", iPCatagory));
        dataAccess.TransCommit();
        return id;

    }
    public void UpdateProductType(int ProductCategoryId, string CategoryName, int UpdatedBy, DateTime UpdatedOn, string UpdatedIpAddr)
    {
        Smartworks.ColumnField[] uProductCategory = new Smartworks.ColumnField[5];
        uProductCategory[0] = new Smartworks.ColumnField("@ProductTypeId", ProductCategoryId);
        uProductCategory[1] = new Smartworks.ColumnField("@Description", CategoryName);
        uProductCategory[2] = new Smartworks.ColumnField("@UpdatedBy    ", UpdatedBy);
        uProductCategory[3] = new Smartworks.ColumnField("@UpdatedOn    ", UpdatedOn);
        uProductCategory[4] = new Smartworks.ColumnField("@UpdatedIpAddr", UpdatedIpAddr);

        dataAccess.BeginTransaction();
        dataAccess.ExecuteStoredProcedure("dbo.UpdateProductType", uProductCategory);
        dataAccess.TransCommit();
    }


    public int DeleteProductType(string ProductCategoryId)
    {
        int id;

        Smartworks.ColumnField[] dProductCategory = new Smartworks.ColumnField[1];
        dProductCategory[0] = new Smartworks.ColumnField("@ProductTypeId", ProductCategoryId);

        dataAccess.BeginTransaction();
        id = Convert.ToInt32(dataAccess.ExecuteStoredProcedure("dbo.DeleteProductType", dProductCategory));

        dataAccess.TransCommit();

        return id;
    }

    public DataTable GetAllProductType()
    {
        return dataAccess.getDataTable("select ProductTypeId , Description from ProductType ");
    }

    public DataTable GetProductType(int ProductCategoryId)
    {

        DataTable dt;
        dt = dataAccess.getDataTable("Select * from ProductType where ProductTypeId  =" + ProductCategoryId);
        return dt;
    }



    public int GetProductTypeIdByCode(int ProductCategoryId)
    {
        int GetProductCategoryId = -1;
        DataTable dt = new DataTable();
        dt = dataAccess.getDataTable("Select ProductTypeId from ProductType where ProductTypeId  = '" + ProductCategoryId + "' ");
        if (dt.Rows.Count > 0)
        {
            GetProductCategoryId = (int)dt.Rows[0]["ProductTypeId"];
        }
        return GetProductCategoryId;
    }

    //public DataTable GetProductTypeList()
    //{
    //    DataTable dt = new DataTable();
    //    dt = dataAccess.getDataTable("Select ProductTypeId , upper(left(Name, 1)) + right(Name, len(Name) - 1) as Description  from ProductType Order by Name ");
    //    return dt;

    //}
    #endregion

    #region ProductColorMethods
    public int InsertProductColor(string ColorName, int AddedBy, DateTime AddedOn,
                              string AddedIpAddr)
    {
        int id = 0;

        Smartworks.ColumnField[] iPCatagory = new Smartworks.ColumnField[4];
        iPCatagory[0] = new Smartworks.ColumnField("@ColorName", ColorName);
        iPCatagory[1] = new Smartworks.ColumnField("@AddedBy", AddedBy);
        iPCatagory[2] = new Smartworks.ColumnField("@AddedOn", AddedOn);
        iPCatagory[3] = new Smartworks.ColumnField("@AddedIpAddr", AddedIpAddr);
        dataAccess.BeginTransaction();
        id = Convert.ToInt32(dataAccess.ExecuteStoredProcedure("dbo.InsertProductColor", iPCatagory));
        dataAccess.TransCommit();
        return id;

    }
    public void UpdateProductColor(int ColorId, string ColorName, int UpdatedBy, DateTime UpdatedOn, string UpdatedIpAddr)
    {
        Smartworks.ColumnField[] uProductCategory = new Smartworks.ColumnField[5];
        uProductCategory[0] = new Smartworks.ColumnField("@ColorId", ColorId);
        uProductCategory[1] = new Smartworks.ColumnField("@ColorName", ColorName);
        uProductCategory[2] = new Smartworks.ColumnField("@UpdatedBy", UpdatedBy);
        uProductCategory[3] = new Smartworks.ColumnField("@UpdatedOn", UpdatedOn);
        uProductCategory[4] = new Smartworks.ColumnField("@UpdatedIpAddr", UpdatedIpAddr);

        dataAccess.BeginTransaction();
        dataAccess.ExecuteStoredProcedure("dbo.UpdateProductColor", uProductCategory);
        dataAccess.TransCommit();
    }

    public int DeleteProductColor(int ColorId)
    {
        int id;

        Smartworks.ColumnField[] dProductCategory = new Smartworks.ColumnField[1];
        dProductCategory[0] = new Smartworks.ColumnField("@ColorId", ColorId);

        dataAccess.BeginTransaction();
        id = Convert.ToInt32(dataAccess.ExecuteStoredProcedure("dbo.DeleteProductColor", dProductCategory));

        dataAccess.TransCommit();

        return id;
    }

    public DataTable GetAllProductColor()
    {
        return dataAccess.getDataTable("select ColorId , ColorName from ProductColor ");
    }

    public DataTable GetProductColor(int ColorId)
    {
        DataTable dt;
        dt = dataAccess.getDataTable("Select * from ProductColor where ColorId  =" + ColorId);
        return dt;
    }

    public int GetProductColorIdByCode(int ColorId)
    {
        int GetProductCategoryId = -1;
        DataTable dt = new DataTable();
        dt = dataAccess.getDataTable("Select ColorId from ProductColor where ColorId  = '" + ColorId + "' ");
        if (dt.Rows.Count > 0)
        {
            GetProductCategoryId = (int)dt.Rows[0]["ColorId"];
        }
        return GetProductCategoryId;
    }

    public DataTable GetProductColorList()
    {
        DataTable dt = new DataTable();
        dt = dataAccess.getDataTable("Select ColorId , upper(left(ColorName, 1)) + right(ColorName, len(ColorName) - 1) as Description  from ProductColor Order by ColorName ");
        return dt;

    }

    public DataTable GetProductTypeList()
    {
        DataTable dt = new DataTable();
        dt = dataAccess.getDataTable("Select ProductTypeId  , upper(left(Description, 1)) + right(Description, len(Description) - 1) as ProductType  from ProductType Order by Description ");
        return dt;

    }
    #endregion


    #region ProductSizeMethods
    public int InsertProductSize(string SizeName, int AddedBy, DateTime AddedOn,
                              string AddedIpAddr)
    {
        int id = 0;

        Smartworks.ColumnField[] iPSize = new Smartworks.ColumnField[4];
        iPSize[0] = new Smartworks.ColumnField("@SizeName", SizeName);
        iPSize[1] = new Smartworks.ColumnField("@AddedBy", AddedBy);
        iPSize[2] = new Smartworks.ColumnField("@AddedOn", AddedOn);
        iPSize[3] = new Smartworks.ColumnField("@AddedIpAddr", AddedIpAddr);
        dataAccess.BeginTransaction();
        id = Convert.ToInt32(dataAccess.ExecuteStoredProcedure("dbo.InsertProductSize", iPSize));
        dataAccess.TransCommit();
        return id;

    }
    public void UpdateProductSize(int SizeId, string SizeName, int UpdatedBy, DateTime UpdatedOn, string UpdatedIpAddr)
    {
        Smartworks.ColumnField[] uProductSize = new Smartworks.ColumnField[5];
        uProductSize[0] = new Smartworks.ColumnField("@SizeId", SizeId);
        uProductSize[1] = new Smartworks.ColumnField("@SizeName", SizeName);
        uProductSize[2] = new Smartworks.ColumnField("@UpdatedBy", UpdatedBy);
        uProductSize[3] = new Smartworks.ColumnField("@UpdatedOn", UpdatedOn);
        uProductSize[4] = new Smartworks.ColumnField("@UpdatedIpAddr", UpdatedIpAddr);

        dataAccess.BeginTransaction();
        dataAccess.ExecuteStoredProcedure("dbo.UpdateProductSize", uProductSize);
        dataAccess.TransCommit();
    }

    public int DeleteProductSize(int SizeId)
    {
        int id;

        Smartworks.ColumnField[] dProductSize = new Smartworks.ColumnField[1];
        dProductSize[0] = new Smartworks.ColumnField("@SizeId", SizeId);

        dataAccess.BeginTransaction();
        id = Convert.ToInt32(dataAccess.ExecuteStoredProcedure("dbo.DeleteProductSize", dProductSize));

        dataAccess.TransCommit();

        return id;
    }

    public DataTable GetAllProductSize()
    {
        return dataAccess.getDataTable("select SizeId , SizeName from ProductSize ");
    }

    public DataTable GetProductSize(int SizeId)
    {
        DataTable dt;
        dt = dataAccess.getDataTable("Select * from ProductSize where SizeId  =" + SizeId);
        return dt;
    }

    public int GetProductSizeIdByCode(int SizeId)
    {
        int GetProductSizeId = -1;
        DataTable dt = new DataTable();
        dt = dataAccess.getDataTable("Select SizeId from ProductSize where SizeId  = '" + SizeId + "' ");
        if (dt.Rows.Count > 0)
        {
            GetProductSizeId = (int)dt.Rows[0]["SizeId"];
        }
        return GetProductSizeId;
    }

    public int GetProductSizeIdByString(string SizeName)
    {
        int GetProductSizeId = -1;
        DataTable dt = new DataTable();
        dt = dataAccess.getDataTable("Select SizeId from ProductSize where SizeName = Ltrim(Rtrim('" + SizeName.ToString().Trim() + "'))");
        if (dt.Rows.Count > 0)
        {
            GetProductSizeId = (int)dt.Rows[0]["SizeId"];
        }
        return GetProductSizeId;
    }

    public DataTable GetProductSizeList()
    {
        DataTable dt = new DataTable();
        dt = dataAccess.getDataTable("Select SizeId , upper(left(SizeName, 1)) + right(SizeName, len(SizeName) - 1) as Description  from ProductSize Order by SizeName ");
        return dt;

    }
    #endregion

    #region MesurementMethod
    public int InsertMesurementUnit(string MesurementName, decimal ConversionRate, int AddedBy, DateTime AddedOn,
                              string AddedIpAddr)
    {
        int id = 0;

        Smartworks.ColumnField[] iMesurementUnit = new Smartworks.ColumnField[5];
        iMesurementUnit[0] = new Smartworks.ColumnField("@MesurementName", MesurementName);
        iMesurementUnit[1] = new Smartworks.ColumnField("@ConversionRate", ConversionRate);
        iMesurementUnit[2] = new Smartworks.ColumnField("@AddedBy", AddedBy);
        iMesurementUnit[3] = new Smartworks.ColumnField("@AddedOn", AddedOn);
        iMesurementUnit[4] = new Smartworks.ColumnField("@AddedIpAddr", AddedIpAddr);
        dataAccess.BeginTransaction();
        id = Convert.ToInt32(dataAccess.ExecuteStoredProcedure("dbo.InsertMesurementUnit", iMesurementUnit));
        dataAccess.TransCommit();
        return id;

    }
    public void UpdateMesurementUnit(int MesurementId, string MesurementName, decimal ConversionRate, int UpdatedBy, DateTime UpdatedOn, string UpdatedIpAddr)
    {
        Smartworks.ColumnField[] uMesurementUnit = new Smartworks.ColumnField[6];
        uMesurementUnit[0] = new Smartworks.ColumnField("@MesurementId", MesurementId);
        uMesurementUnit[1] = new Smartworks.ColumnField("@MesurementName", MesurementName);
        uMesurementUnit[2] = new Smartworks.ColumnField("@ConversionRate", ConversionRate);
        uMesurementUnit[3] = new Smartworks.ColumnField("@UpdatedBy", UpdatedBy);
        uMesurementUnit[4] = new Smartworks.ColumnField("@UpdatedOn", UpdatedOn);
        uMesurementUnit[5] = new Smartworks.ColumnField("@UpdatedIpAddr", UpdatedIpAddr);

        dataAccess.BeginTransaction();
        dataAccess.ExecuteStoredProcedure("dbo.UpdateMesurementUnit", uMesurementUnit);
        dataAccess.TransCommit();
    }

    public int DeleteMesurementUnit(int MesurementId)
    {
        int id;

        Smartworks.ColumnField[] dMesurementUnit = new Smartworks.ColumnField[1];
        dMesurementUnit[0] = new Smartworks.ColumnField("@MesurementId", MesurementId);

        dataAccess.BeginTransaction();
        id = Convert.ToInt32(dataAccess.ExecuteStoredProcedure("dbo.DeleteMesurementUnit", dMesurementUnit));

        dataAccess.TransCommit();

        return id;
    }

    public DataTable GetAllMesurementUnit()
    {
        return dataAccess.getDataTable("select MesurementId , MesurementName from MesurementUnit ");
    }

    public DataTable GetMesurementUnit(int MesurementId)
    {
        DataTable dt;
        dt = dataAccess.getDataTable("Select * from MesurementUnit where MesurementId  =" + MesurementId);
        return dt;
    }

    public int GetMesurementUnitIdByCode(int MesurementId)
    {
        int GetMesurementUnitId = -1;
        DataTable dt = new DataTable();
        dt = dataAccess.getDataTable("Select MesurementId from MesurementUnit where MesurementId  = '" + MesurementId + "' ");
        if (dt.Rows.Count > 0)
        {
            GetMesurementUnitId = (int)dt.Rows[0]["MesurementId"];
        }
        return GetMesurementUnitId;
    }

    public DataTable GetMesurementUnitList()
    {
        DataTable dt = new DataTable();
        dt = dataAccess.getDataTable("Select MesurementId , upper(left(MesurementName, 1)) + right(MesurementName, len(MesurementName) - 1) as MesurementName  from MesurementUnit Order by MesurementName ");
        return dt;

    }
    #endregion



    #region ProductLedgerMethods

    //yeh wo method hai jo insert and update dono kaam handle kerta hai by Flag Status.
    public int InsertUpdateProductLedgerByFlagIO(int ProductId, DateTime Date,
                          string TransNo, int TranDetailId, string FlagInOut, decimal Quantity, decimal Price,
                          decimal DiscountPercent, decimal DiscountAmount, decimal GSTPercent, decimal GSTAmount,
                          int UpdatedBy, DateTime UpdatedOn, string UpdatedIpAddr, string BatchNo, Nullable<DateTime> ExpiryDate, string Remarks, int WarehouseId, int SizeId = -1,
                          Smartworks.DAL customdataAcess = null)
    {
        int id = 0;
        Smartworks.ColumnField[] iProductLedger = new Smartworks.ColumnField[19];
        iProductLedger[0] = new Smartworks.ColumnField("@ProductId", ProductId);
        iProductLedger[1] = new Smartworks.ColumnField("@Date", Date);
        iProductLedger[2] = new Smartworks.ColumnField("@TransNo", TransNo);
        iProductLedger[3] = new Smartworks.ColumnField("@TranDetailId", TranDetailId);
        iProductLedger[4] = new Smartworks.ColumnField("@FlagInOut", FlagInOut);
        iProductLedger[5] = new Smartworks.ColumnField("@Quantity", Quantity);
        iProductLedger[6] = new Smartworks.ColumnField("@Price", Price);
        iProductLedger[7] = new Smartworks.ColumnField("@DiscountPercent", DiscountPercent);
        iProductLedger[8] = new Smartworks.ColumnField("@DiscountAmount", DiscountAmount);
        iProductLedger[9] = new Smartworks.ColumnField("@GSTPercent", GSTPercent);
        iProductLedger[10] = new Smartworks.ColumnField("@GSTAmount", GSTAmount);
        iProductLedger[11] = new Smartworks.ColumnField("@AddedBy", UpdatedBy);
        iProductLedger[12] = new Smartworks.ColumnField("@AddedOn", UpdatedOn);
        iProductLedger[13] = new Smartworks.ColumnField("@AddedIpAddr", UpdatedIpAddr);
        iProductLedger[14] = new Smartworks.ColumnField("@BatchNo", BatchNo);
        if (ExpiryDate == null)
        {
            iProductLedger[15] = new Smartworks.ColumnField("@ExpiryDate", DBNull.Value);
        }
        else
        {
            iProductLedger[15] = new Smartworks.ColumnField("@ExpiryDate", ExpiryDate);
        }
        iProductLedger[16] = new Smartworks.ColumnField("@WarehouseId", WarehouseId);
        iProductLedger[17] = new Smartworks.ColumnField("@Remarks", Remarks);
        iProductLedger[18] = new Smartworks.ColumnField("@SizeId", SizeId);

        if (customdataAcess != null)
        {
            id = Convert.ToInt32(customdataAcess.ExecuteStoredProcedure("dbo.InsertUpdateProductLedgerByFlagIO", iProductLedger));
        }
        else
        {
            dataAccess.BeginTransaction();
            id = Convert.ToInt32(dataAccess.ExecuteStoredProcedure("dbo.InsertUpdateProductLedgerByFlagIO", iProductLedger));
            dataAccess.TransCommit();
        }

        return id;

    }

    //yeh wo method hai jo insert and update dono kaam handle kerta hai .
    public int InsertUpdateProductLedger(int ProductId, DateTime Date,
                           string TransNo, int TranDetailId, string FlagInOut, decimal Quantity, decimal Price,
                           decimal DiscountPercent, decimal DiscountAmount, decimal GSTPercent, decimal GSTAmount,
                           int UpdatedBy, DateTime UpdatedOn, string UpdatedIpAddr, string BatchNo, Nullable<DateTime> ExpiryDate, int WarehouseId, int SizeId = -1,
                           Smartworks.DAL customdataAcess = null)
    {
        int id = 0;
        Smartworks.ColumnField[] iProductLedger = new Smartworks.ColumnField[18];
        iProductLedger[0] = new Smartworks.ColumnField("@ProductId", ProductId);
        iProductLedger[1] = new Smartworks.ColumnField("@Date", Date);
        iProductLedger[2] = new Smartworks.ColumnField("@TransNo", TransNo);
        iProductLedger[3] = new Smartworks.ColumnField("@TranDetailId", TranDetailId);
        iProductLedger[4] = new Smartworks.ColumnField("@FlagInOut", FlagInOut);
        iProductLedger[5] = new Smartworks.ColumnField("@Quantity", Quantity);
        iProductLedger[6] = new Smartworks.ColumnField("@Price", Price);
        iProductLedger[7] = new Smartworks.ColumnField("@DiscountPercent", DiscountPercent);
        iProductLedger[8] = new Smartworks.ColumnField("@DiscountAmount", DiscountAmount);
        iProductLedger[9] = new Smartworks.ColumnField("@GSTPercent", GSTPercent);
        iProductLedger[10] = new Smartworks.ColumnField("@GSTAmount", GSTAmount);
        iProductLedger[11] = new Smartworks.ColumnField("@AddedBy", UpdatedBy);
        iProductLedger[12] = new Smartworks.ColumnField("@AddedOn", UpdatedOn);
        iProductLedger[13] = new Smartworks.ColumnField("@AddedIpAddr", UpdatedIpAddr);
        iProductLedger[14] = new Smartworks.ColumnField("@BatchNo", BatchNo);
        if (ExpiryDate == null)
        {
            iProductLedger[15] = new Smartworks.ColumnField("@ExpiryDate", DBNull.Value);
        }
        else
        {
            iProductLedger[15] = new Smartworks.ColumnField("@ExpiryDate", ExpiryDate);
        }
        iProductLedger[16] = new Smartworks.ColumnField("@WarehouseId", WarehouseId);
        iProductLedger[17] = new Smartworks.ColumnField("@SizeId", SizeId);

        if (customdataAcess != null)
        {
            id = Convert.ToInt32(customdataAcess.ExecuteStoredProcedure("dbo.InsertUpdateProductLedger", iProductLedger));
        }
        else
        {
            dataAccess.BeginTransaction();
            id = Convert.ToInt32(dataAccess.ExecuteStoredProcedure("dbo.InsertUpdateProductLedger", iProductLedger));
            dataAccess.TransCommit();
        }

        return id;

    }

    public int InsertProductLedger(int ProductId, DateTime Date,
                          string TransNo, int TranDetailId, string FlagInOut, decimal Quantity, decimal Price,
                          decimal DiscountPercent, decimal DiscountAmount, decimal GSTPercent, decimal GSTAmount,
                          int UpdatedBy, DateTime UpdatedOn, string UpdatedIpAddr, string BatchNo, Nullable<DateTime> ExpiryDate, string Remarks, int WarehouseId, int SizeId = -1, string Grade= "A"  ,   Smartworks.DAL customdataAcess = null)
    {
        int id = 0;
        Smartworks.ColumnField[] iProductLedger = new Smartworks.ColumnField[20];
        iProductLedger[0] = new Smartworks.ColumnField("@ProductId", ProductId);
        iProductLedger[1] = new Smartworks.ColumnField("@Date", Date);
        iProductLedger[2] = new Smartworks.ColumnField("@TransNo", TransNo);
        iProductLedger[3] = new Smartworks.ColumnField("@TranDetailId", TranDetailId);
        iProductLedger[4] = new Smartworks.ColumnField("@FlagInOut", FlagInOut);
        iProductLedger[5] = new Smartworks.ColumnField("@Quantity", Quantity);
        iProductLedger[6] = new Smartworks.ColumnField("@Price", Price);
        iProductLedger[7] = new Smartworks.ColumnField("@DiscountPercent", DiscountPercent);
        iProductLedger[8] = new Smartworks.ColumnField("@DiscountAmount", DiscountAmount);
        iProductLedger[9] = new Smartworks.ColumnField("@GSTPercent", GSTPercent);
        iProductLedger[10] = new Smartworks.ColumnField("@GSTAmount", GSTAmount);
        iProductLedger[11] = new Smartworks.ColumnField("@AddedBy", UpdatedBy);
        iProductLedger[12] = new Smartworks.ColumnField("@AddedOn", UpdatedOn);
        iProductLedger[13] = new Smartworks.ColumnField("@AddedIpAddr", UpdatedIpAddr);
        iProductLedger[14] = new Smartworks.ColumnField("@BatchNo", BatchNo);
        if (ExpiryDate == null)
        {
            iProductLedger[15] = new Smartworks.ColumnField("@ExpiryDate", DBNull.Value);
        }
        else
        {
            iProductLedger[15] = new Smartworks.ColumnField("@ExpiryDate", ExpiryDate);
        }
        iProductLedger[16] = new Smartworks.ColumnField("@WarehouseId", WarehouseId);
        iProductLedger[17] = new Smartworks.ColumnField("@SizeId", SizeId);
        iProductLedger[18] = new Smartworks.ColumnField("@Remarks", Remarks);
        iProductLedger[19] = new Smartworks.ColumnField("@Grade", Grade);
        

        if (customdataAcess != null)
        {
            id = Convert.ToInt32(customdataAcess.ExecuteStoredProcedure("dbo.InsertProductLedger", iProductLedger));
        }
        else
        {
            dataAccess.BeginTransaction();
            id = Convert.ToInt32(dataAccess.ExecuteStoredProcedure("dbo.InsertProductLedger", iProductLedger));
            dataAccess.TransCommit();
        }

        return id;

    }

    public void UpdateProductLedger(int StockLedgerId, int ProductId, DateTime Date,
                             string TransNo, string FlagInOut, decimal Quantity, decimal Price,
                             decimal DiscountPercent, decimal DiscountAmount, decimal GSTPercent, decimal GSTAmount,
                             int AddedBy, DateTime AddedOn, string AddedIpAddr,
                             Smartworks.DAL customdataAcess = null)
    {
        Smartworks.ColumnField[] uProductLedger = new Smartworks.ColumnField[15];
        uProductLedger[0] = new Smartworks.ColumnField("@StockLedgerId", StockLedgerId);
        uProductLedger[1] = new Smartworks.ColumnField("@ProductId", ProductId);
        uProductLedger[2] = new Smartworks.ColumnField("@Date", Date);
        uProductLedger[3] = new Smartworks.ColumnField("@TransNo", TransNo);
        uProductLedger[4] = new Smartworks.ColumnField("@FlagInOut", FlagInOut);
        uProductLedger[5] = new Smartworks.ColumnField("@Quantity", Quantity);
        uProductLedger[6] = new Smartworks.ColumnField("@Price", Price);
        uProductLedger[7] = new Smartworks.ColumnField("@DiscountPercent", DiscountPercent);
        uProductLedger[8] = new Smartworks.ColumnField("@DiscountAmount", DiscountAmount);
        uProductLedger[9] = new Smartworks.ColumnField("@GSTPercent", GSTPercent);
        uProductLedger[10] = new Smartworks.ColumnField("@GSTAmount", GSTAmount);
        uProductLedger[11] = new Smartworks.ColumnField("@GSTAmount", GSTAmount);
        uProductLedger[12] = new Smartworks.ColumnField("@UpdatedBy", AddedBy);
        uProductLedger[13] = new Smartworks.ColumnField("@UpdatedOn", AddedOn);
        uProductLedger[14] = new Smartworks.ColumnField("@UpdatedIpAddr", AddedIpAddr);
        dataAccess.BeginTransaction();
        dataAccess.ExecuteStoredProcedure("dbo.UpdateProductLedger", uProductLedger);
        dataAccess.TransCommit();
    }


    public int DeleteProductLedger(string StockLedgerId)
    {
        int id;
        Smartworks.ColumnField[] dStockLedger = new Smartworks.ColumnField[1];
        dStockLedger[0] = new Smartworks.ColumnField("@StockLedgerId", StockLedgerId);
        dataAccess.BeginTransaction();
        id = Convert.ToInt32(dataAccess.ExecuteStoredProcedure("dbo.DeleteProductLedger", dStockLedger));
        dataAccess.TransCommit();
        return id;
    }

    public void DeleteProductLedgerByTransNo(string TransNo, Smartworks.DAL customdataAccess = null)
    {
        Smartworks.ColumnField[] dStockLedger = new Smartworks.ColumnField[1];
        dStockLedger[0] = new Smartworks.ColumnField("@TransNo", TransNo);
        if (customdataAccess != null)
        {
            customdataAccess.ExecuteStoredProcedure("dbo.DeleteProductLedgerByTransNo", dStockLedger);
        }
        else
        {
            dataAccess.BeginTransaction();
            dataAccess.ExecuteStoredProcedure("dbo.DeleteProductLedgerByTransNo", dStockLedger);
            dataAccess.TransCommit();
        }

    }


    public void DeleteFinishFromProductLedgerByTransNo(string TransNo, Smartworks.DAL customdataAccess = null)
    {
        Smartworks.ColumnField[] dStockLedger = new Smartworks.ColumnField[1];
        dStockLedger[0] = new Smartworks.ColumnField("@TransNo", TransNo);
        if (customdataAccess != null)
        {
            customdataAccess.ExecuteStoredProcedure("dbo.DeleteFinishFromProductLedgerByTransNo", dStockLedger);
        }
        else
        {
            dataAccess.BeginTransaction();
            dataAccess.ExecuteStoredProcedure("dbo.DeleteFinishFromProductLedgerByTransNo", dStockLedger);
            dataAccess.TransCommit();
        }

    }

    public void DeleteProductLedgerByTransNo(string TransNo, bool IsAllyear ,  Smartworks.DAL customdataAccess = null)
    {
        Smartworks.ColumnField[] dStockLedger = new Smartworks.ColumnField[1];
        dStockLedger[0] = new Smartworks.ColumnField("@TransNo", TransNo);
        if (customdataAccess != null)
        {
            if (IsAllyear)
            {
                customdataAccess.ExecuteStoredProcedure("dbo.DeleteProductLedgerByTransNoAllYear", dStockLedger);
            }
            else
            {
                customdataAccess.ExecuteStoredProcedure("dbo.DeleteProductLedgerByTransNo", dStockLedger);
            }
            
        }
        else
        {
            dataAccess.BeginTransaction();
            if (IsAllyear)
            {
                dataAccess.ExecuteStoredProcedure("dbo.DeleteProductLedgerByTransNoAllYear", dStockLedger);
            }
            else
            {
                dataAccess.ExecuteStoredProcedure("dbo.DeleteProductLedgerByTransNo", dStockLedger);
            }
            
            dataAccess.TransCommit();
        }

    }

    public void DeleteProductFromLedgerByTransNoAndDetailId(string TransNo, int DetailId, Smartworks.DAL customdataAccess = null)
    {
        Smartworks.ColumnField[] dStockLedger = new Smartworks.ColumnField[2];
        dStockLedger[0] = new Smartworks.ColumnField("@TransNo", TransNo);
        dStockLedger[1] = new Smartworks.ColumnField("@DetailId", DetailId);
        if (customdataAccess != null)
        {
            customdataAccess.ExecuteStoredProcedure("dbo.sp_DeleteProductLedgerByTranNoAndDetailId", dStockLedger);
        }
        else
        {
            dataAccess.BeginTransaction();
            dataAccess.ExecuteStoredProcedure("dbo.sp_DeleteProductLedgerByTranNoAndDetailId", dStockLedger);
            dataAccess.TransCommit();
        }

    }


    public void DeleteProductFromLedgerByTransNoAndDetailIdForPurchase(string TransNo, int DetailId, Smartworks.DAL customdataAccess = null)
    {
        Smartworks.ColumnField[] dStockLedger = new Smartworks.ColumnField[2];
        dStockLedger[0] = new Smartworks.ColumnField("@TransNo", TransNo);
        dStockLedger[1] = new Smartworks.ColumnField("@DetailId", DetailId);
        if (customdataAccess != null)
        {
            customdataAccess.ExecuteStoredProcedure("dbo.sp_DeleteProductLedgerByPurchaseId", dStockLedger);
        }
        else
        {
            dataAccess.BeginTransaction();
            dataAccess.ExecuteStoredProcedure("dbo.sp_DeleteProductLedgerByPurchaseId", dStockLedger);
            dataAccess.TransCommit();
        }

    }


    public void DeleteProductFromLedgerByTransNoAndDetailIdForSales(string TransNo, int DetailId, Smartworks.DAL customdataAccess = null)
    {
        Smartworks.ColumnField[] dStockLedger = new Smartworks.ColumnField[2];
        dStockLedger[0] = new Smartworks.ColumnField("@TransNo", TransNo);
        dStockLedger[0] = new Smartworks.ColumnField("@DetailId", DetailId);
        if (customdataAccess != null)
        {
            customdataAccess.ExecuteStoredProcedure("dbo.sp_DeleteProductLedgerBySalesId", dStockLedger);
        }
        else
        {
            dataAccess.BeginTransaction();
            dataAccess.ExecuteStoredProcedure("dbo.sp_DeleteProductLedgerBySalesId", dStockLedger);
            dataAccess.TransCommit();
        }

    }



    public DataTable GetProductLedger(int StockLedgerId)
    {

        DataTable dt;
        dt = dataAccess.getDataTable("Select * from ProductLedger where StockLedgerId =" + StockLedgerId);
        return dt;
    }


    public DataTable GetProductLedgerReport(Nullable<DateTime> FromDate, Nullable<DateTime> ToDate, string FromCode, string ToCode, int CategoryId, int WarehouseId)
    {

        DataTable dt = new DataTable();
        Smartworks.ColumnField[] report = new Smartworks.ColumnField[6];
        if (FromDate == null)
        {
            report[0] = new Smartworks.ColumnField("@FromDate", DBNull.Value);
        }
        else
        {
            report[0] = new Smartworks.ColumnField("@FromDate", FromDate);
        }
        if (ToDate == null)
        {
            report[1] = new Smartworks.ColumnField("@ToDate", DBNull.Value);
        }
        else
        {
            report[1] = new Smartworks.ColumnField("@ToDate", ToDate);
        }

        report[2] = new Smartworks.ColumnField("@FromProductCode", FromCode);
        report[3] = new Smartworks.ColumnField("@ToProductCode", ToCode);
        report[4] = new Smartworks.ColumnField("@CategoryId", CategoryId);
        report[5] = new Smartworks.ColumnField("@WarehouseId", WarehouseId);


        dt = dataAccess.getDataTableByStoredProcedure("sp_ReportProductLedger", report);
        return dt;
    }

    #endregion


    #region ProductFormula

    public DataSet GetProductFormulaStructure(int FormulaId)
    {
        DataSet ds = new DataSet();
        Smartworks.ColumnField[] gFormula = new Smartworks.ColumnField[1];
        gFormula[0] = new Smartworks.ColumnField("@FormulaMasterId", FormulaId);
        ds = dataAccess.getDataSetByStoredProcedure("sp_GetProductFormulaStructure", gFormula);
        return ds;
    }

    public DataTable GetProductFormulaMaster(int FormulaId)
    {
        return dataAccess.getDataTable("Select * from ProductFormulaMaster  where FormulaMasterId = '" + FormulaId + "' ");
    }

    public DataSet GetProductAssumptionStructure(int FormulaId, int Qty, string SOrderNo, int S39, int S40, int S41, int S42, int S43, int S44, int S45, int S46, int S47)
    {
        DataSet ds = new DataSet();
        Smartworks.ColumnField[] gFormula = new Smartworks.ColumnField[12];
        gFormula[0] = new Smartworks.ColumnField("@FormulaMasterId", FormulaId);
        gFormula[1] = new Smartworks.ColumnField("@Qty", Qty);
        gFormula[2] = new Smartworks.ColumnField("@SOrderNo", SOrderNo);
        gFormula[3] = new Smartworks.ColumnField("@S39", S39);
        gFormula[4] = new Smartworks.ColumnField("@S40", S40);
        gFormula[5] = new Smartworks.ColumnField("@S41", S41);
        gFormula[6] = new Smartworks.ColumnField("@S42", S42);
        gFormula[7] = new Smartworks.ColumnField("@S43", S43);
        gFormula[8] = new Smartworks.ColumnField("@S44", S44);
        gFormula[9] = new Smartworks.ColumnField("@S45", S45);
        gFormula[10] = new Smartworks.ColumnField("@S46", S46);
        gFormula[11] = new Smartworks.ColumnField("@S47", S47);
        ds = dataAccess.getDataSetByStoredProcedure("sp_GetProductAssumptionStructure", gFormula);
        return ds;
    }

    public int InsertProductFormulaMaster(string FormulaName, int ProductId, string Remarks, int LastNoId, bool IsActive, int AddedBy, DateTime AddedOn, string AddedIPAddr, Smartworks.DAL customDataAcess = null)
    {
        int id = -1;

        Smartworks.ColumnField[] iFormulaMaster = new Smartworks.ColumnField[8];
        iFormulaMaster[0] = new Smartworks.ColumnField("@FormulaName", FormulaName);
        iFormulaMaster[1] = new Smartworks.ColumnField("@ProductId", ProductId);
        iFormulaMaster[2] = new Smartworks.ColumnField("@Remarks", Remarks);
        iFormulaMaster[3] = new Smartworks.ColumnField("@LastNoId", LastNoId);
        iFormulaMaster[4] = new Smartworks.ColumnField("@IsActive", IsActive);
        iFormulaMaster[5] = new Smartworks.ColumnField("@AddedBy", AddedBy);
        iFormulaMaster[6] = new Smartworks.ColumnField("@AddedOn", AddedOn);
        iFormulaMaster[7] = new Smartworks.ColumnField("@AddedIPAddr", AddedIPAddr);

        if (customDataAcess != null)
        {
            id = Convert.ToInt32(customDataAcess.ExecuteStoredProcedure("InsertProductFormulaMaster", iFormulaMaster));
        }
        else
        {
            dataAccess.BeginTransaction();
            id = Convert.ToInt32(dataAccess.ExecuteStoredProcedure("InsertProductFormulaMaster", iFormulaMaster));
            dataAccess.TransCommit();
        }


        return id;
    }


    public void UpdateProductFormulaMaster(int FormulaMasterId, string FormulaName, int ProductId, string Remarks, int LastNoId, bool IsActive, int UpdatedBy,
        DateTime UpdatedOn, string UpdatedIPAddr, Smartworks.DAL customDataAcess = null)
    {
        Smartworks.ColumnField[] uFormulaMaster = new Smartworks.ColumnField[9];
        uFormulaMaster[0] = new Smartworks.ColumnField("@FormulaMasterId", FormulaMasterId);
        uFormulaMaster[1] = new Smartworks.ColumnField("@FormulaName", FormulaName);
        uFormulaMaster[2] = new Smartworks.ColumnField("@ProductId", ProductId);
        uFormulaMaster[3] = new Smartworks.ColumnField("@Remarks", Remarks);
        uFormulaMaster[4] = new Smartworks.ColumnField("@LastNoId", LastNoId);
        uFormulaMaster[5] = new Smartworks.ColumnField("@IsActive", IsActive);
        uFormulaMaster[6] = new Smartworks.ColumnField("@UpdatedBy", UpdatedBy);
        uFormulaMaster[7] = new Smartworks.ColumnField("@UpdatedOn", UpdatedOn);
        uFormulaMaster[8] = new Smartworks.ColumnField("@UpdatedIPAddr", UpdatedIPAddr);

        if (customDataAcess != null)
        {
            customDataAcess.ExecuteStoredProcedure("UpdateProductFormulaMaster", uFormulaMaster);
        }
        else
        {
            dataAccess.BeginTransaction();
            dataAccess.ExecuteStoredProcedure("UpdateProductFormulaMaster", uFormulaMaster);
            dataAccess.TransCommit();
        }

    }

    public void UpdateUnActiveOtherReceipy(int FormulaMasterId, int ProductId, Smartworks.DAL customDataAcess = null)
    {
        if (customDataAcess != null)
        {
            customDataAcess.ExecuteNonQuery("Update [ProductFormulaMaster]  set  IsActive = 0 where ProductId = '" + ProductId + "' and FormulaMasterId <> '" + FormulaMasterId + "' ");
        }
        else
        {
            dataAccess.ExecuteNonQuery("Update [ProductFormulaMaster]  set  IsActive = 0 where ProductId = '" + ProductId + "' and FormulaMasterId <> '" + FormulaMasterId + "' ");
        }

    }

    public int InsertProductFormulaDetail(int FormulaMasterId, int ProductId, int UnitId, decimal Qty, int WarehouseId, int ActualProductId, string Remarks, int ColorId, Smartworks.DAL customDataAcess = null)
    {
        int id = -1;
        Smartworks.ColumnField[] iFormulaDetail = new Smartworks.ColumnField[8];
        iFormulaDetail[0] = new Smartworks.ColumnField("@FormulaMasterId", FormulaMasterId);
        iFormulaDetail[1] = new Smartworks.ColumnField("@ProductId", ProductId);
        iFormulaDetail[2] = new Smartworks.ColumnField("@UnitId", UnitId);
        iFormulaDetail[3] = new Smartworks.ColumnField("@Qty", Qty);
        iFormulaDetail[4] = new Smartworks.ColumnField("@WarehouseId", WarehouseId);
        iFormulaDetail[5] = new Smartworks.ColumnField("@ActualProductId", ActualProductId);
        iFormulaDetail[6] = new Smartworks.ColumnField("@Remarks", Remarks);
        iFormulaDetail[7] = new Smartworks.ColumnField("@ColorId", ColorId);

        if (customDataAcess != null)
        {
            id = Convert.ToInt32(customDataAcess.ExecuteStoredProcedure("InsertFormulaDetail", iFormulaDetail));
        }
        else
        {
            dataAccess.BeginTransaction();
            id = Convert.ToInt32(dataAccess.ExecuteStoredProcedure("InsertFormulaDetail", iFormulaDetail));
            dataAccess.TransCommit();
        }
        return id;
    }

    public int InsertProductFormulaSubDetail(int FormulaDetailId, int FormulaMasterId, int ProductId, int SizeId, decimal Qty, Smartworks.DAL customDataAcess = null)
    {
        int id = -1;
        Smartworks.ColumnField[] iFormulaSubDetail = new Smartworks.ColumnField[5];
        iFormulaSubDetail[0] = new Smartworks.ColumnField("@FormulaDetailId", FormulaDetailId);
        iFormulaSubDetail[1] = new Smartworks.ColumnField("@FormulaMasterId", FormulaMasterId);
        iFormulaSubDetail[2] = new Smartworks.ColumnField("@ProductId", ProductId);
        iFormulaSubDetail[3] = new Smartworks.ColumnField("@SizeId", SizeId);
        iFormulaSubDetail[4] = new Smartworks.ColumnField("@Qty", Qty);

        if (customDataAcess != null)
        {
            customDataAcess.ExecuteStoredProcedure("InsertFormulaSubDetail", iFormulaSubDetail);
        }
        else
        {
            dataAccess.BeginTransaction();
            dataAccess.ExecuteStoredProcedure("InsertFormulaSubDetail", iFormulaSubDetail);
            dataAccess.TransCommit();
        }
        return id;
    }

    public int DeleteFormulaDetailByMasterId(int FormulaMasterId, Smartworks.DAL customDataAcess = null)
    {
        int IsDeleted = -1;
        Smartworks.ColumnField[] uFormulaMaster = new Smartworks.ColumnField[1];
        uFormulaMaster[0] = new Smartworks.ColumnField("@FormulaMasterId", FormulaMasterId);
        if (customDataAcess != null)
        {
            IsDeleted = Convert.ToInt32(customDataAcess.ExecuteStoredProcedure("DeleteFormulaDetailByMasterId", uFormulaMaster));
        }
        else
        {
            dataAccess.BeginTransaction();
            IsDeleted = Convert.ToInt32(dataAccess.ExecuteStoredProcedure("DeleteFormulaDetailByMasterId", uFormulaMaster));
            dataAccess.TransCommit();
        }
        return IsDeleted;
    }

    public int DeleteProductFormula(int FormulaMasterId, Smartworks.DAL customDataAcess = null)
    {
        int IsDeleted = -1;
        Smartworks.ColumnField[] uFormulaMaster = new Smartworks.ColumnField[1];
        uFormulaMaster[0] = new Smartworks.ColumnField("@FormulaMasterId", FormulaMasterId);
        if (customDataAcess != null)
        {
            IsDeleted = Convert.ToInt32(customDataAcess.ExecuteStoredProcedure("DeleteFormulaMaster", uFormulaMaster));
        }
        else
        {
            dataAccess.BeginTransaction();
            IsDeleted = Convert.ToInt32(dataAccess.ExecuteStoredProcedure("DeleteFormulaMaster", uFormulaMaster));
            dataAccess.TransCommit();
        }
        return IsDeleted;
    }

    public int GetFormulaIdByCode(int FormulaId)
    {
        int Id = -1;
        DataTable dtFormula = new DataTable();
        dtFormula = dataAccess.getDataTable("Select * from ProductFormulaMaster where FormulaMasterId = " + FormulaId);
        if (dtFormula.Rows.Count > 0)
        {
            Id = Convert.ToInt32(dtFormula.Rows[0]["FormulaMasterId"]);
        }
        return Id;
    }

    public DataTable GetFormulaDetailForProduction(int PFMId, decimal Quantity, int WarehouseId, string SOrderNo , int ArticleId , DateTime dated  , string BatchNo)
    {
        string qurey = "select  FormulaDetailId,FormulaMasterId,WarehouseId,ProductId,ActualProductId,ColorId,UnitId,isnull(Qty,0) * " + Quantity + " as Qty ,Remarks , AvailableQty = (select dbo.GetProductBalanceBySONo(ProductFormulaDetail.ActualProductId , Cast('"+ dated +"' as Date)  , WarehouseId , '" + SOrderNo + "' , '"+ ArticleId +"' , '"+ BatchNo +"' ))  from ProductFormulaDetail";
        string WhereCondition = " where FormulaMasterId = '" + PFMId + "'";
        if (WarehouseId > 0)
        {
            WhereCondition += " and WarehouseId = '" + WarehouseId + "'  ";
        }
        return dataAccess.getDataTable(qurey + WhereCondition);
    }

    public decimal GetActualProductAvailableQtyForProduction(int ActualProductId , DateTime Dated , int WarehouseId , string SOrderNo , int ArticleId , string BatchNo)
    {
        decimal qty = 0;
        try
        {
            string qurey = "select dbo.GetProductBalanceBySONo('" + ActualProductId + "' , Cast('" + Dated + "' as Date)  , '" + WarehouseId + "', '" + SOrderNo + "' , '" + ArticleId + "' , '" + BatchNo + "' ) as Qty ";
            qty = Convert.ToDecimal(dataAccess.getDataTable(qurey).Rows[0]["Qty"]);

        }
        catch (Exception ex)
        {
            qty = 0;
        }

        return qty;
    }

    public DataTable GetProductFormulaByFinishProductId(int FinishProductId)
    {
        return dataAccess.getDataTable("Select * from ProductFormulaMaster where ProductId = '" + FinishProductId + "' and IsActive = 1 ");
    }

    public DataTable GetAllProductFormulaByFinishProductId(int FinishProductId)
    {
        return dataAccess.getDataTable("Select FormulaMasterId , FormulaName from ProductFormulaMaster where ProductId = '" + FinishProductId + "'");
    }

    public DataTable GetAllProductFormula()
    {
        return dataAccess.getDataTable("Select FormulaMasterId , FormulaName from ProductFormulaMaster ");
    }


    public DataTable GetTestReportProduct(int ProductId)
    {
        DataTable dt = new DataTable();
        Smartworks.ColumnField[] PriceList = new Smartworks.ColumnField[1];
        PriceList[0] = new Smartworks.ColumnField("@ProductId", ProductId);
        dt = dataAccess.getDataTableByStoredProcedure("spTestReportImage", PriceList);
        return dt;
    }


    public DataTable GetReportProductFormula(int FormulaMasterId)
    {
        DataTable dt = new DataTable();
        Smartworks.ColumnField[] PriceList = new Smartworks.ColumnField[1];
        PriceList[0] = new Smartworks.ColumnField("@FormulaMasterId", FormulaMasterId);
        dt = dataAccess.getDataTableByStoredProcedure("sp_ReportProductFormula", PriceList);
        return dt;
    }

    public DataTable GetReportProductFormulaWithAmount(int FormulaMasterId)
    {
        DataTable dt = new DataTable();
        Smartworks.ColumnField[] PriceList = new Smartworks.ColumnField[1];
        PriceList[0] = new Smartworks.ColumnField("@FormulaMasterId", FormulaMasterId);
        dt = dataAccess.getDataTableByStoredProcedure("sp_ReportProductFormulaWithAmount", PriceList);
        return dt;
    }

    public DataTable GetReportProductFormulaWithRequired(int FormulaMasterId , int Qty)
    {
        DataTable dt = new DataTable();
        Smartworks.ColumnField[] PriceList = new Smartworks.ColumnField[2];
        PriceList[0] = new Smartworks.ColumnField("@FormulaMasterId", FormulaMasterId);
        PriceList[1] = new Smartworks.ColumnField("@Qty", Qty);
        dt = dataAccess.getDataTableByStoredProcedure("sp_ReportProductFormulaWithRequired", PriceList);
        return dt;
    }

    public DataTable GetReportProductAssumption(int FormulaMasterId, int Quantity, string SOrderNo, int S39, int S40, int S41, int S42, int S43, int S44, int S45, int S46, int S47)
    {
        DataTable dt = new DataTable();
        Smartworks.ColumnField[] gProductReport = new Smartworks.ColumnField[12];
        gProductReport[0] = new Smartworks.ColumnField("@FormulaMasterId", FormulaMasterId);
        gProductReport[1] = new Smartworks.ColumnField("@Qty", Quantity);
        gProductReport[2] = new Smartworks.ColumnField("@SOrderNo", SOrderNo);
        gProductReport[3] = new Smartworks.ColumnField("@S39", S39);
        gProductReport[4] = new Smartworks.ColumnField("@S40", S40);
        gProductReport[5] = new Smartworks.ColumnField("@S41", S41);
        gProductReport[6] = new Smartworks.ColumnField("@S42", S42);
        gProductReport[7] = new Smartworks.ColumnField("@S43", S43);
        gProductReport[8] = new Smartworks.ColumnField("@S44", S44);
        gProductReport[9] = new Smartworks.ColumnField("@S45", S45);
        gProductReport[10] = new Smartworks.ColumnField("@S46", S46);
        gProductReport[11] = new Smartworks.ColumnField("@S47", S47);
        dt = dataAccess.getDataTableByStoredProcedure("sp_ReportProductAssumption", gProductReport);
        return dt;
    }

    public DataTable GetUpdatedProducts()
    {
        DataTable dtProduct = new DataTable();
        dtProduct = dataAccess.getDataTable("Select ProductId , ProductCode , ProductName ,  ProductNature , PC.CategoryName , Product.MesurementUnitId from Product left join ProductCategory PC on Product.ProductCatagoryId = PC.ProductCategoryId ");
        return dtProduct;
    }

    #endregion

    #region ProductFormulaConfiguration

    public DataSet GetProductFormulaConfigStructure()
    {
        DataSet ds = new DataSet();
        ds = dataAccess.getDataSetByStoredProcedure("sp_GetProductFormulaConfigStructure", null);
        return ds;
    }

    public void DeleteFormulaConfigByConfigId(int Id, Smartworks.DAL customdataAcess = null)
    {
        if (customdataAcess != null)
        {
            customdataAcess.ExecuteNonQuery("Delete from ProductFormulaConfig where FormulaConfigId = " + Id);
        }
        else
        {
            dataAccess.BeginTransaction();
            dataAccess.ExecuteNonQuery("Delete from ProductFormulaConfig where FormulaConfigId = " + Id);
            dataAccess.TransCommit();
        }
    }

    public int InsertUpdateFormulaConfig(int FormulaConfigId, int WarehouseId, int ProductId, int UnitId, int WarehouseSequance, int ProductSequance, Smartworks.DAL customdataAcess = null)
    {
        int Id = -1;
        Smartworks.ColumnField[] iuFormulaConfig = new Smartworks.ColumnField[6];
        iuFormulaConfig[0] = new Smartworks.ColumnField("@FormulaConfigId", FormulaConfigId);
        iuFormulaConfig[1] = new Smartworks.ColumnField("@WarehouseId", WarehouseId);
        iuFormulaConfig[2] = new Smartworks.ColumnField("@ProductId", ProductId);
        iuFormulaConfig[3] = new Smartworks.ColumnField("@UnitId", UnitId);
        iuFormulaConfig[4] = new Smartworks.ColumnField("@WarehouseSequance", WarehouseSequance);
        iuFormulaConfig[5] = new Smartworks.ColumnField("@ProductSequance", ProductSequance);

        if (customdataAcess != null)
        {
            Id = Convert.ToInt32(customdataAcess.ExecuteStoredProcedure("InsertUpdateProductFormulaConfig", iuFormulaConfig));
        }
        else
        {
            dataAccess.BeginTransaction();
            Id = Convert.ToInt32(dataAccess.ExecuteStoredProcedure("InsertUpdateProductFormulaConfig", iuFormulaConfig));
            dataAccess.TransCommit();
        }

        return Id;
    }

    #endregion


    #region ProductReoprt
    public DataTable GetReportPriceList(int CategoryId, string FromItem, String ToItem)
    {
        DataTable dt = new DataTable();
        Smartworks.ColumnField[] PriceList = new Smartworks.ColumnField[3];
        PriceList[0] = new Smartworks.ColumnField("@CategoryId", CategoryId);
        PriceList[1] = new Smartworks.ColumnField("@FromItem", FromItem);
        PriceList[2] = new Smartworks.ColumnField("@ToItem", ToItem);
        dt = dataAccess.getDataTableByStoredProcedure("sp_ReportPageList", PriceList);
        return dt;
    }

    public DataTable GetReportStock(int CategoryId, string FromItem, string ToItem, int WarehouseId)
    {
        DataTable dt = new DataTable();
        Smartworks.ColumnField[] ProductStock = new Smartworks.ColumnField[4];
        ProductStock[0] = new Smartworks.ColumnField("@CategoryId", CategoryId);
        ProductStock[1] = new Smartworks.ColumnField("@FromItem", FromItem);
        ProductStock[2] = new Smartworks.ColumnField("@ToItem", ToItem);
        ProductStock[3] = new Smartworks.ColumnField("@WarehouseId", WarehouseId);

        dt = dataAccess.getDataTableByStoredProcedure("sp_ReportStockItem", ProductStock);
        return dt;
    }
    #endregion



    #region ProductOpeningBalance

    public DataSet GetProductOpeningStructure(int POBId)
    {
        DataSet ds = new DataSet();
        Smartworks.ColumnField[] getPOB = new Smartworks.ColumnField[1];
        getPOB[0] = new Smartworks.ColumnField("@ProdOpenBalMasterId", POBId);
        ds = dataAccess.getDataSetByStoredProcedure("sp_GetProductOpeningBalanceStructure", getPOB);
        return ds;
    }

    public int InsertProductOpeningBalance(DateTime Date, bool Posted, decimal TAmount, string VoucherNo, string BranchCode,
        string Remarks, int AddedBy, DateTime AddedOn, string AddedIpAddr, Smartworks.DAL customdataAccess = null)
    {
        int Id = -1;
        Smartworks.ColumnField[] iPOB = new Smartworks.ColumnField[9];
        iPOB[0] = new Smartworks.ColumnField("@Date", Date);
        iPOB[1] = new Smartworks.ColumnField("@Posted", Posted);
        iPOB[2] = new Smartworks.ColumnField("@TAmount", TAmount);
        iPOB[3] = new Smartworks.ColumnField("@VoucherNo", VoucherNo);
        iPOB[4] = new Smartworks.ColumnField("@BranchCode", BranchCode);
        iPOB[5] = new Smartworks.ColumnField("@Remarks", Remarks);
        iPOB[6] = new Smartworks.ColumnField("@AddedBy", AddedBy);
        iPOB[7] = new Smartworks.ColumnField("@AddedOn", AddedOn);
        iPOB[8] = new Smartworks.ColumnField("@AddedIpAddr", AddedIpAddr);

        if (customdataAccess != null)
        {
            Id = Convert.ToInt32(customdataAccess.ExecuteStoredProcedure("InsertProductOpeningBalance", iPOB));
        }
        else
        {
            dataAccess.BeginTransaction();
            Id = Convert.ToInt32(dataAccess.ExecuteStoredProcedure("InsertProductOpeningBalance", iPOB));
            dataAccess.TransCommit();
        }

        return Id;
    }


    public int UpdateProductOpeningBalance(int ProdOpenBalMasterId, DateTime Date, bool Posted, decimal TAmount, string VoucherNo, string BranchCode,
       string Remarks, int AddedBy, DateTime AddedOn, string AddedIpAddr, Smartworks.DAL customdataAccess = null)
    {
        int Id = -1;
        Smartworks.ColumnField[] uPOB = new Smartworks.ColumnField[10];
        uPOB[0] = new Smartworks.ColumnField("@ProdOpenBalMasterId", ProdOpenBalMasterId);
        uPOB[1] = new Smartworks.ColumnField("@Date", Date);
        uPOB[2] = new Smartworks.ColumnField("@Posted", Posted);
        uPOB[3] = new Smartworks.ColumnField("@TAmount", TAmount);
        uPOB[4] = new Smartworks.ColumnField("@VoucherNo", VoucherNo);
        uPOB[5] = new Smartworks.ColumnField("@BranchCode", BranchCode);
        uPOB[6] = new Smartworks.ColumnField("@Remarks", Remarks);
        uPOB[7] = new Smartworks.ColumnField("@UpdatedBy", AddedBy);
        uPOB[8] = new Smartworks.ColumnField("@UpdatedOn", AddedOn);
        uPOB[9] = new Smartworks.ColumnField("@UpdatedIpAddr", AddedIpAddr);

        if (customdataAccess != null)
        {
            Id = Convert.ToInt32(customdataAccess.ExecuteStoredProcedure("UpdateProductOpeningBalance", uPOB));
        }
        else
        {
            dataAccess.BeginTransaction();
            Id = Convert.ToInt32(dataAccess.ExecuteStoredProcedure("UpdateProductOpeningBalance", uPOB));
            dataAccess.TransCommit();
        }

        return Id;
    }

    public int InsertUpdateProductOpeningDetail(int ProdOpenBalDetailId, int ProdOpenBalMasterId, int ProductId, string StockType, string BatchNo, int WarehouseId,
        decimal OpeningBalance, decimal Price, Nullable<DateTime> ExpiryDate, Smartworks.DAL customdataAccess = null)
    {
        int Id = -1;
        Smartworks.ColumnField[] iuPOBDetail = new Smartworks.ColumnField[9];
        iuPOBDetail[0] = new Smartworks.ColumnField("@ProdOpenBalDetailId", ProdOpenBalDetailId);
        iuPOBDetail[1] = new Smartworks.ColumnField("@ProdOpenBalMasterId", ProdOpenBalMasterId);
        iuPOBDetail[2] = new Smartworks.ColumnField("@ProductId", ProductId);
        iuPOBDetail[3] = new Smartworks.ColumnField("@StockType", StockType);
        iuPOBDetail[4] = new Smartworks.ColumnField("@BatchNo", BatchNo);
        iuPOBDetail[5] = new Smartworks.ColumnField("@WarehouseId", WarehouseId);
        iuPOBDetail[6] = new Smartworks.ColumnField("@OpeningBalance", OpeningBalance);
        iuPOBDetail[7] = new Smartworks.ColumnField("@Price", Price);
        if (ExpiryDate == null)
        {
            iuPOBDetail[8] = new Smartworks.ColumnField("@ExpiryDate", DBNull.Value);
        }
        else
        {
            iuPOBDetail[8] = new Smartworks.ColumnField("@ExpiryDate", ExpiryDate);
        }


        if (customdataAccess != null)
        {
            Id = Convert.ToInt32(customdataAccess.ExecuteStoredProcedure("InsertUpdateProductOpeningDetail", iuPOBDetail));
        }
        else
        {
            dataAccess.BeginTransaction();
            Id = Convert.ToInt32(dataAccess.ExecuteStoredProcedure("InsertUpdateProductOpeningDetail", iuPOBDetail));
            dataAccess.TransCommit();

        }

        return Id;
    }

    public int DeleteProductOpeningBalanceMaster(int ProdOpenBalMasterId, Smartworks.DAL customdataAccess = null)
    {
        int Id = -1;

        Smartworks.ColumnField[] dPOB = new Smartworks.ColumnField[1];
        dPOB[0] = new Smartworks.ColumnField("@ProdOpenBalMasterId", ProdOpenBalMasterId);
        if (customdataAccess != null)
        {
            Id = Convert.ToInt32(customdataAccess.ExecuteStoredProcedure("dbo.DeleteProductOpeningBalance", dPOB));
        }
        else
        {
            dataAccess.BeginTransaction();
            Id = Convert.ToInt32(dataAccess.ExecuteStoredProcedure("dbo.DeleteProductOpeningBalance", dPOB));
            dataAccess.TransCommit();
        }
        return Id;
    }


    public void DeleteProductOpeningBalanceByDetailId(int ProdOpenBalDetailId, Smartworks.DAL customdataAcess = null)
    {
        Smartworks.ColumnField[] dPOBDetail = new Smartworks.ColumnField[1];
        dPOBDetail[0] = new Smartworks.ColumnField("@ProdOpenBalDetailId", ProdOpenBalDetailId);
        if (customdataAcess != null)
        {
            customdataAcess.ExecuteStoredProcedure("dbo.DeletePBODetailByDetailId", dPOBDetail);
        }
        else
        {
            dataAccess.BeginTransaction();
            dataAccess.ExecuteStoredProcedure("dbo.DeletePBODetailByDetailId", dPOBDetail);
            dataAccess.TransCommit();
        }
    }

    public int GetPOBIdByCode(string Code)
    {
        int POBMasterId = -1;
        DataTable dt = new DataTable();
        dt = dataAccess.getDataTable("Select ProdOpenBalMasterId from [ProductOpeningBalanceMaster] where ProdOpenBalMasterId =  " + Code);
        if (dt.Rows.Count > 0)
        {
            POBMasterId = Convert.ToInt32(dt.Rows[0]["ProdOpenBalMasterId"]);
        }
        return POBMasterId;
    }


    public bool UpdatePOBPosted(int ProdOpenBalMasterId, Smartworks.DAL customdataAcess = null)
    {
        bool result = false;

        if (customdataAcess != null)
        {
            result = Convert.ToBoolean(customdataAcess.ExecuteNonQuery("Update  [ProductOpeningBalanceMaster] set Posted = 1 where ProdOpenBalMasterId = " + ProdOpenBalMasterId));
        }
        else
        {
            result = Convert.ToBoolean(dataAccess.ExecuteNonQuery("Update  [ProductOpeningBalanceMaster] set Posted = 1 where ProdOpenBalMasterId = " + ProdOpenBalMasterId));
        }

        return result;
    }
    public bool UpdatePOB_UnPosted(int ProdOpenBalMasterId, Smartworks.DAL customdataAcess = null)
    {
        bool result = false;

        if (customdataAcess != null)
        {
            result = Convert.ToBoolean(customdataAcess.ExecuteNonQuery("Update  [ProductOpeningBalanceMaster] set Posted = 0 where ProdOpenBalMasterId = " + ProdOpenBalMasterId));
        }
        else
        {
            result = Convert.ToBoolean(dataAccess.ExecuteNonQuery("Update  [ProductOpeningBalanceMaster] set Posted = 0 where ProdOpenBalMasterId = " + ProdOpenBalMasterId));
        }

        return result;
    }




    #endregion

    #region StockAdjustment
    public DataSet GetAdjustmentStructure(int AdjustmentId)
    {
        DataSet ds = new DataSet();
        Smartworks.ColumnField[] getAdjustment = new Smartworks.ColumnField[1];
        getAdjustment[0] = new Smartworks.ColumnField("@AdjustmentId", AdjustmentId);
        ds = dataAccess.getDataSetByStoredProcedure("sp_GetAdjustmentStructure", getAdjustment);
        return ds;
    }
    public int GetAdjustmentIdByCode(string Code)
    {
        int POBMasterId = -1;
        DataTable dt = new DataTable();
        dt = dataAccess.getDataTable("Select AdjustId from [AdjustmentMaster] where AdjustNo =  '" + Code + "' " );
        if (dt.Rows.Count > 0)
        {
            POBMasterId = Convert.ToInt32(dt.Rows[0]["AdjustId"]);
        }
        return POBMasterId;
    }

    public DataTable InsertStockAdjusmentMaster(DateTime Date, int WarehouseId , string Remarks, int AddedBy, DateTime AddedOn, string AddedIpAddr, Smartworks.DAL customdataAccess = null)
    {
        DataTable dt = null;

        Smartworks.ColumnField[] iAdjust = new Smartworks.ColumnField[6];
        iAdjust[0] = new Smartworks.ColumnField("@Date", Date);
        iAdjust[1] = new Smartworks.ColumnField("@WarehouseId", WarehouseId);
        iAdjust[2] = new Smartworks.ColumnField("@Remarks", Remarks);
        iAdjust[3] = new Smartworks.ColumnField("@AddedBy", AddedBy);
        iAdjust[4] = new Smartworks.ColumnField("@AddedOn", AddedOn);
        iAdjust[5] = new Smartworks.ColumnField("@AddedIpAddr", AddedIpAddr);

        if (customdataAccess != null)
        {
            dt =  customdataAccess.getDataTableByStoredProcedure("InsertStockAdjustmentMaster", iAdjust);
        }
        else
        {
            dataAccess.BeginTransaction();
            dt = dataAccess.getDataTableByStoredProcedure("InsertStockAdjustmentMaster", iAdjust);
            dataAccess.TransCommit();
        }

        return dt;
    }

    public int UpdateStockAdjusmentMaster(int AdjustId , DateTime Date, int WarehouseId, string Remarks, int AddedBy, DateTime AddedOn, string AddedIpAddr, Smartworks.DAL customdataAccess = null)
    {
        int Id = -1;

        Smartworks.ColumnField[] iAdjust = new Smartworks.ColumnField[7];
        iAdjust[0] = new Smartworks.ColumnField("@AdjustId", AdjustId);
        iAdjust[1] = new Smartworks.ColumnField("@Date", Date);
        iAdjust[2] = new Smartworks.ColumnField("@WarehouseId", WarehouseId);
        iAdjust[3] = new Smartworks.ColumnField("@Remarks", Remarks);
        iAdjust[4] = new Smartworks.ColumnField("@AddedBy", AddedBy);
        iAdjust[5] = new Smartworks.ColumnField("@AddedOn", AddedOn);
        iAdjust[6] = new Smartworks.ColumnField("@AddedIpAddr", AddedIpAddr);

        if (customdataAccess != null)
        {
            Id = Convert.ToInt32(customdataAccess.ExecuteStoredProcedure("UpdateStockAdjustmentMaster", iAdjust));
        }
        else
        {
            dataAccess.BeginTransaction();
            Id = Convert.ToInt32(dataAccess.ExecuteStoredProcedure("UpdateStockAdjustmentMaster", iAdjust));
            dataAccess.TransCommit();
        }

        return Id;
    }

    public int InsertUpdateStockAdjustmentDetail(int AdjustDetailId, int AdjustId, int ProductId, string StockType, int WarehouseId,
        decimal Qty, string FlagIO, Smartworks.DAL customdataAccess = null)
    {
        int Id = -1;

        Smartworks.ColumnField[] iuStockAdjustDetail = new Smartworks.ColumnField[7];
        iuStockAdjustDetail[0] = new Smartworks.ColumnField("@AdjustDetailId", AdjustDetailId);
        iuStockAdjustDetail[1] = new Smartworks.ColumnField("@AdjustId", AdjustId);
        iuStockAdjustDetail[2] = new Smartworks.ColumnField("@ProductId", ProductId);
        iuStockAdjustDetail[3] = new Smartworks.ColumnField("@StockType", StockType);
        iuStockAdjustDetail[4] = new Smartworks.ColumnField("@WarehouseId", WarehouseId);
        iuStockAdjustDetail[5] = new Smartworks.ColumnField("@Qty", Qty);
        iuStockAdjustDetail[6] = new Smartworks.ColumnField("@FlagIO", FlagIO);
        
        if (customdataAccess != null)
        {
            Id = Convert.ToInt32(customdataAccess.ExecuteStoredProcedure("InsertUpdateAdjustmentDetail", iuStockAdjustDetail));
        }
        else
        {
            dataAccess.BeginTransaction();
            Id = Convert.ToInt32(dataAccess.ExecuteStoredProcedure("InsertUpdateAdjustmentDetail", iuStockAdjustDetail));
            dataAccess.TransCommit();

        }

        return Id;
    }

    public void DeleteAdjustDetailByDetailId(int AdjustDetailId, Smartworks.DAL customdataAcess = null)
    {
        Smartworks.ColumnField[] dAdjustDetail = new Smartworks.ColumnField[1];
        dAdjustDetail[0] = new Smartworks.ColumnField("@AdjustDetailId", AdjustDetailId);
        if (customdataAcess != null)
        {
            customdataAcess.ExecuteStoredProcedure("dbo.DeleteAdjustDetailByDetailId", dAdjustDetail);
        }
        else
        {
            dataAccess.BeginTransaction();
            dataAccess.ExecuteStoredProcedure("dbo.DeleteAdjustDetailByDetailId", dAdjustDetail);
            dataAccess.TransCommit();
        }
    }


    public int DeleteAdjustmentMaster(int AdjustId, Smartworks.DAL customdataAccess = null)
    {
        int Id = -1;

        Smartworks.ColumnField[] dAdjust = new Smartworks.ColumnField[1];
        dAdjust[0] = new Smartworks.ColumnField("@AdjustId", AdjustId);
        if (customdataAccess != null)
        {
            Id = Convert.ToInt32(customdataAccess.ExecuteStoredProcedure("dbo.DeleteAdjustment", dAdjust));
        }
        else
        {
            dataAccess.BeginTransaction();
            Id = Convert.ToInt32(dataAccess.ExecuteStoredProcedure("dbo.DeleteAdjustment", dAdjust));
            dataAccess.TransCommit();
        }
        return Id;
    }
    
    #endregion
}


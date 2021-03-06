﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Erp.BO;
using Ice.Core;
using Ice.Lib.Framework;
using Ice.Proxy.BO;
using Erp;
using Epicor.Hosting;
using Epicor.Utilities;
using Ice.BO.DynamicQuery;
using System.Runtime;
using System.Windows;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;


namespace Epicor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            List<string> ops = new List<string>();
            Session epiSession;
            epiSession = new Session("seth.romanowski", "Baseball33", "net.tcp://LW-EPICOR-APP/ERP102200", Session.LicenseType.Default, @"C:\Epicor\ERP10.2Client\Client\config\ERP102200.sysconfig");
            ILauncher oTrans = null;
            if (epiSession != null)
            {
                MessageBox.Show("Connected!");
                oTrans = new ILauncher(epiSession);
            }

            try
            {
                string BAQName = "OpMaster-Seth";
                Ice.BO.QueryExecutionDataSet ds = new Ice.BO.QueryExecutionDataSet();
                // Use Business Object Directly
                Ice.Proxy.BO.DynamicQueryImpl dynamicQuery = WCFServiceSupport.CreateImpl<Ice.Proxy.BO.DynamicQueryImpl>((Ice.Core.Session)oTrans.Session, Epicor.ServiceModel.Channels.ImplBase<Ice.Contracts.DynamicQuerySvcContract>.UriPath);
                System.Data.DataSet results = dynamicQuery.ExecuteByID(BAQName, ds);
                // Lets Loop through our results
                if (results.Tables["Results"].Rows.Count > 0)
                {
                    foreach (DataRow item in results.Tables["Results"].Rows)
                    {
                        // In E9 you used TableName.Column in E10 it is TableName_Column
                        comboBox2.Items.Add(new {Text=item["OpMaster_OpDesc"].ToString(),Value= item["OpMaster_OpDesc"].ToString()});

                    }
                }
                comboBox2.DisplayMember = "Text";
                comboBox2.ValueMember = "Value";

                string BAQName2 = "zResourceGroupList";
                Ice.BO.QueryExecutionDataSet ds2 = new Ice.BO.QueryExecutionDataSet();
                // Use Business Object Directly
                Ice.Proxy.BO.DynamicQueryImpl dynamicQuery2 = WCFServiceSupport.CreateImpl<Ice.Proxy.BO.DynamicQueryImpl>((Ice.Core.Session)oTrans.Session, Epicor.ServiceModel.Channels.ImplBase<Ice.Contracts.DynamicQuerySvcContract>.UriPath);
                System.Data.DataSet results2 = dynamicQuery.ExecuteByID(BAQName2, ds);
                // Lets Loop through our results
                if (results2.Tables["Results"].Rows.Count > 0)
                {
                    foreach (DataRow item in results2.Tables["Results"].Rows)
                    {
                        // In E9 you used TableName.Column in E10 it is TableName_Column
                        comboBox3.Items.Add(new { Text = item["resourcegroup_description"].ToString(), Value = item["resourcegroup_description"].ToString() });

                    }
                }
                comboBox3.DisplayMember = "Text";
                comboBox3.ValueMember = "Value";


                string BAQName3 = "zResourceList";
                Ice.BO.QueryExecutionDataSet ds3 = new Ice.BO.QueryExecutionDataSet();
                // Use Business Object Directly
                Ice.Proxy.BO.DynamicQueryImpl dynamicQuery3 = WCFServiceSupport.CreateImpl<Ice.Proxy.BO.DynamicQueryImpl>((Ice.Core.Session)oTrans.Session, Epicor.ServiceModel.Channels.ImplBase<Ice.Contracts.DynamicQuerySvcContract>.UriPath);
                System.Data.DataSet results3 = dynamicQuery.ExecuteByID(BAQName3, ds);
                // Lets Loop through our results
                if (results3.Tables["Results"].Rows.Count > 0)
                {
                    foreach (DataRow item in results3.Tables["Results"].Rows)
                    {
                        // In E9 you used TableName.Column in E10 it is TableName_Column
                        comboBox4.Items.Add(new { Text = item["Resource_Description"].ToString(), Value = item["Resource_Description"].ToString() });

                    }
                }
                comboBox4.DisplayMember = "Text";
                comboBox4.ValueMember = "Value";

                string BAQName4 = "ProductGroups-Seth";
                Ice.BO.QueryExecutionDataSet ds4 = new Ice.BO.QueryExecutionDataSet();
                // Use Business Object Directly
                Ice.Proxy.BO.DynamicQueryImpl dynamicQuery4 = WCFServiceSupport.CreateImpl<Ice.Proxy.BO.DynamicQueryImpl>((Ice.Core.Session)oTrans.Session, Epicor.ServiceModel.Channels.ImplBase<Ice.Contracts.DynamicQuerySvcContract>.UriPath);
                System.Data.DataSet results4 = dynamicQuery.ExecuteByID(BAQName4, ds);
                // Lets Loop through our results
                if (results4.Tables["Results"].Rows.Count > 0)
                {
                    foreach (DataRow item in results4.Tables["Results"].Rows)
                    {
                        // In E9 you used TableName.Column in E10 it is TableName_Column
                        comboBox5.Items.Add(new { Text = item["ProdGrup_Description"].ToString(), Value = item["ProdGrup_Description"].ToString() });

                    }
                }
                comboBox5.DisplayMember = "Text";
                comboBox5.ValueMember = "Value";

                string BAQName5 = "PartClasses-Seth";
                Ice.BO.QueryExecutionDataSet ds5 = new Ice.BO.QueryExecutionDataSet();
                // Use Business Object Directly
                Ice.Proxy.BO.DynamicQueryImpl dynamicQuery5 = WCFServiceSupport.CreateImpl<Ice.Proxy.BO.DynamicQueryImpl>((Ice.Core.Session)oTrans.Session, Epicor.ServiceModel.Channels.ImplBase<Ice.Contracts.DynamicQuerySvcContract>.UriPath);
                System.Data.DataSet results5 = dynamicQuery.ExecuteByID(BAQName5, ds);
                // Lets Loop through our results
                if (results5.Tables["Results"].Rows.Count > 0)
                {
                    foreach (DataRow item in results5.Tables["Results"].Rows)
                    {
                        // In E9 you used TableName.Column in E10 it is TableName_Column
                        comboBox6.Items.Add(new { Text = item["PartClass_Description"].ToString(), Value = item["PartClass_Description"].ToString() });

                    }
                }
                comboBox6.DisplayMember = "Text";
                comboBox6.ValueMember = "Value";
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Session epiSession;
            epiSession = new Session("seth.romanowski", "Baseball33", "net.tcp://LW-EPICOR-APP/ERP102200", Session.LicenseType.Default, @"C:\Epicor\ERP10.2Client\Client\config\ERP102200.sysconfig");
            ILauncher oTrans = null;
            if (epiSession != null)
            {
                MessageBox.Show("Connected!");
                oTrans = new ILauncher(epiSession);
            }

            try
            {
                if (comboBox1.Text == "Test")
                {
                    // Declare and Initialize Variables
                    string BAQName = "Test";
                    Ice.BO.QueryExecutionDataSet ds = new Ice.BO.QueryExecutionDataSet();

                    // Add Parameter Rows
                    // Definition: AddExecutionParameterRow(string ParameterID, string ParameterValue, string ValueType, bool IsEmpty, Guid SysRowID, string RowMod)
                    // Possible ValueTypes: nvarchar, int, decimal, date, datetime, bit, uniqueidentifier, bigint
                    // IsEmpty indicates if your passed value Is Empty because if it is, you can define in your params to use a default value if empty.
                    // Typically you use string.IsNullOrEmpty(yourValueVariable) but if you are hard coding a value then you can simply set it to false
                    ds.ExecutionParameter.AddExecutionParameterRow("PartNum", "1040980", "nvarchar", false, Guid.Empty, "A");

                    // Use Business Object Directly
                    Ice.Proxy.BO.DynamicQueryImpl dynamicQuery = WCFServiceSupport.CreateImpl<Ice.Proxy.BO.DynamicQueryImpl>((Ice.Core.Session)oTrans.Session, Epicor.ServiceModel.Channels.ImplBase<Ice.Contracts.DynamicQuerySvcContract>.UriPath);
                    System.Data.DataSet results = dynamicQuery.ExecuteByID(BAQName, ds);

                    string val, val2, val3, val4, val5, val6;
                    string[] row;

                    dataGridView1.ColumnCount = 6;
                    dataGridView1.Columns[0].Name = "JobNum";
                    dataGridView1.Columns[1].Name = "StartDate";
                    dataGridView1.Columns[2].Name = "DueDate";
                    dataGridView1.Columns[3].Name = "PartNum";
                    dataGridView1.Columns[4].Name = "PartDesc";
                    dataGridView1.Columns[5].Name = "ProdQty";


                    // Lets Loop through our results
                    if (results.Tables["Results"].Rows.Count > 0)
                    {
                        foreach (DataRow item in results.Tables["Results"].Rows)
                        {
                            // In E9 you used TableName.Column in E10 it is TableName_Column
                            val = item["JobHead_JobNum"].ToString();
                            val2 = item["JobHead_StartDate"].ToString();
                            val3 = item["JobHead_DueDate"].ToString();
                            val4 = item["JobHead_PartNum"].ToString();
                            val5 = item["JobHead_PartDescription"].ToString();
                            val6 = item["JobHead_ProdQty"].ToString();

                            row = new string[] { val, val2, val3, val4, val5, val6 };
                            dataGridView1.Rows.Add(row);
                        }
                    }
                }
                if (comboBox1.Text == "CustOrdHist")
                {
                    // Declare and Initialize Variables
                    string BAQName = "CustOrdHist";
                    Ice.BO.QueryExecutionDataSet ds = new Ice.BO.QueryExecutionDataSet();

                    // Add Parameter Rows
                    // Definition: AddExecutionParameterRow(string ParameterID, string ParameterValue, string ValueType, bool IsEmpty, Guid SysRowID, string RowMod)
                    // Possible ValueTypes: nvarchar, int, decimal, date, datetime, bit, uniqueidentifier, bigint
                    // IsEmpty indicates if your passed value Is Empty because if it is, you can define in your params to use a default value if empty.
                    // Typically you use string.IsNullOrEmpty(yourValueVariable) but if you are hard coding a value then you can simply set it to false
                    ds.ExecutionParameter.AddExecutionParameterRow("CustID", textBox1.Text.ToString(), "nvarchar", false, Guid.Empty, "A");

                    // Use Business Object Directly
                    Ice.Proxy.BO.DynamicQueryImpl dynamicQuery = WCFServiceSupport.CreateImpl<Ice.Proxy.BO.DynamicQueryImpl>((Ice.Core.Session)oTrans.Session, Epicor.ServiceModel.Channels.ImplBase<Ice.Contracts.DynamicQuerySvcContract>.UriPath);
                    System.Data.DataSet results = dynamicQuery.ExecuteByID(BAQName, ds);

                    string val, val2, val3, val4, val5, val6, val7, val8, val9, val10, val11, val12, val13;
                    string[] row;

                    dataGridView1.ColumnCount = 13;
                    dataGridView1.Columns[0].Name = "Name";
                    dataGridView1.Columns[1].Name = "Order";
                    dataGridView1.Columns[2].Name = "OrderDate";
                    dataGridView1.Columns[3].Name = "NeedBy";
                    dataGridView1.Columns[4].Name = "Line";
                    dataGridView1.Columns[5].Name = "NeedBy";
                    dataGridView1.Columns[6].Name = "Part";
                    dataGridView1.Columns[7].Name = "Part";
                    dataGridView1.Columns[8].Name = "Rev";
                    dataGridView1.Columns[9].Name = "Desc";
                    dataGridView1.Columns[10].Name = "UnitPrice";
                    dataGridView1.Columns[11].Name = "OrderQty";
                    dataGridView1.Columns[12].Name = "DocUnitPrice";

                    // Lets Loop through our results
                    if (results.Tables["Results"].Rows.Count > 0)
                    {
                        foreach (DataRow item in results.Tables["Results"].Rows)
                        {
                            // In E9 you used TableName.Column in E10 it is TableName_Column
                            val = item["Customer_Name"].ToString();
                            val2 = item["OrderHed_OrderNum"].ToString();
                            val3 = item["OrderHed_OrderDate"].ToString();
                            val4 = item["OrderHed_NeedByDate"].ToString();
                            val5 = item["OrderDtl_OrderLine"].ToString();
                            val6 = item["OrderDtl_NeedByDate"].ToString();
                            val7 = item["OrderDtl_PartNum"].ToString();
                            val8 = item["OrderDtl_XPartNum"].ToString();
                            val9 = item["PartRev_RevisionNum"].ToString();
                            val10 = item["Part_PartDescription"].ToString();
                            val11 = item["OrderDtl_UnitPrice"].ToString();
                            val12 = item["OrderDtl_OrderQty"].ToString();
                            val13 = item["OrderDtl_DocUnitPrice"].ToString();

                            row = new string[] { val, val2, val3, val4, val5, val6, val7, val8, val9, val10, val11, val12, val13 };
                            dataGridView1.Rows.Add(row);
                        }
                    }
                }
                if (comboBox1.Text == "Part Material On-Hand")
                {
                    // Declare and Initialize Variables
                    string BAQName = "PartMtlOnHand2";
                    Ice.BO.QueryExecutionDataSet ds = new Ice.BO.QueryExecutionDataSet();

                    // Add Parameter Rows
                    // Definition: AddExecutionParameterRow(string ParameterID, string ParameterValue, string ValueType, bool IsEmpty, Guid SysRowID, string RowMod)
                    // Possible ValueTypes: nvarchar, int, decimal, date, datetime, bit, uniqueidentifier, bigint
                    // IsEmpty indicates if your passed value Is Empty because if it is, you can define in your params to use a default value if empty.
                    // Typically you use string.IsNullOrEmpty(yourValueVariable) but if you are hard coding a value then you can simply set it to false
                    ds.ExecutionParameter.AddExecutionParameterRow("PartNum", "1040980", "nvarchar", false, Guid.Empty, "A");

                    // Use Business Object Directly
                    Ice.Proxy.BO.DynamicQueryImpl dynamicQuery = WCFServiceSupport.CreateImpl<Ice.Proxy.BO.DynamicQueryImpl>((Ice.Core.Session)oTrans.Session, Epicor.ServiceModel.Channels.ImplBase<Ice.Contracts.DynamicQuerySvcContract>.UriPath);
                    System.Data.DataSet results = dynamicQuery.ExecuteByID(BAQName, ds);

                    string val, val2, val3, val4, val5, val6;
                    string[] row;

                    dataGridView1.ColumnCount = 6;
                    dataGridView1.Columns[0].Name = "JobNum";
                    dataGridView1.Columns[1].Name = "StartDate";
                    dataGridView1.Columns[2].Name = "DueDate";
                    dataGridView1.Columns[3].Name = "PartNum";
                    dataGridView1.Columns[4].Name = "PartDesc";
                    dataGridView1.Columns[5].Name = "ProdQty";


                    // Lets Loop through our results
                    if (results.Tables["Results"].Rows.Count > 0)
                    {
                        foreach (DataRow item in results.Tables["Results"].Rows)
                        {
                            // In E9 you used TableName.Column in E10 it is TableName_Column
                            val = item["JobHead_JobNum"].ToString();
                            val2 = item["JobHead_StartDate"].ToString();
                            val3 = item["JobHead_DueDate"].ToString();
                            val4 = item["JobHead_PartNum"].ToString();
                            val5 = item["JobHead_PartDescription"].ToString();
                            val6 = item["JobHead_ProdQty"].ToString();

                            row = new string[] { val, val2, val3, val4, val5, val6 };
                            dataGridView1.Rows.Add(row);
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Excel.Application xl = null;
            Excel.Workbooks xlWbs = null;
            Excel.Workbook xlWb = null;
            Excel.Sheets xlSheets = null;
            Excel.Worksheet xlSheet = null;
            Excel.Range xlRng = null;

            xl = new Excel.Application();

            xlWbs = xl.Workbooks;
            xlWb = xlWbs.Add();
            xlSheets = xlWb.Sheets;
            xlSheet = xlSheets.Item[1];

            xl.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string template;
            string file;
            template = comboBox9.ValueMember;
            file = @"\\lw-dc02\public\Seth\Resources\Reports\Templates\Production Hours.xlsm";

            Excel.Application xl = null;
            Excel.Workbooks xlWbs = null;
            Excel.Workbook xlWb = null;
            Excel.Sheets xlSheets = null;
            Excel.Worksheet xlSheet = null;
            Excel.Range xlRng = null;

            xl = new Excel.Application();

            xlWbs = xl.Workbooks;
            xlWb = xlWbs.Open(file);
            xlSheets = xlWb.Sheets;
            xlSheet = xlSheets.Item[1];

            xl.Visible = true;
        }
    }
    
}

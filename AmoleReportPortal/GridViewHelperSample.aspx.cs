﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AmoleReportPortal
{
    public partial class GridViewHelperSample : System.Web.UI.Page
    {
        public GridViewHelper helper;
        public static string LoginId;
        // To show custom operations...
        private List<int> mQuantities = new List<int>();

        protected void Page_Load(object sender, EventArgs e)
        {
            //LoginId = Login.LoginID;
            //GridViewHelper helper = new GridViewHelper(this.GridView1);
            //helper.RegisterGroup("ReportGroup", true, true);           
            //helper.ApplyGroupSort();
            //SortDirection.Ascending.ToString();
            
            // GridView1.HeaderRow.Visible = false;
        }

        //    private void ConfigSample()
        //    {

        //        switch (rdBtnList.SelectedValue)
        //        {
        //            case "1":
        //                {
        //                    helper.RegisterSummary("ItemTotal", SummaryOperation.Sum);
        //                    break;
        //                }
        //            case "2":
        //                {
        //                    helper.RegisterSummary("Quantity", SaveQuantity, GetMinQuantity);
        //                    break;
        //                }
        //            case "3":
        //                {
        //                    helper.RegisterSummary("ItemTotal", SummaryOperation.Sum);
        //                    helper.RegisterSummary("Quantity", SaveQuantity, GetMinQuantity);
        //                    break;
        //                }
        //            case "4":
        //                {
        //                    helper.RegisterGroup(rdBtnLstGroup.SelectedValue, true, true);
        //                    helper.ApplyGroupSort();
        //                    break;
        //                }
        //            case "5":
        //                {
        //                    helper.RegisterGroup(rdBtnLstGroup.SelectedValue, true, false);
        //                    helper.ApplyGroupSort();
        //                    break;
        //                }
        //            case "6":
        //                {
        //                    GridViewGroup g = helper.RegisterGroup(rdBtnLstGroup.SelectedValue, true, true);
        //                    //helper.RegisterSummary("Quantity", SummaryOperation.Sum, rdBtnLstGroup.SelectedValue);
        //                    helper.RegisterSummary("ItemTotal", SummaryOperation.Sum, rdBtnLstGroup.SelectedValue);
        //                    helper.ApplyGroupSort();
        //                    break;
        //                }
        //            case "7":
        //                {
        //                    helper.RegisterGroup(rdBtnLstGroup.SelectedValue, true, true);
        //                    helper.RegisterSummary("ItemTotal", SummaryOperation.Sum, rdBtnLstGroup.SelectedValue);
        //                    helper.RegisterSummary("ItemTotal", SummaryOperation.Sum);
        //                    helper.ApplyGroupSort();
        //                    break;
        //                }
        //            case "8":
        //                {
        //                    helper.SetSuppressGroup(rdBtnLstGroup.SelectedValue);
        //                    helper.RegisterSummary("Quantity", SummaryOperation.Sum, rdBtnLstGroup.SelectedValue);
        //                    helper.RegisterSummary("ItemTotal", SummaryOperation.Sum, rdBtnLstGroup.SelectedValue);
        //                    helper.HideColumnsWithoutGroupSummary();
        //                    helper.ApplyGroupSort();
        //                    break;
        //                }
        //            case "9":
        //                {
        //                    helper.SetSuppressGroup(rdBtnLstGroup.SelectedValue);
        //                    helper.RegisterSummary("ReportGroup", SummaryOperation.Sum, rdBtnLstGroup.SelectedValue);
        //                    helper.ApplyGroupSort();
        //                    break;
        //                }
        //            case "10":
        //                {
        //                    helper.RegisterGroup("ReportGroup", true, true);
        //                    helper.GroupHeader += new GroupEvent(helper_GroupHeader);
        //                    helper.ApplyGroupSort();
        //                    break;
        //                }
        //            case "11":
        //                {
        //                    string[] cols = new string[2];
        //                    cols[0] = "ReportGroup";
        //                    helper.RegisterGroup(cols, true, true);
        //                    helper.RegisterSummary("ReportGroup", SummaryOperation.Avg, "ReportGroup");
        //                    helper.GroupSummary += new GroupEvent(helper_GroupSummary);
        //                    helper.ApplyGroupSort();
        //                    break;
        //                }
        //            case "12":
        //                {
        //                    helper.RegisterGroup("ReportGroup", true, true);
        //                    helper.RegisterSummary("ReportGroup", SummaryOperation.Sum, "ReportGroup");
        //                    helper.RegisterSummary("ReportGroup", SummaryOperation.Sum);
        //                    helper.GroupSummary += new GroupEvent(helper_Bug);
        //                    helper.ApplyGroupSort();
        //                    break;
        //                }
        //            case "13":
        //                {
        //                    GridViewSummary s = helper.RegisterSummary("ReportGroup", SummaryOperation.Sum);
        //                    s.Automatic = false;
        //                    s = helper.RegisterSummary("ReportGroup", SummaryOperation.Count);
        //                    s.Automatic = false;
        //                    helper.GeneralSummary += new FooterEvent(helper_ManualSummary);
        //                    break;
        //                }
        //        }
        //    }

        //    private void helper_ManualSummary(GridViewRow row)
        //    {
        //        GridViewRow newRow = helper.InsertGridRow(row);
        //        newRow.Cells[0].HorizontalAlign = HorizontalAlign.Right;
        //        newRow.Cells[0].Text = String.Format("Total: {0} itens, {1:c}", helper.GeneralSummaries["ReportGroup"].Value);
        //    }

        //    private void helper_GroupSummary(string groupName, object[] values, GridViewRow row)
        //    {
        //        row.Cells[0].HorizontalAlign = HorizontalAlign.Right;
        //        row.Cells[0].Text = "Média";
        //    }

        //    private void helper_GroupHeader(string groupName, object[] values, GridViewRow row)
        //    {
        //        if (groupName == "ReportGroup")
        //        {
        //            row.BackColor = Color.LightGray;
        //            row.Cells[0].Text = "&nbsp;&nbsp;" + row.Cells[0].Text;
        //        }
        //        else if (groupName == "ReportGroup")
        //        {
        //            row.BackColor = Color.FromArgb(236, 236, 236);
        //            row.Cells[0].Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + row.Cells[0].Text;
        //        }
        //    }

        //    private void SaveQuantity(string column, string group, object value)
        //    {
        //        mQuantities.Add(Convert.ToInt32(value));
        //    }

        //    private object GetMinQuantity(string column, string group)
        //    {
        //        int[] qArray = new int[mQuantities.Count];
        //        mQuantities.CopyTo(qArray);
        //        Array.Sort(qArray);
        //        return qArray[0];
        //    }

        //    private void helper_Bug(string groupName, object[] values, GridViewRow row)
        //    {
        //        if (groupName == null) return;

        //        row.BackColor = Color.Bisque;
        //        row.Cells[0].HorizontalAlign = HorizontalAlign.Center;
        //        row.Cells[0].Text = "[ Summary for " + groupName + " " + values[0] + " ]";
        //    }
        //}
    }
}
/* Title:           Warehouse Trailer Inspection Class
 * Date:            9-4-18
 * Author:          Terry Holmes
 * 
 * Description:     This class is the class that will control the Warehouse Trailer Inspection */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewEventLogDLL;

namespace WarehouseTrailerInspectionDLL
{
    public class WarehouseTrailerInspectionClass
    {
        EventLogClass TheEventLogClass = new EventLogClass();

        WarehouseTrailerInspectionDataSet aWarehouseTrailerInspectionDataSet;
        WarehouseTrailerInspectionDataSetTableAdapters.warehousetrailerinspectionTableAdapter aWarehouseTrailerInspectionTableAdapter;

        InsertWarehouseTrailerInspectionEntryTableAdapters.QueriesTableAdapter aInsertWarehouseTrailerInspectionTableAdapter;

        FindWarehouseTrailerInspectionByTrailerNumberDataSet aFindWarehouseTrailerInspectionByTrailerNumberDataSet;
        FindWarehouseTrailerInspectionByTrailerNumberDataSetTableAdapters.FindWarehouseTrailerInspectionByTrailerNumberTableAdapter aFindWarehouseTrailerInspectionByTrailerNumberTableAdapter;

        FindWarehouseTrailerInspectionByEmployeeIDDataSet aFindWarehouseTrailerInspectionByEmployeeIDDataSet;
        FindWarehouseTrailerInspectionByEmployeeIDDataSetTableAdapters.FindWarehouseTrailerInspectionByEmployeeIDTableAdapter aFindWarehouseTrailerInspectionByEmployeeIDTableAdapter;

        FindWarehouseTrailerInspectionByDateRangeDataSet aFindWarehouseTrailerInspectionByDateRangeDataSet;
        FindWarehouseTrailerInspectionByDateRangeDataSetTableAdapters.FindWarehouseTrailerInspectionByDateRangeTableAdapter aFindWarehouseTrailerInspectionByDateRangeTableAdapter;

        public FindWarehouseTrailerInspectionByDateRangeDataSet FindWarehouseTrailerInspectionByDateRange(DateTime datStartDate, DateTime datEndDate)
        {
            try
            {
                aFindWarehouseTrailerInspectionByDateRangeDataSet = new FindWarehouseTrailerInspectionByDateRangeDataSet();
                aFindWarehouseTrailerInspectionByDateRangeTableAdapter = new FindWarehouseTrailerInspectionByDateRangeDataSetTableAdapters.FindWarehouseTrailerInspectionByDateRangeTableAdapter();
                aFindWarehouseTrailerInspectionByDateRangeTableAdapter.Fill(aFindWarehouseTrailerInspectionByDateRangeDataSet.FindWarehouseTrailerInspectionByDateRange, datStartDate, datEndDate);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Warehouse Trailer Inspection class // Find Warehouse Trailer Inspection By Date Range " + Ex.Message);
            }

            return aFindWarehouseTrailerInspectionByDateRangeDataSet;
        }
        public FindWarehouseTrailerInspectionByEmployeeIDDataSet FindWarehouseTrailerInspectionByEmployeeID(int intEmployeeID, DateTime datStartDate, DateTime datEndDate)
        {
            try
            {
                aFindWarehouseTrailerInspectionByEmployeeIDDataSet = new FindWarehouseTrailerInspectionByEmployeeIDDataSet();
                aFindWarehouseTrailerInspectionByEmployeeIDTableAdapter = new FindWarehouseTrailerInspectionByEmployeeIDDataSetTableAdapters.FindWarehouseTrailerInspectionByEmployeeIDTableAdapter();
                aFindWarehouseTrailerInspectionByEmployeeIDTableAdapter.Fill(aFindWarehouseTrailerInspectionByEmployeeIDDataSet.FindWarehouseTrailerInspectionByEmployeeID, intEmployeeID, datStartDate, datEndDate);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Warehouse Trailer Inspection Class // Find Warehouse Trailer Inspection By Employee ID " + Ex.Message);
            }

            return aFindWarehouseTrailerInspectionByEmployeeIDDataSet;
        }
        public FindWarehouseTrailerInspectionByTrailerNumberDataSet FindWarehouseTrailerInspectionByTrailerNumber(string strTrailerNumber, DateTime datStartDate, DateTime datEndDate)
        {
            try
            {
                aFindWarehouseTrailerInspectionByTrailerNumberDataSet = new FindWarehouseTrailerInspectionByTrailerNumberDataSet();
                aFindWarehouseTrailerInspectionByTrailerNumberTableAdapter = new FindWarehouseTrailerInspectionByTrailerNumberDataSetTableAdapters.FindWarehouseTrailerInspectionByTrailerNumberTableAdapter();
                aFindWarehouseTrailerInspectionByTrailerNumberTableAdapter.Fill(aFindWarehouseTrailerInspectionByTrailerNumberDataSet.FindWarehouseTrailerInspectionByTrailerNumber, strTrailerNumber, datStartDate, datEndDate);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Warehouse Trailer Inspection Class // Find Warehouse Trailer Inspectioin By Trailer Number " + Ex.Message);
            }

            return aFindWarehouseTrailerInspectionByTrailerNumberDataSet;
        }
        public bool InsertWarehouseTrailerInspection(int intTrailerID, int intEmployeeID, string strInspectionStatus, int intPartID, string strReelNumber, int intCurrentFootage, string strInspectionNotes)
        {
            bool blnFatalError = false;

            try
            {
                aInsertWarehouseTrailerInspectionTableAdapter = new InsertWarehouseTrailerInspectionEntryTableAdapters.QueriesTableAdapter();
                aInsertWarehouseTrailerInspectionTableAdapter.InsertWarehouseTrailerInspection(intTrailerID, intEmployeeID, DateTime.Now, strInspectionStatus, intPartID, strReelNumber, intCurrentFootage, strInspectionNotes);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Warehouse Trailer Inspection Class // Insert Warehouse Trailer Inspection " + Ex.Message);

                blnFatalError = true;
            }

            return blnFatalError;
        }
        public WarehouseTrailerInspectionDataSet GetWarehouseTrailerInspectionInfo()
        {
            try
            {
                aWarehouseTrailerInspectionDataSet = new WarehouseTrailerInspectionDataSet();
                aWarehouseTrailerInspectionTableAdapter = new WarehouseTrailerInspectionDataSetTableAdapters.warehousetrailerinspectionTableAdapter();
                aWarehouseTrailerInspectionTableAdapter.Fill(aWarehouseTrailerInspectionDataSet.warehousetrailerinspection);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Warehouse Trailer Inspection Class // Get Warehouse Trailer Inspection Info " + Ex.Message);
            }

            return aWarehouseTrailerInspectionDataSet;
        }
        public void UpdateWarehouseTrailerInspectionDB(WarehouseTrailerInspectionDataSet aWarehouseTrailerInspectionDataSet)
        {
            try
            {
                aWarehouseTrailerInspectionTableAdapter = new WarehouseTrailerInspectionDataSetTableAdapters.warehousetrailerinspectionTableAdapter();
                aWarehouseTrailerInspectionTableAdapter.Update(aWarehouseTrailerInspectionDataSet.warehousetrailerinspection);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Warehouse Trailer Inspection Class // Update Warehouse Trailer Inspection DB " + Ex.Message);
            }
        }
        
    }
}

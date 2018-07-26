using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;


public class AttendancePolicy
{
    Smartworks.DAL dataAccess = new Smartworks.DAL();

    public AttendancePolicy()
    {
        string connString = ConfigurationManager.ConnectionStrings["HSConnectionString"].ConnectionString;
        
        Smartworks.DAL.ConnectionString = connString;
    }

    public DataTable GetTimeAttendancePolicy()
    {
      return  dataAccess.getDataTable("Select * from [TimeAttendancePolicy]");
    }

    public void InsertUpdateTimeAttendancePolicy(ref int PolicyId, string PolicyCode, string DepartmentId, string ShiftID, int CasualLeave, int SickLeave, 
        int HalfDayStartTime, decimal OverTimeRate, string OverTimeBasedOn, int OverTimeStart, int EarlyLeaveAbsent, int AbsentAfter,
        DateTime DutyTimeOn, DateTime DutyTimeOff, DateTime StartAttTime, DateTime EndAttTime, int OffDayDutyRate, int GraceTime, 
        int ConsiderAfterLate, int DeductionAfterLate , Smartworks.DAL customdataAcess = null )
    {
        Smartworks.ColumnField[] iTimeAttendancePolicy = new Smartworks.ColumnField[20];
        iTimeAttendancePolicy[0] = new Smartworks.ColumnField("@PolicyId", PolicyId, true, SqlDbType.Int);
        iTimeAttendancePolicy[1] = new Smartworks.ColumnField("@PolicyCode", PolicyCode, false, SqlDbType.VarChar);
        iTimeAttendancePolicy[2] = new Smartworks.ColumnField("@DepartmentId", DepartmentId, false, SqlDbType.Int);
        iTimeAttendancePolicy[3] = new Smartworks.ColumnField("@ShiftID", ShiftID, false, SqlDbType.Int);
        iTimeAttendancePolicy[4] = new Smartworks.ColumnField("@CasualLeave", CasualLeave, false, SqlDbType.Int);
        iTimeAttendancePolicy[5] = new Smartworks.ColumnField("@SickLeave", SickLeave, false, SqlDbType.Int);
        iTimeAttendancePolicy[6] = new Smartworks.ColumnField("@HalfDayStartTime", HalfDayStartTime, false, SqlDbType.Int);
        iTimeAttendancePolicy[7] = new Smartworks.ColumnField("@OverTimeRate", OverTimeRate, false, SqlDbType.Decimal);
        iTimeAttendancePolicy[8] = new Smartworks.ColumnField("@OverTimeBasedOn", OverTimeBasedOn, false, SqlDbType.VarChar);
        iTimeAttendancePolicy[9] = new Smartworks.ColumnField("@OverTimeStart", OverTimeStart, false, SqlDbType.Int);
        iTimeAttendancePolicy[10] = new Smartworks.ColumnField("@EarlyLeaveAbsent", EarlyLeaveAbsent, false, SqlDbType.Int);
        iTimeAttendancePolicy[11] = new Smartworks.ColumnField("@AbsentAfter", AbsentAfter, false, SqlDbType.Int);
        iTimeAttendancePolicy[12] = new Smartworks.ColumnField("@DutyTimeOn", DutyTimeOn, false, SqlDbType.DateTime);
        iTimeAttendancePolicy[13] = new Smartworks.ColumnField("@DutyTimeOff", DutyTimeOff, false, SqlDbType.DateTime);
        iTimeAttendancePolicy[14] = new Smartworks.ColumnField("@StartAttTime", StartAttTime, false, SqlDbType.DateTime);
        iTimeAttendancePolicy[15] = new Smartworks.ColumnField("@EndAttTime", EndAttTime, false, SqlDbType.DateTime);
        iTimeAttendancePolicy[16] = new Smartworks.ColumnField("@OffDayDutyRate", OffDayDutyRate, false, SqlDbType.Int);
        iTimeAttendancePolicy[17] = new Smartworks.ColumnField("@GraceTime", GraceTime, false, SqlDbType.Int);
        iTimeAttendancePolicy[18] = new Smartworks.ColumnField("@ConsiderLateAfter", ConsiderAfterLate, false, SqlDbType.Int);
        iTimeAttendancePolicy[19] = new Smartworks.ColumnField("@DeductionAfterLate", DeductionAfterLate, false, SqlDbType.Int);

        if(customdataAcess != null)
        {
            customdataAcess.ExecuteStoredProcedure("InsertTimeAttendancePolicy", iTimeAttendancePolicy);
        }
        else
        {
            dataAccess.BeginTransaction();
            dataAccess.ExecuteStoredProcedure("InsertTimeAttendancePolicy", iTimeAttendancePolicy);
            dataAccess.TransCommit();
        }
            
        }
       
    }




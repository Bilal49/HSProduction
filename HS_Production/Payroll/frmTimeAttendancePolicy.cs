using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FIL.Payroll
{
    public partial class frmTimeAttendancePolicy : Form
    {
        AttendancePolicy managePolicy =  new AttendancePolicy();
        Smartworks.DAL dataAcess = new Smartworks.DAL();
        public frmTimeAttendancePolicy()
        {
            InitializeComponent();
        }

        private void frmTimeAttendancePolicy_Load(object sender, EventArgs e)
        {
            try
            {
                FillTimeAttendancePolicy();
            }
            catch (Exception ex)
            {
            }
        }

        private void FillTimeAttendancePolicy()
        {
            DataTable dtPolicy = managePolicy.GetTimeAttendancePolicy();
            if (dtPolicy.Rows.Count > 0)
            {
//                PolicyId
//PolicyCode
//DepartmentId
//ShiftID
//CasualLeave
//SickLeave
//HalfDayStartTime
//OverTimeBasedOn
//OverTimeRate
//OverTimeStart
//EarlyLeaveAbsent
//AbsentAfter
//DutyTimeOn
//DutyTimeOff
//StartAttTime
//EndAttTime
//GraceTime
//OffDayDutyRate
//ConsiderLateAfter
//DeductionAfterLate

                txtPolicyCode.Text = dtPolicy.Rows[0]["PolicyCode"].ToString();
                txtCasualLeave.Text = dtPolicy.Rows[0]["CasualLeave"].ToString();
                txtSickLeave.Text = dtPolicy.Rows[0]["SickLeave"].ToString();
                txtHalfDayStartTime.Text = dtPolicy.Rows[0]["HalfDayStartTime"].ToString();
                txtOverTimeRate.Text = dtPolicy.Rows[0]["OverTimeRate"].ToString();
                DutyTimeON.Value = Convert.ToDateTime(dtPolicy.Rows[0]["DutyTimeOn"]);
                DutyTimeOFF.Value = Convert.ToDateTime(dtPolicy.Rows[0]["DutyTimeOff"]);
                BeginAttTime.Value = Convert.ToDateTime(dtPolicy.Rows[0]["StartAttTime"]);
                EndAttTime.Value = Convert.ToDateTime(dtPolicy.Rows[0]["EndAttTime"]);
                txtGraceTime.Text = dtPolicy.Rows[0]["GraceTime"].ToString();
                txtLateAfter.Text = dtPolicy.Rows[0]["ConsiderLateAfter"].ToString();
                txtOffDayDutyRate.Text = dtPolicy.Rows[0]["OffDayDutyRate"].ToString();
                txtDeductionAfterLate.Text = dtPolicy.Rows[0]["DeductionAfterLate"].ToString();
            }
        }

        private bool Validations()
        {
            bool result = true;

            return result;
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Validations())
            {
                try
                {
                    int PolicyId = -1;
                    dataAcess.BeginTransaction();
                    managePolicy.InsertUpdateTimeAttendancePolicy(ref PolicyId, txtPolicyCode.Text, "-1", "-1", (string.IsNullOrEmpty(txtCasualLeave.Text) ? 0 : Convert.ToInt32(txtCasualLeave.Text)), (string.IsNullOrEmpty(txtSickLeave.Text) ? 0 : Convert.ToInt32(txtSickLeave.Text)),
                    (string.IsNullOrEmpty(txtHalfDayStartTime.Text) ? 0 : Convert.ToInt32(txtHalfDayStartTime.Text)), (string.IsNullOrEmpty(txtOverTimeRate.Text) ? 0 : Convert.ToInt32(txtOverTimeRate.Text)), "", 0, 0, 0,
                    DutyTimeON.Value, DutyTimeOFF.Value, BeginAttTime.Value, EndAttTime.Value, (string.IsNullOrEmpty(txtOffDayDutyRate.Text) ? 0 : Convert.ToInt32(txtOffDayDutyRate.Text)), (string.IsNullOrEmpty(txtGraceTime.Text) ? 0 : Convert.ToInt32(txtGraceTime.Text)),
                    (string.IsNullOrEmpty(txtLateAfter.Text) ? 0 : Convert.ToInt32(txtLateAfter.Text)), (string.IsNullOrEmpty(txtDeductionAfterLate.Text) ? 0 : Convert.ToInt32(txtDeductionAfterLate.Text)), dataAcess);
                    dataAcess.TransCommit();

                    MessageBox.Show("Time Attendance Policy Save Sucessfully", "Record Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FillTimeAttendancePolicy();

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
    }
}

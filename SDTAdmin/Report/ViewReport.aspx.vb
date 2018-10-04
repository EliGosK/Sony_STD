Imports Web.Data
Partial Public Class ViewReport
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Dim myConnection As New SqlClient.SqlConnection()
        'myConnection.ConnectionString = "server= (local)\NetSDK;database=pubs;Trusted_Connection=yes"
        'Dim MyCommand As New SqlClient.SqlCommand()
        'MyCommand.Connection = myConnection
        'MyCommand.CommandText = "Select * from Stores"
        'MyCommand.CommandType = CommandType.Text
        'Dim MyDA As New SqlClient.SqlDataAdapter()
        'MyDA.SelectCommand = MyCommand
        'Dim myDS As New DataSet
        ''This is our DataSet created at Design Time      
        'MyDA.Fill(myDS, "Stores")
        ''You have to use the same name as that of your Dataset that you created during design time
        Dim oRpt As New rptBoxOffice()
        Dim theaterRead As New cDatabase
        ' This is the Crystal Report file created at Design Time
        oRpt.SetDataSource(theaterRead.GetRevenuDetail("100", "1", "2"))
        ' Set the SetDataSource property of the Report to the Dataset
        CrystalReportViewer1.ReportSource = oRpt
        ' Set the Crystal Report Viewer's property to the oRpt Report object that we created
    End Sub
End Class
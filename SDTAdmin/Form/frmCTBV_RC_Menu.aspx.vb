Imports System.Web.Security

Partial Public Class frmCTBV_RC_Menu
    Inherits Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Mid(Session("permission"), 11, 1) = "0" Then
            Response.Redirect("InfoPage.aspx")
        End If

        If Mid(Session("permission"), 15, 1) = "0" Then
            hplExportBoxOffice.Enabled = False
            hplExportBoxOffice.ForeColor = Color.Gray
        End If
        If Mid(Session("permission"), 16, 1) = "0" Then
            hplSdtDailyBoxOffice.Enabled = False
            hplSdtDailyBoxOffice.ForeColor = Color.Gray
        End If
        If Mid(Session("permission"), 17, 1) = "0" Then
            hplCompDailyBoxOffice.Enabled = False
            hplCompDailyBoxOffice.ForeColor = Color.Gray
        End If
        If Mid(Session("permission"), 18, 1) = "0" Then
            hplSdtWeeklyBoxOffice.Enabled = False
            hplSdtWeeklyBoxOffice.ForeColor = Color.Gray
        End If
        If Mid(Session("permission"), 19, 1) = "0" Then
            hplWeekendTrading.Enabled = False
            hplWeekendTrading.ForeColor = Color.Gray
        End If
        If Mid(Session("permission"), 20, 1) = "0" Then
            'hplSdtMarketShare.Enabled = False
            'hplSdtMarketShare.ForeColor = Color.Gray

            hplMovieMarketShare.Enabled = False
            hplMovieMarketShare.ForeColor = Color.Gray
        End If
        If Mid(Session("permission"), 21, 1) = "0" Then
            hplCompMarketShare.Enabled = False
            hplCompMarketShare.ForeColor = Color.Gray
        End If
        If Not CheckPermission(AdminPage.Report_GeneralIndustryMarketShare, False) Then
            'hplGeneralIndustryMarketShare.Enabled = False
            'hplGeneralIndustryMarketShare.ForeColor = Color.Gray

            hplGeneralIndustryMarketShare2.Enabled = False
            hplGeneralIndustryMarketShare2.ForeColor = Color.Gray
        End If
        If Mid(Session("permission"), 23, 1) = "0" Then
            hplSdtBoxOfficeBySoundAndFilm.Enabled = False
            hplSdtBoxOfficeBySoundAndFilm.ForeColor = Color.Gray
        End If
        If Mid(Session("permission"), 24, 1) = "0" Then
            'hplSdtCheckerWage.Enabled = False
            'hplSdtCheckerWage.ForeColor = Color.Gray          

            hplSdtCheckerWageNew.Enabled = False
            hplSdtCheckerWageNew.ForeColor = Color.Gray
        End If
        If Mid(Session("permission"), 25, 1) = "0" Then
            hplBoxOfficeByTitle.Enabled = False
            hplBoxOfficeByTitle.ForeColor = Color.Gray
        End If
        If Mid(Session("permission"), 33, 1) = "0" Then
            hplTheaterInfo.Enabled = False
            hplTheaterInfo.ForeColor = Color.Gray
        End If
        If Mid(Session("permission"), 34, 1) = "0" Then
            hplOccupencyReport.Enabled = False
            hplOccupencyReport.ForeColor = Color.Gray
        End If
        If Mid(Session("permission"), 35, 1) = "0" Then
            hplIndustryInfo.Enabled = False
            hplIndustryInfo.ForeColor = Color.Gray
        End If

        If Mid(Session("permission"), 36, 1) = "0" Then
            hplCompBoxOfficeBySoundAndFilm.Enabled = False
            hplCompBoxOfficeBySoundAndFilm.ForeColor = Color.Gray
        End If

        If Not CheckPermission(AdminPage.Report_FreeTicketAndPerCapAndTicketTypeSummary, False) Then
            hplFreeTicketSummary.Enabled = False
            hplFreeTicketSummary.ForeColor = Color.Gray
        End If
    End Sub

    Protected Sub ImbOutClick(ByVal sender As Object, ByVal e As ImageClickEventArgs) Handles imbOut.Click
        FormsAuthentication.SignOut()
        FormsAuthentication.RedirectToLoginPage()
    End Sub
End Class
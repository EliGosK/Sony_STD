Public Partial Class popUpCal
    Inherits System.Web.UI.UserControl
    Public Sub displayCalendar(ByVal sCalToolText As String, _
ByVal dSelectedDate As Date, _
ByVal sDateFieldName As String, _
ByVal iTop As Integer, _
ByVal iLeft As Integer)
        '************************************************************************
        'Purpose: Displays & hides the calendar. 
        'Input: sCalToolText - Text to use as the tooltip text for the calendar
        ' dSelectedDate - Date to set as the selected date for the calendar
        ' txtDate - string containing name of applicable textbox 
        ' iTop - top position of calendar
        ' iLeft - left position of calendar
        '************************************************************************

        'If the calendar is visible, but it is displayed for a different field
        'than the one selected, then hide it
        If pnlCalendar.Visible = True And Calendar1.Attributes.Item("selectedfield") <> sDateFieldName Then
            hideCalendar()
        End If

        'If the calendar is hidden, then position it and show it, otherwise hide it
        If pnlCalendar.Visible = False Then

            'Set the location of the calendar
            'pnlCalendar.Style.Item("top") = iTop
            'pnlCalendar.Style.Item("left") = iLeft
            pnlCalendar.Attributes.Add("style", "POSITION: absolute")
            'If a valid date is passed in, then set this date as the selected date
            'on the calendar. Otherwise display the current month and year 
            If IsDate(dSelectedDate) Then
                'Setting the selected date property will tell the calendar to 
                'highlight the date assigned to this property.
                Calendar1.SelectedDate = dSelectedDate

                'Setting the visible date property will tell the calendar to
                'initially display the month and year of the date assigned to 
                'this property.
                Calendar1.VisibleDate = dSelectedDate
            Else
                Calendar1.SelectedDate = #12:00:00 AM#
                Calendar1.VisibleDate = Now
            End If

            'Set the tooltip text and id of the selected field
            Calendar1.ToolTip = sCalToolText
            Calendar1.Attributes.Item("SelectedField") = sDateFieldName

            'Show the calendar
            pnlCalendar.Visible = True
        Else
            'Hide the calendar
            hideCalendar()
        End If

    End Sub
    Public Sub Calendar1_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Calendar1.SelectionChanged
        '************************************************************************
        'Purpose: Write the selected date to the appropriate text field.
        '************************************************************************
        Dim txtDate As TextBox

        'get the textbox that the date should be written to
        txtDate = Page.FindControl(Calendar1.Attributes.Item("SelectedField"))

        'Write value to appropriate textbox
        txtDate.Text = Calendar1.SelectedDate.ToString("dd-MMMM-yyyy")

        'Hide the calendar
        hideCalendar()

    End Sub

    Public Sub hideCalendar()
        'Hide the calendar
        pnlCalendar.Visible = False
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

End Class
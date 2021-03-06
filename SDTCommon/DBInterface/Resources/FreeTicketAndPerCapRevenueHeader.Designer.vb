﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:2.0.50727.8689
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On

Imports System

Namespace My.Resources
    
    'This class was auto-generated by the StronglyTypedResourceBuilder
    'class via a tool like ResGen or Visual Studio.
    'To add or remove a member, edit your .ResX file then rerun ResGen
    'with the /str option, or rebuild your VS project.
    '''<summary>
    '''  A strongly-typed resource class, for looking up localized strings, etc.
    '''</summary>
    <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "2.0.0.0"),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute()>  _
    Friend Class FreeTicketAndPerCapRevenueHeader
        
        Private Shared resourceMan As Global.System.Resources.ResourceManager
        
        Private Shared resourceCulture As Global.System.Globalization.CultureInfo
        
        <Global.System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")>  _
        Friend Sub New()
            MyBase.New
        End Sub
        
        '''<summary>
        '''  Returns the cached ResourceManager instance used by this class.
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Friend Shared ReadOnly Property ResourceManager() As Global.System.Resources.ResourceManager
            Get
                If Object.ReferenceEquals(resourceMan, Nothing) Then
                    Dim temp As Global.System.Resources.ResourceManager = New Global.System.Resources.ResourceManager("SDTCommon.FreeTicketAndPerCapRevenueHeader", GetType(FreeTicketAndPerCapRevenueHeader).Assembly)
                    resourceMan = temp
                End If
                Return resourceMan
            End Get
        End Property
        
        '''<summary>
        '''  Overrides the current thread's CurrentUICulture property for all
        '''  resource lookups using this strongly typed resource class.
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Friend Shared Property Culture() As Global.System.Globalization.CultureInfo
            Get
                Return resourceCulture
            End Get
            Set
                resourceCulture = value
            End Set
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to DELETE tblFreeTicketAndCapRevenueHeader
        '''WHERE revenue_id = @revenue_id;.
        '''</summary>
        Friend Shared ReadOnly Property DeleteRevenue() As String
            Get
                Return ResourceManager.GetString("DeleteRevenue", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to INSERT INTO tblFreeTicketAndCapRevenueHeader
        '''(
        ''' revenue_id
        ''' , free_ticket_norm_count
        ''' , free_ticket_special_count
        ''' , free_more_5_count
        ''' , free_more_5_sum
        ''' , update_by
        ''' , update_date
        ''')
        '''VALUES
        '''(
        ''' @revenue_id
        ''' , @free_ticket_norm_count
        ''' , @free_ticket_special_count
        ''' , @free_more_5_count
        ''' , @free_more_5_sum
        ''' , @update_by
        ''' , @cvDate
        ''');.
        '''</summary>
        Friend Shared ReadOnly Property Insert() As String
            Get
                Return ResourceManager.GetString("Insert", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to SELECT
        '''	rv.revenueid
        '''	, rv.revenue_adms
        '''	, rv.revenue_amount
        '''	, rv.revenue_date
        '''	, rv.revenue_Time
        '''	, rv.revenue_LastUpdate
        '''	, rv.revenue_type
        '''	, rv.theatersub_id
        '''	, rv.user_id
        '''	, rv.movie_system
        '''	, rv.movies_id
        '''	, rv.theater_id
        '''	, rv.status_id
        '''	, rv.sound_type
        '''	, rv.timehour_id
        '''	, rv.timemin_id
        '''	, rv.film_type_sound_id
        '''	, rv.revenue_amount_no_cap
        '''	, rv.revenue_adms_with_free_ticket
        '''	, rv.check_ticket
        '''	, m.movie_id
        '''	, m.movietype_id
        '''	, SUBSTRING(m.movie_nameen, 1, 15) AS ShortName
        '''	, [rest of string was truncated]&quot;;.
        '''</summary>
        Friend Shared ReadOnly Property SelectAllIncomplete() As String
            Get
                Return ResourceManager.GetString("SelectAllIncomplete", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to SELECT
        '''	rv.revenueid AS revenue_id
        '''	, rv.revenue_amount
        '''	, rv.revenue_amount_no_cap
        '''	, rv.revenue_adms
        '''	, rv.revenue_adms_with_free_ticket
        '''	, rv.movies_id AS movie_id
        '''	, ISNULL(ftrh.free_ticket_norm_count, 0) AS free_ticket_norm_count
        '''	, ISNULL(ftrh.free_ticket_special_count, 0) AS free_ticket_special_count
        '''	, ISNULL(ftrh.free_more_5_count, 0) AS free_more_5_count
        '''	, ISNULL(ftrh.free_more_5_sum, 0) AS free_more_5_sum
        '''	, ISNULL(free_ticket.count_revenue_free, 0) AS count_revenue_free
        '''	, ISNULL(fr [rest of string was truncated]&quot;;.
        '''</summary>
        Friend Shared ReadOnly Property SelectCheckRevenue() As String
            Get
                Return ResourceManager.GetString("SelectCheckRevenue", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to SELECT
        ''' revenue_id
        ''' , free_ticket_norm_count
        ''' , free_ticket_special_count
        ''' , free_more_5_count
        ''' , free_more_5_sum
        ''' , update_by
        ''' , update_date
        '''FROM tblFreeTicketAndCapRevenueHeader
        '''WHERE revenue_id = @revenue_id;.
        '''</summary>
        Friend Shared ReadOnly Property SelectData() As String
            Get
                Return ResourceManager.GetString("SelectData", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to SELECT DISTINCT
        '''	rv.movies_id AS movie_id
        '''FROM tblRevenue AS rv
        '''LEFT JOIN tblFreeTicketAndCapRevenueHeader AS ftrh
        '''	ON ftrh.revenue_id = rv.revenueid
        '''LEFT JOIN
        '''(
        '''	SELECT
        '''		ftrd.revenue_id
        '''		, SUM(CASE 
        '''				WHEN ftc.counting = 1
        '''					THEN ftrd.quantity
        '''				ELSE 0
        '''				END) AS count_revenue_free
        '''		, SUM(CASE 
        '''				WHEN ftc.counting = 1
        '''					THEN 0
        '''				ELSE ftrd.quantity
        '''				END) AS count_revenue_cap
        '''		, SUM(CASE 
        '''				WHEN ftc.counting = 0 OR rv.revenue_date &gt; ftcm.available_to
        '''					THEN 0
        ''' [rest of string was truncated]&quot;;.
        '''</summary>
        Friend Shared ReadOnly Property SelectIncompleteMovie() As String
            Get
                Return ResourceManager.GetString("SelectIncompleteMovie", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to UPDATE tblFreeTicketAndCapRevenueHeader
        '''SET
        ''' free_ticket_norm_count = @free_ticket_norm_count
        ''' , free_ticket_special_count = @free_ticket_special_count
        ''' , free_more_5_count = @free_more_5_count
        ''' , free_more_5_sum = @free_more_5_sum
        ''' , update_by = @update_by
        ''' , update_date = @cvDate
        '''WHERE revenue_id = @revenue_id;.
        '''</summary>
        Friend Shared ReadOnly Property Update() As String
            Get
                Return ResourceManager.GetString("Update", resourceCulture)
            End Get
        End Property
    End Class
End Namespace

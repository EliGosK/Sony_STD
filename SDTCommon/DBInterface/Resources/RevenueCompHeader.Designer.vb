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
    Friend Class RevenueCompHeader
        
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
                    Dim temp As Global.System.Resources.ResourceManager = New Global.System.Resources.ResourceManager("SDTCommon.RevenueCompHeader", GetType(RevenueCompHeader).Assembly)
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
        '''  Looks up a localized string similar to DECLARE @revenue_comp_header_id AS INT
        '''SELECT @revenue_comp_header_id = revenue_comp_header_id FROM tblRevenueCompHeader
        '''WHERE revenue_date = @revenue_date
        '''	AND movie_id = @movie_id
        '''	AND theater_id = @theater_id
        ''';
        '''DELETE tblRevenueCompDetail
        '''WHERE revenue_comp_header_id = @revenue_comp_header_id
        ''';
        '''DELETE tblRevenueCompHeader
        '''WHERE revenue_comp_header_id = @revenue_comp_header_id
        ''';
        '''DELETE tblCompRevenue
        '''WHERE comprevenue_id = @revenue_comp_header_id
        ''';.
        '''</summary>
        Friend Shared ReadOnly Property Delete() As String
            Get
                Return ResourceManager.GetString("Delete", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to DELETE tblRevenueCompDetail
        '''WHERE revenue_comp_header_id = @revenue_comp_header_id
        ''';
        '''DELETE tblRevenueCompHeader
        '''WHERE revenue_comp_header_id = @revenue_comp_header_id
        ''';
        '''DELETE tblCompRevenue
        '''WHERE comprevenue_id = @revenue_comp_header_id
        ''';.
        '''</summary>
        Friend Shared ReadOnly Property DeleteAll() As String
            Get
                Return ResourceManager.GetString("DeleteAll", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to INSERT INTO tblRevenueCompHeader (
        '''	revenue_date
        '''	, movie_id
        '''	, theater_id
        '''	, all_screen
        '''	, all_session
        '''	, all_adms
        '''	, all_amount
        '''	, status_id
        '''	, update_by
        '''	, update_date
        '''	)
        '''VALUES (
        '''	@revenue_date
        '''	, @movie_id
        '''	, @theater_id
        '''	, @all_screen
        '''	, @all_session
        '''	, @all_adms
        '''	, @all_amount
        '''	, @status_id
        '''	, @update_by
        '''	, @cvDate
        '''	);
        '''
        '''SELECT SCOPE_IDENTITY();.
        '''</summary>
        Friend Shared ReadOnly Property Insert() As String
            Get
                Return ResourceManager.GetString("Insert", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to SELECT ch.revenue_comp_header_id AS comprevenue_id
        '''	, ch.revenue_date AS comprevenue_date
        '''	, ch.movie_id AS movies_id
        '''	, ch.theater_id AS theater_id
        '''	, ch.all_screen AS comprevenue_screensum
        '''	, ch.all_session AS comprevenue_timesum
        '''	, ch.all_adms AS comprevenue_admssum
        '''	, ch.all_amount AS comprevenue_amountsum
        '''	, ch.status_id AS status_id
        '''	, ch.update_by AS user_id
        '''	, ch.update_date AS comprevenue_lastupdate
        '''	, SUM(CASE 
        '''			WHEN cd.film_type_sound_id IN (
        '''					1
        '''					, 5
        '''					)
        '''				THEN cd.a [rest of string was truncated]&quot;;.
        '''</summary>
        Friend Shared ReadOnly Property InsertUpdateOldTable() As String
            Get
                Return ResourceManager.GetString("InsertUpdateOldTable", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to UPDATE header
        '''SET
        '''	header.all_screen = new_data.new_all_screen
        '''	, header.all_session = new_data.new_all_session
        '''	, header.all_adms = new_data.new_all_adms
        '''	, header.all_amount = new_data.new_all_amount
        '''	, header.status_id = CASE WHEN header.status_id = 1 THEN 1 ELSE new_data.new_status_id END
        '''	, header.update_by = @update_by
        '''	, header.update_date = @cvDate
        '''FROM tblRevenueCompHeader header
        '''INNER JOIN
        '''(
        '''	SELECT
        '''		detail.revenue_comp_header_id
        '''		, SUM(detail.count_screen) AS new_all_screen
        '''		, S [rest of string was truncated]&quot;;.
        '''</summary>
        Friend Shared ReadOnly Property RefreshHeaderAfterEditDetail() As String
            Get
                Return ResourceManager.GetString("RefreshHeaderAfterEditDetail", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to SELECT
        '''	rch.revenue_comp_header_id
        '''	, rch.revenue_date
        '''	, rch.movie_id
        '''	, rch.theater_id
        '''	, rch.all_screen
        '''	, rch.all_session
        '''	, rch.all_adms
        '''	, rch.all_amount
        '''	, rch.status_id
        '''	, rch.update_by
        '''	, rch.update_date
        '''	
        '''	, m.movietype_id
        '''	, SUBSTRING(m.movie_nameen, 1, 15) AS ShortName
        '''	, m.movie_nameen + &apos;/&apos; + m.movie_nameth AS MovieName
        '''FROM tblRevenueCompHeader AS rch
        '''INNER JOIN tblMovie AS m
        '''	ON m.movie_id = rch.movie_id.
        '''</summary>
        Friend Shared ReadOnly Property SelectData() As String
            Get
                Return ResourceManager.GetString("SelectData", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to UPDATE tblRevenueCompHeader
        '''SET
        '''	revenue_date = @revenue_date
        '''	, movie_id = @movie_id
        '''	, theater_id = @theater_id
        '''	, all_screen = @all_screen
        '''	, all_session = @all_session
        '''	, all_adms = @all_adms
        '''	, all_amount = @all_amount
        '''	, status_id = @status_id
        '''	, update_by = @update_by
        '''	, update_date = @cvDate
        '''WHERE revenue_comp_header_id = @revenue_comp_header_id
        ''';.
        '''</summary>
        Friend Shared ReadOnly Property Update() As String
            Get
                Return ResourceManager.GetString("Update", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to UPDATE tblRevenueCompHeader
        '''SET
        '''	status_id = @status_id
        '''	, update_date = @cvDate
        '''WHERE revenue_comp_header_id = @revenue_comp_header_id
        ''';.
        '''</summary>
        Friend Shared ReadOnly Property UpdateStatus() As String
            Get
                Return ResourceManager.GetString("UpdateStatus", resourceCulture)
            End Get
        End Property
    End Class
End Namespace
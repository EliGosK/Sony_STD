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
    Friend Class RevenueCompDetail
        
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
                    Dim temp As Global.System.Resources.ResourceManager = New Global.System.Resources.ResourceManager("SDTCommon.RevenueCompDetail", GetType(RevenueCompDetail).Assembly)
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
        '''SELECT @revenue_comp_header_id = revenue_comp_header_id FROM tblRevenueCompDetail
        '''WHERE revenue_id = @revenue_id;
        '''
        '''DELETE tblRevenueCompDetail
        '''WHERE revenue_id = @revenue_id;
        '''
        '''SELECT @revenue_comp_header_id;.
        '''</summary>
        Friend Shared ReadOnly Property Delete() As String
            Get
                Return ResourceManager.GetString("Delete", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to INSERT INTO tblRevenueCompDetail
        '''(
        '''	revenue_comp_header_id
        '''	, film_type_sound_id
        '''	, count_screen
        '''	, count_session
        '''	, adms
        '''	, amount
        '''	, status_id
        '''	, update_by
        '''	, update_date
        ''')
        '''VALUES 
        '''(
        '''	@revenue_comp_header_id
        '''	, @film_type_sound_id
        '''	, @count_screen
        '''	, @count_session
        '''	, @adms
        '''	, @amount
        '''	, @status_id
        '''	, @update_by
        '''	, @cvDate
        ''')
        ''';.
        '''</summary>
        Friend Shared ReadOnly Property Insert() As String
            Get
                Return ResourceManager.GetString("Insert", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to SELECT
        '''	rcd.revenue_id
        '''	, rcd.revenue_comp_header_id
        '''	, rcd.film_type_sound_id
        '''	, rcd.count_screen
        '''	, rcd.count_session
        '''	, rcd.adms
        '''	, rcd.amount
        '''	, rcd.status_id
        '''	, rcd.update_by
        '''	, rcd.update_date
        '''
        '''	, rch.revenue_comp_header_id
        '''	, rch.revenue_date
        '''	, rch.movie_id
        '''	, rch.theater_id
        '''	, rch.all_screen
        '''	, rch.all_session
        '''	, rch.all_adms
        '''	, rch.all_amount
        '''	, rch.status_id AS header_status_id  
        '''  
        '''	, fts.film_type_sound_name_th
        '''	, fts.film_type_sound_header_group
        '''FROM tblRevenueCompDetai [rest of string was truncated]&quot;;.
        '''</summary>
        Friend Shared ReadOnly Property SelectData() As String
            Get
                Return ResourceManager.GetString("SelectData", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to DECLARE @revenue_comp_header_id AS INT
        '''SELECT @revenue_comp_header_id = revenue_comp_header_id FROM tblRevenueCompDetail
        '''WHERE revenue_id = @revenue_id;
        '''
        '''UPDATE tblRevenueCompDetail
        '''SET 
        '''	film_type_sound_id = @film_type_sound_id
        '''	, count_screen = @count_screen
        '''	, count_session = @count_session
        '''	, adms = @adms
        '''	, amount = @amount
        '''	, status_id = @status_id
        '''	, update_by = @update_by
        '''	, update_date = @cvDate
        '''WHERE revenue_id = @revenue_id
        ''';
        '''
        '''SELECT @revenue_comp_header_id;.
        '''</summary>
        Friend Shared ReadOnly Property Update() As String
            Get
                Return ResourceManager.GetString("Update", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to UPDATE tblRevenueCompDetail
        '''SET 
        '''	status_id = @status_id
        '''	, update_date = @cvDate
        '''WHERE revenue_comp_header_id = @revenue_comp_header_id;.
        '''</summary>
        Friend Shared ReadOnly Property UpdateStatus() As String
            Get
                Return ResourceManager.GetString("UpdateStatus", resourceCulture)
            End Get
        End Property
    End Class
End Namespace

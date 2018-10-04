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
    Friend Class TicketType
        
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
                    Dim temp As Global.System.Resources.ResourceManager = New Global.System.Resources.ResourceManager("SDTCommon.TicketType", GetType(TicketType).Assembly)
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
        '''  Looks up a localized string similar to INSERT INTO tblTicketType 
        '''(
        '''	ticket_type_name
        '''	, circuit_id
        '''	, list_theater_id
        '''	, active_flag
        '''	, create_date
        '''	, create_by
        '''	, update_date
        '''	, update_by
        ''')
        '''VALUES 
        '''(
        '''	@ticket_type_name
        '''	, @circuit_id
        '''	, @list_theater_id
        '''	, @active_flag
        '''	, @cvDate
        '''	, @create_by
        '''	, @cvDate
        '''	, @create_by
        ''');.
        '''</summary>
        Friend Shared ReadOnly Property Insert() As String
            Get
                Return ResourceManager.GetString("Insert", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to SELECT 
        '''	tt.ticket_type_id
        '''	, tt.ticket_type_name
        '''	, tt.circuit_id
        '''	, tt.list_theater_id
        '''	, tt.active_flag
        '''	, tt.create_date
        '''	, tt.create_by
        '''	, tt.update_date
        '''	, tt.update_by
        '''	, dbo.[fnGetTheaterNameList](tt.list_theater_id) AS theater_name_list
        '''	, usr.user_name AS update_name
        '''FROM tblTicketType AS tt
        '''LEFT JOIN tblUser AS usr
        '''	ON usr.user_id = tt.update_by.
        '''</summary>
        Friend Shared ReadOnly Property SelectData() As String
            Get
                Return ResourceManager.GetString("SelectData", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to UPDATE tblTicketType 
        '''SET
        '''	ticket_type_name = @ticket_type_name
        '''	, circuit_id = @circuit_id
        '''	, list_theater_id = @list_theater_id
        '''	, active_flag = @active_flag
        '''	, update_date = @cvDate
        '''	, update_by = @update_by
        '''WHERE ticket_type_id = @ticket_type_id;.
        '''</summary>
        Friend Shared ReadOnly Property Update() As String
            Get
                Return ResourceManager.GetString("Update", resourceCulture)
            End Get
        End Property
    End Class
End Namespace

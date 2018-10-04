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
    Friend Class FreeTicketAndPerCap
        
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
                    Dim temp As Global.System.Resources.ResourceManager = New Global.System.Resources.ResourceManager("SDTCommon.FreeTicketAndPerCap", GetType(FreeTicketAndPerCap).Assembly)
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
        '''  Looks up a localized string similar to INSERT INTO tblFreeTicketAndCap 
        '''(
        '''	ticket_cap_name
        '''	, list_price
        '''	, price_step
        '''	, default_price
        '''	, circuit_id
        '''	, list_theater_id
        '''	, counting
        '''	, active_flag 
        '''	, create_date
        '''	, create_by
        '''	, update_date
        '''	, update_by
        ''')
        '''VALUES 
        '''(
        '''	@ticket_cap_name
        '''	, @list_price
        '''	, @price_step
        '''	, @default_price
        '''	, @circuit_id
        '''	, @list_theater_id
        '''	, @counting
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
        '''	ftc.ticket_cap_id
        '''	, ftc.ticket_cap_name
        '''	, ftc.list_price
        '''	, ftc.price_step
        '''	, ftc.default_price
        '''	, ftc.circuit_id
        '''	, ftc.list_theater_id
        '''	, ftc.counting
        '''	, ftc.active_flag
        '''	, ftc.create_date
        '''	, ftc.create_by
        '''	, ftc.update_date
        '''	, ftc.update_by
        '''	, CASE 
        '''		WHEN CHARINDEX(&apos;,&apos;, ftc.list_price) = 0
        '''			THEN ftc.list_price
        '''		ELSE SUBSTRING(ftc.list_price, 0, CHARINDEX(&apos;,&apos;, ftc.list_price)) + &apos; - &apos; + SUBSTRING(ftc.list_price, LEN(ftc.list_price) - CHARINDEX(&apos;,&apos;, REVERSE(ftc.list_price))  [rest of string was truncated]&quot;;.
        '''</summary>
        Friend Shared ReadOnly Property SelectData() As String
            Get
                Return ResourceManager.GetString("SelectData", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to UPDATE tblFreeTicketAndCap 
        '''SET
        '''	ticket_cap_name = @ticket_cap_name
        '''	, list_price = @list_price
        '''	, price_step = @price_step
        '''	, default_price = @default_price
        '''	, circuit_id = @circuit_id
        '''	, list_theater_id = @list_theater_id
        '''	, counting = @counting
        '''	, active_flag = @active_flag
        '''	, update_date = @cvDate
        '''	, update_by = @update_by
        '''WHERE ticket_cap_id = @ticket_cap_id;.
        '''</summary>
        Friend Shared ReadOnly Property Update() As String
            Get
                Return ResourceManager.GetString("Update", resourceCulture)
            End Get
        End Property
    End Class
End Namespace

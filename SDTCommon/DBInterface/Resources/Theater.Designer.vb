﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:2.0.50727.6400
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
    Friend Class Theater
        
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
                    Dim temp As Global.System.Resources.ResourceManager = New Global.System.Resources.ResourceManager("SDTCommon.Theater", GetType(Theater).Assembly)
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
        '''  Looks up a localized string similar to SELECT t.theater_id
        '''	, t.theater_code
        '''	, t.theater_name
        '''	, t.theater_des
        '''	, t.theater_status
        '''	, t.theater_lastupdate
        '''	, t.user_id
        '''	, t.circuit_id
        '''	, t.open_date
        '''	, t.close_date
        '''	, t.remark
        '''	--, c.circuit_id
        '''	, c.circuit_name
        '''	, c.circuit_address
        '''	, c.circuit_tel
        '''	, c.circuit_remark
        '''	, c.circuit_lastupdate
        '''--, c.user_id
        '''FROM tblUserTheater AS ut
        '''INNER JOIN tblTheater AS t
        '''	ON t.theater_id = ut.theater_id
        '''INNER JOIN tblCircuit AS c
        '''	ON c.circuit_id = t.circuit_id.
        '''</summary>
        Friend Shared ReadOnly Property SelectByUser() As String
            Get
                Return ResourceManager.GetString("SelectByUser", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to SELECT
        '''	t.theater_id
        '''	, t.theater_code
        '''	, t.theater_name
        '''	, t.theater_des
        '''	, t.theater_status
        '''	, t.theater_lastupdate
        '''	, t.user_id
        '''	, t.circuit_id
        '''	, t.open_date
        '''	, t.close_date
        '''	, t.remark
        '''	
        '''	--, c.circuit_id
        '''	, c.circuit_name
        '''	, c.circuit_address
        '''	, c.circuit_tel
        '''	, c.circuit_remark
        '''	, c.circuit_lastupdate
        '''	--, c.user_id
        '''FROM tblTheater AS t
        '''INNER JOIN tblCircuit AS c
        '''	ON c.circuit_id = t.circuit_id.
        '''</summary>
        Friend Shared ReadOnly Property SelectData() As String
            Get
                Return ResourceManager.GetString("SelectData", resourceCulture)
            End Get
        End Property
    End Class
End Namespace

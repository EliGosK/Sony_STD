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
    Friend Class TicketTypeByMovie
        
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
                    Dim temp As Global.System.Resources.ResourceManager = New Global.System.Resources.ResourceManager("SDTCommon.TicketTypeByMovie", GetType(TicketTypeByMovie).Assembly)
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
        '''  Looks up a localized string similar to DELETE
        '''FROM tblTicketTypeByMovie
        '''WHERE movie_id = @movie_id
        ''' AND ticket_type_id = @ticket_type_id
        ''' AND theater_id = @theater_id;.
        '''</summary>
        Friend Shared ReadOnly Property Delete() As String
            Get
                Return ResourceManager.GetString("Delete", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to SELECT
        '''	ttm.movie_id
        '''	, ttm.ticket_type_id
        '''	, ttm.theater_id
        '''	, ttm.create_date
        '''	, ttm.create_by
        '''	, ttm.update_date
        '''	, ttm.update_by
        '''	, tt.ticket_type_name
        '''	, tt.circuit_id
        '''	, tt.list_theater_id
        '''	, tt.active_flag
        '''	, dbo.[fnGetTheaterNameList](tt.list_theater_id) AS theater_name_list
        '''	, t.theater_name
        '''	, usr.user_name AS update_name
        '''	, CONVERT(VARCHAR, ttm.movie_id) + &apos;,&apos; + CONVERT(VARCHAR, ttm.ticket_type_id) + &apos;,&apos; + CONVERT(VARCHAR, ttm.theater_id) AS key_string
        '''FROM tblTicketTypeByMovie AS [rest of string was truncated]&quot;;.
        '''</summary>
        Friend Shared ReadOnly Property SelectData() As String
            Get
                Return ResourceManager.GetString("SelectData", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to UPDATE tblTicketTypeByMovie
        '''SET
        '''	update_date = @cvDate
        '''	, update_by = @update_by
        '''WHERE movie_id = @movie_id
        '''	AND ticket_type_id = @ticket_type_id
        '''	AND theater_id = @theater_id;
        '''
        '''IF @@ROWCOUNT = 0
        '''BEGIN
        '''	INSERT INTO tblTicketTypeByMovie (
        '''		movie_id
        '''		, ticket_type_id
        '''		, theater_id
        '''		, create_date
        '''		, create_by
        '''		, update_date
        '''		, update_by
        '''		)
        '''	VALUES (
        '''		@movie_id
        '''		, @ticket_type_id
        '''		, @theater_id
        '''		, @cvDate
        '''		, @update_by
        '''		, @cvDate
        '''		, @update_by
        '''		);
        '''END.
        '''</summary>
        Friend Shared ReadOnly Property UpdateInsert() As String
            Get
                Return ResourceManager.GetString("UpdateInsert", resourceCulture)
            End Get
        End Property
    End Class
End Namespace

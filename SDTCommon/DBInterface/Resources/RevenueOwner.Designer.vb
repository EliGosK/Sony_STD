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
    Friend Class RevenueOwner
        
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
                    Dim temp As Global.System.Resources.ResourceManager = New Global.System.Resources.ResourceManager("SDTCommon.RevenueOwner", GetType(RevenueOwner).Assembly)
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
        '''  Looks up a localized string similar to DELETE tblRevenue
        '''WHERE revenueid = @revenueid;.
        '''</summary>
        Friend Shared ReadOnly Property Delete() As String
            Get
                Return ResourceManager.GetString("Delete", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to DECLARE @format AS NVARCHAR(100)
        '''DECLARE @sound AS NVARCHAR(100)
        '''
        '''SELECT @format = CASE 
        '''		WHEN film_type_sound_name_th LIKE &apos;%35 มม.%&apos;
        '''			THEN &apos;35 มม.&apos;
        '''		WHEN film_type_sound_name_th LIKE &apos;%3 มิติ%&apos;
        '''			THEN &apos;3 มิติ&apos;
        '''		WHEN film_type_sound_name_th LIKE &apos;%ดิจิตอล%&apos;
        '''			THEN &apos;ดิจิตอล&apos;
        '''		ELSE film_type_sound_name_th
        '''		END
        '''	, @sound = CASE 
        '''		WHEN film_type_sound_name_th LIKE &apos;%พากย์ไทย%&apos;
        '''			THEN &apos;พากย์ไทย&apos;
        '''		ELSE &apos;ต้นฉบับ&apos;
        '''		END
        '''FROM tblFilmTypeSound
        '''WHERE film_type_sound_id = @film_type_sound [rest of string was truncated]&quot;;.
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
        Friend Shared ReadOnly Property SelectData() As String
            Get
                Return ResourceManager.GetString("SelectData", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to DECLARE @format AS NVARCHAR(100)
        '''DECLARE @sound AS NVARCHAR(100)
        '''
        '''SELECT @format = CASE 
        '''		WHEN film_type_sound_name_th LIKE &apos;%35 มม.%&apos;
        '''			THEN &apos;35 มม.&apos;
        '''		WHEN film_type_sound_name_th LIKE &apos;%3 มิติ%&apos;
        '''			THEN &apos;3 มิติ&apos;
        '''		WHEN film_type_sound_name_th LIKE &apos;%ดิจิตอล%&apos;
        '''			THEN &apos;ดิจิตอล&apos;
        '''		ELSE film_type_sound_name_th
        '''		END
        '''	, @sound = CASE 
        '''		WHEN film_type_sound_name_th LIKE &apos;%พากย์ไทย%&apos;
        '''			THEN &apos;พากย์ไทย&apos;
        '''		ELSE &apos;ต้นฉบับ&apos;
        '''		END
        '''FROM tblFilmTypeSound
        '''WHERE film_type_sound_id = @film_type_sound [rest of string was truncated]&quot;;.
        '''</summary>
        Friend Shared ReadOnly Property Update() As String
            Get
                Return ResourceManager.GetString("Update", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to UPDATE tblRevenue
        '''SET
        '''	revenue_amount = @actual_revenue_amount
        '''	, revenue_adms = @actual_viewer
        '''	, revenue_lastupdate = @cvDate
        '''	, user_id = @user_id
        '''	, check_ticket = 1
        '''WHERE revenueid = @revenueid;.
        '''</summary>
        Friend Shared ReadOnly Property UpdateActualSetTicket() As String
            Get
                Return ResourceManager.GetString("UpdateActualSetTicket", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to UPDATE tblRevenue
        '''SET
        '''	revenue_lastupdate = @cvDate
        '''	, status_id = @status_id
        '''WHERE revenueid = @revenueid;.
        '''</summary>
        Friend Shared ReadOnly Property UpdateRevenueStatus() As String
            Get
                Return ResourceManager.GetString("UpdateRevenueStatus", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to UPDATE tblRevenue
        '''SET
        '''	revenue_lastupdate = @cvDate
        '''	, status_id = @status_id
        '''WHERE movies_id = @movies_id
        '''	AND theater_id = @theater_id;.
        '''</summary>
        Friend Shared ReadOnly Property UpdateStatus() As String
            Get
                Return ResourceManager.GetString("UpdateStatus", resourceCulture)
            End Get
        End Property
    End Class
End Namespace

Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Namespace DBInterface
    Public Class ReportGeneralIndustryInfo
        Public Shared Function ReportGeneralIndustryInfoByCircuitTheater(ByVal dateFrom As Date, ByVal dateTo As Date, ByVal byMovieReleaseDate As Boolean, ByVal isCircuit As Boolean) As DataSet
            '@dateFrom
            ', @dateTo
            ', @byMovieReleaseDate
            ', @isCircuit
            Dim paramList As New List(Of SqlParameter)
            paramList.Add(New SqlParameter("@dateFrom", dateFrom))
            paramList.Add(New SqlParameter("@dateTo", dateTo))
            paramList.Add(New SqlParameter("@byMovieReleaseDate", byMovieReleaseDate))
            paramList.Add(New SqlParameter("@isCircuit", isCircuit))

            Dim ds As DataSet = SqlHelper.ExecuteDataset(Utils.MainConnectionString, CommandType.StoredProcedure, "[sp_ReportGeneralIndustryInfoByCircuitTheater]", paramList.ToArray())
            Return ds
        End Function

        Public Shared Function ReportGeneralIndustryInfoByMovieCircuitTheater(ByVal movieId As Int32?, ByVal dateFrom As Date, ByVal dateTo As Date, ByVal byMovieReleaseDate As Boolean, ByVal isCircuit As Boolean) As DataSet
            '@movieId
            ', @dateFrom
            ', @dateTo
            ', @byMovieReleaseDate
            ', @isCircuit
            Dim paramList As New List(Of SqlParameter)
            paramList.Add(New SqlParameter("@movieId", movieId))
            paramList.Add(New SqlParameter("@dateFrom", dateFrom))
            paramList.Add(New SqlParameter("@dateTo", dateTo))
            paramList.Add(New SqlParameter("@byMovieReleaseDate", byMovieReleaseDate))
            paramList.Add(New SqlParameter("@isCircuit", isCircuit))

            Dim ds As DataSet = SqlHelper.ExecuteDataset(Utils.MainConnectionString, CommandType.StoredProcedure, "[sp_ReportGeneralIndustryInfoByMovieCircuitTheater]", paramList.ToArray())
            Return ds
        End Function

        Public Shared Function ReportGeneralIndustryInfoByDistributor(ByVal dateFrom As Date, ByVal dateTo As Date, ByVal byMovieReleaseDate As Boolean, ByVal distributor As String) As DataSet
            '@dateFrom
            ', @dateTo
            ', @byMovieReleaseDate
            ', @distributor

            Dim paramList As New List(Of SqlParameter)
            paramList.Add(New SqlParameter("@dateFrom", dateFrom))
            paramList.Add(New SqlParameter("@dateTo", dateTo))
            paramList.Add(New SqlParameter("@byMovieReleaseDate", byMovieReleaseDate))
            paramList.Add(New SqlParameter("@distributor", distributor))

            Dim ds As DataSet = SqlHelper.ExecuteDataset(Utils.MainConnectionString, CommandType.StoredProcedure, "[sp_ReportGeneralIndustryInfoByDistributor]", paramList.ToArray())
            Return ds
        End Function

        Public Shared Function ReportGeneralIndustryInfoByNationalityDetail(ByVal dateFrom As Date, ByVal dateTo As Date, ByVal byMovieReleaseDate As Boolean, ByVal national As String) As DataSet
            '@dateFrom
            ', @dateTo
            ', @byMovieReleaseDate
            ', @national

            Dim paramList As New List(Of SqlParameter)
            paramList.Add(New SqlParameter("@dateFrom", dateFrom))
            paramList.Add(New SqlParameter("@dateTo", dateTo))
            paramList.Add(New SqlParameter("@byMovieReleaseDate", byMovieReleaseDate))
            paramList.Add(New SqlParameter("@national", national))

            Dim ds As DataSet = SqlHelper.ExecuteDataset(Utils.MainConnectionString, CommandType.StoredProcedure, "[sp_ReportGeneralIndustryInfoByNationalityDetail]", paramList.ToArray())
            Return ds
        End Function

        Public Shared Function ReportGeneralIndustryInfoByStudioCircuitTheater(ByVal dateFrom As Date, ByVal dateTo As Date, ByVal byMovieReleaseDate As Boolean, ByVal studioName As String, ByVal isCircuit As Boolean, ByVal circuitName As String) As DataSet
            '@dateFrom
            ', @dateTo
            ', @byMovieReleaseDate
            ', @studioName
            ', @isCircuit
            ', @circuitName
            Dim paramList As New List(Of SqlParameter)
            paramList.Add(New SqlParameter("@dateFrom", dateFrom))
            paramList.Add(New SqlParameter("@dateTo", dateTo))
            paramList.Add(New SqlParameter("@byMovieReleaseDate", byMovieReleaseDate))
            paramList.Add(New SqlParameter("@studioName", studioName))
            paramList.Add(New SqlParameter("@isCircuit", isCircuit))
            paramList.Add(New SqlParameter("@circuitName", circuitName))

            Dim ds As DataSet = SqlHelper.ExecuteDataset(Utils.MainConnectionString, CommandType.StoredProcedure, "[sp_ReportGeneralIndustryInfoByStudioCircuitTheater]", paramList.ToArray())
            Return ds
        End Function
    End Class
End Namespace
Option Explicit On
Option Strict On

Imports Npgsql
Public Class CategoriesADO

    Private _BD As BdPostgre

    Public Sub New()
        _BD = New BdPostgre
    End Sub


    Public Function Obtener(ByVal sql As String) As Categories

        Dim Lector As NpgsqlDataReader
        Dim Category As Categories = New Categories()

        _BD.Abrir()
        Try
            Lector = _BD.EjecutarDML(sql)

            While Lector.Read()
                Category.CategoryName = Lector.GetString(0)
            End While

        Catch ex As Exception
            Category = Nothing
        Finally
            _BD.Cerrar()
        End Try

        Return Category
    End Function



    Public Function ObtenerTodasCategorias() As List(Of String)

        Dim Lector As NpgsqlDataReader
        Dim ListaCategorias = New List(Of String)

        Dim Sql As String = "SELECT CATEGORYNAME FROM CATEGORIES ORDER BY CATEGORY ASC;"

        _BD.Abrir()

        Try
            Lector = _BD.EjecutarDML(Sql)

            While Lector.Read()
                ListaCategorias.Add(Lector.GetString(0))
            End While

        Catch ex As Exception
            Throw New Exception("Se ha producido un error al obtener las categorías.")
        Finally
            _BD.Cerrar()
        End Try

        Return ListaCategorias
    End Function


    Public Sub Dispose()
        If (Not _BD Is Nothing) Then
            _BD.dispose()
        End If
    End Sub

End Class
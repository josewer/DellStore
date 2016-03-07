Imports Npgsql

Public Class ADOProvincias

    Private _BD As BdPostgre

    Public Sub New()
        _BD = New BdPostgre
    End Sub


    Public Function ObtenerProvincias() As List(Of Provincia)

        Dim Lector As NpgsqlDataReader
        Dim ListaProvincias = New List(Of Provincia)

        Dim Sql As String = "Select provincia , idprovincia from provincia order by provincia asc;"

        _BD.Abrir()

        Try
            Lector = _BD.EjecutarDML(Sql)

            While Lector.Read()
                ListaProvincias.Add(New Provincia(Lector.GetInt32(1), Lector.GetString(0)))
            End While

        Catch ex As Exception
            Throw New Exception("Se ha producido un error al obtener las provincias.")
        Finally
            _BD.Cerrar()
        End Try

        Return ListaProvincias
    End Function



    Public Sub Dispose()
        If (Not _BD Is Nothing) Then
            _BD.dispose()
        End If
    End Sub
End Class

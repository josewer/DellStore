Imports Npgsql

Public Class ADOPoblacion

    Private _BD As BdPostgre

    Public Sub New()
        _BD = New BdPostgre
    End Sub


    Public Function ObtenerPoblacion(ByVal idProvincia As Integer) As List(Of String)

        Dim Lector As NpgsqlDataReader
        Dim poblaciones = New List(Of String)

        Dim Sql As String = String.Format("Select poblacion from poblacion where idprovincia = '{0}'
                                            order by poblacion asc;", idProvincia)

        _BD.Abrir()

        Try
            Lector = _BD.EjecutarDML(Sql)

            While Lector.Read()
                poblaciones.Add(Lector.GetString(0))
            End While

        Catch ex As Exception
            Throw New Exception("Se ha producido un error al obtener las poblaciones.")
        Finally
            _BD.Cerrar()
        End Try

        Return poblaciones
    End Function



    Public Sub Dispose()
        If (Not _BD Is Nothing) Then
            _BD.dispose()
        End If
    End Sub
End Class

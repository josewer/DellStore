Option Explicit On
Option Strict On

Imports Npgsql

Public Class OrdersADO
    Private _BD As BdPostgre

    Public Sub New()
        _BD = New BdPostgre
    End Sub


    Public Function Insertar(ByVal sql As String) As Integer

        Dim Lector As NpgsqlDataReader
        Dim OrderId As Integer = 0

        _BD.Abrir()

        Try
            Lector = _BD.EjecutarDML(sql)

            While Lector.Read()
                OrderId = Lector.GetInt32(0)
            End While

        Catch ex As Exception
            OrderId = 0
        Finally
            _BD.Cerrar()
        End Try

        Return OrderId
    End Function


    Public Function Borrar(ByVal sql As String) As Boolean

        Dim Lector As NpgsqlDataReader
        Dim Borrado As Boolean = True

        _BD.Abrir()

        Try
            Lector = _BD.EjecutarDML(sql)
        Catch ex As Exception
            Borrado = False
        Finally
            _BD.Cerrar()
        End Try

        Return Borrado
    End Function


    Public Function Actualizar(ByVal sql As String) As Boolean

        Dim Lector As NpgsqlDataReader
        Dim Actualizado As Boolean = True

        _BD.Abrir()

        Try
            Lector = _BD.EjecutarDML(sql)
        Catch ex As Exception
            Throw New Exception(ex.Message)
            Actualizado = False
        Finally
            _BD.Cerrar()
        End Try

        Return Actualizado
    End Function


    Public Function Obtener(SQL As String) As Orders

        Dim Lector As NpgsqlDataReader
        Dim Order As Orders = Nothing
        Dim Encontrado As Boolean = False

        _BD.Abrir()

        Try
            Lector = _BD.EjecutarDML(SQL)

            While Lector.Read()

                Encontrado = True

                Order = New Orders(Lector.GetInt32(0),
                            CDate(Lector.GetDate(1)), Lector.GetInt32(2),
                            Lector.GetDouble(3), Lector.GetDouble(4),
                            CShort(Lector.GetDouble(5)))
            End While

        Catch ex As Exception
            Throw New Exception("Error al obtener el pedido.")
        Finally
            _BD.Cerrar()
        End Try

        If (Encontrado = False) Then
            Throw New Exception("El pedido no existe.")
        End If

        Return Order

    End Function



    Public Sub Dispose()
        If (Not _BD Is Nothing) Then
            _BD.dispose()
        End If
    End Sub
End Class

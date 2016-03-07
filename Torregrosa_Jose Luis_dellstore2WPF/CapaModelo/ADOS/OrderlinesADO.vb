Option Explicit On
Option Strict On

Imports Npgsql


Public Class OrderlinesADO
    Private _BD As BdPostgre

    Public Sub New()
        _BD = New BdPostgre
    End Sub


    Public Sub Insertar(ByVal sql As String)

        _BD.Abrir()

        Try
            _BD.EjecutarDML(sql)
        Catch ex As Exception
            Throw New Exception(ex.Message)
            Throw New Exception("Se ha producido un error al insertar la línea de pedido.")
        Finally
            _BD.Cerrar()
        End Try

    End Sub


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
            Actualizado = False
        Finally
            _BD.Cerrar()
        End Try

        Return Actualizado
    End Function


    Public Function Obtener(IdPedido As Int32) As List(Of OrderLines)

        Dim Lector As NpgsqlDataReader
        Dim Lineas As New List(Of OrderLines)

        _BD.Abrir()

        Dim SQL As String = String.Format("SELECT orderlineId , orderId, prod_Id, quantity, orderDate 
            FROM ORDERLINES WHERE  OrderId = '{0}'",
                                          IdPedido)

        Try
            Lector = _BD.EjecutarDML(SQL)

            While Lector.Read()


                Lineas.Add(New OrderLines(Lector.GetInt32(0),
                            Lector.GetInt32(1), Lector.GetInt32(2),
                            CShort(Lector.GetString(3)), CDate(Lector.GetDate(4))))
            End While

        Catch ex As Exception
            Throw New Exception("Error al obtener las lineas de pedido.")
        Finally
            _BD.Cerrar()
        End Try

        Return Lineas

    End Function


    Public Sub Dispose()
        If (Not _BD Is Nothing) Then
            _BD.dispose()
        End If
    End Sub
End Class
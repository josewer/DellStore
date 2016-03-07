Option Explicit On
Option Strict On

Imports Npgsql
Public Class CustomersADO

    Private _BD As BdPostgre

    Public Sub New()
        _BD = New BdPostgre
    End Sub


    Public Function Insertar(ByVal sql As String) As Integer

        Dim Lector As NpgsqlDataReader
        Dim CustomerId As Integer = 0

        _BD.Abrir()

        Try
            Lector = _BD.EjecutarDML(sql)

            While Lector.Read()
                CustomerId = Lector.GetInt32(0)
            End While

        Catch ex As Exception
            CustomerId = 0
        Finally
            _BD.Cerrar()
        End Try

        Return CustomerId
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
            Actualizado = False
        Finally
            _BD.Cerrar()
        End Try

        Return Actualizado
    End Function

    Public Function Obtener(ByVal sql As String) As Customers

        Dim Lector As NpgsqlDataReader
        Dim Customer As Customers = New Customers()

        _BD.Abrir()
        Dim Existe As Boolean = False

        Try
            Lector = _BD.EjecutarDML(sql)

            While Lector.Read()

                Existe = True

                Customer.CustomerId = Lector.GetInt32(0)
                Customer.FirstName = Lector.GetString(1)
                Customer.LastName = Lector.GetString(2)
                Customer.Address1 = Lector.GetString(3)
                Customer.Address2 = Lector.GetString(4)
                Customer.City = Lector.GetString(5)
                Customer.State = Lector.GetString(6)
                Customer.Zip = Lector.GetInt32(7)
                Customer.Country = Lector.GetString(8)
                Customer.Region = CShort(Lector.GetString(9))
                Customer.Email = Lector.GetString(10)
                Customer.Phone = Lector.GetString(11)
                Customer.CreditCardType = Lector.GetInt32(12)
                Customer.CreditCard = Lector.GetString(13)
                Customer.CreditCardExpiration = Lector.GetString(14)
                Customer.UserName = Lector.GetString(15)
                Customer.Password = Lector.GetString(16)
                Customer.Age = CUShort(Lector.GetString(17))
                Customer.Income = Lector.GetInt32(18)
                Customer.Gender = CChar(Lector.GetString(19))
            End While

        Catch ex As Exception
            Customer = Nothing
            Throw New Exception(sql)
        Finally
            _BD.Cerrar()
        End Try

        If Existe Then
            Return Customer
        Else
            Return Nothing
        End If
    End Function


    Public Sub Dispose()
        If (Not _BD Is Nothing) Then
            _BD.dispose()
        End If
    End Sub

End Class

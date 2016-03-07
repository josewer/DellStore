Option Explicit On
Option Strict On

Imports Orders ' Es Capa modelo

Public Class AccionesBDCliente

    Private provincias As List(Of Provincia)

    Public Function ObtenerProvincias() As List(Of String)

        provincias = New ADOProvincias().ObtenerProvincias
        Dim lista As List(Of String) = New List(Of String)

        For i As Integer = 0 To provincias.Count - 1 Step 1
            lista.Add(provincias(i).Nombre)
        Next

        Return lista

    End Function

    Public Function ObtenerPoblaciones(index As Integer) As List(Of String)
        Return New ADOPoblacion().ObtenerPoblacion(provincias(index).ID)
    End Function


    Public Sub InsertarCliente(Nombre As String, Apellidos As String,
                               Dir1 As String, Dir2 As String, Ciudad As String,
                               Provincia As String,
                               CP As Integer, Pais As String, Region As Short,
                               Correo As String, Telefono As String,
                               TipoTarjeta As Integer, NumeroTarjeta As String,
                               FechaCaducidadTarjeta As String, Nick As String,
                               Contra As String, Edad As UShort, Sueldo As Integer,
                               Genero As Char)

        Dim Cliente As Customers = New Customers(Nombre, Apellidos, Dir1, Dir2, Ciudad, Provincia,
            CP, Pais, Region, Correo, Telefono, TipoTarjeta, NumeroTarjeta,
            FechaCaducidadTarjeta, Nick, Contra, Edad, Sueldo, Genero)

    End Sub


    Public Sub ModificarCliente(IdCliente As Integer, Nombre As String, Apellidos As String,
                               Dir1 As String, Dir2 As String, Ciudad As String,
                               Provincia As String,
                               CP As Integer, Pais As String, Region As Short,
                               Correo As String, Telefono As String,
                               TipoTarjeta As Integer, NumeroTarjeta As String,
                               FechaCaducidadTarjeta As String, Nick As String,
                               Contra As String, Edad As UShort, Sueldo As Integer,
                               Genero As Char)

        Dim Cliente As Customers = New Customers(IdCliente, Nombre, Apellidos, Dir1, Dir2, Ciudad, Provincia,
            CP, Pais, Region, Correo, Telefono, TipoTarjeta, NumeroTarjeta,
            FechaCaducidadTarjeta, Nick, Contra, Edad, Sueldo, Genero)

        Cliente.Actualizar()
    End Sub

    ''' <summary>
    ''' FUNCION QUE DEVUELVE UN CLIENTE EN FORMA DE DICCIONARIO PARA QUE LA INTERFAZ
    ''' TENGA INDEPENDENCIA SOBRE LA CAPA DE DATOS.
    ''' </summary>
    Public Function ObtenerCliente(Nick As String) As Dictionary(Of String, String)

        Dim Cliente As Customers = New Customers(Nick)

        Dim DatosCliente = New Dictionary(Of String, String)
        DatosCliente.Add("ID", CStr(Cliente.CustomerId))
        DatosCliente.Add("NOMBRE", Cliente.FirstName)
        DatosCliente.Add("APELLIDOS", Cliente.LastName)
        DatosCliente.Add("DIR1", Cliente.Address1)
        DatosCliente.Add("DIR2", Cliente.Address2)
        DatosCliente.Add("CIUDAD", Cliente.City)
        DatosCliente.Add("PROVINCIA", Cliente.State)
        DatosCliente.Add("CP", CStr(Cliente.Zip))
        DatosCliente.Add("PAIS", Cliente.Country)
        DatosCliente.Add("REGION", CStr(Cliente.Region))
        DatosCliente.Add("CORREO", Cliente.Email)
        DatosCliente.Add("TELEFONO", Cliente.Phone)
        DatosCliente.Add("TIPO_TARJETA", CStr(Cliente.CreditCardType))
        DatosCliente.Add("NUMERO_TARJETA", Cliente.CreditCard)
        DatosCliente.Add("FECHA_CADUCIDAD", Cliente.CreditCardExpiration)
        DatosCliente.Add("NICK", Cliente.UserName)
        DatosCliente.Add("CONTRA", Cliente.Password)
        DatosCliente.Add("EDAD", CStr(Cliente.Age))
        DatosCliente.Add("SUELDO", CStr(Cliente.Income))
        DatosCliente.Add("GENERO", CStr(Cliente.Gender))

        Return DatosCliente

    End Function


    Public Function ObtenerCliente(IDCliente As Integer) As Dictionary(Of String, String)

        Dim Cliente As Customers = New Customers(IDCliente)

        Dim DatosCliente = New Dictionary(Of String, String)
        DatosCliente.Add("ID", CStr(Cliente.CustomerId))
        DatosCliente.Add("NOMBRE", Cliente.FirstName)
        DatosCliente.Add("APELLIDOS", Cliente.LastName)
        DatosCliente.Add("DIR1", Cliente.Address1)
        DatosCliente.Add("DIR2", Cliente.Address2)
        DatosCliente.Add("CIUDAD", Cliente.City)
        DatosCliente.Add("PROVINCIA", Cliente.State)
        DatosCliente.Add("CP", CStr(Cliente.Zip))
        DatosCliente.Add("PAIS", Cliente.Country)
        DatosCliente.Add("REGION", CStr(Cliente.Region))
        DatosCliente.Add("CORREO", Cliente.Email)
        DatosCliente.Add("TELEFONO", Cliente.Phone)
        DatosCliente.Add("TIPO_TARJETA", CStr(Cliente.CreditCardType))
        DatosCliente.Add("NUMERO_TARJETA", Cliente.CreditCard)
        DatosCliente.Add("FECHA_CADUCIDAD", Cliente.CreditCardExpiration)
        DatosCliente.Add("NICK", Cliente.UserName)
        DatosCliente.Add("CONTRA", Cliente.Password)
        DatosCliente.Add("EDAD", CStr(Cliente.Age))
        DatosCliente.Add("SUELDO", CStr(Cliente.Income))
        DatosCliente.Add("GENERO", CStr(Cliente.Gender))

        Return DatosCliente

    End Function

End Class

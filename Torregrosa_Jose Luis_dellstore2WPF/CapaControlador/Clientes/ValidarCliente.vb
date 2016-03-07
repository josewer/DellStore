Public Class ValidarCliente

    Private _Valido As Boolean
    Public Property Valido() As Boolean
        Get
            Return _Valido
        End Get
        Set(ByVal value As Boolean)
            _Valido = value
        End Set
    End Property


    Public Sub New()
        Valido = True
    End Sub

    Public Function ValidarNick(Text As String) As String

        If (Text Is Nothing Or Text = "") Then
            Valido = False
            Return "Este campo no puede ser nulo."
        ElseIf (Text.Length > 50) Then
            Valido = False
            Return "Este campo no puede tener más de 50 carácteres."
        End If

        Return "Campo válido."

    End Function


    Public Function ValidarCalendario(Text As String) As String

        If (Text Is Nothing Or Text = "") Then
            Valido = False
            Return "Tienes que seleccionar una fecha."
        End If

        Return "Campo válido."

    End Function

    Public Function ValidarContra(Text As String) As String

        If (Text Is Nothing Or Text = "") Then
            Valido = False
            Return "Este campo no puede ser nulo."
        ElseIf (Text.Length > 50) Then
            Valido = False
            Return "Este campo no puede tener más de 50 carácteres."
        End If

        Return "Campo válido."

    End Function


    Public Function ValidarNombre(Text As String) As String

        If (Text Is Nothing Or Text = "") Then
            Valido = False
            Return "Este campo no puede ser nulo."
        ElseIf (Text.Length > 50) Then
            Valido = False
            Return "Este campo no puede tener más de 50 carácteres."
        End If

        Return "Campo válido."

    End Function

    Public Function ValidarApellidos(Text As String) As String

        If (Text Is Nothing Or Text = "") Then
            Valido = False
            Return "Este campo no puede ser nulo."
        ElseIf (Text.Length > 50) Then
            Valido = False
            Return "Este campo no puede tener más de 50 carácteres."
        End If

        Return "Campo válido."

    End Function


    Public Function ValidarDir1(Text As String) As String

        If (Text Is Nothing Or Text = "") Then
            Valido = False
            Return "Este campo no puede ser nulo."
        ElseIf (Text.Length > 50) Then
            Valido = False
            Return "Este campo no puede tener más de 50 carácteres."
        End If

        Return "Campo válido."

    End Function


    Public Function ValidarDir2(Text As String) As String

        If (Text.Length > 50) Then
            Valido = False
            Return "Este campo no puede tener más de 50 carácteres."
        End If

        Return "Campo válido."

    End Function

    Public Function ValidarCorreo(Text As String) As String

        If (Text.Length > 50) Then
            Valido = False
            Return "Este campo no puede tener más de 50 carácteres."
        End If

        Return "Campo válido."

    End Function

    Public Function ValidarNumeroTarjeta(Text As String) As String

        If (Text Is Nothing Or Text = "") Then
            Valido = False
            Return "Este campo no puede ser nulo."
        ElseIf (Text.Length > 50) Then
            Valido = False
            Return "Este campo no puede tener más de 50 carácteres."
        End If

        Return "Campo válido."

    End Function


    Public Function ValidarCP(Text As String) As String

        If (Text.Length <> 0 AndAlso Text.Length <> 5) Then
            Valido = False
            Return "Este campo debe de tener 5 carácteres numéricos."
        End If

        Return "Campo válido."

    End Function

    Public Function ValidarTelefono(Text As String) As String

        If (Text.Length <> 0 AndAlso IsNumeric(Text) = False) Then
            Valido = False
            Return "Este campo debe ser numérico."
        ElseIf (Text.Length > 50) Then
            Valido = False
            Return "Este campo no puede tener más de 50 carácteres."
        End If

        Return "Campo válido."

    End Function

    Public Function ValidarPais(Opcion As Integer) As String

        If (Opcion = -1) Then
            Valido = False
            Return "Este campo no puede ser nulo."
        End If

        Return "Campo válido."

    End Function

    Public Function ValidarProvincia(Opcion As Integer) As String

        If (Opcion = -1) Then
            Valido = False
            Return "Este campo no puede ser nulo."
        End If

        Return "Campo válido."

    End Function

    Public Function ValidarCiudad(Opcion As Integer) As String

        If (Opcion = -1) Then
            Valido = False
            Return "Este campo no puede ser nulo."
        End If

        Return "Campo válido."

    End Function


    Public Function ValidarTipoTarjetas(Opcion As Integer) As String

        If (Opcion = -1) Then
            Valido = False
            Return "Este campo no puede ser nulo."
        End If

        Return "Campo válido."

    End Function

    Public Function ValidarGenero(Radio1 As Boolean, Radio2 As Boolean) As String

        If (Radio1 = False AndAlso Radio2 = False) Then
            Valido = False
            Return "Tienes que seleccionar una opción."
        End If

        Return "Campo válido."

    End Function

    Public Function ValidarEdad(Text As String) As String

        If (Text.Length <> 0 AndAlso IsNumeric(Text) = False) Then
            Valido = False
            Return "Tiene que ser un valor numérico."
        End If

        Try
            Dim i As Short = CShort(Text)
        Catch ex As Exception
            Valido = False
            Return "Este campo tiene que ser desde -32.768 a 32.767."
        End Try

        Return "Campo válido."

    End Function

    Public Function ValidarSueldo(Text As String) As String

        If (Text.Length <> 0 AndAlso IsNumeric(Text) = False) Then
            Valido = False
            Return "Tiene que ser un valor numérico."
        End If

        Return "Campo válido."

    End Function


    Public Function ValidarRegion(Text As String) As String

        If (Text Is Nothing Or Text = "") Then
            Valido = False
            Return "Este campo no puede ser nulo."
        ElseIf (IsNumeric(Text) = False) Then
            Valido = False
            Return "Este campo tiene que ser numérico."
        End If

        Try
            Dim i As Short = CShort(Text)
        Catch ex As Exception
            Valido = False
            Return "Este campo tiene que ser desde -32.768 a 32.767."
        End Try

        Return "Campo válido."

    End Function

End Class
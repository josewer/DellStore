Public Class ValidarProductos

    Public Sub New()
        Valido = True
    End Sub

    Private _Valido As Boolean
    Public Property Valido() As Boolean
        Get
            Return _Valido
        End Get
        Set(ByVal value As Boolean)
            _Valido = value
        End Set
    End Property

    Public Function ValidarTitulo(Text As String) As String

        If (Text Is Nothing Or Text = "") Then
            Valido = False
            Return "Este campo no puede ser nulo."
        ElseIf (Text.Length > 50) Then
            Valido = False
            Return "Este campo no puede tener más de 50 carácteres."
        End If

        Return "Campo válido."

    End Function


    Public Function ValidarActor(Text As String) As String

        If (Text Is Nothing Or Text = "") Then
            Valido = False
            Return "Este campo no puede ser nulo."
        ElseIf (Text.Length > 50) Then
            Valido = False
            Return "Este campo no puede tener más de 50 carácteres."
        End If

        Return "Campo válido."

    End Function

    Public Function ValidarPrecio(Text As String) As String

        If (IsNumeric(Text) = False) Then
            Valido = False
            Return "Tiene que ser un valor numérico."
        End If

        Return "Campo válido."

    End Function

    Public Function ValidarEspecial(Text As String) As String

        If (Text.Length <> 0) Then

            If (IsNumeric(Text) = False) Then
                Valido = False
                Return "Este campo tiene que ser numérico."
            End If

            Try
                Dim i As Short = CShort(Text)
            Catch ex As Exception
                Valido = False
                Return "Este campo tiene que ser desde -32.768 a 32.767."
            End Try
        End If

        Return "Campo válido."

    End Function


    Public Function ValidarCategoria(Opcion As Integer) As String

        If (Opcion = -1) Then
            Valido = False
            Return "Este campo no puede ser nulo."
        End If

        Return "Campo válido."

    End Function

    Public Function ValidarIdComun(Text As String) As String

        If (Text Is Nothing Or Text = "") Then
            Valido = False
            Return "Este campo no puede ser nulo."
        ElseIf (IsNumeric(Text) = False) Then
            Valido = False
            Return "Este campo tiene que ser numérico."
        End If

        Try
            Dim i As Short = CInt(Text)
        Catch ex As Exception
            Valido = False
            Return "Este campo tiene que ser entero."
        End Try

        Return "Campo válido."

    End Function

    Public Function ValidarCantidad(Text As String) As String

        If (IsNumeric(Text)) Then
            Try
                Dim cant As Short = CShort(Text)

                If cant > 0 Then
                    Return "Campo válido."
                Else
                    Return "La cantidad no puede ser menor que 1"
                End If

            Catch ex As Exception
                Return "La cantidad tiene que ser desde 1 a 32.767."
            End Try
        Else
            Return "La cantidad tiene que ser un valor númerico."
        End If
    End Function




End Class

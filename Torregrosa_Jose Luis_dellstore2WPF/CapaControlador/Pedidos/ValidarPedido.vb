Public Class ValidarPedido

    Public Function ValidarCantidad(Text As String) As String
        Try
            If Text <> "" Then
                Dim Cantidad As Short = CShort(Text)

                If (Cantidad > 0) Then
                    Return "Campo válido."
                Else
                    Return "Tiene que ser mayor que 0."
                End If
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Return "Tiene que ser un número entero."
        End Try

    End Function
End Class

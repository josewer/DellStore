Option Explicit On
Option Strict On

Public Class Provincia

    Private _ID As Integer
    Public Property ID() As Integer
        Get
            Return _ID
        End Get
        Set(ByVal value As Integer)
            _ID = value
        End Set
    End Property

    Private _Nombre As String
    Public Property Nombre() As String
        Get
            Return _Nombre
        End Get
        Set(ByVal value As String)
            _Nombre = value
        End Set
    End Property

    Public Sub New(id As Integer, nombre As String)
        Me.ID = id
        Me.Nombre = nombre
    End Sub

End Class

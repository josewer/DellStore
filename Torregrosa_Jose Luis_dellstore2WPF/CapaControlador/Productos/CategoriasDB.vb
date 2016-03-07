Option Strict On
Option Explicit On

Imports Orders ' Es Capa modelo

Public Class CategoriasDB

    Public Function ObtenerCategorias() As List(Of String)

        Dim Categories = New CategoriesADO

        Return Categories.ObtenerTodasCategorias

    End Function


End Class
